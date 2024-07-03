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

namespace HMI.MainRegion.MO
{

    [ExportView("M1_CZ")]
    public partial class M1_CZ
    {
        readonly BackgroundWorker AddObjects = new BackgroundWorker();
        readonly BackgroundWorker ClearObjects = new BackgroundWorker();
        readonly IVariableService VS = ApplicationService.GetService<IVariableService>();
        public M1_CZ()
        {
            InitializeComponent();
            Clocked = "CPU2.PLC.Blocks.04 Tray handling.07 CZ.00 Main.DB CZ HMI.Parameter.Stack[0].Id";

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
            ApplicationService.SetView("MainRegion", "Trend",
            new TrendData()
            {
                ArchiveName = "M1CZ1",
                TrendName_1 = "AV",
                CurveTag_1 = "@TrendSystem.Text18",
                TrendName_2 = "SV",
                CurveTag_2 = "@TrendSystem.Text19",
                Header = "@TrendSystem.Text7",
                Min = 0,
                Max = 75,
                BackViewName = "M1_CZ"
            });
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            ApplicationService.SetView("MainRegion", "Trend",
            new TrendData()
            {
                ArchiveName = "M1CZ2",
                TrendName_1 = "AV",
                CurveTag_1 = "@TrendSystem.Text18",
                TrendName_2 = "SV",
                CurveTag_2 = "@TrendSystem.Text19",
                Header = "@TrendSystem.Text20",
                Min = 0,
                Max = 75,
                BackViewName = "M1_CZ"
            });
        }
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            ApplicationService.SetView("MainRegion", "Trend",
            new TrendData()
            {
                ArchiveName = "M1CZ3",
                TrendName_1 = "AV",
                CurveTag_1 = "@TrendSystem.Text18",
                TrendName_2 = "SV",
                CurveTag_2 = "@TrendSystem.Text19",
                Header = "@TrendSystem.Text21",
                Min = 0,
                Max = 75,
                BackViewName = "M1_CZ"
            });
        }
        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            ApplicationService.SetView("MainRegion", "Trend",
            new TrendData()
            {
                ArchiveName = "M1CZ4",
                TrendName_1 = "AV",
                CurveTag_1 = "@TrendSystem.Text18",
                TrendName_2 = "SV",
                CurveTag_2 = "@TrendSystem.Text19",
                Header = "@TrendSystem.Text22",
                Min = 0,
                Max = 75,
                BackViewName = "M1_CZ"
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
                    byte CZ = (byte)ApplicationService.GetVariableValue("CPU2.PLC.Blocks.04 Tray handling.07 CZ.00 Main.DB CZ HMI.Parameter.Stack[0].Id");
                    CZ = (byte)(CZ == 1 ? 15 : CZ == 2 ? 16 : CZ == 3 ? 17 : 18);
                    byte Place = (byte)ApplicationService.GetVariableValue("CPU2.PLC.Blocks.04 Tray handling.07 CZ.00 Main.DB CZ HMI.Parameter.Stack[0].Place");
                    foreach (UIElement uie in Trays.Children)
                    {
                        ((CZTray)uie).Head = false;
                        if (((CZTray)uie).Station == CZ && ((CZTray)uie).Place == Place)
                        {
                            ((CZTray)uie).Head = true;
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
            byte CZ = (byte)ApplicationService.GetVariableValue("CPU2.PLC.Blocks.04 Tray handling.07 CZ.00 Main.DB CZ HMI.Parameter.Stack[0].Id");
            byte Place = (byte)ApplicationService.GetVariableValue("CPU2.PLC.Blocks.04 Tray handling.07 CZ.00 Main.DB CZ HMI.Parameter.Stack[0].Place");

            for (int i = 0; i <= 7; i++)
            {
                if (AddObjects.CancellationPending)
                {
                    e.Cancel = true;
                    return;
                }

                CZTray T = null;
                if (i >= 0 && i <= 1)
                {
                    bool Head = CZ == 1 && (i == Place);
                    Dispatcher.InvokeAsync(delegate
                    {
                        T = GetCZTray(i, Head, 1);

                        switch (i)
                        {
                            case 0: T.Margin = new Thickness(115, 500, 0, 0); break;
                            case 1: T.Margin = new Thickness(278, 500, 0, 0); break;
                        }

                        T.HorizontalAlignment = HorizontalAlignment.Left;
                        T.VerticalAlignment = VerticalAlignment.Top;

                        Trays.Children.Add(T);
                    
                    });
                }
                if (i - 2 >= 0 && i - 2 <= 1)
                {
                    bool Head = CZ == 2 && (i - 2 == Place);
                    Dispatcher.InvokeAsync(delegate
                    {
                        T = GetCZTray(i - 2, Head, 2);

                        switch (i - 2)
                        {
                            case 0: T.Margin = new Thickness(490, 500, 0, 0); break;
                            case 1: T.Margin = new Thickness(652, 500, 0, 0); break;
                        }

                        T.HorizontalAlignment = HorizontalAlignment.Left;
                        T.VerticalAlignment = VerticalAlignment.Top;

                        Trays.Children.Add(T);
                    });
                }
                if (i - 4 >= 0 && i - 4 <= 1)
                {
                    bool Head = CZ == 3 && (i - 4 == Place);
                    Dispatcher.InvokeAsync(delegate
                    {
                        T = GetCZTray(i - 4, Head, 3);

                        switch (i - 4)
                        {
                            case 0: T.Margin = new Thickness(865, 500, 0, 0); break;
                            case 1: T.Margin = new Thickness(1027, 500, 0, 0); break;
                        }

                        T.HorizontalAlignment = HorizontalAlignment.Left;
                        T.VerticalAlignment = VerticalAlignment.Top;

                        Trays.Children.Add(T);
                    });
                }
                if (i - 6 >= 0 && i - 6 <= 1)
                {
                    bool Head = CZ == 4 && (i - 6 == Place);
                    Dispatcher.InvokeAsync(delegate
                    {
                        T = GetCZTray(i - 6, Head, 4);

                        switch (i - 6)
                        {
                            case 0: T.Margin = new Thickness(1239, 500, 0, 0); break;
                            case 1: T.Margin = new Thickness(1401, 500, 0, 0); break;
                        }

                        T.HorizontalAlignment = HorizontalAlignment.Left;
                        T.VerticalAlignment = VerticalAlignment.Top;

                        Trays.Children.Add(T);
                    });
                }

                Thread.Sleep(200);
            }
        }
        private void LanguageService_LanguageChanged(object sender, LanguageChangedEventArgs e)
        {

            switch (languageService.CurrentLanguage.LCID)
            {
                case 1033:
                    //CZ1.RawLimitMin = CZ2.RawLimitMin = CZ3.RawLimitMin = CZ4.RawLimitMin = 32;
                    //CZ1.RawLimitMax = CZ2.RawLimitMax = CZ3.RawLimitMax = CZ4.RawLimitMax = 122;
                    CZ1L1.StartValue = CZ2L1.StartValue = CZ3L1.StartValue = CZ4L1.StartValue = 32;
                    CZ1L1.EndValue = CZ2L1.EndValue = CZ3L1.EndValue = CZ4L1.EndValue = 86;
                    CZ1L2.StartValue = CZ2L2.StartValue = CZ3L2.StartValue = CZ4L2.StartValue = 86;
                    CZ1L2.EndValue = CZ2L2.EndValue = CZ3L2.EndValue = CZ4L2.EndValue = 113;
                    CZ1L3.StartValue = CZ2L3.StartValue = CZ1L3.StartValue = CZ4L3.StartValue = 113;
                    CZ1L3.EndValue = CZ2L3.EndValue = CZ3L3.EndValue = CZ4L3.EndValue = 167;
                    break;

                default:
                    //CZ1.RawLimitMin = CZ2.RawLimitMin = CZ3.RawLimitMin = CZ4.RawLimitMin = 0;
                    //CZ1.RawLimitMax = CZ2.RawLimitMax = CZ3.RawLimitMax = CZ4.RawLimitMax = 50;
                    CZ1L1.StartValue = CZ2L1.StartValue = CZ3L1.StartValue = CZ4L1.StartValue = 0;
                    CZ1L1.EndValue = CZ2L1.EndValue = CZ3L1.EndValue = CZ4L1.EndValue = 30;
                    CZ1L2.StartValue = CZ2L2.StartValue = CZ3L2.StartValue = CZ4L2.StartValue = 30;
                    CZ1L2.EndValue = CZ2L2.EndValue = CZ3L2.EndValue = CZ4L2.EndValue = 45;
                    CZ1L3.StartValue = CZ2L3.StartValue = CZ1L3.StartValue = CZ4L3.StartValue = 45;
                    CZ1L3.EndValue = CZ2L3.EndValue = CZ3L3.EndValue = CZ4L3.EndValue = 75;

                    break;
            }
        }
        private CZTray GetCZTray(int i, bool head, byte cz)
        {
            return new CZTray()
            {
                IsTray = "CPU2.PLC.Blocks.04 Tray handling.07 CZ.0" + cz + ".00 Main.DB CZ " + cz + " PD.Place[" + i + "].Tray.Available",
                IsMaterial = "CPU2.PLC.Blocks.04 Tray handling.07 CZ.0" + cz + ".00 Main.DB CZ " + cz + " PD.Place[" + i + "].Charge.Available",
                SetLayer = "CPU2.PLC.Blocks.04 Tray handling.07 CZ.0" + cz + ".00 Main.DB CZ " + cz + " PD.Place[" + i + "].Charge.Layer[1].Set",
                ActualLayer = "CPU2.PLC.Blocks.04 Tray handling.07 CZ.0" + cz + ".00 Main.DB CZ " + cz + " PD.Place[" + i + "].Charge.Layer[1].Actual",
                IsDischarge = "CPU2.PLC.Blocks.04 Tray handling.07 CZ.0" + cz + ".00 Main.DB CZ " + cz + " PD.Place[" + i + "].Tray.Functions.Discharge",
                IsWatch = "CPU2.PLC.Blocks.04 Tray handling.07 CZ.0" + cz + ".00 Main.DB CZ " + cz + " PD.Place[" + i + "].Tray.Functions.Watch",
                Charge = "CPU2.PLC.Blocks.04 Tray handling.07 CZ.0" + cz + ".00 Main.DB CZ " + cz + " PD.Place[" + i + "].Header.Charge",
                Station = cz == 1 ? 15 : cz == 2 ? 16 : cz == 3 ? 17 : 18,
                Place = i,
                Head = head,
                Type = "Tray",
                CPU = "CPU2",
                Header = cz == 1 ? "@Status.Text" + (63 + i).ToString() : cz == 2 ? "@Status.Text" + (65 + i).ToString() : cz == 3 ? "@Status.Text" + (67 + i).ToString() :  "@Status.Text" + (69 + i).ToString()
            };
        }


    }
}




