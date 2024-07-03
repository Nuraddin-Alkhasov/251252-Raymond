using HMI.CO.General;
using HMI.MessageBoxRegion.Views;
using HMI.Resources;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using VisiWin.ApplicationFramework;
using VisiWin.Controls;
using VisiWin.DataAccess;

namespace HMI.DialogRegion.MO.Views
{

    [ExportView("M2_Coating_SF")]
    public partial class M2_Coating_SF
    {
        public M2_Coating_SF()
        {
            InitializeComponent();
        }
        IVariableService VS = ApplicationService.GetService<IVariableService>();

        IVariable VPurge;
        IVariable VPS1;
        IVariable VPS2;

        private void View_Loaded(object sender, RoutedEventArgs e)
        {
            new ObjectAnimator().OpenDialog(this, border);

        
            VPurge = VS.GetVariable("CPU3.PLC.Blocks.03 Basket coating.01 CD.07 Supply.DB CD Supply HMI.Actual.Purge.On");
            VPurge.Change += VPurge_Change;

            VPS1 = VS.GetVariable("CPU3.PLC.Blocks.03 Basket coating.01 CD.07 Supply.DB CD Supply HMI.Actual.Purge.Pressure switch 1");
            VPS1.Change += VPS1_Change;

            VPS2 = VS.GetVariable("CPU3.PLC.Blocks.03 Basket coating.01 CD.07 Supply.DB CD Supply HMI.Actual.Purge.Pressure switch 2");
            VPS2.Change += VPS2_Change;

        }

        private void VPurge_Change(object sender, VariableEventArgs e)
        {
            if (e.Quality.Data == DataQuality.Good)
            {
                if ((bool)e.Value)
                    Purge.Visibility = Visibility.Visible;
                else
                    Purge.Visibility = Visibility.Collapsed;
            }

        }
        private void VPS1_Change(object sender, VariableEventArgs e)
        {
            if (e.Quality.Data == DataQuality.Good)
            {
                if ((bool)e.Value)
                {
                    PS1.Background = (LinearGradientBrush)Application.Current.Resources["FP_Green_Gradient"];
                    PS1.IsBlinkEnabled = false;
                }
                else
                {
                    PS1.Background = (LinearGradientBrush)Application.Current.Resources["FP_Yellow_Gradient"];
                    PS1.IsBlinkEnabled = true;
                }
            }
        }
        private void VPS2_Change(object sender, VariableEventArgs e)
        {
            if (e.Quality.Data == DataQuality.Good)
            {
                if ((bool)e.Value)
                {
                    PS2.Background = (LinearGradientBrush)Application.Current.Resources["FP_Green_Gradient"];
                    PS2.IsBlinkEnabled = false;
                }
                else
                {
                    PS2.Background = (LinearGradientBrush)Application.Current.Resources["FP_Yellow_Gradient"];
                    PS2.IsBlinkEnabled = true;
                }
            }
        }


        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            new ObjectAnimator().CloseDialog1(this, border);
        }

        private void V_Off_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBoxView.Show("@MachineOverview.Text53", "@Buttons.Text64", MessageBoxButton.YesNo, MessageBoxResult.No, MessageBoxIcon.Question) == MessageBoxResult.Yes)
            {
                Task taskA = Task.Run(() =>
                {
                    ApplicationService.SetVariableValue("CPU3.PLC.Blocks.03 Basket coating.01 CD.07 Supply.DB CD Supply HMI.PC.Drive.from.Restart", true);
                });
                taskA.ContinueWith(async x =>
                {
                    await Task.Delay(1000);
                    ApplicationService.SetVariableValue("CPU3.PLC.Blocks.03 Basket coating.01 CD.07 Supply.DB CD Supply HMI.PC.Drive.from.Restart", false);

                }, TaskContinuationOptions.OnlyOnRanToCompletion);
            }


        }
    }
}