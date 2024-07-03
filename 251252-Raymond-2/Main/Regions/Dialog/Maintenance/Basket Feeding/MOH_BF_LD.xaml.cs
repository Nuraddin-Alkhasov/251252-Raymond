using HMI.CO.General;
using HMI.MessageBoxRegion.Views;
using HMI.Resources;
using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using VisiWin.ApplicationFramework;
using VisiWin.Logging;

namespace HMI.DialogRegion.Maintenance.Views
{
    [ExportView("MOH_BF_LD")]
    public partial class MOH_BF_LD
    {
        ILoggingService loggingService = ApplicationService.GetService<ILoggingService>();
        public MOH_BF_LD()
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
            //if (MessageBoxView.Show("@Maintenance.Text15", "@Maintenance.Text16", MessageBoxButton.YesNo, MessageBoxResult.No, MessageBoxIcon.Question) == MessageBoxResult.Yes)
            //{
            //    loggingService.Log("Machine", "Maintenance", "@Logging.Machine.Maintenance.Text1", DateTime.Now);
            //    Task taskA = Task.Run(() =>
            //    {
            //        ApplicationService.SetVariableValue("CPU1.PLC.Blocks.01 Basket feeding.01 LD.02 Clamp.DB LD Clamp HMI.PC.PM.from.Time.Reset", true);
            //    });
            //    taskA.ContinueWith(async x =>
            //    {
            //        await Task.Delay(1000);
            //        ApplicationService.SetVariableValue("CPU1.PLC.Blocks.01 Basket feeding.01 LD.02 Clamp.DB LD Clamp HMI.PC.PM.from.Time.Reset", false);

            //    }, TaskContinuationOptions.OnlyOnRanToCompletion);

            //    new ObjectAnimator().CloseDialog1(this, border);
            //}
        }
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            //if (MessageBoxView.Show("@Maintenance.Text15", "@Maintenance.Text16", MessageBoxButton.YesNo, MessageBoxResult.No, MessageBoxIcon.Question) == MessageBoxResult.Yes)
            //{
            //    loggingService.Log("Machine", "Maintenance", "@Logging.Machine.Maintenance.Text1", DateTime.Now);
            //    Task taskA = Task.Run(() =>
            //    {
            //        ApplicationService.SetVariableValue("CPU1.PLC.Blocks.01 Basket feeding.01 LD.02 Clamp.DB LD Clamp HMI.PC.PM.from.State.Reset", true);
            //    });
            //    taskA.ContinueWith(async x =>
            //    {
            //        await Task.Delay(1000);
            //        ApplicationService.SetVariableValue("CPU1.PLC.Blocks.01 Basket feeding.01 LD.02 Clamp.DB LD Clamp HMI.PC.PM.from.State.Reset", false);

            //    }, TaskContinuationOptions.OnlyOnRanToCompletion);

            //    new ObjectAnimator().CloseDialog1(this, border);

            //}
        }
        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            if (MessageBoxView.Show("@Maintenance.Text15", "@Maintenance.Text16", MessageBoxButton.YesNo, MessageBoxResult.No, MessageBoxIcon.Question) == MessageBoxResult.Yes)
            {
                loggingService.Log("Machine", "Maintenance", "@Logging.Machine.Maintenance.Text2", DateTime.Now);
                Task taskA = Task.Run(() =>
                {
                    ApplicationService.SetVariableValue("CPU1.PLC.Blocks.01 Basket feeding.01 LD.02 Clamp.DB LD Clamp HMI.PC.PM.from.Time.Reset", true);
                });
                taskA.ContinueWith(async x =>
                {
                    await Task.Delay(1000);
                    ApplicationService.SetVariableValue("CPU1.PLC.Blocks.01 Basket feeding.01 LD.02 Clamp.DB LD Clamp HMI.PC.PM.from.Time.Reset", false);

                }, TaskContinuationOptions.OnlyOnRanToCompletion);
               
                new ObjectAnimator().CloseDialog1(this, border);
            }
        }
        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            if (MessageBoxView.Show("@Maintenance.Text15", "@Maintenance.Text16", MessageBoxButton.YesNo, MessageBoxResult.No, MessageBoxIcon.Question) == MessageBoxResult.Yes)
            {
                loggingService.Log("Machine", "Maintenance", "@Logging.Machine.Maintenance.Text2", DateTime.Now);
                Task taskA = Task.Run(() =>
                {
                    ApplicationService.SetVariableValue("CPU1.PLC.Blocks.01 Basket feeding.01 LD.02 Clamp.DB LD Clamp HMI.PC.PM.from.State.Reset", true);
                });
                taskA.ContinueWith(async x =>
                {
                    await Task.Delay(1000);
                    ApplicationService.SetVariableValue("CPU1.PLC.Blocks.01 Basket feeding.01 LD.02 Clamp.DB LD Clamp HMI.PC.PM.from.State.Reset", false);

                }, TaskContinuationOptions.OnlyOnRanToCompletion);
                
                new ObjectAnimator().CloseDialog1(this, border);

            }
        }
        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            if (MessageBoxView.Show("@Maintenance.Text15", "@Maintenance.Text16", MessageBoxButton.YesNo, MessageBoxResult.No, MessageBoxIcon.Question) == MessageBoxResult.Yes)
            {
                loggingService.Log("Machine", "Maintenance", "@Logging.Machine.Maintenance.Text3", DateTime.Now);
                Task taskA = Task.Run(() =>
                {
                    ApplicationService.SetVariableValue("CPU1.PLC.Blocks.01 Basket feeding.01 LD.03 Lift.DB LD Lift HMI.PC.PM.from.Time.Reset", true);
                });
                taskA.ContinueWith(async x =>
                {
                    await Task.Delay(1000);
                    ApplicationService.SetVariableValue("CPU1.PLC.Blocks.01 Basket feeding.01 LD.03 Lift.DB LD Lift HMI.PC.PM.from.Time.Reset", false);

                }, TaskContinuationOptions.OnlyOnRanToCompletion);

                new ObjectAnimator().CloseDialog1(this, border);

            }
        }
        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            if (MessageBoxView.Show("@Maintenance.Text15", "@Maintenance.Text16", MessageBoxButton.YesNo, MessageBoxResult.No, MessageBoxIcon.Question) == MessageBoxResult.Yes)
            {
                loggingService.Log("Machine", "Maintenance", "@Logging.Machine.Maintenance.Text3", DateTime.Now);
                Task taskA = Task.Run(() =>
                {
                    ApplicationService.SetVariableValue("CPU1.PLC.Blocks.01 Basket feeding.01 LD.03 Lift.DB LD Lift HMI.PC.PM.from.State.Reset", true);
                });
                taskA.ContinueWith(async x =>
                {
                    await Task.Delay(1000);
                    ApplicationService.SetVariableValue("CPU1.PLC.Blocks.01 Basket feeding.01 LD.03 Lift.DB LD Lift HMI.PC.PM.from.State.Reset", false);

                }, TaskContinuationOptions.OnlyOnRanToCompletion);

                new ObjectAnimator().CloseDialog1(this, border);

            }
        }
        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
            if (MessageBoxView.Show("@Maintenance.Text15", "@Maintenance.Text16", MessageBoxButton.YesNo, MessageBoxResult.No, MessageBoxIcon.Question) == MessageBoxResult.Yes)
            {
                loggingService.Log("Machine", "Maintenance", "@Logging.Machine.Maintenance.Text4", DateTime.Now);
                Task taskA = Task.Run(() =>
                {
                    ApplicationService.SetVariableValue("CPU1.PLC.Blocks.01 Basket feeding.01 LD.04 Tilt.DB LD Tilt HMI.PC.PM.from.Time.Reset", true);
                });
                taskA.ContinueWith(async x =>
                {
                    await Task.Delay(1000);
                    ApplicationService.SetVariableValue("CPU1.PLC.Blocks.01 Basket feeding.01 LD.04 Tilt.DB LD Tilt HMI.PC.PM.from.Time.Reset", false);

                }, TaskContinuationOptions.OnlyOnRanToCompletion);

                new ObjectAnimator().CloseDialog1(this, border);

            }
        }
        private void Button_Click_8(object sender, RoutedEventArgs e)
        {
            if (MessageBoxView.Show("@Maintenance.Text15", "@Maintenance.Text16", MessageBoxButton.YesNo, MessageBoxResult.No, MessageBoxIcon.Question) == MessageBoxResult.Yes)
            {
                loggingService.Log("Machine", "Maintenance", "@Logging.Machine.Maintenance.Text4", DateTime.Now);
                Task taskA = Task.Run(() =>
                {
                    ApplicationService.SetVariableValue("CPU1.PLC.Blocks.01 Basket feeding.01 LD.04 Tilt.DB LD Tilt HMI.PC.PM.from.State.Reset", true);
                });
                taskA.ContinueWith(async x =>
                {
                    await Task.Delay(1000);
                    ApplicationService.SetVariableValue("CPU1.PLC.Blocks.01 Basket feeding.01 LD.04 Tilt.DB LD Tilt HMI.PC.PM.from.State.Reset", false);

                }, TaskContinuationOptions.OnlyOnRanToCompletion);

                new ObjectAnimator().CloseDialog1(this, border);

            }
        }
        private void Button_Click_9(object sender, RoutedEventArgs e)
        {
            if (MessageBoxView.Show("@Maintenance.Text15", "@Maintenance.Text16", MessageBoxButton.YesNo, MessageBoxResult.No, MessageBoxIcon.Question) == MessageBoxResult.Yes)
            {
                loggingService.Log("Machine", "Maintenance", "@Logging.Machine.Maintenance.Text5", DateTime.Now);
                Task taskA = Task.Run(() =>
                {
                    ApplicationService.SetVariableValue("CPU1.PLC.Blocks.01 Basket feeding.01 LD.05 Lid.DB LD Lid HMI.PC.PM.from.Time.Reset", true);
                });
                taskA.ContinueWith(async x =>
                {
                    await Task.Delay(1000);
                    ApplicationService.SetVariableValue("CPU1.PLC.Blocks.01 Basket feeding.01 LD.05 Lid.DB LD Lid HMI.PC.PM.from.Time.Reset", false);

                }, TaskContinuationOptions.OnlyOnRanToCompletion);

                new ObjectAnimator().CloseDialog1(this, border);

            }
        }
        private void Button_Click_10(object sender, RoutedEventArgs e)
        {
            if (MessageBoxView.Show("@Maintenance.Text15", "@Maintenance.Text16", MessageBoxButton.YesNo, MessageBoxResult.No, MessageBoxIcon.Question) == MessageBoxResult.Yes)
            {
                loggingService.Log("Machine", "Maintenance", "@Logging.Machine.Maintenance.Text5", DateTime.Now);
                Task taskA = Task.Run(() =>
                {
                    ApplicationService.SetVariableValue("CPU1.PLC.Blocks.01 Basket feeding.01 LD.05 Lid.DB LD Lid HMI.PC.PM.from.State.Reset", true);
                });
                taskA.ContinueWith(async x =>
                {
                    await Task.Delay(1000);
                    ApplicationService.SetVariableValue("CPU1.PLC.Blocks.01 Basket feeding.01 LD.05 Lid.DB LD Lid HMI.PC.PM.from.State.Reset", false);

                }, TaskContinuationOptions.OnlyOnRanToCompletion);

                new ObjectAnimator().CloseDialog1(this, border);

            }
        }
     
      
    }
}