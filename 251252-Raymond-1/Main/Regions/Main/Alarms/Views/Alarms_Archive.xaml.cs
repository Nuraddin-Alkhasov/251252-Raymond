using VisiWin.ApplicationFramework;

namespace HMI.MainRegion.Alarms.Views
{
    /// <summary>
    /// Interaction logic for AlarmHistoryView.xaml
    /// </summary>
    [ExportView("Alarms_Archive")]
    public partial class Alarms_Archive
    {
        public Alarms_Archive()
        {
            InitializeComponent();
            DataContext = new Adapters.Alarms_Archive();
        }
    }
}