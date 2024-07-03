using System;
using System.Windows.Media.Imaging;
using VisiWin.ApplicationFramework;
using WpfAnimatedGif;

namespace HMI.DialogRegion.MO.Views
{

    [ExportView("M2_DataPicker")]
    public partial class M2_DataPicker
    {

        public M2_DataPicker()
        {
            InitializeComponent();
            DataContext = new Adapters.M2_DataPicker();

        }

    }
}