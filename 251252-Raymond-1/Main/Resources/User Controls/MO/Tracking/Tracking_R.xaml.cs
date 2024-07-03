using HMI.CO.General;
using System.Windows.Controls;

namespace HMI.Resources.UserControls.MO
{
    public partial class Tracking_R : UserControl
    {
        public Tracking_R()
        {
            InitializeComponent();
        }

        public Track Data 
        {
            set 
            {
                d1.Text = value.Data_1;
                d2.Text = value.Data_2;
                mr.Text = value.MR;
                charges.Text = value.Charges.ToString();
                article.SymbolResourceKey = value.Article;
            }
        }

        private void UserControl_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            new ObjectAnimator().ShowMOElement(A);
        }
    }
}
