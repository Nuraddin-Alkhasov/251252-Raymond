using HMI.CO.General;
using HMI.CO.Trend;
using HMI.MessageBoxRegion.Views;
using HMI.Resources;
using HMI.Resources.UserControls.MO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Animation;
using VisiWin.ApplicationFramework;
using VisiWin.DataAccess;
using VisiWin.Language;

namespace HMI.MainRegion.MO
{

    [ExportView("M1_PZWZ")]
    public partial class M1_PZWZ
    {
        readonly BackgroundWorker AddObjects = new BackgroundWorker();
        readonly BackgroundWorker ClearObjects = new BackgroundWorker();
        readonly IVariableService VS = ApplicationService.GetService<IVariableService>();
        public M1_PZWZ()
        {
            InitializeComponent();

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
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            new SP
            {
                Station = 8,
                Header = "@Status.Text32",
                Type = "Basket",
                CPU= "CPU1"
            }.Open();
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            new SP
            {
                Station = 11,
                Header = "@Status.Text41",
                Type = "Belt",
                CPU= "CPU2"
            }.Open();
        }
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            ApplicationService.SetView("MainRegion", "Trend",
            new TrendData()
            {
                ArchiveName = "M1PZ",
                TrendName_1 = "AV",
                CurveTag_1 = "@TrendSystem.Text1",
                TrendName_2 = "SV",
                CurveTag_2 = "@TrendSystem.Text2",
                Header = "@TrendSystem.Text4",
                Min = 0,
                Max = 120,
                BackViewName = "M1_PZWZ"
            });
        }
        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            ApplicationService.SetView("MainRegion", "Trend",
            new TrendData()
            {
                ArchiveName = "M1WZ",
                TrendName_1 = "AV",
                CurveTag_1 = "@TrendSystem.Text1",
                TrendName_2 = "SV",
                CurveTag_2 = "@TrendSystem.Text2",
                Header = "@TrendSystem.Text5",
                Min = 0,
                Max = 400,
                BackViewName = "M1_PZWZ"
            });
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

        private void IVClocked_ValueChanged(object sender, VariableEventArgs e)
        {
            if (e.Quality.Data == DataQuality.Good)
            {
                if (this.IsVisible)
                {
                    if ((bool)e.Value && Trays.IsLoaded)
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
                }
            }

        }
        private void ClearObjects_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if(!AddObjects.IsBusy)
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
            for (int i = 0; i <= 10; i++)
            {
                if (AddObjects.CancellationPending)
                {
                    e.Cancel = true;
                    return;
                }
                PZWZTray T = null;
                Dispatcher.InvokeAsync(delegate
                {
                    T = GetPZWZTray(i, i == 0);
                    switch (i)
                    {
                        case 0: T.Margin = new Thickness(1590, 455, 0, 0); break;
                        case 1: T.Margin = new Thickness(1497, 455, 0, 0); break;
                        case 2: T.Margin = new Thickness(1404, 455, 0, 0); break;
                        case 3: T.Margin = new Thickness(1311, 455, 0, 0); break;
                        case 4: T.Margin = new Thickness(1218, 455, 0, 0); break;
                        case 5: T.Margin = new Thickness(1125, 455, 0, 0); break;
                        case 6: T.Margin = new Thickness(1032, 455, 0, 0); break;
                        case 7: T.Margin = new Thickness(939, 455, 0, 0); break;
                        case 8: T.Margin = new Thickness(846, 455, 0, 0); break;
                        case 9: T.Margin = new Thickness(753, 455, 0, 0); break;
                        case 10: T.Margin = new Thickness(660, 455, 0, 0); break;
                    }

                    T.HorizontalAlignment = HorizontalAlignment.Left;
                    T.VerticalAlignment = VerticalAlignment.Top;

                    Trays.Children.Add(T);
                });
                Thread.Sleep(200);
            }

        }
       
        private void LanguageService_LanguageChanged(object sender, LanguageChangedEventArgs e)
        {

            switch (languageService.CurrentLanguage.LCID)
            {
                case 1033:
                    //PZ.RawLimitMin = 32;
                    //PZ.RawLimitMax = 266;
                    PZL1.StartValue = 32;
                    PZL1.EndValue = 194;
                    PZL2.StartValue = 194;
                    PZL2.EndValue = 221;
                    PZL3.StartValue = 221;
                    PZL3.EndValue = 248;

                    //WZ.RawLimitMin = 32;
                    //WZ.RawLimitMax = 662;
                    WZL1.StartValue = 32;
                    WZL1.EndValue = 662;
                    WZL2.StartValue = 662;
                    WZL2.EndValue = 707;
                    WZL3.StartValue = 707;
                    WZL3.EndValue = 752;
                    break;


                default:
                    //PZ.RawLimitMin = 0;
                    //PZ.RawLimitMax = 130;
                    PZL1.StartValue = 0;
                    PZL1.EndValue = 90;
                    PZL2.StartValue = 90;
                    PZL2.EndValue = 105;
                    PZL3.StartValue = 105;
                    PZL3.EndValue = 120;

                    //WZ.RawLimitMin = 0;
                    //WZ.RawLimitMax = 350;
                    WZL1.StartValue = 0;
                    WZL1.EndValue = 350;
                    WZL2.StartValue = 350;
                    WZL2.EndValue = 375;
                    WZL3.StartValue = 375;
                    WZL3.EndValue = 400;
                    break;
            }
        }

        private PZWZTray GetPZWZTray(int i, bool head)
        {
            return new PZWZTray()
            {
                IsTray = "CPU2.PLC.Blocks.04 Tray handling.03 TO.00 Main.DB TO PD.Place[" + i + "].Tray.Available", 
                IsMaterial = "CPU2.PLC.Blocks.04 Tray handling.03 TO.00 Main.DB TO PD.Place[" + i + "].Charge.Available",
                SetLayer = "CPU2.PLC.Blocks.04 Tray handling.03 TO.00 Main.DB TO PD.Place[" + i + "].Charge.Layer[1].Set",
                ActualLayer = "CPU2.PLC.Blocks.04 Tray handling.03 TO.00 Main.DB TO PD.Place[" + i + "].Charge.Layer[1].Actual",
                IsDischarge = "CPU2.PLC.Blocks.04 Tray handling.03 TO.00 Main.DB TO PD.Place[" + i + "].Tray.Functions.Discharge",
                IsWatch = "CPU2.PLC.Blocks.04 Tray handling.03 TO.00 Main.DB TO PD.Place[" + i + "].Tray.Functions.Watch",
                Charge = "CPU2.PLC.Blocks.04 Tray handling.03 TO.00 Main.DB TO PD.Place[" + i + "].Header.Charge",
                Station = 12,
                Place = i,
                Head = head,
                Type = "Tray",
                CPU = "CPU2",
                Header = "@Status.Text" + (42+i).ToString()
            };

        }
    }
}




