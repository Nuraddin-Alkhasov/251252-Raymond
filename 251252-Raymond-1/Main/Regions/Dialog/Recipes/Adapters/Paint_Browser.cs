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
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using VisiWin.ApplicationFramework;
using VisiWin.Commands;
using VisiWin.Recipe;

namespace HMI.DialogRegion.Recipes.Adapters
{
    [ExportAdapter("Paint_Browser")]
    public class Paint_Browser : AdapterBase
    {

        public Paint_Browser()
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
        public IRecipeClass Class = ApplicationService.GetService<IRecipeService>().GetRecipeClass("Paint");
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

        private List<Paint> paints { get; set; } = new List<Paint>();
        public List<Paint> Paints
        {
            get { return paints; }
            set
            {
                paints = value;

                OnPropertyChanged("Paints");
            }
        }
        private List<Paint> TPaints { get; set; } = new List<Paint>();

        private Paint selectedPaint { get; set; } = new Paint();
        public Paint SelectedPaint
        {
            get { return selectedPaint; }
            set
            {
                selectedPaint = value;
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
                OnPropertyChanged("SelectedPaint");
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
                        Paints = new List<Paint>();
                        foreach (Paint c in TPaints)
                        {
                            if (c.Header.Name.ToUpper().Contains(value.ToUpper()))
                            {
                                Paints.Add(c);
                            }
                        }
                        SelectedPaint = new Paint();
                    }
                    else
                    {
                        Paints = TPaints;
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
            if (SelectedPaint.Header.Id > 0)
            {
                ((MainRegion.Recipes.Adapters.Recipes_Paint)(iRS.GetView("MainRegion", "Recipes_Paint") as MainRegion.Recipes.Views.Recipes_Paint).DataContext).LoadPaint(SelectedPaint);
                CloseExecuted(null);
            }
        }

        public ICommand Save { get; set; }
        private void SaveExecuted(object parameter)
        {
            if (NameBuffer.Length >= 3)
            {
                Paint a = Paints.Where(x => x.Header.Name == NameBuffer).ToArray().Length > 0 ? Paints.Where(x => x.Header.Name == NameBuffer).ToArray()[0] : new Paint();
                if (a.Header.Id > 0)
                {
                    if (MessageBoxView.Show("@RecipeSystem.Results.OverwriteFileQuery", "@RecipeSystem.Results.SaveFile", MessageBoxButton.YesNo, icon: MessageBoxIcon.Question) == MessageBoxResult.No)
                    {
                        return;
                    }
                }
                int status = a.Check();

                if (status != 0)
                {
                    CloseExecuted(null);
                    switch (status)
                    {
                        case 1: new MessageBoxTask("@RecipeSystem.Check.Text56", "@RecipeSystem.Results.SaveFile", MessageBoxIcon.Exclamation); break;
                        case 2: new MessageBoxTask("@RecipeSystem.Check.Text57", "@RecipeSystem.Results.SaveFile", MessageBoxIcon.Exclamation); break;
                        case 3: new MessageBoxTask("@RecipeSystem.Check.Text58", "@RecipeSystem.Results.SaveFile", MessageBoxIcon.Exclamation); break;
                        case 4: new MessageBoxTask("@RecipeSystem.Check.Text59", "@RecipeSystem.Results.SaveFile", MessageBoxIcon.Exclamation); break;
                        case 5: new MessageBoxTask("@RecipeSystem.Check.Text60", "@RecipeSystem.Results.SaveFile", MessageBoxIcon.Exclamation); break;
                        case 6: new MessageBoxTask("@RecipeSystem.Check.Text61", "@RecipeSystem.Results.SaveFile", MessageBoxIcon.Exclamation); break;
                        case 7: new MessageBoxTask("@RecipeSystem.Check.Text62", "@RecipeSystem.Results.SaveFile", MessageBoxIcon.Exclamation); break;
                        case 8: new MessageBoxTask("@RecipeSystem.Check.Text63", "@RecipeSystem.Results.SaveFile", MessageBoxIcon.Exclamation); break;
                        case 9: new MessageBoxTask("@RecipeSystem.Check.Text64", "@RecipeSystem.Results.SaveFile", MessageBoxIcon.Exclamation); break;
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
                            SaveToFileFromBufferResult e = await Class.SaveToFileFromBufferAsync(NameBuffer, DescriptionBuffer, true);
                            if (e.Result != SaveRecipeResult.Succeeded)
                            {
                                new MessageBoxTask("@RecipeSystem.Results.SaveError", "@RecipeSystem.Results.Text2", MessageBoxIcon.Error);
                            }
                            else
                            {
                                if (a.Header.Id > 0)
                                {
                                    new MSSQLEAdapter("Recipes", "UPDATE Recipes_Paint " +
                                                          "SET " +
                                                          "Description = '" + DescriptionBuffer + "', " +
                                                          "VWRecipe = '" + File.ReadAllText(Class.CurrentPath + @"\\" + NameBuffer + ".R") + "', " +
                                                          "LastChanged = '" + DateTime.Now.ToString("yyyyMMdd HH:mm:ss") + "', " +
                                                          "[User] = '" + ApplicationService.GetVariableValue("__CURRENT_USER.FULLNAME").ToString() + "' " +
                                                          "WHERE Id = " + a.Header.Id + ";").DB_Input();

                                }
                                else
                                {
                                    new MSSQLEAdapter("Recipes", "INSERT " +
                                                          "INTO Recipes_Paint (Name, Description, VWRecipe, [User]) " +
                                                          "VALUES ('" +
                                                          NameBuffer + "','" +
                                                          DescriptionBuffer + "','" +
                                                          File.ReadAllText(Class.CurrentPath + @"\\" + NameBuffer + ".R") + "','" +
                                                          ApplicationService.GetVariableValue("__CURRENT_USER.FULLNAME").ToString() + "');").DB_Input();
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
                            }); return;
                        }
                    });
                } 
            }
        }

        public ICommand Delete { get; set; }
        private void DeleteExecuted(object parameter)
        {
            if (SelectedPaint.Header.Id > 0)
            {
                if (MessageBoxView.Show("@RecipeSystem.Results.DeleteFileQuery", "@RecipeSystem.Results.DeleteFile", MessageBoxButton.YesNo, icon: MessageBoxIcon.Question) == MessageBoxResult.Yes)
                {
                    Wait = Visibility.Visible;

                    Task.Run(async () =>
                    {
                        try
                        {
                            new MSSQLEAdapter("Recipes", "DELETE " +
                                                    "FROM Recipes_Paint " +
                                                    "WHERE Id = " + SelectedPaint.Header.Id + "; ").DB_Output();

                            Dispatcher.Invoke(delegate
                            {
                                Paints.Remove(SelectedPaint);
                                List<Paint> temp = paints;
                                Paints = new List<Paint>();
                                Paints = temp;
                                SelectedPaint = new Paint();

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
            Views.Paint_Browser v = (Views.Paint_Browser)iRS.GetView("Paint_Browser");
            new ObjectAnimator().CloseDialog1(v, v.border);
        }




        #endregion

        #region - - - Event handlers - - -

        protected override void OnViewLoaded(object sender, ViewLoadedEventArg e)
        {
            RecipeInfo temp = ApplicationService.ObjectStore.GetValue("Paint_Browser_KEY") as RecipeInfo;
            ApplicationService.ObjectStore.Remove("Paint_Browser_KEY");
            
            GetPaints(temp);

            filter = "";
            OnPropertyChanged("Filter");

            Views.Paint_Browser v = (Views.Paint_Browser)iRS.GetView("Paint_Browser");
            new ObjectAnimator().OpenDialog(v, v.border);

            base.OnViewLoaded(sender, e);
        }

        #endregion

        #region - - - Methods - - -

        private void GetPaints(RecipeInfo recipe)
        {
            Wait = Visibility.Visible;
            List<Paint> temp = new List<Paint>();
            Task.Run(async () =>
            {
                try
                {
                    DataTable DT = new MSSQLEAdapter("Recipes", "SELECT * FROM Recipes_Paint; ").DB_Output();

                    if (DT.Rows.Count > 0)
                    {
                        foreach (DataRow r in DT.Rows)
                        {
                            await Task.Delay(20);

                            temp.Add(new Paint()
                            {
                                Header = new RecipeInfo()
                                {
                                    Id = (int)r["Id"],
                                    Name = (string)r["Name"],
                                    Description = r["Description"] == DBNull.Value ? "" : ((string)r["Description"]),
                                    LastChanged = ((DateTime)r["LastChanged"]).ToString("dd.MM.yyyy HH:mm:ss"),
                                    User = (string)r["User"]
                                },
                                VWRecipe = new VWRecipe()
                                {
                                    Class = "Paint",
                                    Data = r["VWRecipe"].ToString()
                                }
                            });
                        }
                    }
                    Dispatcher.Invoke(delegate
                    {
                        try
                        {
                            TPaints = Paints = temp;
                            if (Paints.Where(t => t.Header.Name == recipe.Name).Count() != 0)
                            {
                                SelectedPaint = Paints.Where(t => t.Header.Name == recipe.Name).First();
                            }
                            else { SelectedPaint = new Paint(); }
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

        public List<Paint> Convert(IEnumerable original)
        {
            return new List<Paint>(original.Cast<Paint>());
        }

        #endregion


    }
}