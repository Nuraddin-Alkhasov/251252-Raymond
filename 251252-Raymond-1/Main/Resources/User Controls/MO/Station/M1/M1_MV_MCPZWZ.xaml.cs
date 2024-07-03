using HMI.CO.General;
using System.Windows;
using System.Windows.Controls;
using VisiWin.ApplicationFramework;
using VisiWin.DataAccess;

namespace HMI.Resources.UserControls.MO
{
    public partial class M1_MV_MCPZWZ : UserControl
    {
        public M1_MV_MCPZWZ()
        {
            InitializeComponent();
            PZTemp = "CPU2.PLC.Blocks.04 Tray handling.02 PZ.03 Heating.DB PZ Heating HMI.Actual.Temperature";
            PZRpm = "CPU2.PLC.Blocks.04 Tray handling.02 PZ.01 Circulation.DB PZ Circulation HMI.Actual.Drive.Speed";
            WZTemp = "CPU2.PLC.Blocks.04 Tray handling.05 WZ.03 Heating.DB WZ Heating HMI.Actual.Temperature";
            WZRpm = "CPU2.PLC.Blocks.04 Tray handling.05 WZ.01 Circulation.DB WZ Circulation HMI.Actual.Drive.Speed";
        }
        IVariableService VS = ApplicationService.GetService<IVariableService>();

        public string PZTemp
        {
             get { return ""; } 
            set
            {
                if (VS.IsExistingVariable(value))
                {
                    PZT.VariableName = value;
                }
            }
        }
        public string WZTemp
        {
             get { return ""; } 
            set
            {
                if (VS.IsExistingVariable(value))
                {
                    WZT.VariableName = value;
                }
            }
        }
      
        public string PZRpm
        {
             get { return ""; } 
            set
            {
                if (VS.IsExistingVariable(value))
                {
                    PZF.VariableName = value;
                }
            }
        }
        public string WZRpm
        {
             get { return ""; } 
            set
            {
                if (VS.IsExistingVariable(value))
                {
                    WZF.VariableName = value;
                }
            }
        }
       
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            new ObjectAnimator().ShowMOElement(this);
        }
     
        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            ApplicationService.SetView("MainRegion", "M1_PZWZ");
        }

    }
}
