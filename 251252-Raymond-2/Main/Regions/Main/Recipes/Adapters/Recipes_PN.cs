using HMI.CO.Recipe;
using System.Windows;
using System.Windows.Input;
using VisiWin.ApplicationFramework;
using VisiWin.Commands;


namespace HMI.MainRegion.Recipes.Adapters
{
    [ExportAdapter("Recipes_PN")]
    public class Recipes_PN : AdapterBase
    {

        public Recipes_PN()
        {

            if (ApplicationService.IsInDesignMode)
            {
                return;
            }

            Manage = new ActionCommand(ManageExecuted);


        }

        #region - - - Properties - - -

        private readonly IRegionService iRS = ApplicationService.GetService<IRegionService>();
        private Visibility wait { get; set; } = Visibility.Hidden;
        public Visibility Wait
        {
            get { return wait; }
            set
            {
                wait = value;
                OnPropertyChanged("Wait");
            }
        }
        private RecipeInfo recipe { set; get; } = new RecipeInfo();
        public RecipeInfo Recipe
        {
            get { return recipe; }
            set
            {
                recipe = value;
                OnPropertyChanged("Recipe");
            }
        }
        private string localizableText { set; get; } = "";
        public string LocalizableText
        {
            get { return localizableText; }
            set
            {
                localizableText = value;
                OnPropertyChanged("LocalizableText");
            }
        }
        private string authorizationRight { set; get; } = "";
        public string AuthorizationRight
        {
            get { return authorizationRight; }
            set
            {
                authorizationRight = value;
                OnPropertyChanged("AuthorizationRight");
            }
        }

        private int selectedPRI { set; get; } = 1;
        public int SelectedPRI
        {
            get { return selectedPRI; }
            set
            {
                Views.Recipes_MR mr = (Views.Recipes_MR)iRS.GetView("Recipes_MR");
                Adapters.Recipes_MR mra = mr.DataContext as Adapters.Recipes_MR;

                switch (value)
                {
                    case 0:
                        (iRS.GetView("MainRegion", "Recipes_Coating") as Views.Recipes_Coating).UnloadCoating();
                        (iRS.GetView("MainRegion", "Recipes_Paint") as Views.Recipes_Paint).UnloadPaint();

                        Views.Recipes_Article a = iRS.GetView("MainRegion", "Recipes_Article") as Views.Recipes_Article;
                        Adapters.Recipes_Article aa = a.DataContext as Adapters.Recipes_Article;
                        a.LoadArticle();
                        aa.LoadArticle(mra.ArticleBuffer.Article);
                        
                        AuthorizationRight = "RecipeAP";
                        LocalizableText = "@RecipeSystem.Text5";
                        break;
                    case 1:
                        (iRS.GetView("MainRegion", "Recipes_Article") as Views.Recipes_Article).UnloadArticle();
                        (iRS.GetView("MainRegion", "Recipes_Coating") as Views.Recipes_Coating).UnloadCoating();
                        (iRS.GetView("MainRegion", "Recipes_Paint") as Views.Recipes_Paint).UnloadPaint();
                        
                        mra.GetCoatings();
                        mra.GetArticles();

                        uint MR_Id = (uint)ApplicationService.GetVariableValue("CPU1.PLC.Blocks.01 Basket feeding.01 LD.00 Main.DB LD HMI.PC.Header.from.MR");
                        mra.LoadMRFromPLC(MR_Id);

                        AuthorizationRight = "RecipeMP";
                        LocalizableText = "@RecipeSystem.Text3";
                        break;
                    case 2:
                        (iRS.GetView("MainRegion", "Recipes_Article") as Views.Recipes_Article).UnloadArticle();
                        (iRS.GetView("MainRegion", "Recipes_Paint") as Views.Recipes_Paint).UnloadPaint();
                        
                        Views.Recipes_Coating c = iRS.GetView("MainRegion", "Recipes_Coating") as Views.Recipes_Coating;
                        Adapters.Recipes_Coating ca = c.DataContext as Adapters.Recipes_Coating;
                        c.LoadSteps();
                        ca.LoadCoating(mr.GetCheckedCoating().MCP.Coating);
                        
                        AuthorizationRight = "RecipeCP";
                        LocalizableText = "@RecipeSystem.Text4";
                        break;
                    case 3:
                        (iRS.GetView("MainRegion", "Recipes_Article") as Views.Recipes_Article).UnloadArticle();
                        (iRS.GetView("MainRegion", "Recipes_Coating") as Views.Recipes_Coating).UnloadCoating();

                        Views.Recipes_Paint p = iRS.GetView("MainRegion", "Recipes_Paint") as Views.Recipes_Paint;
                        Adapters.Recipes_Paint pa = p.DataContext as Adapters.Recipes_Paint;
                        uint Paint_Id = (uint)ApplicationService.GetVariableValue("CPU1.PLC.Blocks.03 Basket coating.02 DT.00 Main.DB DT PD.Header.Paint");
                        p.LoadPaint();
                        pa.LoadPaintFromPLC(Paint_Id);

                        AuthorizationRight = "RecipePP";
                        LocalizableText = "@RecipeSystem.Text27";
                        break;
                    default:
                        break;

                }

                selectedPRI = value;
                OnPropertyChanged("SelectedPRI");
            }
        }

        #endregion

        #region - - - Commands - - -


        public ICommand Manage { get; set; }
        private void ManageExecuted(object parameter)
        {
            switch (SelectedPRI)
            {
                case 0:
                    ApplicationService.SetView("DialogRegion1", "Article_Browser", Recipe);
                    break;
                case 1:
                    ApplicationService.SetView("DialogRegion1", "MP_Browser", Recipe);
                    break;
                case 2:
                    ApplicationService.SetView("DialogRegion1", "Coating_Browser", Recipe);
                    break;
                case 3:
                    ApplicationService.SetView("DialogRegion1", "Paint_Browser", Recipe);
                    break;
                default:
                    break;
            }

        }


        #endregion

        #region - - - Event handlers - - -

        protected override void OnViewLoaded(object sender, ViewLoadedEventArg e)
        {
            if (sender.GetType().Name == e.View.GetType().Name)
            {
                SelectedPRI = 1;
                LocalizableText = "@RecipeSystem.Text3";
            }

            base.OnViewLoaded(sender, e);
        }
        protected override void OnViewUnloaded(object sender, ViewUnloadedEventArg e)
        {
            base.OnViewUnloaded(sender, e);
        }

        #endregion

        #region - - - Methods - - -



        #endregion


    }
}