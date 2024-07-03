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
    [ExportView("MOH_BC_DT")]
    public partial class MOH_BC_DT
    {
        ILoggingService loggingService = ApplicationService.GetService<ILoggingService>();

        public MOH_BC_DT()
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
                loggingService.Log("Machine", "Maintenance", "@Logging.Machine.Maintenance.Text30", DateTime.Now);
                Task taskA = Task.Run(() =>
                {
                    ApplicationService.SetVariableValue("CPU1.PLC.Blocks.03 Basket coating.02 DT.01 Lift.DB DT Lift HMI.PC.PM.from.Time.Reset", true);
                });
                taskA.ContinueWith(async x =>
                {
                    await Task.Delay(1000);
                    ApplicationService.SetVariableValue("CPU1.PLC.Blocks.03 Basket coating.02 DT.01 Lift.DB DT Lift HMI.PC.PM.from.Time.Reset", false);

                }, TaskContinuationOptions.OnlyOnRanToCompletion);

                new ObjectAnimator().CloseDialog1(this, border);
            }
        }
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (MessageBoxView.Show("@Maintenance.Text15", "@Maintenance.Text16", MessageBoxButton.YesNo, MessageBoxResult.No, MessageBoxIcon.Question) == MessageBoxResult.Yes)
            {
                loggingService.Log("Machine", "Maintenance", "@Logging.Machine.Maintenance.Text30", DateTime.Now);
                Task taskA = Task.Run(() =>
                {
                    ApplicationService.SetVariableValue("CPU1.PLC.Blocks.03 Basket coating.02 DT.01 Lift.DB DT Lift HMI.PC.PM.from.State.Reset", true);
                });
                taskA.ContinueWith(async x =>
                {
                    await Task.Delay(1000);
                    ApplicationService.SetVariableValue("CPU1.PLC.Blocks.03 Basket coating.02 DT.01 Lift.DB DT Lift HMI.PC.PM.from.State.Reset", false);

                }, TaskContinuationOptions.OnlyOnRanToCompletion);

                new ObjectAnimator().CloseDialog1(this, border);

            }
        }
        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            if (MessageBoxView.Show("@Maintenance.Text15", "@Maintenance.Text16", MessageBoxButton.YesNo, MessageBoxResult.No, MessageBoxIcon.Question) == MessageBoxResult.Yes)
            {
                loggingService.Log("Machine", "Maintenance", "@Logging.Machine.Maintenance.Text31", DateTime.Now);
                Task taskA = Task.Run(() =>
                {
                    ApplicationService.SetVariableValue("CPU1.PLC.Blocks.03 Basket coating.02 DT.02 Pump.DB DT Pump HMI.PC.PM.from.Time.Reset", true);
                });
                taskA.ContinueWith(async x =>
                {
                    await Task.Delay(1000);
                    ApplicationService.SetVariableValue("CPU1.PLC.Blocks.03 Basket coating.02 DT.02 Pump.DB DT Pump HMI.PC.PM.from.Time.Reset", false);

                }, TaskContinuationOptions.OnlyOnRanToCompletion);

                new ObjectAnimator().CloseDialog1(this, border);
            }
        }
        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            if (MessageBoxView.Show("@Maintenance.Text15", "@Maintenance.Text16", MessageBoxButton.YesNo, MessageBoxResult.No, MessageBoxIcon.Question) == MessageBoxResult.Yes)
            {
                loggingService.Log("Machine", "Maintenance", "@Logging.Machine.Maintenance.Text31", DateTime.Now);
                Task taskA = Task.Run(() =>
                {
                    ApplicationService.SetVariableValue("CPU1.PLC.Blocks.03 Basket coating.02 DT.02 Pump.DB DT Pump HMI.PC.PM.from.State.Reset", true);
                });
                taskA.ContinueWith(async x =>
                {
                    await Task.Delay(1000);
                    ApplicationService.SetVariableValue("CPU1.PLC.Blocks.03 Basket coating.02 DT.02 Pump.DB DT Pump HMI.PC.PM.from.State.Reset", false);

                }, TaskContinuationOptions.OnlyOnRanToCompletion);

                new ObjectAnimator().CloseDialog1(this, border);

            }
        }
        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            if (MessageBoxView.Show("@Maintenance.Text15", "@Maintenance.Text16", MessageBoxButton.YesNo, MessageBoxResult.No, MessageBoxIcon.Question) == MessageBoxResult.Yes)
            {
                loggingService.Log("Machine", "Maintenance", "@Logging.Machine.Maintenance.Text32", DateTime.Now);
                Task taskA = Task.Run(() =>
                {
                    ApplicationService.SetVariableValue("CPU1.PLC.Blocks.03 Basket coating.02 DT.03 Cooling.DB DT Cooling HMI.PC.PM.from.Time.Reset", true);
                });
                taskA.ContinueWith(async x =>
                {
                    await Task.Delay(1000);
                    ApplicationService.SetVariableValue("CPU1.PLC.Blocks.03 Basket coating.02 DT.03 Cooling.DB DT Cooling HMI.PC.PM.from.Time.Reset", false);

                }, TaskContinuationOptions.OnlyOnRanToCompletion);

                new ObjectAnimator().CloseDialog1(this, border);
            }
        }
        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            if (MessageBoxView.Show("@Maintenance.Text15", "@Maintenance.Text16", MessageBoxButton.YesNo, MessageBoxResult.No, MessageBoxIcon.Question) == MessageBoxResult.Yes)
            {
                loggingService.Log("Machine", "Maintenance", "@Logging.Machine.Maintenance.Text32", DateTime.Now);
                Task taskA = Task.Run(() =>
                {
                    ApplicationService.SetVariableValue("CPU1.PLC.Blocks.03 Basket coating.02 DT.03 Cooling.DB DT Cooling HMI.PC.PM.from.State.Reset", true);
                });
                taskA.ContinueWith(async x =>
                {
                    await Task.Delay(1000);
                    ApplicationService.SetVariableValue("CPU1.PLC.Blocks.03 Basket coating.02 DT.03 Cooling.DB DT Cooling HMI.PC.PM.from.State.Reset", false);

                }, TaskContinuationOptions.OnlyOnRanToCompletion);

                new ObjectAnimator().CloseDialog1(this, border);

            }
        }
    }
}