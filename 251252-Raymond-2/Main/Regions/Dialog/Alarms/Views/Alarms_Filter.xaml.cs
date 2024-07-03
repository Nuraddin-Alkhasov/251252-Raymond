using VisiWin.ApplicationFramework;

namespace HMI.DialogRegion.Alarms.Views
{

    [ExportView("Alarms_Filter")]
    public partial class Alarms_Filter
    {
        public Alarms_Filter()
        {
            InitializeComponent();
            DataContext = ApplicationService.GetAdapter("Alarms_Filter");
        }


    }
}