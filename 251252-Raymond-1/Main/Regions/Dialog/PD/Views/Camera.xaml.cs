using System.Windows;
using HMI.CO.General;
using HMI.MessageBoxRegion.Views;
using VisiWin.ApplicationFramework;
using VisiWin.Logging;
using HMI.Resources;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Linq;
using System;

namespace HMI.DialogRegion.PD.Views
{
    /// <summary>
    /// Interaction logic for UserAdd.xaml
    /// </summary>
    [ExportView("Camera")]
    public partial class Camera
    {
        ILoggingService loggingService = ApplicationService.GetService<ILoggingService>();
        HMI.CO.PD.Camera C;

        public Camera()
        {
            InitializeComponent();
        }

        private void Camera_Loaded(object sender, RoutedEventArgs e)
        {
            new ObjectAnimator().OpenDialog(this, border);
            camera1.IsChecked = true;
        }
        private void Cancel_Click(object sender, RoutedEventArgs e)
        {

            camera1.IsChecked = camera2.IsChecked = false;
            Video.Child = null;

            C.Kill();
            C = null;

            new ObjectAnimator().CloseDialog1(this, border);
        }
        private void Camera1_Click(object sender, RoutedEventArgs e)
        {
            camera2.IsChecked = false;
            camera1.IsEnabled = camera2.IsEnabled = false;

            C = new CO.PD.Camera()
            {
                FileName = "gst-launch-1.0",
                Path = @"C:\gstreamer\1.0\msvc_x86_64\bin\",
                Arguments = "udpsrc port=50010 ! application/x-rtp, payload=96, encoding-name=H264 ! rtph264depay ! h264parse ! d3d11h264dec ! queue ! videorate ! autovideosink",
                MainWindowTitle = "Direct3D11 renderer"
                //FileName = @"ms-teams",
                //MainWindowTitle = "Microsoft Teams"

            };

            Task T = Task.Run(async () =>
            {
                await C.Start();
                Application.Current.Dispatcher.Invoke(delegate
                {
                    try
                    {
                        HwndHostEx host = C.GetHost();
                        if (host != null)
                        {
                            Video.Child = host;
                        }
                    }
                    catch (Exception ex)
                    {
                        new MessageBoxTask(ex, "", MessageBoxIcon.Error);
                    }
                    camera2.IsEnabled = true;
                });
            });

        }
        private void Camera2_Click(object sender, RoutedEventArgs e)
        {
            camera1.IsChecked = false;
            camera1.IsEnabled = camera2.IsEnabled = false;

            C = new CO.PD.Camera()
            {
                FileName = "gst-launch-1.0",
                Path = @"C:\gstreamer\1.0\msvc_x86_64\bin\",
                Arguments = "udpsrc port=50011 ! application/x-rtp, payload=96, encoding-name=H264 ! rtph264depay ! h264parse ! d3d11h264dec ! queue ! videorate ! autovideosink",
                MainWindowTitle = "Direct3D11 renderer"
                //FileName = @"ms-teams",
                //MainWindowTitle = "Microsoft Teams"
            };

            Task T = Task.Run(async () =>
            {
                await C.Start();
                Application.Current.Dispatcher.Invoke(delegate
                {
                    try
                    {
                        HwndHostEx host = C.GetHost();
                        if (host != null)
                        {
                            Video.Child = host;
                        }

                      
                    }
                    catch (Exception ex)
                    {
                        new MessageBoxTask(ex, "", MessageBoxIcon.Error);
                    }
                    camera1.IsEnabled = true;
                });
            });

        }
        private void Clean_Click(object sender, RoutedEventArgs e)
        {
            Cancel_Click(null, null);

            if (MessageBoxView.Show("@Camera.Text4", "@Camera.Text5", MessageBoxButton.YesNo, MessageBoxResult.No, MessageBoxIcon.Question) == MessageBoxResult.Yes)
            {
                ApplicationService.SetVariableValue("CPU1.PLC.Blocks.02 Basket handling.04 BT.00 Main.DB BT PD.Baskets.Functions.Check", 0);
                loggingService.Log("Machine", "Check", "@Logging.Machine.Check.Text1", System.DateTime.Now);

            }


        }
        private void Discharge_Click(object sender, RoutedEventArgs e)
        {
            Cancel_Click(null, null);

            if (MessageBoxView.Show("@Camera.Text4", "@Camera.Text6", MessageBoxButton.YesNo, MessageBoxResult.No, MessageBoxIcon.Question) == MessageBoxResult.Yes)
            {
                ApplicationService.SetVariableValue("CPU1.PLC.Blocks.02 Basket handling.04 BT.00 Main.DB BT PD.Baskets.Functions.Discharge", 1);
                ApplicationService.SetVariableValue("CPU1.PLC.Blocks.02 Basket handling.04 BT.00 Main.DB BT PD.Baskets.Functions.Check", 0);
                loggingService.Log("Machine", "Check", "@Logging.Machine.Check.Text2", System.DateTime.Now);

            }
        }

        private void Switch_Checked(object sender, RoutedEventArgs e)
        {

        }
    }
}