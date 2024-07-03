using HMI.CO.General;
using HMI.CO.Recipe;
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
    [ExportAdapter("Recipe_Selector")]
    public class Recipe_Selector : AdapterBase
    {

        public Recipe_Selector()
        {

            if (ApplicationService.IsInDesignMode)
            {
                return;
            }
            Select = new ActionCommand(SelectExecuted);
            Close = new ActionCommand(CloseExecuted);
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

        private string Identifier { set; get; } = "";

        #endregion

        #region - - - Commands - - -

        public ICommand Select { get; set; }
        private void SelectExecuted(object parameter)
        {
            if (SelectedMR.Header.Id > 0)
            {
                switch (Identifier)
                {
                    case "MP_Binding":
                        Views.MP_Binding vb = (Views.MP_Binding)iRS.GetView("MP_Binding");
                        Adapters.MP_Binding dcb = (Adapters.MP_Binding)vb.DataContext;
                        Barcode temp = dcb.SelectedBarcodeBuffer;
                        temp.MR = SelectedMR;
                        dcb.SelectedBarcodeBuffer = temp;
                        break;
                    case "M1_DataPicker":
                        MO.Views.M1_DataPicker vp1 = (MO.Views.M1_DataPicker)iRS.GetView("M1_DataPicker");
                        MO.Adapters.M1_DataPicker dcp1 = (MO.Adapters.M1_DataPicker)vp1.DataContext;
                        dcp1.MR = SelectedMR;
                        break;
                    case "M2_DataPicker":
                        MO.Views.M2_DataPicker vp2 = (MO.Views.M2_DataPicker)iRS.GetView("M2_DataPicker");
                        MO.Adapters.M2_DataPicker dcp2 = (MO.Adapters.M2_DataPicker)vp2.DataContext;
                        dcp2.MR = SelectedMR;
                        break;
                    case "M1_Status_1":
                        MO.Views.M1_Status_1 m1s1v = (MO.Views.M1_Status_1)iRS.GetView("M1_Status_1");
                        MO.Adapters.M1_Status_1 m1s1a = (MO.Adapters.M1_Status_1)m1s1v.DataContext;
                        m1s1a.SetData(SelectedMR.Header.Id);
                        break;
                    case "M1_Status_2":
                        MO.Views.M1_Status_2 m1s2v = (MO.Views.M1_Status_2)iRS.GetView("M1_Status_2");
                        MO.Adapters.M1_Status_2 m1s2a = (MO.Adapters.M1_Status_2)m1s2v.DataContext;
                        m1s2a.SetData(SelectedMR.Header.Id);
                        break;
                    case "M2_Status_1":
                        MO.Views.M2_Status_1 m2s1v = (MO.Views.M2_Status_1)iRS.GetView("M2_Status_1");
                        MO.Adapters.M2_Status_1 m2s1a = (MO.Adapters.M2_Status_1)m2s1v.DataContext;
                        m2s1a.SetData(SelectedMR.Header.Id);
                        break;
                    case "M2_Status_2":
                        MO.Views.M2_Status_2 m2s2v = (MO.Views.M2_Status_2)iRS.GetView("M2_Status_2");
                        MO.Adapters.M2_Status_2 m2s2a = (MO.Adapters.M2_Status_2)m2s2v.DataContext;
                        m2s2a.SetData(SelectedMR.Header.Id);
                        break;
                    default: break;
                }

                CloseExecuted(null);
            }

        }



        public ICommand Close { get; set; }
        private void CloseExecuted(object parameter)
        {

            Views.Recipe_Selector v = (Views.Recipe_Selector)iRS.GetView("Recipe_Selector");
            new ObjectAnimator().CloseDialog2(v, v.border);
        }




        #endregion

        #region - - - Event handlers - - -

        protected override void OnViewLoaded(object sender, ViewLoadedEventArg e)
        {
            Identifier = ApplicationService.ObjectStore.GetValue("Recipe_Selector_KEY") as string;
            ApplicationService.ObjectStore.Remove("Recipe_Selector_KEY");
            GetMRs();

            filter = "";
            OnPropertyChanged("Filter");

            Views.Recipe_Selector v = (Views.Recipe_Selector)iRS.GetView("Recipe_Selector");
            new ObjectAnimator().OpenDialog(v, v.border);

            base.OnViewLoaded(sender, e);
        }

        #endregion

        #region - - - Methods - - -

        private void GetMRs()
        {
            Wait = Visibility.Visible;

            List<MR> temp = new List<MR>();
            Task.Run(async () =>
            {
                try
                {
                    DataTable DT = new MSSQLEAdapter("Recipes", "SELECT " +
                        "Recipes_MR.Id as Id, " +
                        "Recipes_MR.[Name] as [Name], " +
                        "Recipes_MR.[Description] as [Description], " +
                        "Recipes_MR.LastChanged as LastChanged,  " +
                        "Recipes_MR.[User] as [User], " +
                        "Recipes_Article.Art_Id as Art_Id, " +
                        "Recipes_Article.LD_VWRecipe as LD_VWRecipe, " +
                        "Recipes_Article.BT_VWRecipe as BT_VWRecipe, " +
                        "Recipes_Article.PO_VWRecipe as PO_VWRecipe " +
                        "FROM Recipes_MR " +
                        "INNER JOIN Recipes_Article ON Recipes_MR.Article_Id = Recipes_Article.Id; ").DB_Output();

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
                                    Art_Id= r["Art_Id"].ToString(),
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
                                }
                            });
                        }


                    }
                    Dispatcher.Invoke(delegate
                    {
                        try
                        {
                            TMRs = MRs = temp;
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


        public List<MR> Convert(IEnumerable original)
        {
            return new List<MR>(original.Cast<MR>());
        }

        #endregion


    }
}