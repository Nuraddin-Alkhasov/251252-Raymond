using HMI.CO.General;
using HMI.CO.Trend;
using HMI.Resources.UserControls.MO;
using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Animation;
using VisiWin.ApplicationFramework;
using VisiWin.DataAccess;
using VisiWin.Language;

namespace HMI.MainRegion.MO.Views
{

    [ExportView("M1_HZ")]
    public partial class M1_HZ
    {

        readonly BackgroundWorker AddObjects = new BackgroundWorker();
        readonly BackgroundWorker ClearObjects = new BackgroundWorker();
        readonly IVariableService VS = ApplicationService.GetService<IVariableService>();

        public M1_HZ()
        {
            InitializeComponent();
            Clocked = "CPU2.PLC.Blocks.04 Tray handling.06 HZ.00 Main.DB HZ HMI.Parameter.Stack[0].Place";

            ClearObjects.DoWork += ClearObjects_DoWork;
            ClearObjects.RunWorkerCompleted += ClearObjects_RunWorkerCompleted;
            
            AddObjects.WorkerSupportsCancellation = true;
            AddObjects.DoWork += AddObjects_DoWork;
            AddObjects.RunWorkerCompleted += AddObjects_RunWorkerCompleted;

            languageService.LanguageChanged += LanguageService_LanguageChanged;
            LanguageService_LanguageChanged(null, null);
        }

        private readonly ILanguageService languageService = ApplicationService.GetService<ILanguageService>();



        private IVariable IVClocked;

        public string Clocked
        {
            get { return ""; }
            set
            {
                if (VS.IsExistingVariable(value))
                {
                    IVClocked = VS.GetVariable(value);
                    IVClocked.Change += IVClocked_ValueChanged;
                }
            }
        }

        private void Trays_Loaded(object sender, RoutedEventArgs e)
        {
            if (AddObjects.IsBusy)
            {
                AddObjects.CancelAsync();
            }
            else
            {
                if (!ClearObjects.IsBusy)
                    ClearObjects.RunWorkerAsync();
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            ApplicationService.SetView("MainRegion", "Trend",
            new TrendData()
            {
                ArchiveName = "M1HZ1",
                TrendName_1 = "AV",
                CurveTag_1 = "@TrendSystem.Text1",
                TrendName_2 = "SV",
                CurveTag_2 = "@TrendSystem.Text2",
                Header = "@TrendSystem.Text6",
                Min = 0,
                Max = 400,
                BackViewName = "M1_HZ"
            });
        }







        private void IVClocked_ValueChanged(object sender, VariableEventArgs e)
        {
            if (e.Quality.Data == DataQuality.Good)
            {
                if (this.IsVisible)
                {
                    byte HZ = (byte)(((byte)ApplicationService.GetVariableValue("CPU2.PLC.Blocks.04 Tray handling.06 HZ.00 Main.DB HZ HMI.Parameter.Stack[0].Id")) == 1 ? 13 : 14);
                    byte Place = (byte)ApplicationService.GetVariableValue("CPU2.PLC.Blocks.04 Tray handling.06 HZ.00 Main.DB HZ HMI.Parameter.Stack[0].Place");
                    foreach (UIElement uie in Trays.Children) 
                    {
                        if (uie.ToString() == "HZTray_L")
                        {
                            ((HZTray_L)uie).Head = false;
                            if (((HZTray_L)uie).Station == HZ && ((HZTray_L)uie).Place == Place)
                            {
                                ((HZTray_L)uie).Head = true;
                            }
                        }
                        else 
                        {
                            ((HZTray_R)uie).Head = false;
                            if (((HZTray_R)uie).Station == HZ && ((HZTray_R)uie).Place == Place)
                            {
                                ((HZTray_R)uie).Head = true;
                            }
                        }
                    }
                }
            }
        }

        private void ClearObjects_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (!AddObjects.IsBusy)
                AddObjects.RunWorkerAsync();
        }

        private void ClearObjects_DoWork(object sender, DoWorkEventArgs e)
        {

            Dispatcher.InvokeAsync(delegate
            {
                Trays.Children.Clear();
            });

            Thread.Sleep(200);

        }

        private void AddObjects_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                //
            }
            else if (e.Cancelled)
            {
                ClearObjects.RunWorkerAsync();
            }
            else
            {

            }
        }

        private void AddObjects_DoWork(object sender, DoWorkEventArgs e)
        {
            byte HZ = (byte)ApplicationService.GetVariableValue("CPU2.PLC.Blocks.04 Tray handling.06 HZ.00 Main.DB HZ HMI.Parameter.Stack[0].Id");
            byte Place = (byte)ApplicationService.GetVariableValue("CPU2.PLC.Blocks.04 Tray handling.06 HZ.00 Main.DB HZ HMI.Parameter.Stack[0].Place");
            

            for (int i = 0; i <= 9; i++)
            {
                if (AddObjects.CancellationPending)
                {
                    e.Cancel = true;
                    return;
                }

                HZTray_L T1 = null;
                HZTray_R T2 = null;
                if (i <= 9)
                {
                    bool Head = HZ == 1 && (i == Place);
                    if (i == 0 || i == 3 || i == 4 || i == 7 || i == 8)
                    {
                        Dispatcher.InvokeAsync(delegate
                        {
                            T1 = GetHZTray_L(i, Head, 1);
                            switch (i)
                            {
                                case 0: T1.Margin = new Thickness(733, 0, 0, 63); break;
                                case 3: T1.Margin = new Thickness(733, 0, 0, 144); break;
                                case 4: T1.Margin = new Thickness(733, 0, 0, 225); break;
                                case 7: T1.Margin = new Thickness(733, 0, 0, 306); break;
                                case 8: T1.Margin = new Thickness(733, 0, 0, 387); break;
                            }
                            T1.HorizontalAlignment = HorizontalAlignment.Left;
                            T1.VerticalAlignment = VerticalAlignment.Bottom;
                            Trays.Children.Add(T1);
                        });
                    }
                    else
                    {
                        Dispatcher.InvokeAsync(delegate
                        {
                            T2 = GetHZTray_R(i, Head, 1);
                            switch (i)
                            {
                                case 1: T2.Margin = new Thickness(897, 0, 0, 63); break;
                                case 2: T2.Margin = new Thickness(897, 0, 0, 144); break;
                                case 5: T2.Margin = new Thickness(897, 0, 0, 225); break;
                                case 6: T2.Margin = new Thickness(897, 0, 0, 306); break;
                                case 9: T2.Margin = new Thickness(897, 0, 0, 387); break;
                            }
                            T2.HorizontalAlignment = HorizontalAlignment.Left;
                            T2.VerticalAlignment = VerticalAlignment.Bottom;
                            Trays.Children.Add(T2);
                        });
                    }

                   
                }
                else
                {
                    bool Head = HZ == 2 && (i -10 == Place);

                    if (i - 10 == 0 || i - 10 == 3 || i - 10 == 4 || i - 10 == 7 || i - 10 == 8)
                    {
                        Dispatcher.InvokeAsync(delegate
                        {
                            T1 = GetHZTray_L(i - 10, Head, 2);


                            switch (i - 10)
                            {
                                case 0: T1.Margin = new Thickness(1097, 0, 0, 63); break;
                                case 3: T1.Margin = new Thickness(1097, 0, 0, 144); break;
                                case 4: T1.Margin = new Thickness(1097, 0, 0, 225); break;
                                case 7: T1.Margin = new Thickness(1097, 0, 0, 306); break;
                                case 8: T1.Margin = new Thickness(1097, 0, 0, 387); break;
                            }

                            T1.HorizontalAlignment = HorizontalAlignment.Left;
                            T1.VerticalAlignment = VerticalAlignment.Bottom;

                            Trays.Children.Add(T1);
                        });
                    }
                    else 
                    {
                        Dispatcher.InvokeAsync(delegate
                        {
                            T2 = GetHZTray_R(i-10, Head, 2);


                            switch (i - 10)
                            {
                                case 1: T2.Margin = new Thickness(1261, 0, 0, 63); break;
                                case 2: T2.Margin = new Thickness(1261, 0, 0, 144); break;
                                case 5: T2.Margin = new Thickness(1261, 0, 0, 225); break;
                                case 6: T2.Margin = new Thickness(1261, 0, 0, 306); break;
                                case 9: T2.Margin = new Thickness(1261, 0, 0, 387); break;
                            }

                            T2.HorizontalAlignment = HorizontalAlignment.Left;
                            T2.VerticalAlignment = VerticalAlignment.Bottom;

                            Trays.Children.Add(T2);
                        });
                    }
                }
                Thread.Sleep(250);
            }
        }

        private void LanguageService_LanguageChanged(object sender, LanguageChangedEventArgs e)
        {

            switch (languageService.CurrentLanguage.LCID)
            {
                case 1033:
                    //HZ1.RawLimitMin = HZ2.RawLimitMin = 32;
                    //HZ1.RawLimitMax = HZ2.RawLimitMax = 662;
                    HZ1L1.StartValue = 32;
                    HZ1L1.EndValue = 662;
                    HZ1L2.StartValue = 662;
                    HZ1L2.EndValue = 707;
                    HZ1L3.StartValue = 707;
                    HZ1L3.EndValue = 752;
                    break;


                default:
                    //HZ1.RawLimitMin = HZ2.RawLimitMin = 0;
                    //HZ1.RawLimitMax = HZ2.RawLimitMax = 350;
                    HZ1L1.StartValue = 0;
                    HZ1L1.EndValue = 350;
                    HZ1L2.StartValue = 350;
                    HZ1L2.EndValue = 375;
                    HZ1L3.StartValue = 375;
                    HZ1L3.EndValue = 400;
                    break;
            }
        }
        private HZTray_L GetHZTray_L(int i, bool head, byte hz)
        {
            return new HZTray_L()
            {
                IsTray = "CPU2.PLC.Blocks.04 Tray handling.06 HZ.0" + hz + ".00 Main.DB HZ " + hz + " PD.Place[" + i + "].Tray.Available", 
                IsMaterial = "CPU2.PLC.Blocks.04 Tray handling.06 HZ.0" + hz + ".00 Main.DB HZ " + hz + " PD.Place[" + i + "].Charge.Available",
                SetLayer = "CPU2.PLC.Blocks.04 Tray handling.06 HZ.0" + hz + ".00 Main.DB HZ " + hz + " PD.Place[" + i + "].Charge.Layer[0].Set",
                ActualLayer = "CPU2.PLC.Blocks.04 Tray handling.06 HZ.0" + hz + ".00 Main.DB HZ " + hz + " PD.Place[" + i + "].Charge.Layer[0].Actual",
                IsDischarge = "CPU2.PLC.Blocks.04 Tray handling.06 HZ.0" + hz + ".00 Main.DB HZ " + hz + " PD.Place[" + i + "].Tray.Functions.Discharge",
                IsWatch = "CPU2.PLC.Blocks.04 Tray handling.06 HZ.0" + hz + ".00 Main.DB HZ " + hz + " PD.Place[" + i + "].Tray.Functions.Watch",
                Charge = "CPU2.PLC.Blocks.04 Tray handling.06 HZ.0" + hz + ".00 Main.DB HZ " + hz + " PD.Place[" + i + "].Header.Charge",
                Station = hz == 1 ? 13 : 14,
                Place = i,
                Head = head,
                Type = "Tray",
                CPU= "CPU2",
                Header = hz == 1 ? "@Status.Text" + (53 + i).ToString() : "@Status.Text" + (80 + i).ToString() 

            };
        }
        private HZTray_R GetHZTray_R(int i, bool head, byte hz)
        {
            return new HZTray_R()
            {
                IsTray = "CPU2.PLC.Blocks.04 Tray handling.06 HZ.0" + hz + ".00 Main.DB HZ " + hz + " PD.Place[" + i + "].Tray.Available",
                IsMaterial = "CPU2.PLC.Blocks.04 Tray handling.06 HZ.0" + hz + ".00 Main.DB HZ " + hz + " PD.Place[" + i + "].Charge.Available",
                SetLayer = "CPU2.PLC.Blocks.04 Tray handling.06 HZ.0" + hz + ".00 Main.DB HZ " + hz + " PD.Place[" + i + "].Charge.Layer[0].Set",
                ActualLayer = "CPU2.PLC.Blocks.04 Tray handling.06 HZ.0" + hz + ".00 Main.DB HZ " + hz + " PD.Place[" + i + "].Charge.Layer[0].Actual",
                IsDischarge = "CPU2.PLC.Blocks.04 Tray handling.06 HZ.0" + hz + ".00 Main.DB HZ " + hz + " PD.Place[" + i + "].Tray.Functions.Discharge",
                IsWatch = "CPU2.PLC.Blocks.04 Tray handling.06 HZ.0" + hz + ".00 Main.DB HZ " + hz + " PD.Place[" + i + "].Tray.Functions.Watch",
                Charge = "CPU2.PLC.Blocks.04 Tray handling.06 HZ.0" + hz + ".00 Main.DB HZ " + hz + " PD.Place[" + i + "].Header.Charge",
                Station = hz == 1 ? 13 : 14,
                Place = i,
                Head = head,
                Type = "Tray",
                CPU = "CPU2",
                Header = hz == 1 ? "@Status.Text" + (53 + i).ToString() : "@Status.Text" + (80 + i).ToString()

            };
        }
    }
}



