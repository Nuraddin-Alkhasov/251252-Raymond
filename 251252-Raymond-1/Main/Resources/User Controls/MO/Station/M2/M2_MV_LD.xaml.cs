using HMI.CO.General;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using VisiWin.ApplicationFramework;
using VisiWin.DataAccess;

namespace HMI.Resources.UserControls.MO
{
    public partial class M2_MV_LD : UserControl
    {
        public M2_MV_LD()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            new ObjectAnimator().ShowMOElement(this);
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            ApplicationService.SetView("DialogRegion1", "M2_DataPicker");
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            ApplicationService.SetView("MainRegion", "M2_LD");
        }
    }
}
