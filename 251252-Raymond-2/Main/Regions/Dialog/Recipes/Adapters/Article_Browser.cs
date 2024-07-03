using HMI.CO.General;
using HMI.CO.Recipe;
using HMI.MessageBoxRegion.Views;
using HMI.Resources;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using VisiWin.ApplicationFramework;
using VisiWin.Commands;
using VisiWin.Recipe;

namespace HMI.DialogRegion.Recipes.Adapters
{
    [ExportAdapter("Article_Browser")]
    public class Article_Browser : AdapterBase
    {

        public Article_Browser()
        {

            if (ApplicationService.IsInDesignMode)
            {
                return;
            }
            Load = new ActionCommand(LoadExecuted);
            Save = new ActionCommand(SaveExecuted);
            Delete = new ActionCommand(DeleteExecuted);
            Close = new ActionCommand(CloseExecuted);
        }

        #region - - - Properties - - -
        private readonly IRegionService iRS = ApplicationService.GetService<IRegionService>();
        public IRecipeClass LD_Class = ApplicationService.GetService<IRecipeService>().GetRecipeClass("LD");
        public IRecipeClass BT_Class = ApplicationService.GetService<IRecipeService>().GetRecipeClass("BT");
        public IRecipeClass PO_Class = ApplicationService.GetService<IRecipeService>().GetRecipeClass("PO");

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

        private List<Article> articles { get; set; } = new List<Article>();
        public List<Article> Articles
        {
            get { return articles; }
            set
            {
                articles = value;

                OnPropertyChanged("Articles");
            }
        }
        private List<Article> TArticles { get; set; } = new List<Article>();

        private Article selectedArticle { get; set; } = new Article();
        public Article SelectedArticle
        {
            get { return selectedArticle; }
            set
            {
                selectedArticle = value;
                IsSelected = false;
                if (value != null)
                {
                    NameBuffer = value.Header.Name;
                    DescriptionBuffer = value.Header.Description;

                    if (value.Header.Id > 0)
                    {
                        IsSelected = true;
                    }
                }


                OnPropertyChanged("SelectedArticle");
            }
        }

        private string nameBuffer = "";
        public string NameBuffer
        {
            get { return nameBuffer; }
            set
            {
                nameBuffer = value;
                OnPropertyChanged("NameBuffer");
            }
        }

        private string descriptionBuffer = "";
        public string DescriptionBuffer
        {
            get { return descriptionBuffer; }
            set
            {
                descriptionBuffer = value;
                OnPropertyChanged("DescriptionBuffer");
            }
        }
        private bool isSelected = false;
        public bool IsSelected
        {
            get { return isSelected; }
            set
            {
                isSelected = value;
                OnPropertyChanged("IsSelected");
            }
        }

        private string filter = "";
        public string Filter
        {
            get { return filter; }
            set
            {
                if (filter != value)
                {
                    if (value != "")
                    {
                        Articles = new List<Article>();
                        foreach (Article a in TArticles)
                        {
                            if (a.Header.Name.ToUpper().Contains(value.ToUpper()))
                            {
                                Articles.Add(a);
                            }
                        }
                        SelectedArticle = new Article();
                    }
                    else
                    {
                        Articles = TArticles;
                    }
                    filter = value;
                    OnPropertyChanged("Filter");
                }
            }
        }

        #endregion

        #region - - - Commands - - -

        public ICommand Load { get; set; }
        private void LoadExecuted(object parameter)
        {
            if (SelectedArticle.Header.Id > 0)
            {
                ((MainRegion.Recipes.Adapters.Recipes_Article)(iRS.GetView("MainRegion", "Recipes_Article") as MainRegion.Recipes.Views.Recipes_Article).DataContext).LoadArticle(SelectedArticle);
                CloseExecuted(null);
            }
        }

        public ICommand Save { get; set; }
        private void SaveExecuted(object parameter)
        {
            if (NameBuffer.Length >= 3)
            {
              
                Article a = Articles.Where(x => x.Header.Name == NameBuffer).ToArray().Length > 0 ? Articles.Where(x => x.Header.Name == NameBuffer).ToArray()[0] : new Article();
                if (a.Header.Id > 0)
                {
                    if (MessageBoxView.Show("@RecipeSystem.Results.OverwriteFileQuery", "@RecipeSystem.Results.SaveFile", MessageBoxButton.YesNo, icon: MessageBoxIcon.Question) == MessageBoxResult.No)
                    {
                        return;
                    }
                }

                int status = a.LD.Check();
                if (status != 0)
                {
                    CloseExecuted(null);
                    switch (status)
                    {
                        case 2: new MessageBoxTask("@RecipeSystem.Check.Text2", "@RecipeSystem.Results.SaveFile", MessageBoxIcon.Exclamation); break;
                        case 3: new MessageBoxTask("@RecipeSystem.Check.Text3", "@RecipeSystem.Results.SaveFile", MessageBoxIcon.Exclamation); break;
                        case 4: new MessageBoxTask("@RecipeSystem.Check.Text4", "@RecipeSystem.Results.SaveFile", MessageBoxIcon.Exclamation); break;
                        case 5: new MessageBoxTask("@RecipeSystem.Check.Text5", "@RecipeSystem.Results.SaveFile", MessageBoxIcon.Exclamation); break;
                        case 6: new MessageBoxTask("@RecipeSystem.Check.Text6", "@RecipeSystem.Results.SaveFile", MessageBoxIcon.Exclamation); break;
                        case 7: new MessageBoxTask("@RecipeSystem.Check.Text7", "@RecipeSystem.Results.SaveFile", MessageBoxIcon.Exclamation); break;
                        default: break;
                    }
                }
                else
                {
                    status = a.BT.Check();
                    if (status != 0)
                    {
                        CloseExecuted(null);
                        switch (status)
                        {
                            case 8: new MessageBoxTask("@RecipeSystem.Check.Text8", "@RecipeSystem.Results.SaveFile", MessageBoxIcon.Exclamation); break;
                            case 9: new MessageBoxTask("@RecipeSystem.Check.Text9", "@RecipeSystem.Results.SaveFile", MessageBoxIcon.Exclamation); break;
                            case 10: new MessageBoxTask("@RecipeSystem.Check.Text10", "@RecipeSystem.Results.SaveFile", MessageBoxIcon.Exclamation); break;
                            case 11: new MessageBoxTask("@RecipeSystem.Check.Text11", "@RecipeSystem.Results.SaveFile", MessageBoxIcon.Exclamation); break;
                            case 12: new MessageBoxTask("@RecipeSystem.Check.Text12", "@RecipeSystem.Results.SaveFile", MessageBoxIcon.Exclamation); break;
                            case 13: new MessageBoxTask("@RecipeSystem.Check.Text13", "@RecipeSystem.Results.SaveFile", MessageBoxIcon.Exclamation); break;
                            case 14: new MessageBoxTask("@RecipeSystem.Check.Text14", "@RecipeSystem.Results.SaveFile", MessageBoxIcon.Exclamation); break;
                            case 15: new MessageBoxTask("@RecipeSystem.Check.Text15", "@RecipeSystem.Results.SaveFile", MessageBoxIcon.Exclamation); break;
                            case 16: new MessageBoxTask("@RecipeSystem.Check.Text16", "@RecipeSystem.Results.SaveFile", MessageBoxIcon.Exclamation); break;
                            case 17: new MessageBoxTask("@RecipeSystem.Check.Text17", "@RecipeSystem.Results.SaveFile", MessageBoxIcon.Exclamation); break;
                            case 18: new MessageBoxTask("@RecipeSystem.Check.Text18", "@RecipeSystem.Results.SaveFile", MessageBoxIcon.Exclamation); break;
                            case 19: new MessageBoxTask("@RecipeSystem.Check.Text19", "@RecipeSystem.Results.SaveFile", MessageBoxIcon.Exclamation); break;
                            case 20: new MessageBoxTask("@RecipeSystem.Check.Text20", "@RecipeSystem.Results.SaveFile", MessageBoxIcon.Exclamation); break;
                            default: break;
                        }
                    }
                    else 
                    {
                        status = a.PO.Check();
                        if (status != 0)
                        {
                            CloseExecuted(null);
                            switch (status)
                            {
                                case 21: new MessageBoxTask("@RecipeSystem.Check.Text21", "@RecipeSystem.Results.SaveFile", MessageBoxIcon.Exclamation); break;
                                case 22: new MessageBoxTask("@RecipeSystem.Check.Text22", "@RecipeSystem.Results.SaveFile", MessageBoxIcon.Exclamation); break;
                                default: break;
                            }
                        }
                        else
                        {
                            Wait = Visibility.Visible;
                            Task.Run(async () =>
                            {
                                try 
                                { 
                                    SaveToFileFromBufferResult e = await LD_Class.SaveToFileFromBufferAsync(NameBuffer, DescriptionBuffer, true);
                                    if (e.Result != SaveRecipeResult.Succeeded)
                                    {
                                        new MessageBoxTask("@RecipeSystem.Results.SaveError", "@RecipeSystem.Results.Text2", MessageBoxIcon.Error);
                                    }
                                    else 
                                    {
                                        e = await BT_Class.SaveToFileFromBufferAsync(NameBuffer, DescriptionBuffer, true);
                                        if (e.Result != SaveRecipeResult.Succeeded)
                                        {
                                            new MessageBoxTask("@RecipeSystem.Results.SaveError", "@RecipeSystem.Results.Text2", MessageBoxIcon.Error);
                                        }
                                        else 
                                        {
                                            e = await PO_Class.SaveToFileFromBufferAsync(NameBuffer, DescriptionBuffer, true);

                                            if (e.Result != SaveRecipeResult.Succeeded)
                                            {
                                                new MessageBoxTask("@RecipeSystem.Results.SaveError", "@RecipeSystem.Results.Text2", MessageBoxIcon.Error);
                                            }
                                            else 
                                            {
                                                if (a.Header.Id > 0)
                                                {
                                                    new MSSQLEAdapter("Recipes", "UPDATE Recipes_Article " +
                                                                            "SET " +
                                                                            "Description = '" + DescriptionBuffer + "', " +
                                                                            "Art_Id = " + ApplicationService.GetVariableValue("Recipe.Article_Art").ToString() + ", " +
                                                                            "Type_Id = " + ApplicationService.GetVariableValue("Recipe.Article_Type").ToString() + ", " +
                                                                            "Size_Id = " + ApplicationService.GetVariableValue("Recipe.Article_Size").ToString() + ", " +
                                                                            "LD_VWRecipe = '" + File.ReadAllText(LD_Class.CurrentPath + @"\\" + NameBuffer + ".R") + "', " +
                                                                            "BT_VWRecipe = '" + File.ReadAllText(BT_Class.CurrentPath + @"\\" + NameBuffer + ".R") + "', " +
                                                                            "PO_VWRecipe = '" + File.ReadAllText(PO_Class.CurrentPath + @"\\" + NameBuffer + ".R") + "', " +
                                                                            "LastChanged = '" + DateTime.Now.ToString("yyyyMMdd HH:mm:ss") + "', " +
                                                                            "[User] = '" + ApplicationService.GetVariableValue("__CURRENT_USER.FULLNAME").ToString() + "' " +
                                                                            "WHERE Id = " + a.Header.Id + ";").DB_Input();

                                                }
                                                else
                                                {
                                                    new MSSQLEAdapter("Recipes", "INSERT " +
                                                                            "INTO Recipes_Article (Name, Description, Art_Id, Type_Id, Size_Id, LD_VWRecipe, BT_VWRecipe, PO_VWRecipe, [User]) " +
                                                                            "VALUES ('" +
                                                                            NameBuffer + "','" +
                                                                            DescriptionBuffer + "'," +
                                                                            ApplicationService.GetVariableValue("Recipe.Article_Art").ToString() + "," +
                                                                            ApplicationService.GetVariableValue("Recipe.Article_Type").ToString() + "," +
                                                                            ApplicationService.GetVariableValue("Recipe.Article_Size").ToString() + ",'" +
                                                                            File.ReadAllText(LD_Class.CurrentPath + @"\\" + NameBuffer + ".R") + "','" +
                                                                            File.ReadAllText(BT_Class.CurrentPath + @"\\" + NameBuffer + ".R") + "','" +
                                                                            File.ReadAllText(PO_Class.CurrentPath + @"\\" + NameBuffer + ".R") + "','" +
                                                                            ApplicationService.GetVariableValue("__CURRENT_USER.FULLNAME").ToString() + "');").DB_Input();
                                                }
                                            }
                                        }
                                    }

                                    Dispatcher.Invoke(delegate
                                    {
                                        UpdateName();
                                    });
                                    await Task.Delay(1000);
                                    Dispatcher.Invoke(delegate
                                    {
                                        Wait = Visibility.Hidden;
                                    });
                                    CloseExecuted(null);
                                }
                                catch
                                {
                                    Dispatcher.Invoke(delegate
                                    {
                                        Wait = Visibility.Hidden;
                                    });
                                    return;
                                }
                            });
                        }
                    }
                }
                   
               
            }
        }

        public ICommand Delete { get; set; }
        private void DeleteExecuted(object parameter)
        {
            if (SelectedArticle.Header.Id > 0)
            {
                if (MessageBoxView.Show("@RecipeSystem.Results.DeleteFileQuery", "@RecipeSystem.Results.DeleteFile", MessageBoxButton.YesNo, icon: MessageBoxIcon.Question) == MessageBoxResult.Yes)
                {
                    Wait = Visibility.Visible;

                    Task.Run(async () =>
                    {
                        try 
                        {
                            new MSSQLEAdapter("Recipes", "DELETE " +
                                                 "FROM Recipes_Article " +
                                                 "WHERE Id = " + SelectedArticle.Header.Id + "; ").DB_Output();

                            Dispatcher.Invoke(delegate
                            {
                                Articles.Remove(SelectedArticle);
                                List<Article> temp = articles;
                                Articles = new List<Article>();
                                Articles = temp;
                                SelectedArticle = new Article();

                                UpdateName();
                            });
                            
                            await Task.Delay(1000);

                            Dispatcher.Invoke(delegate
                            {
                                Wait = Visibility.Hidden;
                            });
                        }
                        catch
                        {
                            Dispatcher.Invoke(delegate
                            {
                                Wait = Visibility.Hidden;
                            }); return;
                        }
                    });
                }
            }
        }

        public ICommand Close { get; set; }
        private void CloseExecuted(object parameter)
        {
            Views.Article_Browser v = (Views.Article_Browser)iRS.GetView("Article_Browser");
            new ObjectAnimator().CloseDialog1(v, v.border);
        }




        #endregion

        #region - - - Event handlers - - -

        protected override void OnViewLoaded(object sender, ViewLoadedEventArg e)
        {
            RecipeInfo temp = ApplicationService.ObjectStore.GetValue("Article_Browser_KEY") as RecipeInfo;
            ApplicationService.ObjectStore.Remove("Article_Browser_KEY");
            
          
            GetArticles(temp);

            filter = "";
            OnPropertyChanged("Filter");

            Views.Article_Browser v = (Views.Article_Browser)iRS.GetView("Article_Browser");
            new ObjectAnimator().OpenDialog(v, v.border);

            base.OnViewLoaded(sender, e);
        }

        #endregion

        #region - - - Methods - - -

        private void GetArticles(RecipeInfo recipe)
        {
            Wait = Visibility.Visible;
            List<Article> temp = new List<Article>();
            Task.Run(async () => 
            { 
                try
                {
                    DataTable DT = new MSSQLEAdapter("Recipes", "SELECT * FROM Recipes_Article; ").DB_Output();

                    if (DT.Rows.Count > 0)
                    {
                        foreach (DataRow r in DT.Rows)
                        {
                            await Task.Delay(20);

                            temp.Add(new Article()
                            {

                                Header = new RecipeInfo()
                                {
                                    Id = (int)r["Id"],
                                    Name = (string)r["Name"],
                                    Description = r["Description"] == DBNull.Value ? "" : ((string)r["Description"]),
                                    LastChanged = ((DateTime)r["LastChanged"]).ToString("dd.MM.yyyy HH:mm:ss"),
                                    User = (string)r["User"]
                                },
                                Art_Id = r["Art_Id"].ToString(),
                                Type_Id = (int)r["Type_Id"],
                                Size_Id = (int)r["Size_Id"],
                                LD = new LD()
                                {
                                    Header = new RecipeInfo()
                                    {
                                        Id = (int)r["Id"],
                                        Name = (string)r["Name"],
                                        Description = (string)r["Description"],
                                    },
                                    VWRecipe = new VWRecipe("LD", (string)r["LD_VWRecipe"])
                                },
                                BT = new BT()
                                {
                                    Header = new RecipeInfo()
                                    {
                                        Id = (int)r["Id"],
                                        Name = (string)r["Name"],
                                        Description = (string)r["Description"],
                                    },
                                    VWRecipe = new VWRecipe("BT", (string)r["BT_VWRecipe"])
                                },
                                PO = new PO()
                                {
                                    Header = new RecipeInfo()
                                    {
                                        Id = (int)r["Id"],
                                        Name = (string)r["Name"],
                                        Description = (string)r["Description"],
                                    },
                                    VWRecipe = new VWRecipe("PO", (string)r["PO_VWRecipe"])
                                }
                            });
                        }

                    }
                    Dispatcher.Invoke(delegate
                    {
                        try
                        {
                            TArticles = Articles = temp;
                            if (Articles.Where(t => t.Header.Name == recipe.Name).Count() != 0)
                            {
                                SelectedArticle = Articles.Where(t => t.Header.Name == recipe.Name).First();
                            }
                            else { SelectedArticle = new Article(); }
                        }
                        catch { }
                    });

                    await Task.Delay(1000);

                    Dispatcher.Invoke(delegate
                    {
                        Wait = Visibility.Hidden;
                    });
                }
                catch 
                {
                    Dispatcher.Invoke(delegate
                    {
                        Wait = Visibility.Hidden;
                    }); return;
                }
            });
        }

        private void UpdateName()
        {
            ((MainRegion.Recipes.Adapters.Recipes_PN)((MainRegion.Recipes.Views.Recipes_PN)iRS.GetView("Recipes_PN")).DataContext).Recipe = new RecipeInfo() { Name = NameBuffer, Description = DescriptionBuffer };
        }
        public List<Article> Convert(IEnumerable original)
        {
            return new List<Article>(original.Cast<Article>());
        }

        #endregion


    }
}