using HMI.CO.General;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading;

namespace HMI.CO.Protocol
{

    public class Layer
    {
        public Layer()
        {
        }

        public int Id { set; get; } = -1;
        public int Order_Id { set; get; } = -1;
        public int Box_Id { set; get; } = -1;
        public int Charge_Id { set; get; } = -1;
        public int Machine { set; get; } = 0;
        public int LayerNr { set; get; } = 0;
        public bool Alarm { set; get; } = false;
        public string Start { set; get; } = "";
        public string C_S { set; get; } = "";
        public string C_E { set; get; } = "";
        public string PZ_S { set; get; } = "";
        public string PZ_E { set; get; } = "";
        public string WZ_S { set; get; } = "";
        public string WZ_E { set; get; } = "";
        public int HZ { set; get; } = 0;
        public string HZ_S { set; get; } = "";
        public string HZ_E { set; get; } = "";
        public int CZ { set; get; } = 0;
        public string CZ_S { set; get; } = "";
        public string CZ_E { set; get; } = "";
        public string End { set; get; } = "";
        public string User { set; get; } = "";

        public List<Alarm> AlarmList { set; get; } = new List<Alarm>();
        public ActualValues ActualValues { set; get; } = new ActualValues();
        public SetValues SetValues { set; get; } = new SetValues();
        public Trend PZTrend { set; get; } = new Trend();
        public Trend WZTrend { set; get; } = new Trend();
        public Trend HZTrend { set; get; } = new Trend();
        public Trend CZTrend { set; get; } = new Trend();

        public int SelectedTrendId { set; get; } = 1;
        public void FillAlarmList()
        {
            List<Alarm> temp = new List<Alarm>();
            DataTable DT = new MSSQLEAdapter("Orders", "Select * From Alarms WHERE Layer_Id = " + Id).DB_Output();
            if (DT.Rows.Count > 0)
            {
                foreach (DataRow r in DT.Rows)
                {
                    Thread.Sleep(20);
                    temp.Add(new Alarm()
                    {
                        Order_Id = (int)r["Order_Id"],
                        Box_Id = (int)r["Box_Id"],
                        Charge_Id = (int)r["Charge_Id"],
                        Layer_Id = Id,
                        AlarmNr = (int)r["Alarm"],
                        ActivationTime = ((DateTime)r["ActivationTime"]).ToString("dd.MM.yyyy HH:mm:ss"),
                        DeactivationTime = r["DeactivationTime"] == DBNull.Value ? "" : ((DateTime)r["DeactivationTime"]).ToString("dd.MM.yyyy HH:mm:ss"),
                        LocalizableText = (string)r["LocalizableText"],
                        User = (string)r["User"]
                    });

                }
            }
            AlarmList = temp;
        }
        public void FillActualValues()
        {
            ActualValues temp = new ActualValues();
            DataTable DT = new MSSQLEAdapter("Orders", "Select * From ActualValues WHERE Layer_Id = " + Id).DB_Output();
            Thread.Sleep(20);
            if (DT.Rows.Count > 0)
            {

                temp = new ActualValues()
                {
                    Id = (int)DT.Rows[0]["Id"],
                    Order_Id = (int)DT.Rows[0]["Order_Id"],
                    Box_Id = (int)DT.Rows[0]["Box_Id"],
                    Charge_Id = (int)DT.Rows[0]["Charge_Id"],
                    Layer_Id = (int)DT.Rows[0]["Layer_Id"],
                    PaintTemp = (float)DT.Rows[0]["PaintTemp"],
                    PZTempMin = (float)DT.Rows[0]["PZTempMin"],
                    PZTemp = (float)DT.Rows[0]["PZTemp"],
                    PZTempMax = (float)DT.Rows[0]["PZTempMax"],
                    WZTempMin = (float)DT.Rows[0]["WZTempMin"],
                    WZTemp = (float)DT.Rows[0]["WZTemp"],
                    WZTempMax = (float)DT.Rows[0]["WZTempMax"],
                    HZTempMin = (float)DT.Rows[0]["HZTempMin"],
                    HZTemp = (float)DT.Rows[0]["HZTemp"],
                    HZTempMax = (float)DT.Rows[0]["HZTempMax"],
                    CZTempMin = (float)DT.Rows[0]["CZTempMin"],
                    CZTemp = (float)DT.Rows[0]["CZTemp"],
                    CZTempMax = (float)DT.Rows[0]["CZTempMax"]
                };

            }
            ActualValues = temp;
        }
        public void FillSetValues()
        {
            SetValues temp = new SetValues();
            DataTable DT = new MSSQLEAdapter("Orders", "Select * From SetValues WHERE Layer_Id = " + Id).DB_Output();
            Thread.Sleep(20);
            if (DT.Rows.Count > 0)
            {
                temp = new SetValues()
                {
                    Id = (int)DT.Rows[0]["Id"],
                    Order_Id = (int)DT.Rows[0]["Order_Id"],
                    Box_Id = (int)DT.Rows[0]["Box_Id"],
                    Charge_Id = (int)DT.Rows[0]["Charge_Id"],
                    Layer_Id = (int)DT.Rows[0]["Layer_Id"],
                    PaintTemp = (float)DT.Rows[0]["PaintTemp"],
                    PZTemp = (float)DT.Rows[0]["PZTemp"],
                    WZTemp = (float)DT.Rows[0]["WZTemp"],
                    HZTemp = (float)DT.Rows[0]["HZTemp"],
                    CZTemp = (float)DT.Rows[0]["CZTemp"],
                };
            }
            SetValues = temp;
        }
        public void FillPZTrend()
        {
            Trend temp = new Trend();
            DataTable DT = new MSSQLEAdapter("Orders", "Select * From Trends WHERE Layer_Id = " + Id + " AND TrendType_Id = 1").DB_Output();
            Thread.Sleep(20);
            if (DT.Rows.Count > 0)
            {
                temp = new Trend()
                {
                    Id = (int)DT.Rows[0]["Id"],
                    Order_Id = (int)DT.Rows[0]["Order_Id"],
                    Box_Id = (int)DT.Rows[0]["Box_Id"],
                    Charge_Id = (int)DT.Rows[0]["Charge_Id"],
                    Layer_Id = (int)DT.Rows[0]["Layer_Id"],
                    TrendType_Id = (int)DT.Rows[0]["TrendType_Id"],
                    Start = DT.Rows[0]["Start"] == DBNull.Value ? "" : ((DateTime)DT.Rows[0]["Start"]).ToString("dd.MM.yyyy HH:mm:ss"),
                    End = DT.Rows[0]["End"] == DBNull.Value ? "" : ((DateTime)DT.Rows[0]["End"]).ToString("dd.MM.yyyy HH:mm:ss")
                };
                temp.SetTrendPoints((string)DT.Rows[0]["Trend"]);
            }
            PZTrend = temp;

        }
        public void FillWZTrend()
        {
            Trend temp = new Trend();
            DataTable DT = new MSSQLEAdapter("Orders", "Select * From Trends WHERE Layer_Id = " + Id + " AND TrendType_Id = 2").DB_Output();
            Thread.Sleep(20);
            if (DT.Rows.Count > 0)
            {
                temp = new Trend()
                {
                    Id = (int)DT.Rows[0]["Id"],
                    Order_Id = (int)DT.Rows[0]["Order_Id"],
                    Box_Id = (int)DT.Rows[0]["Box_Id"],
                    Charge_Id = (int)DT.Rows[0]["Charge_Id"],
                    Layer_Id = (int)DT.Rows[0]["Layer_Id"],
                    TrendType_Id = (int)DT.Rows[0]["TrendType_Id"],
                    Start = DT.Rows[0]["Start"] == DBNull.Value ? "" : ((DateTime)DT.Rows[0]["Start"]).ToString("dd.MM.yyyy HH:mm:ss"),
                    End = DT.Rows[0]["End"] == DBNull.Value ? "" : ((DateTime)DT.Rows[0]["End"]).ToString("dd.MM.yyyy HH:mm:ss")
                };
                temp.SetTrendPoints((string)DT.Rows[0]["Trend"]);
            }
            WZTrend = temp;

        }
        public void FillHZTrend()
        {
            Trend temp = new Trend();
            DataTable DT = new MSSQLEAdapter("Orders", "Select * From Trends WHERE Layer_Id = " + Id + " AND TrendType_Id = 3").DB_Output();
            Thread.Sleep(20);
            if (DT.Rows.Count > 0)
            {
                temp = new Trend()
                {
                    Id = (int)DT.Rows[0]["Id"],
                    Order_Id = (int)DT.Rows[0]["Order_Id"],
                    Box_Id = (int)DT.Rows[0]["Box_Id"],
                    Charge_Id = (int)DT.Rows[0]["Charge_Id"],
                    Layer_Id = (int)DT.Rows[0]["Layer_Id"],
                    TrendType_Id = (int)DT.Rows[0]["TrendType_Id"],
                    Start = DT.Rows[0]["Start"] == DBNull.Value ? "" : ((DateTime)DT.Rows[0]["Start"]).ToString("dd.MM.yyyy HH:mm:ss"),
                    End = DT.Rows[0]["End"] == DBNull.Value ? "" : ((DateTime)DT.Rows[0]["End"]).ToString("dd.MM.yyyy HH:mm:ss")
                };
                temp.SetTrendPoints((string)DT.Rows[0]["Trend"]);
            }
            HZTrend = temp;

        }
        public void FillCZTrend()
        {
            Trend temp = new Trend();
            DataTable DT = new MSSQLEAdapter("Orders", "Select * From Trends WHERE Layer_Id = " + Id + " AND TrendType_Id = 4").DB_Output();
            Thread.Sleep(20);
            if (DT.Rows.Count > 0)
            {
                temp = new Trend()
                {
                    Id = (int)DT.Rows[0]["Id"],
                    Order_Id = (int)DT.Rows[0]["Order_Id"],
                    Box_Id = (int)DT.Rows[0]["Box_Id"],
                    Charge_Id = (int)DT.Rows[0]["Charge_Id"],
                    Layer_Id = (int)DT.Rows[0]["Layer_Id"],
                    TrendType_Id = (int)DT.Rows[0]["TrendType_Id"],
                    Start = DT.Rows[0]["Start"] == DBNull.Value ? "" : ((DateTime)DT.Rows[0]["Start"]).ToString("dd.MM.yyyy HH:mm:ss"),
                    End = DT.Rows[0]["End"] == DBNull.Value ? "" : ((DateTime)DT.Rows[0]["End"]).ToString("dd.MM.yyyy HH:mm:ss")
                };
                temp.SetTrendPoints((string)DT.Rows[0]["Trend"]);
            }
            CZTrend = temp;

        }
    }
}
