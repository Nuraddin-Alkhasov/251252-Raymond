using VisiWin.ApplicationFramework;
using VisiWin.Controls;

namespace HMI.DialogRegion.MO.Views
{

    [ExportView("M2_Status_1")]
    public partial class M2_Status_1
    {

        public M2_Status_1()
        {
            this.InitializeComponent();

            DataContext = new Adapters.M2_Status_1();
        }
       
    }
}