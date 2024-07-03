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
using VisiWin.Recipe;

namespace HMI.DialogRegion.Recipes.Adapters
{
    class MP_Binding : AdapterBase
    {
        public MP_Binding()
        {
            New = new ActionCommand(NewExecuted);
            Edit = new ActionCommand(EditExecuted);
            Close = new ActionCommand(CloseExecuted);

            SelectMachineRecipe = new ActionCommand(SelectMachineRecipeExecuted);
            CloseEditDialog = new ActionCommand(CloseEditDialogExecuted);

            Save = new ActionCommand(SaveExecuted);
            Delete = new ActionCommand(DeleteExecuted);

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

        List<Barcode> barcodes = new List<Barcode>();
        public List<Barcode> Barcodes
        {
            get { return barcodes; }
            set
            {
                barcodes = value;
                OnPropertyChanged("Barcodes");
            }
        }
        List<Barcode> TBarcodes = new List<Barcode>();

        Barcode selectedBarcode = new Barcode();
        public Barcode SelectedBarcode
        {
            get { return selectedBarcode; }
            set
            {
                if (value != null) { IsBCToMRSelected = true; }
                else { IsBCToMRSelected = false; }
                selectedBarcode = value;
                OnPropertyChanged("SelectedBarcode");
            }
        }

        Barcode selectedBarcodeBuffer = new Barcode();
        public Barcode SelectedBarcodeBuffer
        {
            get { return selectedBarcodeBuffer; }
            set
            {
                selectedBarcodeBuffer = value;
                OnPropertyChanged("SelectedBarcodeBuffer");
            }
        }

        bool isBCToMRSelected;
        public bool IsBCToMRSelected
        {
            get { return isBCToMRSelected; }
            set
            {
                isBCToMRSelected = value;
                OnPropertyChanged("IsBCToMRSelected");
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
                        Barcodes = new List<Barcode>();
                        foreach (Barcode c in TBarcodes)
                        {
                            if (c.BC.ToUpper().Contains(value.ToUpper()))
                            {
                                Barcodes.Add(c);
                            }
                        }
                      
                        SelectedBarcode = new Barcode();
                    }
                    else
                    {
                        Barcodes = TBarcodes;
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


        #endregion

        #region - - - Commands - - -
        public ICommand New { get; set; }
        private void NewExecuted(object parameter)
        {
            Views.MP_Binding v = (Views.MP_Binding)iRS.GetView("MP_Binding");
            new ObjectAnimator().ShowUIElement(v.dataedit);
            SelectedBarcodeBuffer = new Barcode();
        }
        public ICommand Edit { get; set; }
        private void EditExecuted(object parameter)
        {
            Views.MP_Binding v = (Views.MP_Binding)iRS.GetView("MP_Binding");
            new ObjectAnimator().ShowUIElement(v.dataedit);
            SelectedBarcodeBuffer = new Barcode()
            {
                Id = SelectedBarcode.Id,
                BC = SelectedBarcode.BC,
                MR = SelectedBarcode.MR
            };
        }
        public ICommand Delete { get; set; }
        private void DeleteExecuted(object parameter)
        {
            if (MessageBoxView.Show("@RecipeSystem.Text80", "@RecipeSystem.Text81", MessageBoxButton.YesNo, icon: MessageBoxIcon.Question) == MessageBoxResult.Yes)
            {
                Wait = Visibility.Visible;
                Task.Run(async () =>
                {
                    try
                    {
                        DataTable DT = new MSSQLEAdapter("Recipes", "DELETE FROM Barcodes " +
                            "WHERE Id = '" + SelectedBarcode.Id + "';").DB_Output();
                        await GetBarcodes();

                        await Task.Delay(1000);

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
        public ICommand Save { get; set; }
        private void SaveExecuted(object parameter)
        {
            if (Barcodes.Where(x => x.BC == SelectedBarcodeBuffer.BC).ToArray().Length > 0)
            {
                if (MessageBoxView.Show("@RecipeSystem.Text78", "@RecipeSystem.Text79", MessageBoxButton.YesNo, MessageBoxResult.No, MessageBoxIcon.Question) == MessageBoxResult.Yes)
                {
                    Wait = Visibility.Visible;
                    Task.Run(async () =>
                    {
                        try
                        {
                            DataTable DT = new MSSQLEAdapter("Recipes", "UPDATE Barcodes " +
                            "SET " +
                            "Barcode ='" + SelectedBarcodeBuffer.BC + "', " +
                            "MR_Id = " + SelectedBarcodeBuffer.MR.Header.Id + ", " +
                            "MR_Name = '" + SelectedBarcodeBuffer.MR.Header.Name + "' " +
                            "WHERE Id = " + Barcodes.First(x => x.BC == SelectedBarcodeBuffer.BC).Id + ";").DB_Output();

                            await GetBarcodes(); 

                            await Task.Delay(1000);

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
                            });
                            return;
                        }
                    });
                    
                }
            }
            else
            {
                Wait = Visibility.Visible;
                Task.Run(async () =>
                {
                    try
                    {
                        DataTable DT = new MSSQLEAdapter("Recipes", "INSERT INTO Barcodes " +
                            "(Barcode, MR_Id, MR_Name) " +
                            "VALUES ('" + SelectedBarcodeBuffer.BC + "'," + SelectedBarcodeBuffer.MR.Header.Id + ",'" + SelectedBarcodeBuffer.MR.Header.Name + "');").DB_Output();
                        await GetBarcodes();
                        await Task.Delay(1000);

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
                        });
                        return;
                    }
                });
            }

        }
        public ICommand SelectMachineRecipe { get; set; }
        private void SelectMachineRecipeExecuted(object parameter)
        {
            ApplicationService.SetView("DialogRegion2", "Recipe_Selector", "MP_Binding");
        }
        public ICommand CloseEditDialog { get; set; }
        private void CloseEditDialogExecuted(object parameter)
        {
            Views.MP_Binding v = (Views.MP_Binding)iRS.GetView("MP_Binding");
            new ObjectAnimator().HideUIElement(v.dataedit);
        }
        public ICommand Close { get; set; }
        private void CloseExecuted(object parameter)
        {
            Views.MP_Binding v = (Views.MP_Binding)iRS.GetView("MP_Binding");
            new ObjectAnimator().CloseDialog1(v, v.border);
        }

        #endregion


        #region - - - Event handlers - - -

        protected override void OnViewLoaded(object sender, ViewLoadedEventArg e)
        {
            
            GetBarcodes(true);

            Views.MP_Binding v = (Views.MP_Binding)iRS.GetView("MP_Binding");
            new ObjectAnimator().OpenDialog(v, v.border);

            base.OnViewLoaded(sender, e);
        }

        #endregion

        #region - - - Methods - - -

        async private Task GetBarcodes()
        {
            List<Barcode> temp = new List<Barcode>();
               
            try
            {
                DataTable DT = new MSSQLEAdapter("Recipes", "SELECT * FROM Barcodes; ").DB_Output();

                if (DT.Rows.Count > 0)
                {
                    foreach (DataRow r in DT.Rows)
                    {
                        await Task.Delay(20);

                        temp.Add(new Barcode()
                        {
                            Id = (int)r["Id"],
                            BC = (string)r["Barcode"],
                            MR = new MR()
                            {
                                Header = new RecipeInfo()
                                {
                                    Id = (int)r["MR_Id"],
                                    Name = (string)r["MR_Name"],
                                }
                            }
                        });
                    }
                }
                Dispatcher.Invoke(delegate
                {
                    try
                    {
                        TBarcodes = Barcodes = temp;
                    }
                    catch { }
                });
            }
            catch { }

        }
        private void GetBarcodes(bool _wait)
        {
            if (_wait) { Wait = Visibility.Visible; }
            List<Barcode> temp = new List<Barcode>();
            Task.Run(async () =>
            {
                try
                {
                    DataTable DT = new MSSQLEAdapter("Recipes", "SELECT * FROM Barcodes; ").DB_Output();

                    if (DT.Rows.Count > 0)
                    {
                        foreach (DataRow r in DT.Rows)
                        {
                            await Task.Delay(20);

                            temp.Add(new Barcode()
                            {
                                Id = (int)r["Id"],
                                BC = (string)r["Barcode"],
                                MR = new MR()
                                {
                                    Header = new RecipeInfo()
                                    {
                                        Id = (int)r["MR_Id"],
                                        Name = (string)r["MR_Name"],
                                    }
                                }
                            });
                        }
                    }
                    Dispatcher.Invoke(delegate
                    {
                        try
                        {
                            TBarcodes = Barcodes = temp;
                        }
                        catch { }
                    });

                    await Task.Delay(1000);
                    if (_wait)
                    {
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
        public List<Barcode> Convert(IEnumerable original)
        {
            return new List<Barcode>(original.Cast<Barcode>());
        }
        #endregion

    }
}
