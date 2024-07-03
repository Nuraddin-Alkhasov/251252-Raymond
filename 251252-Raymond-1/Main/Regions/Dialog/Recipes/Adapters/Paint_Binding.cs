using HMI.CO.General;
using HMI.CO.Recipe;
using HMI.MessageBoxRegion.Views;
using HMI.Resources;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using VisiWin.ApplicationFramework;
using VisiWin.Commands;
using VisiWin.Controls;
using VisiWin.Recipe;

namespace HMI.DialogRegion.Recipes.Adapters
{
    class Paint_Binding : AdapterBase
    {
        public Paint_Binding()
        {
            Edit = new ActionCommand(EditExecuted);
            Close = new ActionCommand(CloseExecuted);

            CloseEditDialog = new ActionCommand(CloseEditDialogExecuted);

            Save = new ActionCommand(SaveExecuted);

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

        List<Diptank> diptanks = new List<Diptank>();
        public List<Diptank> Diptanks
        {
            get { return diptanks; }
            set
            {
                diptanks = value;
                OnPropertyChanged("Diptanks");
            }
        }
        List<Diptank> TDiptanks = new List<Diptank>();

        Diptank selectedDiptank = new Diptank();
        public Diptank SelectedDiptank
        {
            get { return selectedDiptank; }
            set
            {
                if (value != null) { IsDTToPaintSelected = true; }
                else { IsDTToPaintSelected = false; }
                selectedDiptank = value;
                OnPropertyChanged("SelectedDiptank");
            }
        }

        bool isDTToPaintSelected;
        public bool IsDTToPaintSelected
        {
            get { return isDTToPaintSelected; }
            set
            {
                isDTToPaintSelected = value;
                OnPropertyChanged("IsDTToPaintSelected");
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
                        Diptanks = new List<Diptank>();
                        foreach (Diptank c in TDiptanks)
                        {
                            if (c.DT.ToUpper().Contains(value.ToUpper()))
                            {
                                Diptanks.Add(c);
                            }
                        }
                      
                        SelectedDiptank = new Diptank();
                    }
                    else
                    {
                        Diptanks = TDiptanks;
                    }
                    filter = value;
                    OnPropertyChanged("Filter");
                }
            }
        }

        Visibility editDialog = Visibility.Hidden;
        public Visibility EditDialog
        {
            get { return editDialog; }
            set
            {
                editDialog = value;
                OnPropertyChanged("EditDialog");
            }
        }

        List<Paint> Paints { set; get; } = new List<Paint>();
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
        State selectedPaint = new State();
        public State SelectedPaint
        {
            get { return selectedPaint; }
            set
            {
                if (value != null)
                {
                    selectedPaint = value;
                    OnPropertyChanged("SelectedPaint");
                }
            }
        }

        #endregion

        #region - - - Commands - - -

        public ICommand Edit { get; set; }
        private void EditExecuted(object parameter)
        {
            Views.Paint_Binding v = (Views.Paint_Binding)iRS.GetView("Paint_Binding");
            new ObjectAnimator().ShowUIElement(v.dataedit);
            SelectedPaint = ((State)PaintTypes.First(x => x.Value == SelectedDiptank.Paint.Header.Id.ToString()));
        }
       
        public ICommand Save { get; set; }
        private void SaveExecuted(object parameter)
        {
            if (Diptanks.Where(x => x.DT == SelectedDiptank.DT).ToArray().Length > 0)
            {
                if (MessageBoxView.Show("@MachineOverview.Text53", "@Buttons.Text25", MessageBoxButton.YesNo, MessageBoxResult.No, MessageBoxIcon.Question) == MessageBoxResult.Yes)
                {
                    Wait = Visibility.Visible;
                    Task.Run(async () =>
                    {
                        try
                        {
                            Dispatcher.Invoke(delegate
                            {
                                try
                                {
                                    DataTable DT = new MSSQLEAdapter("Recipes", "UPDATE Diptanks " +
                                    "SET " +
                                    "Paint_Id = " + SelectedPaint.Value + ", " +
                                    "Paint_Name = '" + SelectedPaint.Text + "' " +
                                    "WHERE Id = " + Diptanks.First(x => x.DT == SelectedDiptank.DT).Id + ";").DB_Output();
                                }
                                catch { }
                            });

                            await Task.Delay(1000);
                            await GetDiptanks();
                            Dispatcher.Invoke(delegate
                            {
                                Wait = Visibility.Hidden;
                            });
                            CloseEditDialogExecuted(null);
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
        public ICommand CloseEditDialog { get; set; }
        private void CloseEditDialogExecuted(object parameter)
        {
            Views.Paint_Binding v = (Views.Paint_Binding)iRS.GetView("Paint_Binding");
            new ObjectAnimator().HideUIElement(v.dataedit);
        }
        public ICommand Close { get; set; }
        private void CloseExecuted(object parameter)
        {
            Views.Paint_Binding v = (Views.Paint_Binding)iRS.GetView("Paint_Binding");
            new ObjectAnimator().CloseDialog1(v, v.border);
        }

        #endregion


        #region - - - Event handlers - - -

        protected override void OnViewLoaded(object sender, ViewLoadedEventArg e)
        {
            GetDiptanks(true);

            PaintTypes = GetPaintTypes();
            Views.Paint_Binding v = (Views.Paint_Binding)iRS.GetView("Paint_Binding");
            new ObjectAnimator().OpenDialog(v, v.border);

            base.OnViewLoaded(sender, e);
        }

        #endregion

        #region - - - Methods - - -

        async private Task GetDiptanks()
        {
            List<Diptank> temp = new List<Diptank>();
                
            try
            {
                DataTable DT = new MSSQLEAdapter("Recipes", "SELECT * FROM Diptanks; ").DB_Output();

                if (DT.Rows.Count > 0)
                {
                    foreach (DataRow r in DT.Rows)
                    {
                        await Task.Delay(20);

                        temp.Add(new Diptank()
                        {
                            Id = (int)r["Id"],
                            DT = (string)r["Diptank"],
                            Paint = new Paint()
                            {
                                Header = new RecipeInfo()
                                {
                                    Id = (int)r["Paint_Id"],
                                    Name = (int)r["Paint_Id"] != -1 ? (string)r["Paint_Name"] : "- - -",
                                }
                            }
                        });
                    }
                }
                Dispatcher.Invoke(delegate
                {
                    try
                    {
                        TDiptanks = Diptanks = temp;
                    }
                    catch { }
                });
            }
            catch { }
        }
        private void GetDiptanks(bool _wait)
        {
            if (_wait) { Wait = Visibility.Visible; }
            List<Diptank> temp = new List<Diptank>();
            Task.Run(async () =>
            {
                try
                {
                    DataTable DT = new MSSQLEAdapter("Recipes", "SELECT * FROM Diptanks; ").DB_Output();

                    if (DT.Rows.Count > 0)
                    {
                        foreach (DataRow r in DT.Rows)
                        {
                            await Task.Delay(20);

                            temp.Add(new Diptank()
                            {
                                Id = (int)r["Id"],
                                DT = (string)r["Diptank"],
                                Paint = new Paint()
                                {
                                    Header = new RecipeInfo()
                                    {
                                        Id = (int)r["Paint_Id"],
                                        Name = (int)r["Paint_Id"] != -1 ? (string)r["Paint_Name"] : "- - -",
                                    }
                                }
                            });
                        }
                    }
                    Dispatcher.Invoke(delegate
                    {
                        try
                        {
                            TDiptanks = Diptanks = temp;
                        }
                        catch { }
                    });
                    await Task.Delay(1000);

                    if (_wait) {
                        Dispatcher.Invoke(delegate
                        {
                            Wait = Visibility.Hidden;
                        });
                    }
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
        private StateCollection GetPaintTypes()
        {
            StateCollection Temp_SC = new StateCollection();
            Paints = new List<Paint>();
            Temp_SC.Add(new State()
            {
                Text = " - - - ",
                Value = "0"
            });
            DataTable DT = new MSSQLEAdapter("Recipes", "SELECT *  FROM Recipes_Paint; ").DB_Output();
            foreach (DataRow r in DT.Rows)
                if (DT.Rows.Count > 0)
                {
                    Temp_SC.Add(new State()
                    {
                        Text = (string)r["Name"],
                        Value = r["Id"].ToString()
                    });
                    Paints.Add(new Paint()
                    {
                        Header = new RecipeInfo()
                        {
                            Id = (int)r["Id"],
                            Name = (string)r["Name"],
                            Description = r["Description"] == DBNull.Value ? "" : (string)r["Description"],
                            LastChanged = ((DateTime)r["LastChanged"]).ToString("dd.MM.yyyy HH:mm:ss"),
                            User = r["User"] == DBNull.Value ? "" : (string)r["User"],
                        },
                        VWRecipe = new VWRecipe((string)r["VWRecipe"])
                    });
                }
            return Temp_SC;
        }
        public List<Diptank> Convert(IEnumerable original)
        {
            return new List<Diptank>(original.Cast<Diptank>());
        }
        #endregion

    }
}
