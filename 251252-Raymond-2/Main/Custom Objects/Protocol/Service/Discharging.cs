using HMI.CO.General;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using VisiWin.ApplicationFramework;
using VisiWin.DataAccess;

namespace HMI.CO.Protocol
{
    class Discharging
    {
        public Discharging(string V)
        {
            IVariableService VS = ApplicationService.GetService<IVariableService>();
            Event = VS.GetVariable(V);
            Event.Change += Event_Discharging;
        }



        #region - - - Properties - - -  

        IVariable Event;
        public IVariable Layer_Id { set; get; }
        public IVariable Order_US { set; get; }
        public IVariable MES { set; get; }
        public IVariable Custom_PO { set; get; }
        public IVariable Custom_PWG { set; get; }
        public IVariable Custom_PT { set; get; }
        #endregion

        #region - - - Event Handlers - - - 
        private void Event_Discharging(object sender, VariableEventArgs e)
        {
            if (e.Quality.Data == DataQuality.Good && e.Value != e.PreviousValue && (bool)e.Value)
            {
                Event.Value = false;
                Task.Run(() =>
                {
                    Layer r = GetLayer((int)(uint)Layer_Id.Value);
                    if (r.Id > 0)
                    {
                        WriteEndToLayer(r);
                        WriteEndToCharge(r);
                        WriteEndToBoxes(r);
                        Dictionary<string, string> Data = WriteEndToOrders(r);
                        Order_US.Value = Data["Order"];
                        
                        if ((bool)MES.Value) 
                        {
                            Custom_PO.Value = Data.ContainsKey("PO") ? Data["PO"] : "";
                            Custom_PWG.Value = Data.ContainsKey("PWG") ? Data["PWG"] : "";
                            Custom_PT.Value = Data.ContainsKey("ProcessTime") ? Data["ProcessTime"] : "";
                        }
                    }
                });
            }
        }

        #endregion

        #region - - - Methods - - - 
        private Layer GetLayer(int layer_id)
        {
            DataTable DT = new MSSQLEAdapter("Orders", "SELECT * " +
                                             "FROM Layers " +
                                             "WHERE Id = " + layer_id + ";").DB_Output();
            if (DT.Rows.Count > 0)
            {
                return new Layer()
                {
                    Id = layer_id,
                    Order_Id = (int)DT.Rows[0]["Order_Id"],
                    Box_Id = (int)DT.Rows[0]["Box_Id"],
                    Charge_Id = (int)DT.Rows[0]["Charge_Id"]
                };
            }
            else { return new Layer(); }
        }
        private void WriteEndToLayer(Layer r)
        {
            new MSSQLEAdapter("Orders", "UPDATE Layers " +
                                  "SET [End] = '" + DateTime.Now.ToString("yyyyMMdd HH:mm:ss") + "' " +
                                  "WHERE Id = " + r.Id + ";").DB_Input();
        }
        private void WriteEndToCharge(Layer r)
        {
            new MSSQLEAdapter("Orders", "UPDATE Charges " +
                                  "SET [End] = '" + DateTime.Now.ToString("yyyyMMdd HH:mm:ss") + "' " +
                                  "WHERE Id = " + r.Charge_Id + ";").DB_Input();
        }

        private void WriteEndToBoxes(Layer r)
        {
            DataTable charges = new MSSQLEAdapter("Orders", "SELECT * " +
                                            "FROM Charges " +
                                            "WHERE Box_Id = " + r.Box_Id + ";").DB_Output();

            

            string current = (from row in charges.AsEnumerable() where row.Field<int>("Id") == r.Charge_Id select row).First()["Charge"].ToString();

            string max = charges.AsEnumerable().Max(row => row["Charge"]).ToString();

            if (current == max)
            {
                new MSSQLEAdapter("Orders", "UPDATE Boxes " +
                                     "SET [End] = '" + DateTime.Now.ToString("yyyyMMdd HH:mm:ss") + "' " +
                                     "WHERE Id = " + r.Box_Id + ";").DB_Input();
              
            }
        }

        private Dictionary<string, string> WriteEndToOrders(Layer r)
        {
            Dictionary<string, string> Data = new Dictionary<string, string>();

            DataTable boxes = new MSSQLEAdapter("Orders", "SELECT * " +
                                                  "FROM Boxes " +
                                                  "WHERE Order_Id = " + r.Order_Id + ";").DB_Output();

            DataTable T = new MSSQLEAdapter("Orders", "SELECT * " +
                                                "FROM Orders " +
                                                "WHERE Id = " + r.Order_Id + ";").DB_Output();

            string current = (from row in boxes.AsEnumerable() where row.Field<int>("Id") == r.Box_Id select row).First()["Box"].ToString();
            DateTime start = (DateTime)(from row in boxes.AsEnumerable() where row.Field<int>("Id") == r.Box_Id select row).First()["Start"];
            string max = boxes.AsEnumerable().Max(row => row["Box"]).ToString();

            if (current == max)
            {
                new MSSQLEAdapter("Orders", "UPDATE Orders " +
                                     "SET [End] = '" + DateTime.Now.ToString("yyyyMMdd HH:mm:ss") + "' " +
                                     "WHERE Id = " + r.Order_Id + ";").DB_Input();
            }
            
            Data.Add("Order", T.Rows[0]["Data_1"].ToString());
            if ((bool)MES.Value)
            {
                HMI.CO.PD.Barcode B = new HMI.CO.PD.Barcode(T.Rows[0]["Data_3"].ToString());
                Data.Add("PO", B.Data.ContainsKey("PO") ? B.Data["PO"] : "");
                Data.Add("PWG", B.Data.ContainsKey("PWG") ? B.Data["PWG"] : "");
                Data.Add("ProcessTime", (DateTime.Now.Subtract((DateTime)start).TotalSeconds).ToString());
            }
            return Data;

        }

        #endregion

    }
}
