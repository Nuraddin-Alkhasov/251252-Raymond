using HMI.CO.General;
using HMI.MessageBoxRegion.Views;
using HMI.Resources;
using System;
using System.Threading.Tasks;
using System.Windows;
using VisiWin.ApplicationFramework;
using VisiWin.Logging;

namespace HMI.DialogRegion.Maintenance.Views
{
    [ExportView("MOH_BF_HC")]
    public partial class MOH_BF_HC
    {
        ILoggingService loggingService = ApplicationService.GetService<ILoggingService>();

        public MOH_BF_HC()
        {
            this.InitializeComponent();
        }

        private void Close_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            new ObjectAnimator().CloseDialog1(this, border);

        }
        private void _Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            new ObjectAnimator().OpenDialog(this, border);
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (MessageBoxView.Show("@Maintenance.Text15", "@Maintenance.Text16", MessageBoxButton.YesNo, MessageBoxResult.No, MessageBoxIcon.Question) == MessageBoxResult.Yes)
            {
                loggingService.Log("Machine", "Maintenance", "@Logging.Machine.Maintenance.Text6", DateTime.Now);
                Task taskA = Task.Run(() =>
                {
                    ApplicationService.SetVariableValue("CPU1.PLC.Blocks.01 Basket feeding.02 HC.01 Belt.DB HC Belt HMI.PC.PM.from.Time.Reset", true);
                });
                taskA.ContinueWith(async x =>
                {
                    await Task.Delay(1000);
                    ApplicationService.SetVariableValue("CPU1.PLC.Blocks.01 Basket feeding.02 HC.01 Belt.DB HC Belt HMI.PC.PM.from.Time.Reset", false);

                }, TaskContinuationOptions.OnlyOnRanToCompletion);

                new ObjectAnimator().CloseDialog1(this, border);
            }
        }
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (MessageBoxView.Show("@Maintenance.Text15", "@Maintenance.Text16", MessageBoxButton.YesNo, MessageBoxResult.No, MessageBoxIcon.Question) == MessageBoxResult.Yes)
            {
                loggingService.Log("Machine", "Maintenance", "@Logging.Machine.Maintenance.Text6", DateTime.Now);
                Task taskA = Task.Run(() =>
                {
                    ApplicationService.SetVariableValue("CPU1.PLC.Blocks.01 Basket feeding.02 HC.01 Belt.DB HC Belt HMI.PC.PM.from.State.Reset", true);
                });
                taskA.ContinueWith(async x =>
                {
                    await Task.Delay(1000);
                    ApplicationService.SetVariableValue("CPU1.PLC.Blocks.01 Basket feeding.02 HC.01 Belt.DB HC Belt HMI.PC.PM.from.State.Reset", false);

                }, TaskContinuationOptions.OnlyOnRanToCompletion);

                new ObjectAnimator().CloseDialog1(this, border);

            }
        }
        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            if (MessageBoxView.Show("@Maintenance.Text15", "@Maintenance.Text16", MessageBoxButton.YesNo, MessageBoxResult.No, MessageBoxIcon.Question) == MessageBoxResult.Yes)
            {
                loggingService.Log("Machine", "Maintenance", "@Logging.Machine.Maintenance.Text7", DateTime.Now);
                Task taskA = Task.Run(() =>
                {
                    ApplicationService.SetVariableValue("CPU1.PLC.Blocks.01 Basket feeding.02 HC.02 Scale.DB HC Scale HMI.PC.PM.from.Time.Reset", true);
                });
                taskA.ContinueWith(async x =>
                {
                    await Task.Delay(1000);
                    ApplicationService.SetVariableValue("CPU1.PLC.Blocks.01 Basket feeding.02 HC.02 Scale.DB HC Scale HMI.PC.PM.from.Time.Reset", false);

                }, TaskContinuationOptions.OnlyOnRanToCompletion);

                new ObjectAnimator().CloseDialog1(this, border);
            }
        }
        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            if (MessageBoxView.Show("@Maintenance.Text15", "@Maintenance.Text16", MessageBoxButton.YesNo, MessageBoxResult.No, MessageBoxIcon.Question) == MessageBoxResult.Yes)
            {
                loggingService.Log("Machine", "Maintenance", "@Logging.Machine.Maintenance.Text7", DateTime.Now);
                Task taskA = Task.Run(() =>
                {
                    ApplicationService.SetVariableValue("CPU1.PLC.Blocks.01 Basket feeding.02 HC.02 Scale.DB HC Scale HMI.PC.PM.from.State.Reset", true);
                });
                taskA.ContinueWith(async x =>
                {
                    await Task.Delay(1000);
                    ApplicationService.SetVariableValue("CPU1.PLC.Blocks.01 Basket feeding.02 HC.02 Scale.DB HC Scale HMI.PC.PM.from.State.Reset", false);

                }, TaskContinuationOptions.OnlyOnRanToCompletion);

                new ObjectAnimator().CloseDialog1(this, border);

            }
        }
    }
}