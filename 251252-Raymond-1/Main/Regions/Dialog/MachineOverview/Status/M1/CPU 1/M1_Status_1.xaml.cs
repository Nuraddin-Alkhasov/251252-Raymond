using VisiWin.ApplicationFramework;
using VisiWin.Controls;

namespace HMI.DialogRegion.MO.Views
{

    [ExportView("M1_Status_1")]
    public partial class M1_Status_1
    {

        public M1_Status_1()
        {
            this.InitializeComponent();

            DataContext = new Adapters.M1_Status_1();
        }
       
    }
}