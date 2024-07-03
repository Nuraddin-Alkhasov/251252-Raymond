using HMI.CO.General;
using VisiWin.ApplicationFramework;

namespace HMI.DialogRegion.MO.Views
{

	[ExportView("M1_Sheduler")]
	public partial class M1_Sheduler
    {

        public M1_Sheduler()
		{
			this.InitializeComponent();
          
        }

        private void CancelButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            new ObjectAnimator().CloseDialog2(this, border);
        }

        private void LeftButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            ApplicationService.SetVariableValue("CPU2.PLC.Blocks.00 Main.02 HMI.00 Main.DB HMI Main.Timer.On", true);
        }

        private void RightButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            ApplicationService.SetVariableValue("CPU2.PLC.Blocks.00 Main.02 HMI.00 Main.DB HMI Main.Timer.On", false);
        }

        private void View_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            new ObjectAnimator().OpenDialog(this, border);
        }
    }
}