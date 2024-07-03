using HMI.CO.General;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Threading;
using System.Threading.Tasks;
using VisiWin.ApplicationFramework;

namespace HMI.CO.Protocol
{

    public class Charge : AdapterBase
    {
        public Charge()
        {

        }

        public int Id { set; get; } = -1;
        public int Order_Id { set; get; } = -1;
        public int Box_Id { set; get; } = -1;
        public int ChargeNr { set; get; } = 0;
        public float Weight { set; get; } = 0;
        public bool RMO { set; get; } = false;
        public int Layers { set; get; } = 0;
        public bool Alarm { set; get; } = false;
        public string Start { set; get; } = "";
        public string End { set; get; } = "";
        public string User { set; get; } = "";

        public List<Layer> LayerList { set; get; } = new List<Layer>();

        public void FillRunList()
        {
            List<Layer> temp = new List<Layer>();
            DataTable DT = new MSSQLEAdapter("Orders", "Select * From Layers WHERE Charge_Id = " + Id).DB_Output();
            if (DT.Rows.Count > 0)
            {
                foreach (DataRow r in DT.Rows)
                {
                    Thread.Sleep(20);
                    temp.Add(new Layer()
                    {
                        Id = (int)r["Id"],
                        Order_Id = (int)r["Order_Id"],
                        Box_Id = (int)r["Box_Id"],
                        Charge_Id = Id,
                        Machine = (int)r["Machine"],
                        LayerNr = (int)r["Layer"],
                        Alarm = (bool)r["Alarm"],
                        Start = ((DateTime)r["Start"]).ToString("dd.MM.yyyy HH:mm:ss"),
                        C_S = r["C_S"] == DBNull.Value ? "" : ((DateTime)r["C_S"]).ToString("dd.MM.yyyy HH:mm:ss"),
                        C_E = r["C_E"] == DBNull.Value ? "" : ((DateTime)r["C_E"]).ToString("dd.MM.yyyy HH:mm:ss"),
                        PZ_S = r["PZ_S"] == DBNull.Value ? "" : ((DateTime)r["PZ_S"]).ToString("dd.MM.yyyy HH:mm:ss"),
                        PZ_E = r["PZ_E"] == DBNull.Value ? "" : ((DateTime)r["PZ_E"]).ToString("dd.MM.yyyy HH:mm:ss"),
                        WZ_S = r["WZ_S"] == DBNull.Value ? "" : ((DateTime)r["WZ_S"]).ToString("dd.MM.yyyy HH:mm:ss"),
                        WZ_E = r["WZ_E"] == DBNull.Value ? "" : ((DateTime)r["WZ_E"]).ToString("dd.MM.yyyy HH:mm:ss"),
                        HZ = (int)r["HZ"],
                        HZ_S = r["HZ_S"] == DBNull.Value ? "" : ((DateTime)r["HZ_S"]).ToString("dd.MM.yyyy HH:mm:ss"),
                        HZ_E = r["HZ_E"] == DBNull.Value ? "" : ((DateTime)r["HZ_E"]).ToString("dd.MM.yyyy HH:mm:ss"),
                        CZ = (int)r["CZ"],
                        CZ_S = r["CZ_S"] == DBNull.Value ? "" : ((DateTime)r["CZ_S"]).ToString("dd.MM.yyyy HH:mm:ss"),
                        CZ_E = r["CZ_E"] == DBNull.Value ? "" : ((DateTime)r["CZ_E"]).ToString("dd.MM.yyyy HH:mm:ss"),
                        End = r["End"] == DBNull.Value ? "" : ((DateTime)r["End"]).ToString("dd.MM.yyyy HH:mm:ss"),
                        User = (string)r["User"]
                    });

                }
            }
            LayerList = temp;
        }


    }
}
