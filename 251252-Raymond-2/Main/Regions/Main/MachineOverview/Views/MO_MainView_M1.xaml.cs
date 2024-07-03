using HMI.CO.General;
using HMI.Resources.UserControls.MO;
using System.ComponentModel;
using System.Threading;
using System.Windows;
using VisiWin.ApplicationFramework;


namespace HMI.MainRegion.MO.Views
{

    [ExportView("MO_MainView_M1")]
    public partial class MO_MainView_M1
    {
        readonly BackgroundWorker AddObjects = new BackgroundWorker();
        readonly BackgroundWorker ClearObjects = new BackgroundWorker();
        public MO_MainView_M1()
        {
            InitializeComponent();
            ClearObjects.DoWork += ClearObjects_DoWork;
            ClearObjects.RunWorkerCompleted += ClearObjects_RunWorkerCompleted;

            AddObjects.WorkerSupportsCancellation = true;
            AddObjects.DoWork += AddObjects_DoWork;
            AddObjects.RunWorkerCompleted += AddObjects_RunWorkerCompleted;
        }

        M1_MV_LD LD;
        M1_MV_BSMP BSMP;
        M1_MV_CD CD;
        M1_MV_ST ST;
        M1_MV_MCPZWZ MCPZWZ;
        M1_MV_TM TM;
        M1_MV_HZ HZ1;
        M1_MV_CZ MVCZ;
        M1_MV_PO MVPO;
        M1_MV_CI CI;
        M1_MV_US MVUS;

        private void LayoutRoot_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            if (!ClearObjects.IsBusy)
                ClearObjects.RunWorkerAsync(argument: true);
        }

        private void ClearObjects_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if ((bool)e.Result)
            {
                if (!AddObjects.IsBusy)
                    AddObjects.RunWorkerAsync();
            }
        }
        private void ClearObjects_DoWork(object sender, DoWorkEventArgs e)
        {

            Dispatcher.InvokeAsync(delegate
            {
                LayoutRoot.Children.Clear();
            });

            e.Result = e.Argument;

            Thread.Sleep(250);

        }
        private void AddObjects_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                //
            }
            else if (e.Cancelled)
            {
                ClearObjects.RunWorkerAsync(argument: true);
            }
            else
            {

            }
        }
        private void AddObjects_DoWork(object sender, DoWorkEventArgs e)
        {
            Thread.Sleep(100);
            Dispatcher.InvokeAsync(delegate
            {
                CI = new M1_MV_CI
                {

                    Margin = new Thickness(612, -20, 0, 315),
                    HorizontalAlignment = HorizontalAlignment.Left,
                    VerticalAlignment = VerticalAlignment.Bottom,
                };
                LayoutRoot.Children.Add(CI);
            });

            if (AddObjects.CancellationPending)
            {
                e.Cancel = true;
                return;
            }

            Thread.Sleep(100);
            Dispatcher.InvokeAsync(delegate
            {
                MVCZ = new M1_MV_CZ()
                {
                    Margin = new Thickness(952, 342, 0, 0),
                    HorizontalAlignment = HorizontalAlignment.Left,
                    VerticalAlignment = VerticalAlignment.Top
                };
                LayoutRoot.Children.Add(MVCZ);
            });
            if (AddObjects.CancellationPending)
            {
                e.Cancel = true;
                return;
            }
            Thread.Sleep(100);
            Dispatcher.InvokeAsync(delegate
            {
                MCPZWZ = new M1_MV_MCPZWZ()
                {
                    Margin = new Thickness(555, 240, 0, 0),
                    HorizontalAlignment = HorizontalAlignment.Left,
                    VerticalAlignment = VerticalAlignment.Top
                };
                LayoutRoot.Children.Add(MCPZWZ);
            });
            if (AddObjects.CancellationPending)
            {
                e.Cancel = true;
                return;
            }
            Thread.Sleep(100);
            Dispatcher.InvokeAsync(delegate
            {
                HZ1 = new M1_MV_HZ()
                {

                    Margin = new Thickness(1509, 266, 0, 0),
                    HorizontalAlignment = HorizontalAlignment.Left,
                    VerticalAlignment = VerticalAlignment.Top
                };
                LayoutRoot.Children.Add(HZ1);
            });
            if (AddObjects.CancellationPending)
            {
                e.Cancel = true;
                return;
            }

            Thread.Sleep(100);
            Dispatcher.InvokeAsync(delegate
            {
                MVUS = new M1_MV_US()
                {
                    Margin = new Thickness(682, 418, 0, 0),
                    HorizontalAlignment = HorizontalAlignment.Left,
                    VerticalAlignment = VerticalAlignment.Top
                };
                LayoutRoot.Children.Add(MVUS);
            });
            if (AddObjects.CancellationPending)
            {
                e.Cancel = true;
                return;
            }
            Thread.Sleep(100);
            Dispatcher.InvokeAsync(delegate
            {
                TM = new M1_MV_TM()
                {
                    Margin = new Thickness(778, 461, 0, 0),
                    HorizontalAlignment = HorizontalAlignment.Left,
                    VerticalAlignment = VerticalAlignment.Top
                };
                LayoutRoot.Children.Add(TM);
            });
            if (AddObjects.CancellationPending)
            {
                e.Cancel = true;
                return;
            }
            Thread.Sleep(100);
            Dispatcher.InvokeAsync(delegate
            {
                BSMP = new M1_MV_BSMP
                {
                    Margin = new Thickness(171, 140, 0, 0),
                    HorizontalAlignment = HorizontalAlignment.Left,
                    VerticalAlignment = VerticalAlignment.Top
                };
                LayoutRoot.Children.Add(BSMP);
            });
            if (AddObjects.CancellationPending)
            {
                e.Cancel = true;
                return;
            }
            Thread.Sleep(100);
            Dispatcher.InvokeAsync(delegate
            {
                MVPO = new M1_MV_PO()
                {
                    Margin = new Thickness(555, 418, 0, 0),
                    HorizontalAlignment = HorizontalAlignment.Left,
                    VerticalAlignment = VerticalAlignment.Top
                };
                LayoutRoot.Children.Add(MVPO);
            });
            if (AddObjects.CancellationPending)
            {
                e.Cancel = true;
                return;
            }
            Thread.Sleep(100);
            Dispatcher.InvokeAsync(delegate
            {
                ST = new M1_MV_ST
                {
                    Margin = new Thickness(395, 442, 0, 0),
                    HorizontalAlignment = HorizontalAlignment.Left,
                    VerticalAlignment = VerticalAlignment.Top
                };
                LayoutRoot.Children.Add(ST);
            });
            if (AddObjects.CancellationPending)
            {
                e.Cancel = true;
                return;
            }
            Thread.Sleep(100);
            Dispatcher.InvokeAsync(delegate
            {
                CD = new M1_MV_CD
                {
                    Margin = new Thickness(86, 257, 0, 0),
                    HorizontalAlignment = HorizontalAlignment.Left,
                    VerticalAlignment = VerticalAlignment.Top,
                };
                LayoutRoot.Children.Add(CD);
            });
            if (AddObjects.CancellationPending)
            {
                e.Cancel = true;
                return;
            }
            Thread.Sleep(100);
            Dispatcher.InvokeAsync(delegate
            {
                Dispatcher.InvokeAsync(delegate
                {
                    LD = new M1_MV_LD
                    {
                        Margin = new Thickness(-5, 395, 0, 0),
                        HorizontalAlignment = HorizontalAlignment.Left,
                        VerticalAlignment = VerticalAlignment.Top,
                    };
                    LayoutRoot.Children.Add(LD);
                });
            });

        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            new SP()
            {
                CPU = "CPU1",
                Station = 8,
                Header = "@Status.Text32",
                Type = "Basket"
            }.Open();
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            new SP()
            {
                CPU = "CPU2",
                Station = 11,
                Header = "@Status.Text41",
                Type = "Belt"
            }.Open();
        }
    }
}
