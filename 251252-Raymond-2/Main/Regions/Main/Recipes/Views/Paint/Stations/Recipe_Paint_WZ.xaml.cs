using HMI.CO.General;
using System.Windows;
using VisiWin.ApplicationFramework;
using VisiWin.Recipe;

namespace HMI.MainRegion.Recipes.Views
{

    [ExportView("Recipe_Paint_WZ")]
    public partial class Recipe_Paint_WZ
    {

        public Recipe_Paint_WZ()
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

      
        private void to_ValueChanged(object sender, VisiWin.DataAccess.VariableEventArgs e)
        {
            if ((bool)to.IsChecked)
            {
                ul.IsEnabled = true;
                s.IsEnabled = true;
                ll.IsEnabled = true;
                s.RawLimitMin = 180;
                s.RawLimitMax = 320;
                ul.RawLimitMax = s.RawValue + 60;
                ul.RawLimitMin = s.RawValue + 1;
                ll.RawLimitMax = s.RawValue - 1;
                ll.RawLimitMin = s.RawValue - 60;
            }
            else
            {
                s.RawLimitMin = 0;
                s.RawLimitMax = 0;
                ul.RawLimitMax = 0;
                ul.RawLimitMin = 0;
                ll.RawLimitMax = 0;
                ll.RawLimitMin = 0;

                ul.IsEnabled = false;
                s.IsEnabled = false;
                ll.IsEnabled = false;
            }
        }

        private void s_ValueChanged(object sender, VisiWin.DataAccess.VariableEventArgs e)
        {
            if ((bool)to.IsChecked) 
            {
                s.RawLimitMin = 180;
                s.RawLimitMax = 320;
                ul.RawLimitMax = s.RawValue + 60;
                ul.RawLimitMin = s.RawValue + 1;
                ll.RawLimitMax = s.RawValue - 1;
                ll.RawLimitMin = s.RawValue - 60;
            }
               
        }

    }
}