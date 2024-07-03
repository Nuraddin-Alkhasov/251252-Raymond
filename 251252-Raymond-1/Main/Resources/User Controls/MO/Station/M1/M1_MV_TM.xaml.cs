using HMI.CO.General;
using System;
using System.Windows;
using System.Windows.Controls;
using VisiWin.ApplicationFramework;
using VisiWin.DataAccess;

namespace HMI.Resources.UserControls.MO
{
    public partial class M1_MV_TM : UserControl
    {
        public M1_MV_TM()
        {
            InitializeComponent();
            Traction = "CPU2.PLC.Blocks.04 Tray handling.04 TM.01 Traction.DB TM Traction HMI.Actual.Drive.Position";

        }
        IVariableService VS = ApplicationService.GetService<IVariableService>();

        IVariable IVTraction;
        public string Traction
        {
             get { return ""; } 
            set
            {
                if (VS.IsExistingVariable(value))
                {
                    IVTraction = VS.GetVariable(value);
                    IVTraction.Change += IVTraction_Change;
                }
            }
        }
        double OldTraction = 0;
        private void IVTraction_Change(object sender, VariableEventArgs e)
        {
            // CZ3[0] = 5809 | PO = 12219.3
            double pos = Math.Round(450 - ((float)e.Value - 5809) * 820 / 12219.3);
            
            if (OldTraction != pos)
            {
                Mani.Margin = new Thickness(pos, 3, 0, 0);
                OldTraction = pos;
             
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
                CPU= "CPU2",
                Station = 19,
                Header = "@Status.Text71",
                Type = "Tray"
            }.Open();
        }
    }
}
