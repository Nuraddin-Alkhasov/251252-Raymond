using System;
using System.Windows.Media.Imaging;
using VisiWin.ApplicationFramework;
using WpfAnimatedGif;

namespace HMI.DialogRegion.Recipes.Views
{

    [ExportView("Paint_Browser")]
    public partial class Paint_Browser
    {
        public Paint_Browser()
        {
            InitializeComponent();

            DataContext = new Adapters.Paint_Browser();

            BitmapImage image = new BitmapImage();
            image.BeginInit();
            image.UriSource = new Uri(new Resources.LocalResources().Paths.LoadingGif);
            image.EndInit();
            ImageBehavior.SetAnimatedSource(gif, image);
        }



    }
}