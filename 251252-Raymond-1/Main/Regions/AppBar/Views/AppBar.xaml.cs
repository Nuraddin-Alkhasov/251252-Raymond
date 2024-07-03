using HMI.CO.General;
using System.Windows;
using VisiWin.ApplicationFramework;

namespace HMI.AppBarRegion.Views
{
    [ExportView("AppBar")]
    public partial class AppBar
    {
        public AppBar()
        {
            InitializeComponent();
            DataContext = new Adapters.AppBar();
        }

        private void View_Loaded(object sender, RoutedEventArgs e)
        {
            ((Adapters.AppBar)DataContext).SetAlarmLineData(null, null);
        }
    }
}

