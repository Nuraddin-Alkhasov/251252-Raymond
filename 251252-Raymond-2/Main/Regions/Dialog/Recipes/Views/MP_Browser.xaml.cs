using System;
using System.Windows;
using System.Windows.Media.Imaging;
using VisiWin.ApplicationFramework;
using WpfAnimatedGif;

namespace HMI.DialogRegion.Recipes.Views
{

    [ExportView("MP_Browser")]
    public partial class MP_Browser
    {
        readonly IRegionService iRS = ApplicationService.GetService<IRegionService>();

        public MP_Browser()
        {
            InitializeComponent();

            DataContext = new Adapters.MP_Browser();
            BitmapImage image = new BitmapImage();
            image.BeginInit();
            image.UriSource = new Uri((new Resources.LocalResources()).Paths.LoadingGif);
            image.EndInit();
            ImageBehavior.SetAnimatedSource(gif, image);
        }

    }
}