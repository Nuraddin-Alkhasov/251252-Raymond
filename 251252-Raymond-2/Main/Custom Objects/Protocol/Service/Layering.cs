using HMI.CO.General;
using System;
using System.Data;
using System.Threading.Tasks;
using VisiWin.ApplicationFramework;
using VisiWin.DataAccess;

namespace HMI.CO.Protocol
{
    class Layering
    {
        public Layering(string V)
        {
            IVariableService VS = ApplicationService.GetService<IVariableService>();
            Event = VS.GetVariable(V);
            Event.Change += Event_Layering;
        }



        #region - - - Properties - - -  

        IVariable Event;
        public IVariable Charge_Id { set; get; }
        public IVariable Layer_Id { set; get; }
        public int Machine { set; get; }

        #endregion

        #region - - - Event Handlers - - - 
        private void Event_Layering(object sender, VariableEventArgs e)
        {
            if (e.Quality.Data == DataQuality.Good && e.Value != e.PreviousValue && (bool)e.Value)
            {
                Event.Value = false;
                Task.Run(() =>
                {
                    Charge c = GetCharge((int)(uint)Charge_Id.Value);
                    if (c.Id > 0)
                    {
                        WriteEndToLayer();
                        Layer_Id.Value = WriteNewLayer(c);
                    }
                });
            }
        }

        #endregion

        #region - - - Methods - - - 
        private Charge GetCharge(int charge_id)
        {
            DataTable DT = new MSSQLEAdapter("Orders", "SELECT * " +
                                      "FROM Charges " +
                                      "WHERE Id = " + charge_id + ";").DB_Output();
            if (DT.Rows.Count > 0)
            {
                return new Charge()
                {
                    Id = charge_id,
                    Order_Id = (int)DT.Rows[0]["Order_Id"],
                    Box_Id = (int)DT.Rows[0]["Box_Id"],
                    Layers = (int)DT.Rows[0]["Layers"]

                };
            }
            else
            {
                return new Charge();
            }
        }
        private void WriteEndToLayer()
        {
            new MSSQLEAdapter("Orders", "UPDATE Layers " +
                                  "SET [End] = '" + DateTime.Now.ToString("yyyyMMdd HH:mm:ss") + "' " +
                                  "WHERE Id = " + Layer_Id.Value + ";").DB_Input();
        }
        private int WriteNewLayer(Charge charge)
        {
            charge.Layers += 1;
            new MSSQLEAdapter("Orders", "INSERT " +
                                "INTO Layers (Order_Id, Box_Id, Charge_Id, Machine, Layer, [User]) " +
                                "VALUES (" +
                                charge.Order_Id + "," +
                                charge.Box_Id + "," +
                                charge.Id + ", " +
                                Machine + "," +
                                charge.Layers + ",'" +
                                ApplicationService.GetVariableValue("__CURRENT_USER.FULLNAME").ToString() + "');").DB_Input();
            DataTable DT = new MSSQLEAdapter("Orders", "SELECT * " +
                                             "FROM Layers " +
                                             "WHERE Charge_Id = " + charge.Id + " AND " +
                                             "Layer = " + charge.Layers + ";").DB_Output();

            return (int)DT.Rows[0]["Id"];
        }
        #endregion

    }
}
