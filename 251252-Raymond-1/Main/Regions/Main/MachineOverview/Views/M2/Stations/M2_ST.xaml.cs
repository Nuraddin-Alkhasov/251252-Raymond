using HMI.CO.General;
using System;
using System.Windows;
using System.Windows.Media;
using VisiWin.ApplicationFramework;
using VisiWin.DataAccess;

namespace HMI.MainRegion.MO.Views
{

    [ExportView("M2_ST")]
    public partial class M2_ST
    {

        public M2_ST()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int M3_Temp = Convert.ToInt32(((VisiWin.Controls.Button)sender).Tag);
            
            SP sp = new SP(){
                Station = 6,
                Place = M3_Temp,
                Type = "Basket",
                CPU= "CPU3"
            };

            switch (M3_Temp)
            {
                case 0: sp.Header = "@Status.Text35"; break;
                case 1: sp.Header = "@Status.Text36"; break;
                case 2: sp.Header = "@Status.Text37"; break;
            }

            sp.Open();
        }

    }
}



