using HMI.Resources.UserControls;
using System.Threading.Tasks;
using VisiWin.ApplicationFramework;


namespace HMI.MainRegion.Recipes.Views
{
    /// <summary>
    /// Interaction logic for View1.xaml
    /// </summary>
    [ExportView("Recipes_Paint")]
    public partial class Recipes_Paint
    {
        public Recipes_Paint()
        {
            InitializeComponent();
            DataContext = new Adapters.Recipes_Paint();
        }

        PaintGeneral ag;
        PaintRecipe ar;

        public void LoadPaint()
        {
            Task t1 = Task.Run(async () =>
            {
                await Task.Delay(0);
                await Dispatcher.InvokeAsync(delegate
                {
                    ag = new PaintGeneral();
                    stack.Children.Add(ag);
                });
            });
            t1.ContinueWith(x1 =>
            {
                Task t2 = Task.Run(async () =>
                {
                    await Task.Delay(200);
                    await Dispatcher.InvokeAsync(delegate
                    {
                        ar = new PaintRecipe();
                        stack.Children.Add(ar);
                    });
                });

            }, TaskContinuationOptions.OnlyOnRanToCompletion);


        }
        public void UnloadPaint()
        {
            Task.Run(() =>
            {
                Dispatcher.InvokeAsync(delegate
                {
                    stack.Children.Remove(ag);
                    stack.Children.Remove(ar);
                });
            });

        }

    }
}