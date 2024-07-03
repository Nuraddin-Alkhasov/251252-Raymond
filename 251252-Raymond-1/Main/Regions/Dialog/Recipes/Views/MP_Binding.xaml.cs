using System;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using VisiWin.ApplicationFramework;
using VisiWin.DataAccess;


namespace HMI.DialogRegion.Recipes.Views
{

    [ExportView("MP_Binding")]
    public partial class MP_Binding
    {
        public MP_Binding()
        {
            this.InitializeComponent();
            DataContext = new Adapters.MP_Binding();

            BitmapImage image = new BitmapImage();
            image.BeginInit();
            image.UriSource = new Uri((new Resources.LocalResources()).Paths.LoadingGif);
            image.EndInit();
            WpfAnimatedGif.ImageBehavior.SetAnimatedSource(gif, image);
        }

        private void DataGridRow_PreviewTouchDown(object sender, TouchEventArgs e)
        {
            dgv_bctor.UnselectAllCells();
            ((DataGridRow)sender).IsSelected = true;
        }

    }
}