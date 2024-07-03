using HMI.CO.General;
using System;
using System.Windows;
using System.Windows.Controls;
using VisiWin.ApplicationFramework;
using VisiWin.DataAccess;

namespace HMI.Resources.UserControls.MO
{
    public partial class M2_MV_CI : UserControl
    {
        public M2_MV_CI()
        {
            InitializeComponent();
            Position = "CPU3.PLC.Blocks.02 Basket handling.05 CI.01 Traction.DB CI Traction HMI.Actual.Drive.Position";

        }
        IVariableService VS = ApplicationService.GetService<IVariableService>();

        IVariable IVPosition;
        public string Position
        {
             get { return ""; } 
            set
            {
                IVPosition = VS.GetVariable(value);
                IVPosition.Change += IVPosition_ValueChanged;
            }
        }
        double Oldpos = -1;
        private void IVPosition_ValueChanged(object sender, VariableEventArgs e)
        {


            double pos = 0;
            if ((float)e.Value > 2550)
            {
                pos = Math.Round(120 + Math.Abs((float)e.Value - 2535) * 465 / 6000);
            }
            else
            {
                pos = Math.Round(((float)e.Value) * 120 / 2535);
            }
            if (Oldpos != pos)
            {
                HVT.Margin = new Thickness(3, 0, 0, pos);
                Oldpos = pos;
            }
        }



        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            new ObjectAnimator().ShowMOElement(this);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            new SP
            {
                Station = 9,
                Header = "@Status.Text39",
                Type = "Basket",
                CPU = "CPU3"
            }.Open();
        }
    }
}
