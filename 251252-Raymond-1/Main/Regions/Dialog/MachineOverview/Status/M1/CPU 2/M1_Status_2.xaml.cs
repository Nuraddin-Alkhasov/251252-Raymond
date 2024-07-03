using VisiWin.ApplicationFramework;

namespace HMI.DialogRegion.MO.Views
{

    [ExportView("M1_Status_2")]
    public partial class M1_Status_2
    {

        public M1_Status_2()
        {
            this.InitializeComponent();

            DataContext = new Adapters.M1_Status_2();

        }

    }
}