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
            Position2 = "CPU3.PLC.Blocks.02 Basket handling.05 CI.01 Traction.DB CI Traction HMI.Actual.Drive.Position";
            Position1 = "CPU1.PLC.Blocks.02 Basket handling.05 CI.01 Traction.DB CI Traction HMI.Actual.Drive.Position";

        }
        IVariableService VS = ApplicationService.GetService<IVariableService>();

        IVariable IVPosition1;
        public string Position1
        {
             get { return ""; } 
            set
            {
                IVPosition1 = VS.GetVariable(value);
                IVPosition1.Change += IVPosition1_ValueChanged;
            }
        }
        double Oldpos1 = -1;
        private void IVPosition1_ValueChanged(object sender, VariableEventArgs e)
        {
            double pos = 0;

            if ((float)e.Value > 4000)
            {
                pos = Math.Round(-120 + Math.Abs((float)e.Value - 4000) * 430 / 6041);
            }
            else 
            {
                pos = -120;

            }

            if (Oldpos2 != pos)
            {
                HVT1.Margin = new Thickness(3, 0, 0, pos);
                Oldpos2 = pos;
            }
        }

        IVariable IVPosition2;
        public string Position2
        {
            get { return ""; }
            set
            {
                IVPosition2 = VS.GetVariable(value);
                IVPosition2.Change += IVPosition2_ValueChanged;
            }
        }
        double Oldpos2 = -1;
        private void IVPosition2_ValueChanged(object sender, VariableEventArgs e)
        {

            double pos = Math.Round(((float)e.Value) * 120 / 1672);

            if (Oldpos1 != pos)
            {
                HVT2.Margin = new Thickness(3, 0, 0, 315 + pos);
                Oldpos1 = pos;
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
