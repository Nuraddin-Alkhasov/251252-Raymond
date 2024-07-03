using HMI.CO.General;
using HMI.CO.Recipe;
using HMI.MessageBoxRegion.Views;
using HMI.Resources;
using HMI.Resources.UserControls;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using VisiWin.ApplicationFramework;
using VisiWin.Commands;
using VisiWin.Recipe;

namespace HMI.DialogRegion.Recipes.Adapters
{
    [ExportAdapter("MP_Browser")]
    public class MP_Browser : AdapterBase
    {

        public MP_Browser()
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
        public IRecipeClass Class = ApplicationService.GetService<IRecipeService>().GetRecipeClass("Article");
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

        private List<MR> mrs { get; set; } = new List<MR>();
        public List<MR> MRs
        {
            get { return mrs; }
            set
            {
                mrs = value;

                OnPropertyChanged("MRs");
            }
        }
        private List<MR> TMRs { get; set; } = new List<MR>();

        private MR selectedMR { get; set; } = new MR();
        public MR SelectedMR
        {
            get { return selectedMR; }
            set
            {
                selectedMR = value;
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


                OnPropertyChanged("SelectedMR");
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
                        MRs = new List<MR>();
                        foreach (MR c in TMRs)
                        {
                            if (c.Header.Name.ToUpper().Contains(value.ToUpper()))
                            {
                                MRs.Add(c);
                            }
                        }
                       
                        SelectedMR = new MR();
                    }
                    else
                    {
                        MRs = TMRs;
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
            if (SelectedMR.Header.Id > 0)
            {
                ((MainRegion.Recipes.Adapters.Recipes_MR)(iRS.GetView("MainRegion", "Recipes_MR") as MainRegion.Recipes.Views.Recipes_MR).DataContext).LoadMR(SelectedMR);
                CloseExecuted(null);
            }
        }

        public ICommand Save { get; set; }
        private void SaveExecuted(object parameter)
        {
            if (NameBuffer.Length >= 3)
            {
                MR mr = MRs.Where(x => x.Header.Name == NameBuffer).ToArray().Length > 0 ? MRs.First(x => x.Header.Name == NameBuffer) : new MR();
                if (mr.Header.Id > 0)
                {
                    if (MessageBoxView.Show("@RecipeSystem.Results.OverwriteFileQuery", "@RecipeSystem.Results.SaveFile", MessageBoxButton.YesNo, icon: MessageBoxIcon.Question) == MessageBoxResult.No)
                    {
                        return;
                    }
                }
                MainRegion.Recipes.Views.Recipes_MR v = (MainRegion.Recipes.Views.Recipes_MR)iRS.GetView("Recipes_MR");
                MainRegion.Recipes.Adapters.Recipes_MR dc = (MainRegion.Recipes.Adapters.Recipes_MR)v.DataContext;


                mr.Header.Name = NameBuffer;
                mr.Header.Description = DescriptionBuffer;

                mr.Article = dc.ArticleBuffer.Article;

                List<MCP> temp = new List<MCP>();
                for (int i = 0; i < dc.CoatingBuffer.Count; i++)
                {
                    if (dc.CoatingBuffer[i].ToString() == "MR_Layer")
                    {
                        temp.Add(((MR_Layer)dc.CoatingBuffer[i]).MCP);
                    }
                }

                mr.Layers = temp;

                int status = mr.Check();
                if (status != 0)
                {
                    CloseExecuted(null);
                    switch (status)
                    {
                        case 1: new MessageBoxTask("@RecipeSystem.Check.Text40", "@RecipeSystem.Results.SaveFile", MessageBoxIcon.Exclamation); break;
                        case 2: new MessageBoxTask("@RecipeSystem.Check.Text41", "@RecipeSystem.Results.SaveFile", MessageBoxIcon.Exclamation); break;
                        case 3: new MessageBoxTask("@RecipeSystem.Check.Text42", "@RecipeSystem.Results.SaveFile", MessageBoxIcon.Exclamation); break;
                        case 4: new MessageBoxTask("@RecipeSystem.Check.Text43", "@RecipeSystem.Results.SaveFile", MessageBoxIcon.Exclamation); break;
                        case 5: new MessageBoxTask("@RecipeSystem.Check.Text44", "@RecipeSystem.Results.SaveFile", MessageBoxIcon.Exclamation); break;
                        case 6: new MessageBoxTask("@RecipeSystem.Check.Text45", "@RecipeSystem.Results.SaveFile", MessageBoxIcon.Exclamation); break;
                        case 7: new MessageBoxTask("@RecipeSystem.Check.Text46", "@RecipeSystem.Results.SaveFile", MessageBoxIcon.Exclamation); break;
                        case 8: new MessageBoxTask("@RecipeSystem.Check.Text47", "@RecipeSystem.Results.SaveFile", MessageBoxIcon.Exclamation); break;
                        case 9: new MessageBoxTask("@RecipeSystem.Check.Text48", "@RecipeSystem.Results.SaveFile", MessageBoxIcon.Exclamation); break;
                        case 10: new MessageBoxTask("@RecipeSystem.Check.Text49", "@RecipeSystem.Results.SaveFile", MessageBoxIcon.Exclamation); break;
                        case 11: new MessageBoxTask("@RecipeSystem.Check.Text50", "@RecipeSystem.Results.SaveFile", MessageBoxIcon.Exclamation); break;
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
                            if (mr.Header.Id > 0)
                    {
                        string UpdateData = ", Article_Id = " + dc.ArticleBuffer.Article.Header.Id.ToString();
                        for (int i = 0; i < mr.Layers.Count; i++)
                        {
                            UpdateData += ", M" + i.ToString() + "_Id = " + mr.Layers[i].Machine.ToString();
                            UpdateData += ", C" + i.ToString() + "_Id = " + mr.Layers[i].Coating.Header.Id.ToString();
                            UpdateData += ", P" + i.ToString() + "_Id = " + mr.Layers[i].Paint.Header.Id.ToString();
                        }
                        if (mr.Layers.Count < 5)
                        {
                            for (int i = mr.Layers.Count; i < 5; i++)
                            {
                                UpdateData += ", M" + i.ToString() + "_Id = -1";
                                UpdateData += ", C" + i.ToString() + "_Id = -1";
                                UpdateData += ", P" + i.ToString() + "_Id = -1";
                            }
                        }

                        new MSSQLEAdapter("Recipes", "UPDATE Recipes_MR " +
                                                "SET " +
                                                "Description = '" + DescriptionBuffer + "'" +
                                                UpdateData +
                                                ",LastChanged = '" + DateTime.Now.ToString("yyyyMMdd HH:mm:ss") + "', " +
                                                "[User] = '" + ApplicationService.GetVariableValue("__CURRENT_USER.FULLNAME").ToString() + "' " +
                                                "WHERE Id = " + mr.Header.Id + ";").DB_Input();
                    }
                            else
                            {
                                string ColumnNames = ", Article_Id";
                                string Values = "," + mr.Article.Header.Id.ToString();

                                for (int i = 0; i < mr.Layers.Count; i++)
                                {
                                    ColumnNames += ", M" + i.ToString() + "_Id";
                                    ColumnNames += ", C" + i.ToString() + "_Id";
                                    ColumnNames += ", P" + i.ToString() + "_Id";
                                    Values += ", " + mr.Layers[i].Machine.ToString();
                                    Values += ", " + mr.Layers[i].Coating.Header.Id.ToString();
                                    Values += ", " + mr.Layers[i].Paint.Header.Id.ToString();
                                }

                                new MSSQLEAdapter("Recipes", "INSERT " +
                                                    "INTO Recipes_MR (Name, Description " + ColumnNames + ", [User]) " +
                                                    "VALUES ('" +
                                                    NameBuffer + "', '" +
                                                    DescriptionBuffer + "'" +
                                                    Values + ", '" +
                                                    ApplicationService.GetVariableValue("__CURRENT_USER.FULLNAME").ToString() + "');").DB_Input();
                            }
                            
                           
                            Dispatcher.Invoke(delegate
                            {
                                UpdateName();
                                dc.LastLoadedSavedMR = mr;
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
                            }); return;
                        }
                    });
                }
            }
        }

        public ICommand Delete { get; set; }
        private void DeleteExecuted(object parameter)
        {
            if (SelectedMR.Header.Id > 0)
            {
                if (MessageBoxView.Show("@RecipeSystem.Results.DeleteFileQuery", "@RecipeSystem.Results.DeleteFile", MessageBoxButton.YesNo, icon: MessageBoxIcon.Question) == MessageBoxResult.Yes)
                {
                    Wait = Visibility.Visible;

                    Task.Run(async () =>
                    {
                        try
                        {
                            new MSSQLEAdapter("Recipes", "DELETE " +
                                                    "FROM Recipes_MR " +
                                                    "WHERE Id = " + SelectedMR.Header.Id + "; ").DB_Output();
                            Dispatcher.Invoke(delegate
                            {
                                MRs.Remove(SelectedMR);
                                List<MR> temp = mrs;
                                MRs = new List<MR>();
                                MRs = temp;
                                SelectedMR = new MR();

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
            Views.MP_Browser v = (Views.MP_Browser)iRS.GetView("MP_Browser");
            new ObjectAnimator().CloseDialog1(v, v.border);
        }




        #endregion

        #region - - - Event handlers - - -

        protected override void OnViewLoaded(object sender, ViewLoadedEventArg e)
        {
            RecipeInfo temp = ApplicationService.ObjectStore.GetValue("MP_Browser_KEY") as RecipeInfo;
            ApplicationService.ObjectStore.Remove("MP_Browser_KEY");
            
            GetMRs(temp);

            filter = "";
            OnPropertyChanged("Filter");

            Views.MP_Browser v = (Views.MP_Browser)iRS.GetView("MP_Browser");
            new ObjectAnimator().OpenDialog(v, v.border);

            base.OnViewLoaded(sender, e);
        }

        #endregion

        #region - - - Methods - - -

        private void GetMRs(RecipeInfo recipe)
        {
            Wait = Visibility.Visible;
            List<MR> temp = new List<MR>();
            Task.Run(async () =>
            {
                try
                {
                    DataTable DT = new MSSQLEAdapter("Recipes", "SELECT * FROM Recipes_MR; ").DB_Output();

                    if (DT.Rows.Count > 0)
                    {
                        foreach (DataRow r in DT.Rows)
                        {
                            await Task.Delay(20);

                            temp.Add(new MR()
                            {

                                Header = new RecipeInfo()
                                {
                                    Id = (int)r["Id"],
                                    Name = (string)r["Name"],
                                    Description = r["Description"] == DBNull.Value ? "" : ((string)r["Description"]),
                                    LastChanged = ((DateTime)r["LastChanged"]).ToString("dd.MM.yyyy HH:mm:ss"),
                                    User = (string)r["User"]
                                },
                                Article = new Article()
                                {
                                    Header = new RecipeInfo()
                                    {
                                        Id = (int)r["Article_Id"]
                                    }

                                },
                                Layers = new List<MCP>()
                                {
                                    new MCP()
                                    {
                                        Machine = (int)r["M0_Id"],
                                        Coating = new CO.Recipe.Coating() { Header = new RecipeInfo() { Id = (int)r["C0_Id"] } },
                                        Paint = new CO.Recipe.Paint() { Header = new RecipeInfo() { Id = (int)r["P0_Id"] } }
                                    },
                                    new MCP()
                                    {
                                        Machine = (int)r["M1_Id"],
                                        Coating = new CO.Recipe.Coating() { Header = new RecipeInfo() { Id = (int)r["C1_Id"] } },
                                        Paint = new CO.Recipe.Paint() { Header = new RecipeInfo() { Id = (int)r["P1_Id"] } }
                                    },
                                    new MCP()
                                    {
                                        Machine = (int)r["M2_Id"],
                                        Coating = new CO.Recipe.Coating() { Header = new RecipeInfo() { Id = (int)r["C2_Id"] } },
                                        Paint = new CO.Recipe.Paint() { Header = new RecipeInfo() { Id = (int)r["P2_Id"] } }
                                    },
                                    new MCP()
                                    {
                                        Machine = (int)r["M3_Id"],
                                        Coating = new CO.Recipe.Coating() { Header = new RecipeInfo() { Id = (int)r["C3_Id"] } },
                                        Paint = new CO.Recipe.Paint() { Header = new RecipeInfo() { Id = (int)r["P3_Id"] } }
                                    },
                                    new MCP()
                                    {
                                        Machine = (int)r["M4_Id"],
                                        Coating = new CO.Recipe.Coating() { Header = new RecipeInfo() { Id = (int)r["C4_Id"] } },
                                        Paint = new CO.Recipe.Paint() { Header = new RecipeInfo() { Id = (int)r["P4_Id"] } }
                                    }
                                }
                            });
                        }


                    }
                    
                    Dispatcher.Invoke(delegate
                    {
                        try
                        {
                            TMRs = MRs = temp;
                            if (MRs.Where(t => t.Header.Name == recipe.Name).Count() != 0)
                            {
                                SelectedMR = MRs.Where(t => t.Header.Name == recipe.Name).First();
                            }
                            else { SelectedMR = new MR(); }
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

        public List<MR> Convert(IEnumerable original)
        {
            return new List<MR>(original.Cast<MR>());
        }

        #endregion


    }
}