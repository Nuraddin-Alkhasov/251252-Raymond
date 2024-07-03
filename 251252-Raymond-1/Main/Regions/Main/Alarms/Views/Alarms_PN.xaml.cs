using HMI.CO.General;
using System;
using System.Windows.Media.Imaging;
using VisiWin.ApplicationFramework;
using WpfAnimatedGif;

namespace HMI.MainRegion.Alarms.Views
{
    /// <summary>
    /// Interaction logic for View2.xaml
    /// </summary>
    [ExportView("Alarms_PN")]
    public partial class Alarms_PN
    {
        public Alarms_PN()
        {
            InitializeComponent();
            BitmapImage image = new BitmapImage();
            image.BeginInit();
            image.UriSource = new Uri(new Resources.LocalResources().Paths.LoadingGif);
            image.EndInit();
            ImageBehavior.SetAnimatedSource(gif, image);
        }
        private readonly IRegionService iRS = ApplicationService.GetService<IRegionService>();
        private void Pn_SelectedPanoramaRegionChanged(object sender, VisiWin.Controls.SelectedPanoramaRegionChangedEventArgs e)
        {
            if (pn_diagnose.SelectedPanoramaRegionIndex == 0)
            {
                header.LocalizableText = "@Diagnose.Text1";
            }
            else
            {
                header.LocalizableText = "@Diagnose.Text2";

                MainRegion.Alarms.Views.Alarms_Archive v = (MainRegion.Alarms.Views.Alarms_Archive)iRS.GetView("Alarms_Archive");
                MainRegion.Alarms.Adapters.Alarms_Archive a = (MainRegion.Alarms.Adapters.Alarms_Archive)v.DataContext;
                a.LoadData();

            }

        }

        private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {

        }

        private void PN_diagnose_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            if (pn_diagnose.SelectedPanoramaRegionIndex != 0)
                pn_diagnose.ScrollPrevious();
        }
    }
}