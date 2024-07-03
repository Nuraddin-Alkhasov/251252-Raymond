using HMI.CO.General;
using HMI.CO.Protocol;
using HMI.CO.Recipe;
using HMI.DialogRegion.MO.Views;
using HMI.MessageBoxRegion.Views;
using HMI.Resources;
using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using VisiWin.ApplicationFramework;
using VisiWin.Commands;
using VisiWin.Logging;
using VisiWin.Controls;
using System.Linq;
using System.Collections.Generic;

namespace HMI.DialogRegion.MO.Adapters
{
    [ExportAdapter("M2_Status_1")]
    public class M2_Status_1 : AdapterBase
    {

        public M2_Status_1()
        {

            if (ApplicationService.IsInDesignMode)
            {
                return;
            }
            SelectMR = new ActionCommand(SelectMRExecuted);
            Update = new ActionCommand(UpdateExecuted);
            Delete = new ActionCommand(DeleteExecuted);
            Close = new ActionCommand(CloseExecuted);
        }

        #region - - - Properties - - -

        private readonly IRegionService iRS = ApplicationService.GetService<IRegionService>();

        string header { set; get; } = "";
        public string Header
        {
            get { return header; }
            set
            {
                header = value;
                OnPropertyChanged("Header");
            }
        }
        string data1 { set; get; } = "";
        public string Data_1
        {
            get { return data1; }
            set
            {
                data1 = value;
                OnPropertyChanged("Data_1");
            }
        }

        string data2 { set; get; } = "";
        public string Data_2
        {
            get { return data2; }
            set
            {
                data2 = value;
                OnPropertyChanged("Data_2");
            }
        }

        string data3 { set; get; } = "";
        public string Data_3
        {
            get { return data3; }
            set
            {
                data3 = value;
                OnPropertyChanged("Data_3");
            }
        }
        int box { set; get; } = 0;
        public int Box
        {
            get { return box; }
            set
            {
                box = value;
                OnPropertyChanged("Box");
            }
        }
        int charge { set; get; } = 0;
        public int Charge
        {
            get { return charge; }
            set
            {
                charge = value;
                OnPropertyChanged("Charge");
            }
        }

        float weight { set; get; } = 0;
        public float Weight
        {
            get { return weight; }
            set
            {
                weight = value;
                OnPropertyChanged("Weight");
            }
        }

        int run { set; get; } = 0;
        public int Run
        {
            get { return run; }
            set
            {
                run = value;
                OnPropertyChanged("Run");
            }
        }

        string painta { set; get; } = " - - - ";
        public string PaintA
        {
            get { return painta; }
            set
            {
                painta = value;
                OnPropertyChanged("PaintA");
            }
        }
        string paintn { set; get; } = " - - - ";
        public string PaintN
        {
            get { return paintn; }
            set
            {
                paintn = value;
                OnPropertyChanged("PaintN");
            }
        }

        int layersSet { set; get; } = 0;
        public int LayersSet
        {
            get { return layersSet; }
            set
            {
                layersSet = value;
                OnPropertyChanged("LayersSet");
            }
        }


        object content { set; get; } = new object();
        public object Content
        {
            get { return content; }
            set
            {
                content = value;
                OnPropertyChanged("Content");
            }
        }

        MR mr { set; get; } = new MR();
        public MR MR
        {
            get { return mr; }
            set
            {
                mr = value;
                OnPropertyChanged("MR");
            }
        }

        string user { set; get; } = "";
        public string User
        {
            get { return user; }
            set
            {
                user = value;
                OnPropertyChanged("User");
            }
        }

        private SP SPData { set; get; } = new SP();
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

        public ICommand Close { get; set; }
        private void CloseExecuted(object parameter)
        {
            SPData.Close();

            Views.M2_Status_1 v = (Views.M2_Status_1)iRS.GetView("M2_Status_1");
            new ObjectAnimator().CloseDialog1(v, v.border);
        }

        public ICommand Delete { get; set; }
        private void DeleteExecuted(object parameter)
        {
            if (MessageBoxView.Show("@Status.Text26", "@Status.Text27", MessageBoxButton.YesNo, MessageBoxResult.No, MessageBoxIcon.Question) == MessageBoxResult.Yes)
            {

                Task taskA = Task.Run(() =>
                {
                    ApplicationService.SetVariableValue("CPU3.PLC.Blocks.00 Main.02 HMI.01 PC.DB PC.State.from.Data.Delete", true);
                });
                taskA.ContinueWith(async x =>
                {
                    await Task.Delay(1000);
                    ApplicationService.SetVariableValue("CPU3.PLC.Blocks.00 Main.02 HMI.01 PC.DB PC.State.from.Data.Delete", false);
                    CloseExecuted(null);
                }, TaskContinuationOptions.OnlyOnRanToCompletion);
            }

            ILoggingService loggingService = ApplicationService.GetService<ILoggingService>();
            loggingService.Log("Machine", "Status", "@Logging.Machine.Status.Text1", DateTime.Now);


        }

        public ICommand Update { get; set; }
        private void UpdateExecuted(object parameter)
        {
            string pId = SelectedPaint.Value;
            if (MessageBoxView.Show("@Status.Text29", "@Status.Text28", MessageBoxButton.YesNo, MessageBoxResult.No, MessageBoxIcon.Question) == MessageBoxResult.Yes)
            {
                Task taskA = Task.Run(async () =>
                {
                    if (Paints.Where(x => x.Header.Id.ToString() == pId).ToList().Count != 0) 
                    {
                        Paint paint = Paints.Where(x => x.Header.Id.ToString() == pId).ToList().First();

                        VWVariable v = paint.VWRecipe.VWVariables.Where(x => x.Item.ToString() == "CPU3.PLC.Blocks.03 Basket coating.02 DT.00 Main.DB DT PD.Station.Baskets.Coatings").ToList().First();
                        ApplicationService.SetVariableValue("CPU3.PLC.Blocks.00 Main.02 HMI.01 PC.DB PC.State.to.Data.Baskets.Coatings.Set", v.Value);
                    }

                  
                    ApplicationService.SetVariableValue("CPU3.PLC.Blocks.00 Main.02 HMI.01 PC.DB PC.State.from.Data.Update", true);
                    await Task.Delay(1000);
                    ApplicationService.SetVariableValue("CPU3.PLC.Blocks.00 Main.02 HMI.01 PC.DB PC.State.from.Data.Update", false);
                    CloseExecuted(null);
                });
                

                ILoggingService loggingService = ApplicationService.GetService<ILoggingService>();
                loggingService.Log("Machine", "Status", "@Logging.Machine.Status.Text2", DateTime.Now);

            }
        }
        public ICommand SelectMR { get; set; }
        private void SelectMRExecuted(object parameter)
        {
            ApplicationService.SetView("DialogRegion2", "Recipe_Selector", "M2_Status_1");
        }
        #endregion

        #region - - - Event handlers - - -

        protected override void OnViewLoaded(object sender, ViewLoadedEventArg e)
        {
            if (sender.GetType().Name == e.View.GetType().Name)
            {
                SPData = ApplicationService.ObjectStore.GetValue("M2_Status_1_KEY") as SP;
                ApplicationService.ObjectStore.Remove("M2_Status_1_KEY");
                Header = SPData.Header;

                SetData((uint)ApplicationService.GetVariableValue("CPU3.PLC.Blocks.00 Main.02 HMI.01 PC.DB PC.State.to.Data.Header.MR"));



                ; switch (SPData.Type)
                {
                    case "Box": Content = new M2_Status_Box1(); break;
                    case "Belt": Content = new object(); break;
                    case "Basket": Content = new M2_Status_Basket(); break;
                    case "Tray": Content = new M2_Status_Tray(); break;
                    default: Content = new object(); break;
                }

                Views.M2_Status_1 v = (Views.M2_Status_1)iRS.GetView("M2_Status_1");
                new ObjectAnimator().OpenDialog(v, v.border);

            }

            base.OnViewLoaded(sender, e);
        }

        #endregion

        #region - - - Methods - - -

        void SetData(uint _mrId)
        {
            try
            {
                string[] Layers = new string[5];
                uint OrderId = (uint)ApplicationService.GetVariableValue("CPU3.PLC.Blocks.00 Main.02 HMI.01 PC.DB PC.State.to.Data.Header.Order");
                if (OrderId > 0)
                {
                    DataTable DT = new MSSQLEAdapter("Orders", "SELECT * From Orders WHERE Id = " + OrderId + ";").DB_Output();
                    if (DT.Rows.Count > 0)
                    {
                        Data_1 = (string)DT.Rows[0]["Data_1"];
                        Data_2 = (string)DT.Rows[0]["Data_2"];
                        Data_3 = (string)DT.Rows[0]["Data_3"];
                    }
                }
                else
                {
                    Data_1 = "";
                    Data_2 = "";
                    Data_3 = "";
                }

                uint BoxId = (uint)ApplicationService.GetVariableValue("CPU3.PLC.Blocks.00 Main.02 HMI.01 PC.DB PC.State.to.Data.Header.Box");
                if (BoxId > 0)
                {
                    DataTable DT = new MSSQLEAdapter("Orders", "SELECT * From Boxes WHERE Id = " + BoxId + ";").DB_Output();
                    if (DT.Rows.Count > 0)
                    {
                        Box = (int)DT.Rows[0]["Box"];
                    }
                }
                else
                {
                    Box = 0;
                }
                MR = new MR();
                PaintTypes = GetPaintTypes();
                MR.Header.Id = (int)_mrId;
                LayersSet = 0;
                if (MR.Header.Id > 0)
                {
                    DataTable DT = new MSSQLEAdapter("Recipes", "SELECT * From Recipes_MR WHERE Id = " + MR.Header.Id + ";").DB_Output();
                    if (DT.Rows.Count > 0)
                    {
                        MR.Header.Name = (string)DT.Rows[0]["Name"];
                        MR.Article.Header.Id = (int)DT.Rows[0]["Article_Id"];
                        for (int i = 0; i <= 4; i++)
                        {
                            Layers[i] = (int)DT.Rows[0]["P" + i.ToString() + "_Id"] != -1 ? PaintTypes.ToList().Where(x => x.Value == DT.Rows[0]["P" + i.ToString() + "_Id"].ToString()).First().Text : " - - - ";
                            LayersSet += (int)DT.Rows[0]["C" + i.ToString() + "_Id"] != -1 ? 1 : 0;
                        }
                    }

                    DT = new MSSQLEAdapter("Recipes", "SELECT * From Recipes_Article WHERE Id = " + MR.Article.Header.Id + ";").DB_Output();
                    if (DT.Rows.Count > 0)
                    {
                        MR.Article.Art_Id = DT.Rows[0]["Art_Id"].ToString();
                    }
                }

                uint ChargeId = (uint)ApplicationService.GetVariableValue("CPU3.PLC.Blocks.00 Main.02 HMI.01 PC.DB PC.State.to.Data.Header.Charge");
                if (ChargeId > 0)
                {
                    DataTable DT = new MSSQLEAdapter("Orders", "SELECT * From Charges WHERE Id = " + ChargeId + ";").DB_Output();
                    if (DT.Rows.Count > 0)
                    {
                        Charge = (int)DT.Rows[0]["Charge"];
                        Weight = (float)DT.Rows[0]["Weight"];
                    }
                }
                else
                {
                    Charge = 0;
                    Weight = 0;
                }

                uint RunId = (uint)ApplicationService.GetVariableValue("CPU3.PLC.Blocks.00 Main.02 HMI.01 PC.DB PC.State.to.Data.Header.Layer");
                if (RunId > 0)
                {
                    DataTable DT = new MSSQLEAdapter("Orders", "SELECT * From Layers WHERE Id = " + RunId + ";").DB_Output();
                    if (DT.Rows.Count > 0)
                    {
                        Run = (int)DT.Rows[0]["Layer"];
                    }
                }
                else
                {
                    Run = 0;
                }

               
            }
            catch { }

            OnPropertyChanged("MR");

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
                    Paints.Add (new Paint()
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
        MR GetMRData(uint mr_id)
        {
            MR temp = new MR();
            DataTable DT = new MSSQLEAdapter("Recipes", "SELECT *" +
                                                       "FROM Recipes_MR " +
                                                       "WHERE Id = " + mr_id + ";").DB_Output();
            if (DT.Rows.Count > 0)
            {
                temp.Header = new RecipeInfo
                {
                    Name = (string)DT.Rows[0]["Name"]
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

                temp.Article = GetArticleData((int)DT.Rows[0]["Article_Id"]);
            }

            return temp;
        }
        Article GetArticleData(int _id)
        {
            Article temp = new Article();
            if (_id > 0)
            {
                DataTable DT = new MSSQLEAdapter("Recipes", "SELECT *  FROM Recipes_Article WHERE Id = " + _id + "; ").DB_Output();

                if (DT.Rows.Count > 0)
                {
                    temp = new Article()
                    {
                        Header = new RecipeInfo(),
                        Art_Id = DT.Rows[0]["Art_Id"].ToString(),
                        LD = new LD()
                        {
                            Header = new RecipeInfo(),
                            VWRecipe = new VWRecipe("LD", (string)DT.Rows[0]["LD_VWRecipe"])
                        },
                        BT = new BT(),
                        PO = new PO()
                    };
                }
            }

            return temp;
        }

        public void SetData(int _mrId)
        {

            if (_mrId > 0)
            {
                MR = GetMRData((uint)_mrId);

                byte counter = 0;
                for (int i = 0; i < MR.Layers.Count; i++)
                {
                    if (MR.Layers[i].Coating.Header.Id != -1)
                    {
                        counter++;
                    }
                }
                byte actualLayer = (byte)ApplicationService.GetVariableValue("CPU3.PLC.Blocks.00 Main.02 HMI.01 PC.DB PC.State.to.Data.Charge.Layer[1].Actual");
                ApplicationService.SetVariableValue("CPU3.PLC.Blocks.00 Main.02 HMI.01 PC.DB PC.State.to.Data.Header.MR", _mrId);
                ApplicationService.SetVariableValue("CPU3.PLC.Blocks.00 Main.02 HMI.01 PC.DB PC.State.to.Data.Charge.Available", 1);
                ApplicationService.SetVariableValue("CPU3.PLC.Blocks.00 Main.02 HMI.01 PC.DB PC.State.to.Data.Charge.Machine.Actual", 1);
                ApplicationService.SetVariableValue("CPU3.PLC.Blocks.00 Main.02 HMI.01 PC.DB PC.State.to.Data.Charge.Layer[1].Set", counter);

                if (actualLayer < counter)
                {
                    ApplicationService.SetVariableValue("CPU3.PLC.Blocks.00 Main.02 HMI.01 PC.DB PC.State.to.Data.Charge.Paint.Actual", actualLayer == 0 ? 0 : MR.Layers[actualLayer - 1].Paint.Header.Id);
                    ApplicationService.SetVariableValue("CPU3.PLC.Blocks.00 Main.02 HMI.01 PC.DB PC.State.to.Data.Charge.Paint.Next", MR.Layers[actualLayer].Paint.Header.Id);
                    ApplicationService.SetVariableValue("CPU3.PLC.Blocks.00 Main.02 HMI.01 PC.DB PC.State.to.Data.Charge.Machine.Next", MR.Layers[actualLayer].Machine);
                }
                else
                {
                    ApplicationService.SetVariableValue("CPU3.PLC.Blocks.00 Main.02 HMI.01 PC.DB PC.State.to.Data.Charge.Paint.Actual", MR.Layers[counter - 1].Paint.Header.Id);
                    ApplicationService.SetVariableValue("CPU3.PLC.Blocks.00 Main.02 HMI.01 PC.DB PC.State.to.Data.Charge.Paint.Next", 0);
                    ApplicationService.SetVariableValue("CPU3.PLC.Blocks.00 Main.02 HMI.01 PC.DB PC.State.to.Data.Charge.Machine.Next", 0);
                }
            }
        }
        
        #endregion

    }
}
