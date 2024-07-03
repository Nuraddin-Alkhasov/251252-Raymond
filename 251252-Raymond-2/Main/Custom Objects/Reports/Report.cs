using HMI.CO.General;
using HMI.CO.Reports;
using HMI.Resources;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMI.CO.Reports
{
    class Report
    {
        ReportConfiguration RC { get; set; }
        string Charge_Id { get; set; } = "-1";
        public Report(ReportConfiguration rc, string charge_Id) 
        {
            RC = rc;
            Charge_Id = charge_Id;
        }

        public void Export() 
        {
            using (var localReport = new LocalReport())
            {
                using (var fs = new FileStream(System.IO.Path.GetFullPath(RC.Path), FileMode.Open, FileAccess.Read))
                {
                    localReport.LoadReportDefinition(fs);
                }

                foreach (var subReport in RC.SubReportInfos)
                {
                    localReport.SubreportProcessing += new SubreportProcessingEventHandler(this.CreateEventHandlerFor(subReport));
                    using (var fs = new FileStream(System.IO.Path.GetFullPath(subReport.ReportPath), FileMode.Open, FileAccess.Read))
                    {
                        localReport.LoadSubreportDefinition(subReport.ReportName, fs);
                    }
                }
                foreach (var rds in RC.DataSources)
                {
                    localReport.DataSources.Add(rds);
                }
                
                localReport.SetParameters(RC.ReportParameters);
                byte[] renderedReport = new byte[] { new byte() };
                try
                {
                    renderedReport = localReport.Render("PDF");
                }
                catch
                {

                }

                Directory.CreateDirectory(System.IO.Path.GetDirectoryName(RC.DefaultExportPath));

                string ExportFileName = RC.FileName + ".pdf";
                PrepareFile(RC.DefaultExportPath + ExportFileName);

                try
                {
                    using (var fs = new FileStream(RC.DefaultExportPath + ExportFileName, FileMode.CreateNew, FileAccess.Write))
                    {
                       fs.Write(renderedReport, 0, renderedReport.Length);
                       fs.Flush();
                    }
                }
                catch
                {
                    
                }

            }

            if (Charge_Id != "-1") 
            {
                DataTable Layers = new MSSQLEAdapter("Orders", "SELECT " +
                 "Layers.Id as Id, " +
                 "Layers.Layer as Layer, " +
                 "Recipes_Coating.VWRecipe as Coating, " +
                 "Recipes_Paint.VWRecipe as Paint " +
                 "FROM[VisiWin#Orders].[dbo].Layers " +
                 "INNER JOIN[VisiWin#Orders].[dbo].SetValues " +
                 "ON[SetValues].Layer_Id = Layers.Id " +
                 "INNER JOIN[VisiWin#Orders].[dbo].Recipes_Coating " +
                 "ON[SetValues].Layer_Id = Recipes_Coating.Layer_Id " +
                  "INNER JOIN[VisiWin#Orders].[dbo].Recipes_Paint " +
                 "ON[SetValues].Layer_Id = Recipes_Paint.Layer_Id " +
                 "WHERE[SetValues].Charge_Id = " + Charge_Id).DB_Output();

                foreach (DataRow r in Layers.Rows)
                {
                    string TempName = RC.DefaultExportPath + RC.FileName + "_L_" + r["Layer"].ToString() + "_C_VWRecipe.xml";
                    PrepareFile(TempName);
                    File.WriteAllText(TempName, r["Coating"].ToString());

                    TempName = RC.DefaultExportPath + RC.FileName + "_L_" + r["Layer"].ToString() + "_P_VWRecipe.xml";
                    PrepareFile(TempName);
                    File.WriteAllText(TempName, r["Paint"].ToString());

                    DataTable PZ = new MSSQLEAdapter("Orders", "SELECT * FROM Trends WHERE TrendType_ID = 1 AND Layer_Id = " + r["Id"].ToString()).DB_Output();
                    if (PZ.Rows.Count > 0)
                    {
                        TempName = RC.DefaultExportPath + RC.FileName + "_L_" + r["Layer"].ToString() + "_PZTrend.csv";
                        PrepareFile(TempName);
                        File.WriteAllText(TempName, PZ.Rows[0]["Trend"].ToString());
                    }

                    DataTable WZ = new MSSQLEAdapter("Orders", "SELECT * FROM Trends WHERE TrendType_ID = 2 AND Layer_Id = " + r["Id"].ToString()).DB_Output();
                    if (WZ.Rows.Count > 0)
                    {
                        TempName = RC.DefaultExportPath + RC.FileName + "_L_" + r["Layer"].ToString() + "_WZTrend.csv";
                        PrepareFile(TempName);
                        File.WriteAllText(TempName, WZ.Rows[0]["Trend"].ToString());
                    }

                    DataTable HZ = new MSSQLEAdapter("Orders", "SELECT * FROM Trends WHERE TrendType_ID = 3 AND Layer_Id = " + r["Id"].ToString()).DB_Output();
                    if (WZ.Rows.Count > 0)
                    {
                        TempName = RC.DefaultExportPath + RC.FileName + "_L_" + r["Layer"].ToString() + "_HZTrend.csv";
                        PrepareFile(TempName);
                        File.WriteAllText(TempName, HZ.Rows[0]["Trend"].ToString());
                    }

                    DataTable CZ = new MSSQLEAdapter("Orders", "SELECT * FROM Trends WHERE TrendType_ID = 4 AND Layer_Id = " + r["Id"].ToString()).DB_Output();
                    if (WZ.Rows.Count > 0)
                    {
                        TempName = RC.DefaultExportPath + RC.FileName + "_L_" + r["Layer"].ToString() + "_CZTrend.csv";
                        PrepareFile(TempName);
                        File.WriteAllText(TempName, CZ.Rows[0]["Trend"].ToString());
                    }
                }
            }
         
        } 

        private Action<object, SubreportProcessingEventArgs> CreateEventHandlerFor(SubReportInfo sri)
        {
            return (sender, e) =>
            {
                if (e.ReportPath == sri.ReportName)
                {
                    e.DataSources.Clear();
                    foreach (var rds in sri.ReportDataSources)
                    {
                        e.DataSources.Add(rds);
                    }
                }
            };
        }

        private void PrepareFile(string s) 
        {
            if (File.Exists(s))
            {
                File.Delete(s);
            }
        }

    }
}
