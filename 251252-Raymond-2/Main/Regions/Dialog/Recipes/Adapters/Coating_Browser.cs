﻿using HMI.CO.General;
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
    [ExportAdapter("Coating_Browser")]
    public class Coating_Browser : AdapterBase
    {

        public Coating_Browser()
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
        public IRecipeClass Class = ApplicationService.GetService<IRecipeService>().GetRecipeClass("Coating");
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

        private List<Coating> coatings { get; set; } = new List<Coating>();
        public List<Coating> Coatings
        {
            get { return coatings; }
            set
            {
                coatings = value;

                OnPropertyChanged("Coatings");
            }
        }
        private List<Coating> TCoatings { get; set; } = new List<Coating>();

        private Coating selectedCoating { get; set; } = new Coating();
        public Coating SelectedCoating
        {
            get { return selectedCoating; }
            set
            {
                selectedCoating = value;
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
                OnPropertyChanged("SelectedCoating");
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
                        Coatings = new List<Coating>();
                        foreach (Coating c in TCoatings)
                        {
                            if (c.Header.Name.ToUpper().Contains(value.ToUpper()))
                            {
                                Coatings.Add(c);
                            }
                        }
                        SelectedCoating = new Coating();
                    }
                    else
                    {
                        Coatings = TCoatings;
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
            if (SelectedCoating.Header.Id > 0)
            {
                ((MainRegion.Recipes.Adapters.Recipes_Coating)(iRS.GetView("MainRegion", "Recipes_Coating") as MainRegion.Recipes.Views.Recipes_Coating).DataContext).LoadCoating(SelectedCoating);
                CloseExecuted(null);
            }
        }

        public ICommand Save { get; set; }
        private void SaveExecuted(object parameter)
        {
            if (NameBuffer.Length >= 3)
            {
                Coating a = Coatings.Where(x => x.Header.Name == NameBuffer).ToArray().Length > 0 ? Coatings.Where(x => x.Header.Name == NameBuffer).ToArray()[0] : new Coating();
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
                        case 1: new MessageBoxTask("@RecipeSystem.Check.Text24", "@RecipeSystem.Results.SaveFile", MessageBoxIcon.Exclamation); break;
                        case 2: new MessageBoxTask("@RecipeSystem.Check.Text25", "@RecipeSystem.Results.SaveFile", MessageBoxIcon.Exclamation); break;
                        case 3: new MessageBoxTask("@RecipeSystem.Check.Text26", "@RecipeSystem.Results.SaveFile", MessageBoxIcon.Exclamation); break;
                        case 4: new MessageBoxTask("@RecipeSystem.Check.Text27", "@RecipeSystem.Results.SaveFile", MessageBoxIcon.Exclamation); break;
                        case 5: new MessageBoxTask("@RecipeSystem.Check.Text28", "@RecipeSystem.Results.SaveFile", MessageBoxIcon.Exclamation); break;
                        case 6: new MessageBoxTask("@RecipeSystem.Check.Text29", "@RecipeSystem.Results.SaveFile", MessageBoxIcon.Exclamation); break;
                        case 7: new MessageBoxTask("@RecipeSystem.Check.Text30", "@RecipeSystem.Results.SaveFile", MessageBoxIcon.Exclamation); break;
                        case 8: new MessageBoxTask("@RecipeSystem.Check.Text31", "@RecipeSystem.Results.SaveFile", MessageBoxIcon.Exclamation); break;
                        case 9: new MessageBoxTask("@RecipeSystem.Check.Text32", "@RecipeSystem.Results.SaveFile", MessageBoxIcon.Exclamation); break;
                        case 10: new MessageBoxTask("@RecipeSystem.Check.Text33", "@RecipeSystem.Results.SaveFile", MessageBoxIcon.Exclamation); break;
                        case 11: new MessageBoxTask("@RecipeSystem.Check.Text34", "@RecipeSystem.Results.SaveFile", MessageBoxIcon.Exclamation); break;
                        case 12: new MessageBoxTask("@RecipeSystem.Check.Text35", "@RecipeSystem.Results.SaveFile", MessageBoxIcon.Exclamation); break;
                        case 13: new MessageBoxTask("@RecipeSystem.Check.Text36", "@RecipeSystem.Results.SaveFile", MessageBoxIcon.Exclamation); break;
                        case 14: new MessageBoxTask("@RecipeSystem.Check.Text37", "@RecipeSystem.Results.SaveFile", MessageBoxIcon.Exclamation); break;
                        case 15: new MessageBoxTask("@RecipeSystem.Check.Text38", "@RecipeSystem.Results.SaveFile", MessageBoxIcon.Exclamation); break;
                        case 16: new MessageBoxTask("@RecipeSystem.Check.Text39", "@RecipeSystem.Results.SaveFile", MessageBoxIcon.Exclamation); break;
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
                                    new MSSQLEAdapter("Recipes", "UPDATE Recipes_Coating " +
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
                                                          "INTO Recipes_Coating (Name, Description, VWRecipe, [User]) " +
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
            if (SelectedCoating.Header.Id > 0)
            {
                if (MessageBoxView.Show("@RecipeSystem.Results.DeleteFileQuery", "@RecipeSystem.Results.DeleteFile", MessageBoxButton.YesNo, icon: MessageBoxIcon.Question) == MessageBoxResult.Yes)
                {
                    Wait = Visibility.Visible;

                    Task.Run(async () =>
                    {
                        try
                        {
                            new MSSQLEAdapter("Recipes", "DELETE " +
                                                    "FROM Recipes_Coating " +
                                                    "WHERE Id = " + SelectedCoating.Header.Id + "; ").DB_Output();
                            Dispatcher.Invoke(delegate
                            {
                                Coatings.Remove(SelectedCoating);
                                List<Coating> temp = coatings;
                                Coatings = new List<Coating>();
                                Coatings = temp;
                                SelectedCoating = new Coating();

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
            Views.Coating_Browser v = (Views.Coating_Browser)iRS.GetView("Coating_Browser");
            new ObjectAnimator().CloseDialog1(v, v.border);
        }




        #endregion

        #region - - - Event handlers - - -

        protected override void OnViewLoaded(object sender, ViewLoadedEventArg e)
        {
            RecipeInfo temp = ApplicationService.ObjectStore.GetValue("Coating_Browser_KEY") as RecipeInfo;
            ApplicationService.ObjectStore.Remove("Coating_Browser_KEY");
            
            GetCoatings(temp);

            filter = "";
            OnPropertyChanged("Filter");

            Views.Coating_Browser v = (Views.Coating_Browser)iRS.GetView("Coating_Browser");
            new ObjectAnimator().OpenDialog(v, v.border);

            base.OnViewLoaded(sender, e);
        }

        #endregion

        #region - - - Methods - - -

        private void GetCoatings(RecipeInfo recipe)
        {
            Wait = Visibility.Visible;
            List<Coating> temp = new List<Coating>(); 
            Task.Run(async () =>
            {
                try
                {
                    DataTable DT = new MSSQLEAdapter("Recipes", "SELECT * FROM Recipes_Coating; ").DB_Output();

                    if (DT.Rows.Count > 0)
                    {
                        foreach (DataRow r in DT.Rows)
                        {
                            await Task.Delay(20);

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
                                VWRecipe = new VWRecipe()
                                {
                                    Class = "Coating",
                                    Data = (string)r["VWRecipe"]
                                }
                            });
                        }
                    }

                    Dispatcher.Invoke(delegate
                    {
                        try
                        {
                            TCoatings = Coatings = temp;
                            if (Coatings.Where(t => t.Header.Name == recipe.Name).Count() != 0)
                            {
                                SelectedCoating = Coatings.Where(t => t.Header.Name == recipe.Name).First();
                            }
                            else { SelectedCoating = new Coating(); }
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

        public List<Coating> Convert(IEnumerable original)
        {
            return new List<Coating>(original.Cast<Coating>());
        }

        #endregion


    }
}