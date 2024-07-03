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
    class Holding
    {
        public Holding(string _Start, string _End, string _Alarm)
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
        public List<IVariable> HZ1_Layer_Id { set; get; } = new List<IVariable>();
        public List<IVariable> HZ2_Layer_Id { set; get; } = new List<IVariable>();
        public IVariable TM_Layer_Id { set; get; }
        public IVariable HZ { set; get; }
        public IVariable Place { set; get; }

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
                    Layer r = new Layer();
                    
                    if ((byte)HZ.Value == 1) 
                    {
                        r = GetLayer((int)(uint)HZ1_Layer_Id[(byte)Place.Value].Value);
                    }
                    //if ((byte)HZ.Value == 2) 
                    //{
                    //    r = GetLayer((int)(uint)HZ2_Layer_Id[(byte)Place.Value].Value);
                    //}
                   
                    if (r.Id > 0)
                    {
                        WriteDateTimeToLayer("HZ_S", r);
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

                    if ((byte)HZ.Value == 1)
                    {
                        TrendArchive = trendService.GetArchive("M1HZ1");
                    }
                    if ((byte)HZ.Value == 2)
                    {
                        TrendArchive = trendService.GetArchive("M1HZ2");
                    }


                    WriteDateTimeToLayer("HZ_E", r);

                    if (TrendArchive != null)
                    {
                        TrendArchive.GetTrendsDataCompleted += WriteActualValuesToLayer;

                        r.HZ_E = DateTime.Now.ToString("yyyyMMdd HH:mm:ss");
                        if (r.HZ_S != "" && r.HZ_E != "")
                            TrendArchive.GetTrendsDataAsync(
                                TrendArchive.TrendNames.ToArray(),
                                DateTime.ParseExact(r.HZ_S, "yyyyMMdd HH:mm:ss", CultureInfo.InvariantCulture),
                                DateTime.ParseExact(r.HZ_E, "yyyyMMdd HH:mm:ss", CultureInfo.InvariantCulture), null, 0);
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
                    if ((byte)HZ.Value == 1)
                    {
                        foreach (IVariable v in HZ1_Layer_Id)
                        {
                            if ((int)(uint)v.Value > 0)
                            {
                                Layer r = GetLayer((int)(uint)v.Value);
                                if (r.Id > 0)
                                    WriteAlarmsToLayer(r);
                            }
                        }
                    }
                    //if ((byte)HZ.Value == 2)
                    //{
                    //    foreach (IVariable v in HZ2_Layer_Id)
                    //    {
                    //        if ((int)(uint)v.Value > 0)
                    //        {
                    //            Layer r = GetLayer((int)(uint)v.Value);
                    //            if (r.Id > 0)
                    //                WriteAlarmsToLayer(r);
                    //        }
                    //    }
                    //}
                    
                });
            }
        }


        private void WriteActualValuesToLayer(object sender, GetTrendsDataCompletedEventArgs e)
        {
            IDataSample[] Data = e.Data[1];
            Task.Run(() =>
            {
                double HZTempMin = Math.Round(Convert.ToDouble(Data[0].YValue), 1);
                double HZTemp = 0;
                double HZTempMax = HZTempMin;
                string trend = "";
                for (int i = 0; i <= Data.Length - 1; i++)
                {
                    string time = ((DateTime)Data[i].XValue).ToString("HH:mm:ss");
                    double value = Math.Round(Convert.ToDouble(Data[i].YValue), 1);

                    if (value < HZTempMin) { HZTempMin = value; }
                    if (value > HZTempMax) { HZTempMax = value; }
                    HZTemp += value;

                    trend += time + ";";
                    trend += value + Environment.NewLine;
                }
                HZTemp = HZTemp / Data.Length;
                Layer r = GetLayer((int)(uint)TM_Layer_Id.Value);
                

                new MSSQLEAdapter("Orders", "Update ActualValues " +
                                    "SET " +
                                    "HZTempMin = " + Math.Round(HZTempMin, 0) + ", " +
                                    "HZTemp = " + Math.Round(HZTemp, 0) + ", " +
                                    "HZTempMax = " + Math.Round(HZTempMax, 0) + " " +
                                    "WHERE Layer_Id = " + r.Id + ";").DB_Input();
               
                new MSSQLEAdapter("Orders", "INSERT " +
                                "INTO Trends " +
                                "(Order_Id, Box_Id, Charge_Id, Layer_Id, TrendType_Id, Trend, [Start], [End]) " +
                                "VALUES (" +
                                r.Order_Id + "," +
                                r.Box_Id + "," +
                                r.Charge_Id + "," +
                                r.Id + "," +
                                "3,'" +
                                trend + "','" +
                                r.HZ_S + "','" +
                                r.HZ_E + "')").DB_Input();

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
                    HZ_S = DT.Rows[0]["HZ_S"] == DBNull.Value ? "" : ((DateTime)DT.Rows[0]["HZ_S"]).ToString("yyyyMMdd HH:mm:ss"),
                    HZ_E = DateTime.Now.ToString("yyyyMMdd HH:mm:ss")
                };
            }
            else { return new Layer(); }
        }

        private void WriteDateTimeToLayer(string clmn, Layer layer)
        {
            new MSSQLEAdapter("Orders", "UPDATE Layers SET " + 
                                    clmn + " = '" + DateTime.Now.ToString("yyyyMMdd HH:mm:ss") + "', " +
                                    "HZ = " + HZ.Value.ToString() + " " +
                                    "WHERE Id = " + layer.Id + ";").DB_Input();
        }

        private void WriteSetValuesToLayer(Layer layer)
        {
            new MSSQLEAdapter("Orders", "Update SetValues " +
                                  "SET HZTemp = " + Math.Round((float)SetTemp.Value, 0) + " " +
                                  "WHERE Layer_Id = " + layer.Id + " ;").DB_Input();

        }

        private void WriteAlarmsToLayer(Layer layer)
        {
            IAlarmItem[] TT = CurrentAlarmList.Alarms.Where(x => (x.Group.Name == "Error" || x.Group.Name == "Warning") && x.AlarmState == AlarmState.Active && x.Param1 =="HZ").ToArray();

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
