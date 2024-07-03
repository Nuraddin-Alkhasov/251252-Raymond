using HMI.CO.General;
using System.Data;
using VisiWin.ApplicationFramework;
using VisiWin.Controls;

namespace HMI.DialogRegion.MO.Views
{

    [ExportView("M1_Status_Basket")]
    public partial class M1_Status_Basket
    {

        public M1_Status_Basket()
        {
            InitializeComponent();
            IRegionService iRS = ApplicationService.GetService<IRegionService>();
        }
    }
}