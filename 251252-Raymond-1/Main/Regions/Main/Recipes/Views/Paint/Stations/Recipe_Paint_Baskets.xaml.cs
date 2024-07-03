using HMI.CO.General;
using System.Windows;
using VisiWin.ApplicationFramework;

namespace HMI.MainRegion.Recipes.Views
{
    [ExportView("Recipe_Paint_Baskets")]
    public partial class Recipe_Paint_Baskets
    {

        public Recipe_Paint_Baskets()
        {
            this.InitializeComponent();
        }
        private void View_Loaded(object sender, RoutedEventArgs e)
        {
            new ObjectAnimator().ShowUIElement(this);
        }

    }
}