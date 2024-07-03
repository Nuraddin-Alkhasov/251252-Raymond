using System.ComponentModel.Composition;
using VisiWin.ApplicationFramework;
using VisiWin.Controls;
using System;
using System.Data;
using System.ComponentModel;
using HMI.CO.General;

namespace HMI.MainRegion.Dashboard.Widgets
{
    [ExportDashboardWidget("DB_Widget_PSC", "Dashboard.Text31", "@Dashboard.Text13", 1, 1)]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public partial class DB_Widget_PSC : View
    {

        public DB_Widget_PSC()
        {
            InitializeComponent();
            BackgroundWorker BGW = new BackgroundWorker();
            BGW.DoWork += BGW_DoWork;
            BGW.RunWorkerCompleted += BGW_RunWorkerCompleted;
            BGW.RunWorkerAsync();


        }

        private void BGW_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            gauge.Value = Layers;
        }
        double Layers = 0;
        private void BGW_DoWork(object sender, DoWorkEventArgs e)
        {
            DataTable temp = new MSSQLEAdapter("Orders", "SELECT Count(Id) as Layers " +
                                               "FROM Layers " +
                                               "WHERE Start >= '" + DateTime.Now.AddHours(-1).ToString("yyyyMMdd HH:mm:ss") + "' AND Start<='" + DateTime.Now.ToString("yyyyMMdd HH:mm:ss") + "';").DB_Output();
            if (temp.Rows.Count == 0)
            { Layers = 0; }
            else
            {
                if (temp.Rows[0]["Layers"] != System.DBNull.Value)
                {
                    Layers = Convert.ToDouble(temp.Rows[0]["Layers"]);
                }
                else
                {
                    Layers = 0;
                }
            }

        }
        private void Border_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            new ObjectAnimator().OpenDialog(this, border);
        }
    }
}
