using HMI.CO.General;
using System.Data;
using VisiWin.ApplicationFramework;
using VisiWin.Controls;

namespace HMI.DialogRegion.MO.Views
{

    [ExportView("M2_Status_Basket")]
    public partial class M2_Status_Basket
    {

        public M2_Status_Basket()
        {
            InitializeComponent();
            IRegionService iRS = ApplicationService.GetService<IRegionService>();
        }
    }
}