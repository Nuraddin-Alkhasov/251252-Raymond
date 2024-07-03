using HMI.CO.General;
using System.Windows;
using VisiWin.ApplicationFramework;
using VisiWin.DataAccess;

namespace HMI.MainRegion.MO.Views
{

    [ExportView("M1_CD_Spin")]
	public partial class M1_CD_Spin
    {
 

        public M1_CD_Spin()
		{
			this.InitializeComponent();


            SpinType = VS.GetVariable("CPU1.PLC.Blocks.03 Basket coating.01 CD.00 Main.DB CD HMI.Actual.Spin type");
            SpinType.Change += SpinType_Change;
        }

        private void SpinType_Change(object sender, VariableEventArgs e)
        {
            switch ((byte)e.Value) 
            {
                case 2: s2.IsChecked = true; break;
                case 3: s3.IsChecked = true; break;
                default: s1.IsChecked = true; break;

            }
        }

        IVariableService VS = ApplicationService.GetService<IVariableService>();
        IVariable SpinType;
        private void _Loaded(object sender, RoutedEventArgs e)
        {

            new ObjectAnimator().ShowUIElement(this);       
                 
        }

    }
}