using HMI.CO.General;
using HMI.CO.Recipe;
using HMI.Resources;
using HMI.Resources.UserControls;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using VisiWin.ApplicationFramework;
using VisiWin.Commands;
using VisiWin.Controls;

namespace HMI.MainRegion.Recipes.Adapters
{

    [ExportAdapter("Recipes_MR")]
    public class Recipes_MR : AdapterBase
    {
        readonly IRegionService iRS = ApplicationService.GetService<IRegionService>();
        public Recipes_MR()
        {
            New = new ActionCommand(NewExecuted);
            DeleteArticle = new ActionCommand(DeleteArticleExecuted);
            DeleteCoating = new ActionCommand(DeleteCoatingExecuted);
            AssignPP = new ActionCommand(AssignPPExecuted);
            AssignMP = new ActionCommand(AssignMPExecuted);
           

            ArticleUp = new ActionCommand(ArticleUpExecuted);
            ArticleDown = new ActionCommand(ArticleDownExecuted);
            CoatingUp = new ActionCommand(CoatingUpExecuted);
            CoatingDown = new ActionCommand(CoatingDownExecuted);
        }

        #region - - - Properties - - -
        private Visibility wait1 { get; set; } = Visibility.Hidden;
        public Visibility Wait1
        {
            get { return wait1; }
            set
            {
                wait1 = value;
                OnPropertyChanged("Wait1");
            }
        }
        private Visibility wait2 { get; set; } = Visibility.Hidden;
        public Visibility Wait2
        {
            get { return wait2; }
            set
            {
                wait2 = value;
                OnPropertyChanged("Wait2");
            }
        }


        private string filter1 = "";
        public string Filter1
        {
            get { return filter1; }
            set
            {
                if (filter1 != value)
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
                        ArticleIndex = -1;
                    }
                    else
                    {
                        Articles = TArticles;
                    }
                    filter1 = value;
                    OnPropertyChanged("Filter1");
                }
            }
        }

        private string filter2 = "";
        public string Filter2
        {
            get { return filter2; }
            set
            {
                if (filter2 != value)
                {
                    if (value != "")
                    {
                        Coatings = new List<Coating>();
                        foreach (Coating c in TCoatings) 
                        {
                            if (c.Header.Name.ToUpper().Contains(value.ToUpper())) 
                            {
                                Coatings.Add(c);
                            }
                        }
                        CoatingIndex = -1;
                    }
                    else
                    {
                        Coatings = TCoatings;
                    }
                    filter2 = value;
                    OnPropertyChanged("Filter2");
                }
            }
        }

        List<Article> articles = new List<Article>();
        public List<Article> Articles
        {
            get { return articles; }
            set
            {
                articles = value;
                //if (value.Count >= 1) ArticleRecipeSelectedIndex = 0;
                OnPropertyChanged("Articles");
            }
        }
        private List<Article> TArticles { get; set; } = new List<Article>();
        bool isArticleChecked = false;
        public bool IsArticleChecked
        {
            get { return this.isArticleChecked; }
            set
            {
                if (value)
                {
                    ArticleIndex = Articles.Count > 1 ? 0 : -1;
                }
                else
                {
                    ArticleIndex = -1;
                }
                this.isArticleChecked = value;
                this.OnPropertyChanged("IsArticleChecked");
            }
        }

        private int articleIndex = -1;
        public int ArticleIndex
        {
            get { return articleIndex; }
            set
            {
                articleIndex = value;
                OnPropertyChanged("ArticleIndex");

            }
        }

        List<Coating> coatings = new List<Coating>();
        public List<Coating> Coatings
        {
            get { return coatings; }
            set
            {
                coatings = value;
                //if (value.Count >= 1) ArticleRecipeSelectedIndex = 0;
                OnPropertyChanged("Coatings");
            }
        }

        bool isCoatingChecked = false;
        public bool IsCoatingChecked
        {
            get { return this.isCoatingChecked; }
            set
            {
                if (value)
                {
                    CoatingIndex = Coatings.Count > 1 ? 0 : -1;
                }
                else
                {
                    CoatingIndex = -1;
                }
                this.isCoatingChecked = value;
                this.OnPropertyChanged("IsCoatingChecked");
            }
        }
        private int coatingIndex = -1;
        public int CoatingIndex
        {
            get { return coatingIndex; }
            set
            {
                coatingIndex = value;
                OnPropertyChanged("CoatingIndex");

            }
        }
        private List<Coating> TCoatings { get; set; } = new List<Coating>();
        MR_Article articleBuffer;
        public MR_Article ArticleBuffer
        {
            get { return articleBuffer; }
            set
            {
                articleBuffer = value;
                //if (value.Count >= 1) ArticleRecipeSelectedIndex = 0;
                OnPropertyChanged("ArticleBuffer");
            }
        }

        ObservableCollection<object> coating = new ObservableCollection<object>();
        public ObservableCollection<object> CoatingBuffer
        {
            get { return coating; }
            set
            {
                coating = value;
                OnPropertyChanged("CoatingBuffer");
            }
        }

        private object selectedCoating;
        public object SelectedCoating
        {
            get { return selectedCoating; }
            set
            {
                if (value != null)
                {
                    if (value.ToString() == "Recipe_Add")
                    {
                        selectedCoating = ((MR_Layer)CoatingBuffer[CoatingBuffer.Count - 2]);
                    }
                    selectedCoating = value;
                }
                else
                {
                    selectedCoating = value;
                }

                OnPropertyChanged("SelectedCoating");
            }
        }


        StateCollection paintTypes = new StateCollection();
        public StateCollection PaintTypes
        {
            get { return paintTypes; }
            set
            {
                if (value != null)
                {
                    paintTypes = value;
                    OnPropertyChanged("PaintTypes");
                }
            }
        }

        public MR LastLoadedSavedMR { set; get; } = new MR();
        StateCollection paints { set; get; } = new StateCollection();
        StateCollection Paints 
        {
            get { return paints; }
            set 
            {
                paints = value;
                OnPropertyChanged("PaintTypes");
            }
        }
        #endregion

        #region - - - Commands - - - 

        public ICommand New { get; set; }
        private void NewExecuted(object parameter)
        {
            if (CoatingBuffer.Count == 5)
            {
                CoatingBuffer.RemoveAt(4);
                AddRecipe(new MR_Layer() { Id = CoatingBuffer.Count, LocalizableLabelText = "@Lists.CoatingLayers.Text" + CoatingBuffer.Count.ToString() });
            }
            else
            {
                AddRecipe(new MR_Layer() { Id = CoatingBuffer.Count - 1, LocalizableLabelText = "@Lists.CoatingLayers.Text" + (CoatingBuffer.Count - 1).ToString() });

            }

        }
        public ICommand DeleteArticle { get; set; }
        private void DeleteArticleExecuted(object parameter)
        {
            ArticleBuffer.Article = new Article();
        }

        public ICommand DeleteCoating { get; set; }
        private void DeleteCoatingExecuted(object parameter)
        {
            if (CoatingBuffer.Count == 2)
            {
                ((MR_Layer)CoatingBuffer[0]).MCP = new MCP();
            }
            else
            {
                CoatingBuffer.RemoveAt(((MR_Layer)parameter).Id);
                if (CoatingBuffer[CoatingBuffer.Count - 1].ToString() != "MR_Add")
                {
                    AddAddBtn();
                }

                for (int i = 0; i < CoatingBuffer.Count; i++)
                {
                    if (CoatingBuffer[i].ToString() != "MR_Add")
                    {
                        ((MR_Layer)CoatingBuffer[i]).Id = i;
                        ((MR_Layer)CoatingBuffer[i]).LocalizableLabelText = "@Lists.CoatingLayers.Text" + i;

                    }

                }

                    ((MR_Layer)CoatingBuffer[0]).A.IsChecked = true;
            }
        }
        public ICommand AssignPP { get; set; }
        private void AssignPPExecuted(object parameter)
        {
            ApplicationService.SetView("DialogRegion1", "Paint_Binding");
        }
        public ICommand AssignMP { get; set; }
        private void AssignMPExecuted(object parameter)
        {
            ApplicationService.SetView("DialogRegion1", "MP_Binding");
        }

        public ICommand ArticleUp { get; set; }
        private void ArticleUpExecuted(object parameter)
        {
            if (!IsArticleChecked) IsArticleChecked = true;
            if (ArticleIndex < Articles.Count - 1)
                ArticleIndex += 1;
        }
        public ICommand ArticleDown { get; set; }
        private void ArticleDownExecuted(object parameter)
        {
            if (!IsArticleChecked) IsArticleChecked = true;
            if (ArticleIndex > 0)
                ArticleIndex -= 1;
        }

        public ICommand CoatingUp { get; set; }
        private void CoatingUpExecuted(object parameter)
        {
            if (!IsCoatingChecked) IsCoatingChecked = true;
            if (CoatingIndex < Coatings.Count - 1)
                CoatingIndex += 1;
        }
        public ICommand CoatingDown { get; set; }
        private void CoatingDownExecuted(object parameter)
        {
            if (!IsCoatingChecked) IsCoatingChecked = true;
            if (CoatingIndex > 0)
                CoatingIndex -= 1;
        }
        #endregion

        #region - - - Event Handlers - - -
        protected override void OnViewLoaded(object sender, ViewLoadedEventArg e)
        {
            if (sender.GetType().Name == e.View.GetType().Name)
            {
                GetArticles();
                GetCoatings();
                FeedWithItems();
                
                filter1 = "";
                OnPropertyChanged("Filter1");
                filter2 = "";
                OnPropertyChanged("Filter2");

            }

            base.OnViewLoaded(sender, e);
        }
        protected override void OnViewUnloaded(object sender, ViewUnloadedEventArg e)
        {
            base.OnViewUnloaded(sender, e);
        }

        #endregion





        #region - - - Methods - - -
        public void GetArticles()
        {
            Wait1 = Visibility.Visible;
            List<Article> temp = new List<Article>();
            Task obTask = Task.Run(async () =>
            {
                DataTable DT = new MSSQLEAdapter("Recipes", "SELECT * FROM Recipes_Article; ").DB_Output();

                if (DT.Rows.Count > 0)
                {
                    foreach (DataRow r in DT.Rows)
                    {
                        await Task.Delay(50);
                        temp.Add(new Article()
                        {
                            Header = new RecipeInfo()
                            {
                                Id = (int)r["Id"],
                                Name = (string)r["Name"],
                                Description = r["Description"] == DBNull.Value ? "" : ((string)r["Description"]),
                            },
                            Art_Id= r["Art_Id"].ToString(),
                            Type_Id= (int)r["Type_Id"],
                            Size_Id= (int)r["Size_Id"],
                            LD = new LD()
                            {
                                Header = new RecipeInfo()
                                {
                                    Id = (int)r["Id"],
                                    Name = (string)r["Name"],
                                    Description = r["Description"] == DBNull.Value ? "" : (string)r["Description"],
                                },
                                VWRecipe = new VWRecipe("LD", (string)r["LD_VWRecipe"])
                            },
                            BT = new BT()
                            {
                                Header = new RecipeInfo()
                                {
                                    Id = (int)r["Id"],
                                    Name = (string)r["Name"],
                                    Description = r["Description"] == DBNull.Value ? "" : (string)r["Description"],
                                },
                                VWRecipe = new VWRecipe("BT", (string)r["BT_VWRecipe"])
                            },
                            PO = new PO()
                            {
                                Header = new RecipeInfo()
                                {
                                    Id = (int)r["Id"],
                                    Name = (string)r["Name"],
                                    Description = r["Description"] == DBNull.Value ? "" : (string)r["Description"],
                                },
                                VWRecipe = new VWRecipe("PO", (string)r["PO_VWRecipe"])
                            }
                        });
                    }


                }

            });

            obTask.ContinueWith(x =>
            {
                Application.Current.Dispatcher.Invoke(delegate
                {
                    TArticles = Articles = temp;
                    Wait1 = Visibility.Hidden;
                });
            }, TaskContinuationOptions.OnlyOnRanToCompletion);
        }

        public void GetCoatings()
        {
            Wait2 = Visibility.Visible;
            List<Coating> temp = new List<Coating>();
            Task obTask = Task.Run(async () =>
            {
                DataTable DT = new MSSQLEAdapter("Recipes", "SELECT * FROM Recipes_Coating; ").DB_Output();

                if (DT.Rows.Count > 0)
                {
                    foreach (DataRow r in DT.Rows)
                    {
                        await Task.Delay(50);

                        temp.Add(new Coating()
                        {
                            Header = new RecipeInfo()
                            {
                                Id = (int)r["Id"],
                                Name = (string)r["Name"],
                                Description = r["Description"] == DBNull.Value ? "" : ((string)r["Description"]),
                                LastChanged = ((DateTime)r["LastChanged"]).ToString("dd.MM.yyyy HH:mm:ss"),
                                User = (string)r["User"]
                            },
                            VWRecipe = new VWRecipe((string)r["VWRecipe"])
                            {
                                Class = "Coating"
                            }
                        });
                    }


                }

            });

            obTask.ContinueWith(x =>
            {
                Application.Current.Dispatcher.Invoke(delegate
                {
                    TCoatings = Coatings = temp;
                    Wait2 = Visibility.Hidden;
                });
            }, TaskContinuationOptions.OnlyOnRanToCompletion);


        }

        public void FeedWithItems()
        {
            ArticleBuffer = new MR_Article();
            CoatingBuffer.Clear();

            AddRecipe(new MR_Layer() { Id = 0, LocalizableLabelText = "@Lists.CoatingLayers.Text0" });
            AddAddBtn();
        }

        

        public List<Article> ConvertArticle(IEnumerable original)
        {
            return new List<Article>(original.Cast<Article>());
        }
        public List<Coating> ConvertCoating(IEnumerable original)
        {
            return new List<Coating>(original.Cast<Coating>());
        }
        public void AddRecipe(MR_Layer mrc)
        {

            mrc._del.Command = DeleteCoating;
            mrc._del.CommandParameter = mrc;
            mrc._paint.ItemsSource = PaintTypes;


            for (int i = 0; i < CoatingBuffer.Count; i++)
            {
                if (CoatingBuffer[i].ToString() != "MR_Add")
                {
                    ((MR_Layer)CoatingBuffer[i]).A.IsChecked = false;

                }
            }

            if (CoatingBuffer.Count > 0 && CoatingBuffer[CoatingBuffer.Count - 1].ToString() == "MR_Add")
            {
                CoatingBuffer.Insert(CoatingBuffer.Count - 1, mrc);

            }
            else
            {
                CoatingBuffer.Insert(CoatingBuffer.Count, mrc);
            }

        }

        public void AddAddBtn()
        {

            CoatingBuffer.Add(new MR_Add());
            ((MR_Add)CoatingBuffer[CoatingBuffer.Count - 1]).Addbtn.Command = New;

        }

        public void LoadMR(MR mr)
        {
            
            MR temp = new MR();
            ((Adapters.Recipes_PN)((Views.Recipes_PN)iRS.GetView("Recipes_PN")).DataContext).Wait = Visibility.Visible;

            Task obTask = Task.Run(async () =>
            {
                try
                {
                    DataTable A = new MSSQLEAdapter("Recipes", "SELECT * FROM Recipes_Article WHERE Id = " + mr.Article.Header.Id + "; ").DB_Output();

                    Article a = new Article();
                    if (A.Rows.Count > 0)
                    {

                        a = new Article()
                        {
                            Header = new RecipeInfo()
                            {
                                Id = (int)A.Rows[0]["Id"],
                                Name = (string)A.Rows[0]["Name"],
                                Description = A.Rows[0]["Description"] == DBNull.Value ? "" : ((string)A.Rows[0]["Description"]),
                                LastChanged = ((DateTime)A.Rows[0]["LastChanged"]).ToString("dd.MM.yyyy HH:mm:ss"),
                                User = (string)A.Rows[0]["User"]
                            },
                            Art_Id= A.Rows[0]["Art_Id"].ToString(),
                            Type_Id= (int)A.Rows[0]["Type_Id"],
                            Size_Id= (int)A.Rows[0]["Size_Id"],
                            LD = new LD()
                            {
                                Header = new RecipeInfo()
                                {
                                    Id = (int)A.Rows[0]["Id"],
                                    Name = (string)A.Rows[0]["Name"],
                                    Description = A.Rows[0]["Description"] == DBNull.Value ? "" : ((string)A.Rows[0]["Description"]),
                                },
                                VWRecipe = new VWRecipe("LD", (string)A.Rows[0]["LD_VWRecipe"])
                            },
                            BT = new BT()
                            {
                                Header = new RecipeInfo()
                                {
                                    Id = (int)A.Rows[0]["Id"],
                                    Name = (string)A.Rows[0]["Name"],
                                    Description = A.Rows[0]["Description"] == DBNull.Value ? "" : ((string)A.Rows[0]["Description"]),
                                },
                                VWRecipe = new VWRecipe("BT", (string)A.Rows[0]["BT_VWRecipe"])
                            },
                            PO = new PO()
                            {
                                Header = new RecipeInfo()
                                {
                                    Id = (int)A.Rows[0]["Id"],
                                    Name = (string)A.Rows[0]["Name"],
                                    Description = A.Rows[0]["Description"] == DBNull.Value ? "" : ((string)A.Rows[0]["Description"]),
                                },
                                VWRecipe = new VWRecipe("PO", (string)A.Rows[0]["PO_VWRecipe"])
                            }
                        };
                    }
                    Dispatcher.Invoke(delegate
                    {
                        ArticleBuffer.Article = a;
                    });

                    List<MCP> temp2 = new List<MCP>();
                    if (mr.Layers.Count > 0)
                    {
                        for (int i = 0; i < mr.Layers.Count; i++)
                        {
                            if (mr.Layers[i].Coating.Header.Id != -1)
                            {
                                DataTable C = new MSSQLEAdapter("Recipes", "SELECT * FROM Recipes_Coating WHERE Id = " + mr.Layers[i].Coating.Header.Id + "; ").DB_Output();

                                temp2.Add(new MCP()
                                {
                                    Machine = mr.Layers[i].Machine,
                                    Coating = new Coating()
                                    {
                                        Header = new RecipeInfo()
                                        {
                                            Id = (int)C.Rows[0]["Id"],
                                            Name = (string)C.Rows[0]["Name"],
                                            Description = C.Rows[0]["Description"] == DBNull.Value ? "" : ((string)C.Rows[0]["Description"]),
                                        },
                                        VWRecipe = new VWRecipe((string)C.Rows[0]["VWRecipe"])
                                        {
                                            Class = "Coating"
                                        }
                                    },
                                    Paint = new Paint()
                                    {
                                        Header = new RecipeInfo()
                                        {
                                            Id = mr.Layers[i].Paint.Header.Id
                                        }
                                    }
                                });
                                await Task.Delay(30);
                            }
                        }
                    }
                    else
                    {
                        temp2.Add(new MCP());
                    }

                    Dispatcher.Invoke(delegate
                    {
                        CoatingBuffer.Clear();
                    });

                    await Task.Delay(100);

                    for (int i = 0; i < temp2.Count; i++)
                    {
                        Dispatcher.Invoke(delegate
                        {
                            AddRecipe(new MR_Layer()
                            {
                                Id = i,
                                LocalizableLabelText = "@Lists.CoatingLayers.Text" + i.ToString(),
                                MCP = temp2[i]
                            });
                        });
                        await Task.Delay(100);
                    }

                    Dispatcher.Invoke(delegate
                    {
                        if (temp2.Count < 5)
                            AddAddBtn();
                    });

                    await Task.Delay(100);
                }
                catch (Exception e)
                {
                    new MessageBoxTask(e, "", MessageBoxIcon.Error);
                }
               
                   
            });
            obTask.ContinueWith(x =>
            {

                Dispatcher.Invoke(delegate
                {
                    ((Adapters.Recipes_PN)((Views.Recipes_PN)iRS.GetView("Recipes_PN")).DataContext).Wait = Visibility.Hidden;
                });
            }, TaskContinuationOptions.OnlyOnRanToCompletion);
            UpdateName(mr);

            LastLoadedSavedMR = mr;
        }
        public void LoadMRFromPLC(uint MR_Id) 
        {
            try
            {
                DataTable DT = new MSSQLEAdapter("Recipes", "SELECT * FROM Recipes_MR WHERE Id= " + MR_Id + "; ").DB_Output();
                MR temp = new MR();
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
                    temp.Article = new Article()
                    {
                        Header = new RecipeInfo()
                        {
                            Id = (int)DT.Rows[0]["Article_Id"]
                        }

                    };
                    temp.Layers = new List<MCP>()
                    {
                        new MCP()
                        {
                            Machine = (int)DT.Rows[0]["M0_Id"],
                            Coating = new CO.Recipe.Coating() { Header = new RecipeInfo() { Id = (int)DT.Rows[0]["C0_Id"] } },
                            Paint = new CO.Recipe.Paint() { Header = new RecipeInfo() { Id = (int)DT.Rows[0]["P0_Id"] } }
                        },
                        new MCP()
                        {
                            Machine = (int)DT.Rows[0]["M1_Id"],
                            Coating = new CO.Recipe.Coating() { Header = new RecipeInfo() { Id = (int)DT.Rows[0]["C1_Id"] } },
                            Paint = new CO.Recipe.Paint() { Header = new RecipeInfo() { Id = (int)DT.Rows[0]["P1_Id"] } }
                        },
                        new MCP()
                        {
                            Machine = (int)DT.Rows[0]["M2_Id"],
                            Coating = new CO.Recipe.Coating() { Header = new RecipeInfo() { Id = (int)DT.Rows[0]["C2_Id"] } },
                            Paint = new CO.Recipe.Paint() { Header = new RecipeInfo() { Id = (int)DT.Rows[0]["P2_Id"] } }
                        },
                        new MCP()
                        {
                            Machine = (int)DT.Rows[0]["M3_Id"],
                            Coating = new CO.Recipe.Coating() { Header = new RecipeInfo() { Id = (int)DT.Rows[0]["C3_Id"] } },
                            Paint = new CO.Recipe.Paint() { Header = new RecipeInfo() { Id = (int)DT.Rows[0]["P3_Id"] } }
                        },
                        new MCP()
                        {
                            Machine = (int)DT.Rows[0]["M4_Id"],
                            Coating = new CO.Recipe.Coating() { Header = new RecipeInfo() { Id = (int)DT.Rows[0]["C4_Id"] } },
                            Paint = new CO.Recipe.Paint() { Header = new RecipeInfo() { Id = (int)DT.Rows[0]["P4_Id"] } }
                        }
                    };
                }

                LoadMR(temp);
            }
            catch { }

        }
        private void UpdateName(MR mr)
        {
            ((Adapters.Recipes_PN)((Views.Recipes_PN)iRS.GetView("Recipes_PN")).DataContext).Recipe = mr.Header;
        }
        #endregion

    }


}