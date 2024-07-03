using System;
using System.Windows.Media.Imaging;
using VisiWin.ApplicationFramework;
using WpfAnimatedGif;

namespace HMI.DialogRegion.MO.Views
{

    [ExportView("M1_DataPicker")]
    public partial class M1_DataPicker
    {

        public M1_DataPicker()
        {
            InitializeComponent();
            DataContext = new Adapters.M1_DataPicker();

        }

    }
}