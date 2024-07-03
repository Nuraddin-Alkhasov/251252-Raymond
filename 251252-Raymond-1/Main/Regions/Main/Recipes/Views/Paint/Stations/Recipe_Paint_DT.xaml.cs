using HMI.CO.General;
using System.Windows;
using VisiWin.ApplicationFramework;
using VisiWin.Recipe;

namespace HMI.MainRegion.Recipes.Views
{

    [ExportView("Recipe_Paint_DT")]
    public partial class Recipe_Paint_DT
    {

        public Recipe_Paint_DT()
        {
            this.InitializeComponent();
        }

        #region - - - Properties - - -

        #endregion
        private void View_Loaded(object sender, RoutedEventArgs e)
        {
            new ObjectAnimator().ShowUIElement(this);
        }

       

        private void po_ValueChanged(object sender, VisiWin.DataAccess.VariableEventArgs e)
        {
            if ((bool)po.IsChecked)
            {
                pot.IsEnabled = true;
                poft.IsEnabled = true;
                pot.RawLimitMin = 1;
                pot.RawLimitMax = 250;
                poft.RawLimitMin = 0;
                poft.RawLimitMax = 250;
            }
            else 
            {
               
                pot.RawLimitMin = 0;
                pot.RawLimitMax = 0;
                poft.RawLimitMin = 0;
                poft.RawLimitMax = 0;
                pot.IsEnabled = false;
                poft.IsEnabled = false;
            }
        }
        private void vc_ValueChanged(object sender, VisiWin.DataAccess.VariableEventArgs e)
        {
            if ((bool)vc.IsChecked)
            {
                vh.IsEnabled = true;
                vm.IsEnabled = true;
                vh.RawLimitMin = 1;
                vh.RawLimitMax = 10;
                vm.RawLimitMin = 0;
                vm.RawLimitMax = 59;
            }
            else
            {
               
                vh.RawLimitMin = 0;
                vh.RawLimitMax = 0;
                vm.RawLimitMin = 0;
                vm.RawLimitMax = 0;
                vh.IsEnabled = false;
                vm.IsEnabled = false;
            }
        }

        private void to_ValueChanged(object sender, VisiWin.DataAccess.VariableEventArgs e)
        {
            if ((bool)to.IsChecked)
            {
                ul.IsEnabled = true;
                s.IsEnabled = true;
                ll.IsEnabled = true;
                s.RawLimitMin = 10;
                s.RawLimitMax = 30;
                ul.RawLimitMax = s.RawValue + 10;
                ul.RawLimitMin = s.RawValue + 3;
                ll.RawLimitMax = s.RawValue - 3;
                ll.RawLimitMin = s.RawValue - 10;
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
                s.RawLimitMin = 10;
                s.RawLimitMax = 30;
                ul.RawLimitMax = s.RawValue + 10;
                ul.RawLimitMin = s.RawValue + 1;
                ll.RawLimitMax = s.RawValue - 1;
                ll.RawLimitMin = s.RawValue - 10;
            }

        }
    }
}