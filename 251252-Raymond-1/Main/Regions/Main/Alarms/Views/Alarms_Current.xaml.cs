using HMI.CO.General;
using System.Windows;
using VisiWin.ApplicationFramework;

namespace HMI.MainRegion.Alarms.Views
{
    /// <summary>
    /// Interaction logic for View1.xaml
    /// </summary>
    [ExportView("Alarms_Current")]
    public partial class Alarms_Current
    {
        public Alarms_Current()
        {
            InitializeComponent();
            DataContext = new Adapters.Alarms_Current();
        }

    }
}