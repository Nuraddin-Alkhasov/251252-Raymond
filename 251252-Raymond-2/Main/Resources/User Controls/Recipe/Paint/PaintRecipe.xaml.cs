using HMI.CO.General;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;
using VisiWin.ApplicationFramework;
using VisiWin.Recipe;

namespace HMI.Resources.UserControls
{
    public partial class PaintRecipe : UserControl
    {
        public PaintRecipe()
        {
            if (ApplicationService.IsInDesignMode)
            {
                return;
            }
            InitializeComponent();
        }
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            Task obTask = Task.Run(() =>
            {
                new ObjectAnimator().ShowUIElement(this);

                Application.Current.Dispatcher.InvokeAsync(delegate
                {
                    ThicknessAnimation a = SetMargin(new Thickness(0, 500, 0, 0), new Thickness(0, 0, 0, 0), 200);
                    BeginAnimation(MarginProperty, a);
                });
            });
        }

        private ThicknessAnimation SetMargin(Thickness _From, Thickness _To, int _T)
        {
            return new ThicknessAnimation
            {
                From = _From,
                To = _To,
                Duration = TimeSpan.FromMilliseconds(_T),
            };
        }

        private void UserControl_Unloaded(object sender, RoutedEventArgs e)
        {
            IRecipeClass Class = ApplicationService.GetService<IRecipeService>().GetRecipeClass("Paint");
            List<string> VariableNames = Class.GetVariableNames();
            foreach (string vn in VariableNames)
            {
                Class.SetValue(vn, 0);
            }
        }
    }
}
