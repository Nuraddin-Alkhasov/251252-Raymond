using HMI.CO.General;
using HMI.MessageBoxRegion.Views;
using HMI.Resources;
using System.Windows;
using System.Windows.Media;
using VisiWin.ApplicationFramework;
using VisiWin.DataAccess;
using VisiWin.Language;

namespace HMI.MainRegion.MO.Views
{

    [ExportView("M2_LD")]
    public partial class M2_LD
    {

        public M2_LD()
        {
            InitializeComponent();
            Weight = "CPU3.PLC.Blocks.02 Basket handling.01 BS.00 Main.DB BS PD.Station.BS.Weight";
        }

        readonly IVariableService VS = ApplicationService.GetService<IVariableService>();


        IVariable IVWeight;
        public string Weight
        {
            set
            {
                if (VS.IsExistingVariable(value))
                {
                    IVWeight = VS.GetVariable(value);
                    IVWeight.Change += IVWeight_ValueChanged;
                }
            }
        }
        private void IVWeight_ValueChanged(object sender, VariableEventArgs e)
        {
            if (e.Quality.Data == DataQuality.Good)
            {
                ApplicationService.SetVariableValue("Main.M2WeightFrom", (float)e.RawValue);
                ApplicationService.SetVariableValue("Main.M2WeightTo", (float)e.RawValue + (float)ApplicationService.GetVariableValue("CPU3.PLC.Blocks.02 Basket handling.01 BS.00 Main.DB BS HMI.Parameters.Weight.Limit"));
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            new SP
            {
                CPU= "CPU3",
                Station = 4,
                Header = "@Status.Text25",
                Type = "Basket"
            }.Open();
        }
    }
}



