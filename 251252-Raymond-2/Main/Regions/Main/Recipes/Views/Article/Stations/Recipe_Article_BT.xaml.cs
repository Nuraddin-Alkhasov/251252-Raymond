using HMI.CO.General;
using System.Windows;
using VisiWin.ApplicationFramework;
using VisiWin.Recipe;

namespace HMI.MainRegion.Recipes.Views
{

    [ExportView("Recipe_Article_BT")]
    public partial class Recipe_Article_BT
    {

        public Recipe_Article_BT()
        {
            this.InitializeComponent();
        }

        #region - - - Properties - - -

        public IRecipeClass Class = ApplicationService.GetService<IRecipeService>().GetRecipeClass("BT");

        #endregion

        private void View_Loaded(object sender, RoutedEventArgs e)
        {
            new ObjectAnimator().ShowUIElement(this);
        }
      
        private void s0a_ValueChanged(object sender, VisiWin.DataAccess.VariableEventArgs e)
        {
            if (s0a.Value == 0)
            {
                Class.SetValue("CPU1.PLC.Blocks.02 Basket handling.04 BT.00 Main.DB BT PD.Station.BT.Step[1].Angle", 0);
                s1a.IsEnabled = false;

                Class.SetValue("CPU1.PLC.Blocks.02 Basket handling.04 BT.00 Main.DB BT PD.Station.BT.Step[0].Speed", 0);
                Class.SetValue("CPU1.PLC.Blocks.02 Basket handling.04 BT.00 Main.DB BT PD.Station.BT.Step[0].Wait", 0);
                s0r.IsChecked = false;

            }
            else
            {
                s1a.IsEnabled = true;
            }
        }

        private void s1a_ValueChanged(object sender, VisiWin.DataAccess.VariableEventArgs e)
        {
            if (s1a.Value == 0)
            {
                Class.SetValue("CPU1.PLC.Blocks.02 Basket handling.04 BT.00 Main.DB BT PD.Station.BT.Step[2].Angle", 0);
                s2a.IsEnabled = false;

                Class.SetValue("CPU1.PLC.Blocks.02 Basket handling.04 BT.00 Main.DB BT PD.Station.BT.Step[1].Speed", 0);
                Class.SetValue("CPU1.PLC.Blocks.02 Basket handling.04 BT.00 Main.DB BT PD.Station.BT.Step[1].Wait", 0);
                s1r.IsChecked = false;

                s1s.IsEnabled = false;
                s1w.IsEnabled = false;
                s1r.IsEnabled = false;

                s1s.RawLimitMin = 0;
                s1w.RawLimitMin = 0;
            }
            else
            {
                s2a.IsEnabled = true;

                s1s.IsEnabled = true;
                s1w.IsEnabled = true;
                s1r.IsEnabled = true;

                s1s.RawLimitMin = 0.1;
                s1w.RawLimitMin = 0.1;
            }
        }

        private void s2a_ValueChanged(object sender, VisiWin.DataAccess.VariableEventArgs e)
        {
            if (s2a.Value == 0)
            {
                Class.SetValue("CPU1.PLC.Blocks.02 Basket handling.04 BT.00 Main.DB BT PD.Station.BT.Step[3].Angle", 0);
                s3a.IsEnabled = false;

                Class.SetValue("CPU1.PLC.Blocks.02 Basket handling.04 BT.00 Main.DB BT PD.Station.BT.Step[2].Speed", 0);
                Class.SetValue("CPU1.PLC.Blocks.02 Basket handling.04 BT.00 Main.DB BT PD.Station.BT.Step[2].Wait", 0);
                s2r.IsChecked = false;

                s2s.IsEnabled = false;
                s2w.IsEnabled = false;
                s2r.IsEnabled = false;

                s2s.RawLimitMin = 0;
                s2w.RawLimitMin = 0;
            }
            else
            {
                s3a.IsEnabled = true;

                s2s.IsEnabled = true;
                s2w.IsEnabled = true;
                s2r.IsEnabled = true;

                s2s.RawLimitMin = 0.1;
                s2w.RawLimitMin = 0.1;
            }
        }

        private void s3a_ValueChanged(object sender, VisiWin.DataAccess.VariableEventArgs e)
        {
            if (s3a.Value == 0)
            {
                Class.SetValue("CPU1.PLC.Blocks.02 Basket handling.04 BT.00 Main.DB BT PD.Station.BT.Step[3].Speed", 0);
                Class.SetValue("CPU1.PLC.Blocks.02 Basket handling.04 BT.00 Main.DB BT PD.Station.BT.Step[3].Wait", 0);
                s3r.IsChecked = false;

                s3s.IsEnabled = false;
                s3w.IsEnabled = false;
                s3r.IsEnabled = false;

                s3s.RawLimitMin = 0;
                s3w.RawLimitMin = 0;
            }
            else 
            {
                s3s.IsEnabled = true;
                s3w.IsEnabled = true;  
                s3r.IsEnabled = true;

                s3s.RawLimitMin = 0.1;
                s3w.RawLimitMin = 0.1;
            }

        }

   
    }
}