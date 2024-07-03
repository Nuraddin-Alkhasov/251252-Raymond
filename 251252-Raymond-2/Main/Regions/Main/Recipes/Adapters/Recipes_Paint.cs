using HMI.CO.General;
using HMI.CO.Recipe;
using HMI.MainRegion.Recipes.Views;
using HMI.Resources;
using System;
using System.Data;
using System.IO;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using VisiWin.ApplicationFramework;
using VisiWin.Commands;
using VisiWin.Language;
using VisiWin.Recipe;

namespace HMI.MainRegion.Recipes.Adapters
{
    [ExportAdapter("Recipes_Paint")]
    public class Recipes_Paint : AdapterBase
    {

        public Recipes_Paint()
        {

            if (ApplicationService.IsInDesignMode)
            {
                return;
            }
            //   languageService.LanguageChanged += LanguageService_LanguageChanged;
            
            B = new ActionCommand(BExecuted);
            DT = new ActionCommand(DTExecuted);

            PZ = new ActionCommand(PZExecuted);

            WZ = new ActionCommand(WZExecuted);
            HZ = new ActionCommand(HZExecuted);
        }

        #region - - - Properties - - -

        public IRecipeClass Class = ApplicationService.GetService<IRecipeService>().GetRecipeClass("Paint");
        private readonly IRegionService iRS = ApplicationService.GetService<IRegionService>();
        private readonly ILanguageService languageService = ApplicationService.GetService<ILanguageService>();

        private bool dtIsChecked { get; set; } = true;
        public bool DTIsChecked
        {
            get { return dtIsChecked; }
            set
            {
                dtIsChecked = value;
                if (value)
                    Content = new Recipe_Paint_DT();
                OnPropertyChanged("DTIsChecked");
            }
        }
        object content;
        public object Content
        {
            get { return content; }
            set
            {
                this.content = value;
                this.OnPropertyChanged("Content");
            }
        }
        #endregion

        #region - - - Commands - - -
        public ICommand B { get; set; }
        private void BExecuted(object parameter)
        {
            Content = new Recipe_Paint_Baskets();
        }
        public ICommand DT { get; set; }
        private void DTExecuted(object parameter)
        {
            Content = new Recipe_Paint_DT();
        }
        public ICommand PZ { get; set; }
        private void PZExecuted(object parameter)
        {
            Content = new Recipe_Paint_PZ();
        }

        public ICommand WZ { get; set; }
        private void WZExecuted(object parameter)
        {
            Content = new Recipe_Paint_WZ();
        }
        public ICommand HZ { get; set; }
        private void HZExecuted(object parameter)
        {
            Content = new Recipe_Paint_HZ();
        }
        #endregion

        #region - - - Event handlers - - -

        protected override void OnViewLoaded(object sender, ViewLoadedEventArg e)
        {
            if (sender.GetType().Name == e.View.GetType().Name)
            {
                DTIsChecked = true;
            }
           

            base.OnViewLoaded(sender, e);
        }
        protected override void OnViewUnloaded(object sender, ViewUnloadedEventArg e)
        {
            base.OnViewUnloaded(sender, e);
        }


        #endregion

        #region - - - Methods - - -
        public void LoadPaint(Paint p)
        {
            if (p.Header.Id > 0)
            {
                Paint temp = new Paint();
                ((Adapters.Recipes_PN)((Views.Recipes_PN)iRS.GetView("Recipes_PN")).DataContext).Wait = Visibility.Visible;
                Task obTask = Task.Run(async () =>
                {
                    File.WriteAllText(Class.CurrentPath + @"\" + p.Header.Name + ".R", p.VWRecipe.Data);

                    await Task.Delay(1500);

                });
                obTask.ContinueWith(x =>
                {

                    Dispatcher.Invoke(async delegate
                    {
                        LoadFromFileToBufferResult result = await Class.LoadFromFileToBufferAsync(p.Header.Name);
                        if (result.Result != LoadRecipeResult.Succeeded)
                        {
                            new MessageBoxTask("@RecipeSystem.Results.LoadError", "@RecipeSystem.Results.Text2", MessageBoxIcon.Error);
                        }
                          ((Adapters.Recipes_PN)((Views.Recipes_PN)iRS.GetView("Recipes_PN")).DataContext).Wait = Visibility.Hidden;

                    });
                }, TaskContinuationOptions.OnlyOnRanToCompletion);
            }
            UpdateName(p);
        }
        public void LoadPaintFromPLC(uint Paint_Id)
        {
            try
            {
                DataTable DT = new MSSQLEAdapter("Recipes", "SELECT * FROM Recipes_Paint WHERE Id= " + Paint_Id + "; ").DB_Output();
                Paint temp = new Paint();
                if (DT.Rows.Count > 0)
                {
                    temp.Header = new RecipeInfo()
                    {
                        Id = (int)DT.Rows[0]["Id"],
                        Name = (string)DT.Rows[0]["Name"],
                        Description = DT.Rows[0]["Description"] == DBNull.Value ? "" : ((string)DT.Rows[0]["Description"]),
                        LastChanged = ((DateTime)DT.Rows[0]["LastChanged"]).ToString("dd.MM.yyyy HH:mm:ss"),
                        User = (string)DT.Rows[0]["User"]
                    };
                  
                    temp.VWRecipe = new VWRecipe((string)DT.Rows[0]["VWRecipe"]);
                }

                LoadPaint(temp);
            }
            catch 
            {
            
            }
        }

        private void UpdateName(Paint c)
        {
            ((Adapters.Recipes_PN)((Views.Recipes_PN)iRS.GetView("Recipes_PN")).DataContext).Recipe = c.Header;
        }
        #endregion


    }
}