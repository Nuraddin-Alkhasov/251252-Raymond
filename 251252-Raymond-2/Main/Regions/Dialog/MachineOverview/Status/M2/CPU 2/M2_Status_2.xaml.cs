using VisiWin.ApplicationFramework;

namespace HMI.DialogRegion.MO.Views
{

    [ExportView("M2_Status_2")]
    public partial class M2_Status_2
    {

        public M2_Status_2()
        {
            this.InitializeComponent();

            DataContext = new Adapters.M2_Status_2();

        }

    }
}