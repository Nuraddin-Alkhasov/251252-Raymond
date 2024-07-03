using HMI.CO.General;
using HMI.MessageBoxRegion.Views;
using HMI.Resources;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using VisiWin.ApplicationFramework;
using VisiWin.Controls;
using VisiWin.DataAccess;
using VisiWin.Language;

namespace HMI.DialogRegion.MO.Views
{

    [ExportView("M1_HR_T")]
    public partial class M1_HR_T
    {
        public M1_HR_T()
        {
            InitializeComponent();
        }
        ILanguageService textService = ApplicationService.GetService<ILanguageService>();
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
            if (MessageBoxView.Show("@MachineOverview.Text53", "@RecipeSystem.Text58", MessageBoxButton.YesNo, MessageBoxResult.No, MessageBoxIcon.Question) == MessageBoxResult.Yes)
            {
                Task taskA = Task.Run(() =>
                {
                    ApplicationService.SetVariableValue("CPU2.PLC.Blocks.00 Main.02 HMI.00 Main.DB HMI Main.Production.from.Heat treatment.On", true);
                });
                taskA.ContinueWith(async x =>
                {
                    await Task.Delay(1000);
                    ApplicationService.SetVariableValue("CPU2.PLC.Blocks.00 Main.02 HMI.00 Main.DB HMI Main.Production.from.Heat treatment.On", false);

                }, TaskContinuationOptions.OnlyOnRanToCompletion);
            }
        }
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (MessageBoxView.Show("@MachineOverview.Text53", "@RecipeSystem.Text58", MessageBoxButton.YesNo, MessageBoxResult.No, MessageBoxIcon.Question) == MessageBoxResult.Yes)
            {
                Task taskA = Task.Run(() =>
                {
                    ApplicationService.SetVariableValue("CPU2.PLC.Blocks.00 Main.02 HMI.00 Main.DB HMI Main.Production.from.Heat treatment.Off", true);
                });
                taskA.ContinueWith(async x =>
                {
                    await Task.Delay(1000);
                    ApplicationService.SetVariableValue("CPU2.PLC.Blocks.00 Main.02 HMI.00 Main.DB HMI Main.Production.from.Heat treatment.Off", false);

                }, TaskContinuationOptions.OnlyOnRanToCompletion);
            }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            if (MessageBoxView.Show("@MachineOverview.Text53", "@RecipeSystem.Text102", MessageBoxButton.YesNo, MessageBoxResult.No, MessageBoxIcon.Question) == MessageBoxResult.Yes)
            {
                if ((byte)ApplicationService.GetVariableValue("CPU2.PLC.Blocks.00 Main.02 HMI.00 Main.DB HMI Main.Production.to.Heat treatment.Option.State.Solvent") == 0)
                {
                    Task taskA = Task.Run(() =>
                    {
                        ApplicationService.SetVariableValue("CPU2.PLC.Blocks.00 Main.02 HMI.00 Main.DB HMI Main.Production.from.Heat treatment.Solvent.On", true);
                    });
                    taskA.ContinueWith(async x =>
                    {
                        await Task.Delay(1000);
                        ApplicationService.SetVariableValue("CPU2.PLC.Blocks.00 Main.02 HMI.00 Main.DB HMI Main.Production.from.Heat treatment.Solvent.On", false);

                    }, TaskContinuationOptions.OnlyOnRanToCompletion);
                }
                else 
                {
                    
                    Task taskA = Task.Run(() =>
                    {
                        ApplicationService.SetVariableValue("CPU2.PLC.Blocks.00 Main.02 HMI.00 Main.DB HMI Main.Production.from.Heat treatment.Solvent.Off", true);
                    });
                    taskA.ContinueWith(async x =>
                    {
                        await Task.Delay(1000);
                        ApplicationService.SetVariableValue("CPU2.PLC.Blocks.00 Main.02 HMI.00 Main.DB HMI Main.Production.from.Heat treatment.Solvent.Off", false);

                    }, TaskContinuationOptions.OnlyOnRanToCompletion);
                }
                
            }
        }
        private void s1_ValueChanged(object sender, VisiWin.DataAccess.VariableEventArgs e)
        {
           

            if (s1.RawValue == 0)
            {

                ul1.RawLimitMax = 0;
                ul1.RawLimitMin = 0;

                ll1.RawLimitMax = 0;
                ll1.RawLimitMin = 0;

                ul1.IsEnabled = false;
                ll1.IsEnabled = false;
            }
            else
            {
                ul1.IsEnabled = true;
                ll1.IsEnabled = true;
                ul1.RawLimitMax = s1.RawValue + 60;
                ul1.RawLimitMin = s1.RawValue + 5;
                ll1.RawLimitMax = s1.RawValue - 5;
                ll1.RawLimitMin = s1.RawValue - 60;
            }
        }
        private void s2_ValueChanged(object sender, VisiWin.DataAccess.VariableEventArgs e)
        {
            if (s2.RawValue == 0)
            {

                ul2.RawLimitMax = 0;
                ul2.RawLimitMin = 0;

                ll2.RawLimitMax = 0;
                ll2.RawLimitMin = 0;

                ul2.IsEnabled = false;
                ll2.IsEnabled = false;
            }
            else
            {
                ul2.IsEnabled = true;
                ll2.IsEnabled = true;
                ul2.RawLimitMax = s2.RawValue + 60;
                ul2.RawLimitMin = s2.RawValue + 5;
                ll2.RawLimitMax = s2.RawValue - 5;
                ll2.RawLimitMin = s2.RawValue - 60;

            }
        }
        private void s3_ValueChanged(object sender, VisiWin.DataAccess.VariableEventArgs e)
        {
            if (s3.RawValue == 0)
            {

                ul3.RawLimitMax = 0;
                ul3.RawLimitMin = 0;

                ll3.RawLimitMax = 0;
                ll3.RawLimitMin = 0;

                ul3.IsEnabled = false;
                ll3.IsEnabled = false;
            }
            else
            {
                ul3.IsEnabled = true;
                ll3.IsEnabled = true;
                ul3.RawLimitMax = s3.RawValue + 60;
                ul3.RawLimitMin = s3.RawValue + 5;
                ll3.RawLimitMax = s3.RawValue - 5;
                ll3.RawLimitMin = s3.RawValue - 60;

            }
        }
        private void s4_ValueChanged(object sender, VisiWin.DataAccess.VariableEventArgs e)
        {
            if (s4.RawValue == 0)
            {

                ul4.RawLimitMax = 0;
                ul4.RawLimitMin = 0;

                ll4.RawLimitMax = 0;
                ll4.RawLimitMin = 0;

                ul4.IsEnabled = false;
                ll4.IsEnabled = false;
            }
            else
            {
                ul4.IsEnabled = true;
                ll4.IsEnabled = true;
                ul4.RawLimitMax = s4.RawValue + 60;
                ul4.RawLimitMin = s4.RawValue + 5;
                ll4.RawLimitMax = s4.RawValue - 5;
                ll4.RawLimitMin = 0;

            }
        }
    }
}