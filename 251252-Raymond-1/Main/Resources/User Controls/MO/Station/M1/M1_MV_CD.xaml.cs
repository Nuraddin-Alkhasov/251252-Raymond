using HMI.CO.General;
using System.Windows;
using System.Windows.Controls;
using VisiWin.ApplicationFramework;
using VisiWin.DataAccess;

namespace HMI.Resources.UserControls.MO
{
    public partial class M1_MV_CD : UserControl
    {
        public M1_MV_CD()
        {
            InitializeComponent();

            DTTemperature = "CPU1.PLC.Blocks.03 Basket coating.02 DT.03 Cooling.DB DT Cooling HMI.Actual.Temperature";
            ViscoCheck = "CPU1.PLC.Blocks.03 Basket coating.02 DT.00 Main.DB DT HMI.Actual.Viscosity.Expired";
           
        }
        IVariableService VS = ApplicationService.GetService<IVariableService>();

        IVariable VWN_ViscoCheck;
        public string DTTemperature
        {
             get { return ""; } 
            set
            {
                if (VS.IsExistingVariable(value))
                {
                    dtTemp.VariableName = value;
                }
            }
        }
      
        public string ViscoCheck
        {
             get { return ""; } 
            set
            {
                if (VS.IsExistingVariable(value))
                {
                    VWN_ViscoCheck = VS.GetVariable(value);
                    VWN_ViscoCheck.Change += ViscoCheck_ValueChanged;
                }
            }
        }
        private void ViscoCheck_ValueChanged(object sender, VariableEventArgs e)
        {
            if (e.Quality.Data == DataQuality.Good)
            {
                if ((bool)e.Value)
                {
                    Visco.Visibility = Visibility.Visible;
                }
                else
                {
                    Visco.Visibility = Visibility.Hidden;
                }
            }
        }
        
       
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            new ObjectAnimator().ShowMOElement(this);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            ApplicationService.SetView("MainRegion", "M1_CD");
        }
    }
}
