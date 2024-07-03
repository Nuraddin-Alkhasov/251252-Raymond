using HMI.CO.General;
using HMI.MessageBoxRegion.Views;
using HMI.Resources;
using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using VisiWin.ApplicationFramework;
using VisiWin.Controls;
using VisiWin.DataAccess;
using VisiWin.Language;
using VisiWin.Logging;

namespace HMI.DialogRegion.MO.Views
{

    [ExportView("M1_HR_M")]
    public partial class M1_HR_M
    {
        public M1_HR_M()
        {
            InitializeComponent();
        }

        private readonly ILoggingService loggingService = ApplicationService.GetService<ILoggingService>();
        private void View_Loaded(object sender, RoutedEventArgs e)
        {
            new ObjectAnimator().OpenDialog(this, border);
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            new ObjectAnimator().CloseDialog1(this, border);
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (MessageBoxView.Show("@MachineOverview.Text53", "@MachineOverview.Text78", MessageBoxButton.YesNo, MessageBoxResult.No, MessageBoxIcon.Question) == MessageBoxResult.Yes)
            {
                ApplicationService.SetVariableValue("CPU1.PLC.Blocks.00 Main.02 HMI.00 Main.DB HMI Main.Control voltage.from.On", true);
                loggingService.Log("Machine", "OnOff", "@Logging.Machine.Text5", DateTime.Now);
            }
        }
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (MessageBoxView.Show("@MachineOverview.Text53", "@MachineOverview.Text79", MessageBoxButton.YesNo, MessageBoxResult.No, MessageBoxIcon.Question) == MessageBoxResult.Yes)
            {
                ApplicationService.SetVariableValue("CPU1.PLC.Blocks.00 Main.02 HMI.00 Main.DB HMI Main.Control voltage.from.On", false);
                loggingService.Log("Machine", "OnOff", "@Logging.Machine.Text4", DateTime.Now);
            }
        }
        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            if (MessageBoxView.Show("@MachineOverview.Text53", "@MachineOverview.Text65", MessageBoxButton.YesNo, MessageBoxResult.No, MessageBoxIcon.Question) == MessageBoxResult.Yes)
            {

                Task taskA = Task.Run(() =>
                {
                    ApplicationService.SetVariableValue("CPU2.PLC.Blocks.00 Main.02 HMI.00 Main.DB HMI Main.Production.from.Mode.Option.Forced", true);
                });
                taskA.ContinueWith(async x =>
                {
                    await Task.Delay(1000);
                    ApplicationService.SetVariableValue("CPU2.PLC.Blocks.00 Main.02 HMI.00 Main.DB HMI Main.Production.from.Mode.Option.Forced", false);

                }, TaskContinuationOptions.OnlyOnRanToCompletion);
            }
        }
        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            if (MessageBoxView.Show("@MachineOverview.Text53", "@MachineOverview.Text104", MessageBoxButton.YesNo, MessageBoxResult.No, MessageBoxIcon.Question) == MessageBoxResult.Yes)
            {
                Task taskA = Task.Run(() =>
                {
                    ApplicationService.SetVariableValue("CPU2.PLC.Blocks.00 Main.02 HMI.00 Main.DB HMI Main.Production.from.Mode.Empty", true);
                });
                taskA.ContinueWith(async x =>
                {
                    await Task.Delay(1000);
                    ApplicationService.SetVariableValue("CPU2.PLC.Blocks.00 Main.02 HMI.00 Main.DB HMI Main.Production.from.Mode.Empty", false);

                }, TaskContinuationOptions.OnlyOnRanToCompletion);
            }
        }
    }
}