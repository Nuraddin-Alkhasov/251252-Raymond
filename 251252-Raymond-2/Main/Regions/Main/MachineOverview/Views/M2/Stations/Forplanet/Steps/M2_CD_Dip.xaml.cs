using HMI.CO.General;
using System.Windows;
using VisiWin.ApplicationFramework;

namespace HMI.MainRegion.MO.Views
{

    [ExportView("M2_CD_Dip")]
	public partial class M2_CD_Dip
    {
 

        public M2_CD_Dip()
		{
			this.InitializeComponent();
        }

  
        private void _Loaded(object sender, RoutedEventArgs e)
        {
            new ObjectAnimator().ShowUIElement(this);
        }

        private void NumericVarOut_ValueChanged(object sender, VisiWin.DataAccess.VariableEventArgs e)
        {
            if ((float)e.Value == 0.0f)
            {
                setdtime.VariableName = "CPU3.PLC.Blocks.03 Basket coating.01 CD.00 Main.Program.DB Program control.Set.Data.Dipping.Straight time";
                actdtime.VariableName = "CPU3.PLC.Blocks.03 Basket coating.01 CD.00 Main.Program.DB Program control.Actual.Dipping.Straight time";
                pack.Visibility = Visibility.Collapsed;
                border1.Visibility = Visibility.Collapsed;
            }

            if ((float)e.Value == 40.0f)
            {
                setdtime.VariableName = "CPU3.PLC.Blocks.03 Basket coating.01 CD.00 Main.Program.DB Program control.Set.Data.Dipping.Time";
                actdtime.VariableName = "CPU3.PLC.Blocks.03 Basket coating.01 CD.00 Main.Program.DB Program control.Actual.Dipping.Time";
                pack.Visibility = Visibility.Visible;
                border1.Visibility = Visibility.Visible;
            }

            if ((float)e.Value == 50.0f)
            {
                setdtime.VariableName = "CPU3.PLC.Blocks.03 Basket coating.01 CD.00 Main.Program.DB Program control.Set.Data.Dipping.Time";
                actdtime.VariableName = "CPU3.PLC.Blocks.03 Basket coating.01 CD.00 Main.Program.DB Program control.Actual.Dipping.Time";
                pack.Visibility = Visibility.Collapsed;
                border1.Visibility = Visibility.Collapsed;
            }
        }
    }
}