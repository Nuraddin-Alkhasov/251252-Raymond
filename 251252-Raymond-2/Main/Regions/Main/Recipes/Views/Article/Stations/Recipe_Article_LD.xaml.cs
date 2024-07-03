using HMI.CO.General;
using System.Windows;
using VisiWin.ApplicationFramework;
using VisiWin.Recipe;

namespace HMI.MainRegion.Recipes.Views
{

    [ExportView("Recipe_Article_LD")]
    public partial class Recipe_Article_LD
    {

        public Recipe_Article_LD()
        {
            this.InitializeComponent();
        }

        #region - - - Properties - - -

        public IRecipeClass Class = ApplicationService.GetService<IRecipeService>().GetRecipeClass("LD");

        #endregion
        private void View_Loaded(object sender, RoutedEventArgs e)
        {
            new ObjectAnimator().ShowUIElement(this);
        }

        private void s0o_ValueChanged(object sender, VisiWin.DataAccess.VariableEventArgs e)
        {
            if (s0o.Value == 0)
            {
                Class.SetValue("CPU1.PLC.Blocks.01 Basket feeding.01 LD.00 Main.DB LD PD.Station.LD.Step[1].Open", 0);
                s1o.IsEnabled = false;
            }
            else
            {
                s1o.IsEnabled = true;
                s0w.RawLimitMin = 0.1;
            }
        }

        private void s1o_ValueChanged(object sender, VisiWin.DataAccess.VariableEventArgs e)
        {
            if (s1o.Value == 0)
            {
                Class.SetValue("CPU1.PLC.Blocks.01 Basket feeding.01 LD.00 Main.DB LD PD.Station.LD.Step[2].Open", 0);
                s2o.IsEnabled = false;
                Class.SetValue("CPU1.PLC.Blocks.01 Basket feeding.01 LD.00 Main.DB LD PD.Station.LD.Step[1].Wait", 0);
                s1w.RawLimitMin = 0;
                s1w.IsEnabled = false;
            }
            else
            {
                s2o.IsEnabled = true;
                s1w.IsEnabled = true;
                s1w.RawLimitMin = 0.1;
            }
        }

        private void s2o_ValueChanged(object sender, VisiWin.DataAccess.VariableEventArgs e)
        {
            if (s2o.Value == 0)
            {
                Class.SetValue("CPU1.PLC.Blocks.01 Basket feeding.01 LD.00 Main.DB LD PD.Station.LD.Step[3].Open", 0);
                s3o.IsEnabled = false;
                Class.SetValue("CPU1.PLC.Blocks.01 Basket feeding.01 LD.00 Main.DB LD PD.Station.LD.Step[2].Wait", 0);
                s2w.RawLimitMin = 0;
                s2w.IsEnabled = false;
            }
            else
            {
                s3o.IsEnabled = true;
                s2w.IsEnabled = true;
                s2w.RawLimitMin = 0.1;
            }
        }

        private void s3o_ValueChanged(object sender, VisiWin.DataAccess.VariableEventArgs e)
        {
            if (s3o.Value == 0)
            {
                Class.SetValue("CPU1.PLC.Blocks.01 Basket feeding.01 LD.00 Main.DB LD PD.Station.LD.Step[3].Wait", 0);
                s3w.RawLimitMin = 0;
                s3w.IsEnabled = false;
            }
            else
            {
                s3w.IsEnabled = true;
                s3w.RawLimitMin = 0.1;
            }
        }
    }
}