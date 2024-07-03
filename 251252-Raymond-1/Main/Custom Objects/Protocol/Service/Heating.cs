using HMI.CO.General;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using VisiWin.Alarm;
using VisiWin.ApplicationFramework;
using VisiWin.DataAccess;
using VisiWin.Trend;

namespace HMI.CO.Protocol
{
    class Heating
    {
        public Heating(string _Start, string _End, string _Alarm)
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

        ITrendService trendService = ApplicationService.GetService<ITrendService>();
        IArchive TrendArchive;

        ICurrentAlarms2 CurrentAlarmList = ApplicationService.GetService<IAlarmService>().GetCurrentAlarms2();

        IVariable Start;
        IVariable End;
        IVariable Alarm;

        public List<IVariable> WZ_Layer_Id { set; get; } = new List<IVariable>();
        public IVariable TM_Layer_Id { set; get; }
        public IVariable SetTemp { set; get; }

        #endregion

        #region - - - Event Handlers - - - 
        private void Start_Event(object sender, VariableEventArgs e)
        {
            if (e.Quality.Data == DataQuality.Good && e.Value != e.PreviousValue && (bool)e.Value)
            {
                Start.Value = false;
                Task.Run(() =>
                {
                    Layer r = GetLayer((int)(uint)WZ_Layer_Id[6].Value);
                    if (r.Id > 0)
                    {
                        WriteDateTimeToLayer("WZ_S", r);
                        WriteSetValuesToLayer(r);

                    }
                });
            }
        }

        private void End_Event(object sender, VariableEventArgs e)
        {
            if (e.Quality.Data == DataQuality.Good && e.Value != e.PreviousValue && (bool)e.Value)
            {
                End.Value = false;

                Layer r = GetLayer((int)(uint)TM_Layer_Id.Value);
                if (r.Id > 0)
                {
                    TrendArchive = trendService.GetArchive("M1WZ");

                    WriteDateTimeToLayer("WZ_E", r);

                    if (TrendArchive != null)
                    {
                        TrendArchive.GetTrendsDataCompleted += WriteActualValuesToLayer;

                        r.WZ_E = DateTime.Now.ToString("yyyyMMdd HH:mm:ss");
                        if (r.WZ_S != "" && r.WZ_E != "")
                            TrendArchive.GetTrendsDataAsync(
                            TrendArchive.TrendNames.ToArray(),
                            DateTime.ParseExact(r.WZ_S, "yyyyMMdd HH:mm:ss", CultureInfo.InvariantCulture),
                            DateTime.ParseExact(r.WZ_E, "yyyyMMdd HH:mm:ss", CultureInfo.InvariantCulture), null, 0);
                    }
                }
            }
        }

        private void Alarm_Event(object sender, VariableEventArgs e)
        {
            if (e.Quality.Data == DataQuality.Good && e.Value != e.PreviousValue && (bool)e.Value)
            {
                Alarm.Value = false;
                Task.Run(() =>
                {
                    foreach (IVariable v in WZ_Layer_Id)
                    {
                        if ((int)(uint)v.Value > 0)
                        {
                            Layer r = GetLayer((int)(uint)v.Value);
                            if (r.Id > 0)
                                WriteAlarmsToLayer(r);
                        }
                    }
                });
            }
        }


        private void WriteActualValuesToLayer(object sender, GetTrendsDataCompletedEventArgs e)
        {
            IDataSample[] Data = e.Data[1];
            Task.Run(() =>
            {
                double WZTempMin = Math.Round(Convert.ToDouble(Data[0].YValue), 1);
                double WZTemp = 0;
                double WZTempMax = WZTempMin;
                string trend = "";
                for (int i = 0; i <= Data.Length - 1; i++)
                {
                    string time = ((DateTime)Data[i].XValue).ToString("HH:mm:ss");
                    double value = Math.Round(Convert.ToDouble(Data[i].YValue), 1);

                    if (value < WZTempMin) { WZTempMin = value; }
                    if (value > WZTempMax) { WZTempMax = value; }
                    WZTemp += value;

                    trend += time + ";";
                    trend += value + Environment.NewLine;
                }
                WZTemp = WZTemp / Data.Length;
                Layer r = GetLayer((int)(uint)TM_Layer_Id.Value);

               
                new MSSQLEAdapter("Orders", "Update ActualValues " +
                                    "SET " +
                                    "WZTempMin = " + Math.Round(WZTempMin, 0) + ", " +
                                    "WZTemp = " + Math.Round(WZTemp, 0) + ", " +
                                    "WZTempMax = " + Math.Round(WZTempMax, 0) + " " +
                                    "WHERE Layer_Id = " + r.Id + ";").DB_Input();
               
                new MSSQLEAdapter("Orders", "INSERT " +
                                "INTO Trends " +
                                "(Order_Id, Box_Id, Charge_Id, Layer_Id, TrendType_Id, Trend, [Start], [End]) " +
                                "VALUES (" +
                                r.Order_Id + "," +
                                r.Box_Id + "," +
                                r.Charge_Id + "," +
                                r.Id + "," +
                                "2,'" +
                                trend + "','" +
                                r.WZ_S + "','" +
                                r.WZ_E + "')").DB_Input();
               
            });
            TrendArchive.GetTrendsDataCompleted -= WriteActualValuesToLayer;
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
                    Charge_Id = (int)DT.Rows[0]["Charge_Id"],
                    WZ_S = DT.Rows[0]["WZ_S"] == DBNull.Value ? "" : ((DateTime)DT.Rows[0]["WZ_S"]).ToString("yyyyMMdd HH:mm:ss"),
                    WZ_E = DateTime.Now.ToString("yyyyMMdd HH:mm:ss")
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
            new MSSQLEAdapter("Orders", "Update SetValues " +
                                  "SET WZTemp = " + Math.Round((float)SetTemp.Value, 0) + " " +
                                  "WHERE Layer_Id = " + layer.Id + " ;").DB_Input();

        }

        private void WriteAlarmsToLayer(Layer layer)
        {
            IAlarmItem[] TT = CurrentAlarmList.Alarms.Where(x => (x.Group.Name == "Error" || x.Group.Name == "Warning") && x.AlarmState == AlarmState.Active && x.Param1 == "WZ").ToArray();

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
                                                    AI.Name + ",'" +
                                                    AI.ActivationTime.ToString("yyyyMMdd HH:mm:ss") + "','" +
                                                    AI.DeactivationTime.ToString("yyyyMMdd HH:mm:ss") + "','" +
                                                    AI.LocalizableText + "','" +
                                                    ApplicationService.GetVariableValue("__CURRENT_USER.FULLNAME").ToString() + "')").DB_Input();
                }

        }


        #endregion




    }
}
