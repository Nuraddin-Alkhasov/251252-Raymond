using HMI.CO.General;
using HMI.CO.Recipe;
using HMI.MainRegion.Recipes.Views;
using HMI.Resources;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using VisiWin.ApplicationFramework;
using VisiWin.Commands;
using VisiWin.Language;
using VisiWin.Recipe;

namespace HMI.MainRegion.Recipes.Adapters
{
    [ExportAdapter("Recipes_Article")]
    public class Recipes_Article : AdapterBase
    {

        public Recipes_Article()
        {

            if (ApplicationService.IsInDesignMode)
            {
                return;
            }
            
            BS = new ActionCommand(BSExecuted);

            BT = new ActionCommand(BTExecuted);
            
            PO = new ActionCommand(POExecuted);
        }

        #region - - - Properties - - -
        private readonly IRegionService iRS = ApplicationService.GetService<IRegionService>();
        private bool ldIsChecked { get; set; } = true;
        public bool LDIsChecked
        {
            get { return ldIsChecked; }
            set
            {
                ldIsChecked = value;
                if (value)
                    Content = new Recipe_Article_LD();
                OnPropertyChanged("LDIsChecked");
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

       
        public ICommand BS { get; set; }
        private void BSExecuted(object parameter)
        {
            Content = new Recipe_Article_BS();
        }
        public ICommand BT { get; set; }
        private void BTExecuted(object parameter)
        {
            Content = new Recipe_Article_BT();
        }
        
        public ICommand PO { get; set; }
        private void POExecuted(object parameter)
        {
            Content = new Recipe_Article_PO();
        }
        

        #endregion

        #region - - - Event handlers - - -

        protected override void OnViewLoaded(object sender, ViewLoadedEventArg e)
        {
            if (sender.GetType().Name == e.View.GetType().Name)
            {

                LDIsChecked = true;
            }

            base.OnViewLoaded(sender, e);
        }
        protected override void OnViewUnloaded(object sender, ViewUnloadedEventArg e)
        {
            base.OnViewUnloaded(sender, e);
        }

        #endregion

        #region - - - Methods - - -

        public void LoadArticle(Article a)
        {
            if (a.Header.Id > 0)
            {
                Article temp = new Article();
                ((Adapters.Recipes_PN)((Views.Recipes_PN)iRS.GetView("Recipes_PN")).DataContext).Wait = Visibility.Visible;
                IRecipeClass LD_Class = ApplicationService.GetService<IRecipeService>().GetRecipeClass("LD");
                IRecipeClass BT_Class = ApplicationService.GetService<IRecipeService>().GetRecipeClass("BT");
                IRecipeClass PO_Class = ApplicationService.GetService<IRecipeService>().GetRecipeClass("PO");

                Task obTask = Task.Run(async () =>
                {
                    try
                    {
                        File.WriteAllText(LD_Class.CurrentPath + @"\" + a.Header.Name + ".R", a.LD.VWRecipe.Data);
                        File.WriteAllText(BT_Class.CurrentPath + @"\" + a.Header.Name + ".R", a.BT.VWRecipe.Data);
                        File.WriteAllText(PO_Class.CurrentPath + @"\" + a.Header.Name + ".R", a.PO.VWRecipe.Data);
                        
                        await Task.Delay(2000);

                    }
                    catch (Exception e) 
                    {
                        new MessageBoxTask(e, "", MessageBoxIcon.Error);
                    }
                     
                });
                obTask.ContinueWith(x =>
                {  
                    

                    Dispatcher.Invoke(async delegate
                    {
                        LoadFromFileToBufferResult result = await LD_Class.LoadFromFileToBufferAsync(a.LD.Header.Name);
                        ApplicationService.SetVariableValue("Recipe.Article_Art", a.Art_Id);
                        ApplicationService.SetVariableValue("Recipe.Article_Type", a.Type_Id);
                        ApplicationService.SetVariableValue("Recipe.Article_Size", a.Size_Id);

                        if (result.Result != LoadRecipeResult.Succeeded)
                        {
                            new MessageBoxTask("@RecipeSystem.Results.LoadError", "@RecipeSystem.Results.Text2", MessageBoxIcon.Error);
                        }
                        result = await BT_Class.LoadFromFileToBufferAsync(a.BT.Header.Name);
                        if (result.Result != LoadRecipeResult.Succeeded)
                        {
                            new MessageBoxTask("@RecipeSystem.Results.LoadError", "@RecipeSystem.Results.Text2", MessageBoxIcon.Error);
                        }
                        result = await PO_Class.LoadFromFileToBufferAsync(a.PO.Header.Name);
                        if (result.Result != LoadRecipeResult.Succeeded)
                        {
                            new MessageBoxTask("@RecipeSystem.Results.LoadError", "@RecipeSystem.Results.Text2", MessageBoxIcon.Error);
                        }

                        ((Adapters.Recipes_PN)((Views.Recipes_PN)iRS.GetView("Recipes_PN")).DataContext).Wait = Visibility.Hidden;
                    });
                }, TaskContinuationOptions.OnlyOnRanToCompletion);
            }
            UpdateName(a);
        }

        private void UpdateName(Article a)
        {
            ((Adapters.Recipes_PN)((Views.Recipes_PN)iRS.GetView("Recipes_PN")).DataContext).Recipe = a.Header;
        }

        #endregion


    }
}