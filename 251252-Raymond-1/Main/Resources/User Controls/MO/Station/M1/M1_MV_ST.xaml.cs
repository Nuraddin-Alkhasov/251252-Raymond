using HMI.CO.General;
using System.Windows;
using System.Windows.Controls;
using VisiWin.ApplicationFramework;

namespace HMI.Resources.UserControls.MO
{
    public partial class M1_MV_ST : UserControl
    {
        public M1_MV_ST()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            new ObjectAnimator().ShowMOElement(this);

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            ApplicationService.SetView("MainRegion", "M1_ST");
        }
    }
}
