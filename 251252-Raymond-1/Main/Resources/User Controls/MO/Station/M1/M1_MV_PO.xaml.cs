using HMI.CO.General;
using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using VisiWin.ApplicationFramework;
using VisiWin.DataAccess;

namespace HMI.Resources.UserControls.MO
{
    public partial class M1_MV_PO : UserControl
    {
        public M1_MV_PO()
        {
            InitializeComponent();
            Traction = "CPU2.PLC.Blocks.04 Tray handling.08 PO.02 Traction.DB PO Traction HMI.Actual.Drive.Position";
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
            double pos = 0;
            if ((float)e.Value > 0)
            {
                pos = Math.Round(((float)e.Value) * 0.068139);
            }
          
            
            if (OldTraction != pos)
            {
                Tray.Margin = new Thickness(0, 3, 50 + pos, 0);
                OldTraction = pos;
             
            }
        
        }

        
   

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            new ObjectAnimator().ShowMOElement(this);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            new SP
            {
                CPU = "CPU2",
                Station = 20,
                Header = "@Status.Text72",
                Type = "Tray"
            }.Open();
        }
    }
}
