using HMI.CO.General;
using System;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using VisiWin.Alarm;
using VisiWin.ApplicationFramework;
using VisiWin.DataAccess;

namespace HMI.CO.Protocol
{
    class Coating
    {
        public Coating(string _Start, string _End, string _Alarm)
        {
            IVariableService VS = ApplicationService.GetService<IVariableService>();

            Start = VS.GetVariable(_Start);
            Start.Change += Start_Event;

            End = VS.GetVariable(_End);
            End.Change += End_Event;

            Alarm = VS.GetVariable(_Alarm);
            Alarm.Change += Alarm_Event;
        }
        #region - - - Properties - - -  

        ICurrentAlarms2 CurrentAlarmList = ApplicationService.GetService<IAlarmService>().GetCurrentAlarms2();

        IVariable Start;
        IVariable End;
        IVariable Alarm;
        public IVariable Layer_Id { set; get; }
        public IVariable MR_Id { set; get; }
        public IVariable SetPaintTemp { set; get; }
        public IVariable ActualPaintTemp { set; get; }     
        public IVariable ActualLayer { set; get; }

        #endregion

        #region - - - Event Handlers - - - 
        private void Start_Event(object sender, VariableEventArgs e)
        {
            if (e.Quality.Data == DataQuality.Good && e.Value != e.PreviousValue && (bool)e.Value)
            {
                Start.Value = false;
                Task.Run(() =>
                {
                    Layer r = GetLayer((int)(uint)Layer_Id.Value);
                    if (r.Id > 0)
                    {
                        WriteDateTimeToLayer("C_S", r);
                        WriteSetValuesToLayer(r);
                        CopyCoating(r);
                        CopyPaint(r);
                        WriteActualValuesToLayer(r);
                  
                    }
                });
            }
        }

        private void End_Event(object sender, VariableEventArgs e)
        {
            if (e.Quality.Data == DataQuality.Good && e.Value != e.PreviousValue && (bool)e.Value)
            {
                End.Value = false;
                Task.Run(() =>
                {
                    Layer r = GetLayer((int)(uint)Layer_Id.Value);
                    if (r.Id > 0)
                        WriteDateTimeToLayer("C_E", r);
                });
            }
        }

        private void Alarm_Event(object sender, VariableEventArgs e)
        {
            if (e.Quality.Data == DataQuality.Good && e.Value != e.PreviousValue && (bool)e.Value)
            {
                Alarm.Value = false;
                Task.Run(() =>
                {
                    Layer r = GetLayer((int)(uint)Layer_Id.Value);
                    if (r.Id > 0)
                        WriteAlarmsToLayer(r);
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

        private void WriteDateTimeToLayer(string clmn, Layer layer)
        {
            new MSSQLEAdapter("Orders", "UPDATE Layers " +
                                  "SET " + clmn + " = '" + DateTime.Now.ToString("yyyyMMdd HH:mm:ss") + "' " +
                                  "WHERE Id = " + layer.Id + ";").DB_Input();
        }

        private void WriteSetValuesToLayer(Layer layer)
        {
            new MSSQLEAdapter("Orders", "INSERT " +
                                  "INTO SetValues (Order_Id, Box_Id, Charge_Id, Layer_Id, PaintTemp) " +
                                  "VALUES (" +
                                  layer.Order_Id + "," +
                                  layer.Box_Id + "," +
                                  layer.Charge_Id + "," +
                                  Layer_Id.Value + ",'" +
                                  Math.Round((float)SetPaintTemp.Value, 0) + "');").DB_Input();
            
        }

        private void CopyCoating(Layer layer)
        {
           
            DataTable DT = new MSSQLEAdapter("Recipes", "SELECT *  FROM Recipes_MR WHERE Id = " + MR_Id.Value.ToString() + "; ").DB_Output();
            int RecipesCoating_Id = (int)DT.Rows[0]["C" + ((byte)ActualLayer.Value).ToString() + "_Id"];

            DT = new MSSQLEAdapter("Orders", "SELECT Id  FROM Recipes_MR WHERE Box_Id = " + layer.Box_Id + "; ").DB_Output();
            int Protocol_MR_Id = (int)DT.Rows[0]["Id"];


            DT = new MSSQLEAdapter("Recipes", "SELECT * " +
                                             "FROM Recipes_Coating " +
                                             "WHERE Id = " + RecipesCoating_Id + ";").DB_Output();

            new MSSQLEAdapter("Orders", "INSERT " +
                                  "INTO Recipes_Coating (Order_Id, Box_Id, MR_Id, Layer_Id, Layer, Name, Description, LastChanged, [User], VWRecipe) " +
                                  "VALUES (" +
                                  layer.Order_Id + "," +
                                  layer.Box_Id + "," +
                                  Protocol_MR_Id + "," +
                                  layer.Id + "," +
                                  ((byte)ActualLayer.Value + 1).ToString() + ",'" +
                                  DT.Rows[0]["Name"] + "','" +
                                  (DT.Rows[0]["Description"] == DBNull.Value ? "" : (string)DT.Rows[0]["Description"]) + "','" +
                                  ((DateTime)DT.Rows[0]["LastChanged"]).ToString("yyyyMMdd HH:mm:ss") + "','" +
                                  (string)DT.Rows[0]["User"] + "','" +
                                  (string)DT.Rows[0]["VWRecipe"] + "');").DB_Input();

        }

        private void CopyPaint(Layer layer)
        {

            DataTable DT = new MSSQLEAdapter("Recipes", "SELECT *  FROM Recipes_MR WHERE Id = " + MR_Id.Value.ToString() + "; ").DB_Output();
            int RecipesPaint_Id = (int)DT.Rows[0]["P" + ((byte)ActualLayer.Value).ToString() + "_Id"];

            DT = new MSSQLEAdapter("Orders", "SELECT Id  FROM Recipes_MR WHERE Box_Id = " + layer.Box_Id + "; ").DB_Output();
            int Protocol_MR_Id = (int)DT.Rows[0]["Id"];


            DT = new MSSQLEAdapter("Recipes", "SELECT * " +
                                             "FROM Recipes_Paint " +
                                             "WHERE Id = " + RecipesPaint_Id + ";").DB_Output();

            new MSSQLEAdapter("Orders", "INSERT " +
                                  "INTO Recipes_Paint (Order_Id, Box_Id, MR_Id, Layer_Id, Layer, Name, Description, LastChanged, [User], VWRecipe) " +
                                  "VALUES (" +
                                  layer.Order_Id + "," +
                                  layer.Box_Id + "," +
                                  Protocol_MR_Id + "," +
                                  layer.Id + "," +
                                  ((byte)ActualLayer.Value + 1).ToString() + ",'" +
                                  DT.Rows[0]["Name"] + "','" +
                                  (DT.Rows[0]["Description"] == DBNull.Value ? "" : (string)DT.Rows[0]["Description"]) + "','" +
                                  ((DateTime)DT.Rows[0]["LastChanged"]).ToString("yyyyMMdd HH:mm:ss") + "','" +
                                  (string)DT.Rows[0]["User"] + "','" +
                                  (string)DT.Rows[0]["VWRecipe"] + "');").DB_Input();

        }

        private void WriteActualValuesToLayer(Layer layer)
        {
            new MSSQLEAdapter("Orders", "INSERT " +
                                  "INTO ActualValues (Order_Id, Box_Id, Charge_Id, Layer_Id, PaintTemp) " +
                                  "VALUES (" +
                                  layer.Order_Id + "," +
                                  layer.Box_Id + "," +
                                  layer.Charge_Id + "," +
                                  layer.Id + ",'" +
                                  Math.Round((float)ActualPaintTemp.Value, 0) + "');").DB_Input();

        }

        private void WriteAlarmsToLayer(Layer layer)
        {
            IAlarmItem[] TT = CurrentAlarmList.Alarms.Where(x => (x.Group.Name == "Error" || x.Group.Name == "Warning") && x.AlarmState == AlarmState.Active && (x.Param1=="CD" || x.Param1 == "DT")).ToArray();

            if (TT.Length != 0)
                foreach (IAlarmItem AI in TT)
                {
                    bool result = new MSSQLEAdapter("Orders", "INSERT " +
                                                    "INTO Alarms (Order_Id, Box_Id, Charge_Id, Layer_Id, Alarm, ActivationTime, DeactivationTime, LocalizableText, [User]) " +
                                                    "VALUES (" +
                                                    layer.Order_Id + "," +
                                                    layer.Box_Id + "," +
                                                    layer.Charge_Id + "," +
                                                    layer.Id + "," +
                                                    AI.Name +",'" +
                                                    AI.ActivationTime.ToString("yyyyMMdd HH:mm:ss") + "','" +
                                                    AI.DeactivationTime.ToString("yyyyMMdd HH:mm:ss") + "','" +
                                                    AI.LocalizableText + "','" +
                                                    ApplicationService.GetVariableValue("__CURRENT_USER.FULLNAME").ToString() + "')").DB_Input();
                }
        }


        #endregion

    }
}
