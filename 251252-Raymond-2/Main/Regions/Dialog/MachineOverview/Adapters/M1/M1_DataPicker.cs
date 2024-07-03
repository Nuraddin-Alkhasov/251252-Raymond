using HMI.CO.General;
using HMI.CO.Recipe;
using HMI.Resources;
using System.Collections.Generic;
using System.Data;

using System.Windows;
using System.Windows.Input;
using VisiWin.ApplicationFramework;
using VisiWin.Commands;
using VisiWin.DataAccess;
using VisiWin.Logging;

namespace HMI.DialogRegion.MO.Adapters
{
    [ExportAdapter("M1_DataPicker")]
    public class M1_DataPicker : AdapterBase
    {

        public M1_DataPicker()
        {

            if (ApplicationService.IsInDesignMode)
            {
                return;
            }

            loggingService = GetService<ILoggingService>();
            SelectMachineRecipe = new ActionCommand(SelectMachineRecipeExecuted);
            Load = new ActionCommand(LoadExecuted);
            Close = new ActionCommand(CloseExecuted);
            BarcodeData = VS.GetVariable("Main.Barcode");
            BarcodeData.Change += BarcodeData_Change;
        }

        #region - - - Properties - - -

        private ILoggingService loggingService;
        static IVariable BarcodeData;
        private readonly IRegionService iRS = ApplicationService.GetService<IRegionService>();
        private readonly IVariableService VS = ApplicationService.GetService<IVariableService>();
        private Visibility visible { get; set; }
        public Visibility Visible
        {
            get { return visible; }
            set
            {
                visible = value;
                OnPropertyChanged("Visible");
            }
        }
        string order { set; get; } = "";
        public string Order
        {
            get { return order; }
            set
            {
                order = value;
                OnPropertyChanged("Order");
            }
        }
        string barcodeNumber { set; get; } = "";
        public string BarcodeNumber
        {
            get { return barcodeNumber; }
            set
            {
                barcodeNumber = value;
                
                if (value != "")
                {
                    MR = GetMRbyBarcode(value);
                }
                else { MR = new MR(); }

                OnPropertyChanged("BarcodeNumber");
            }
        }
        Dictionary<string, string> data { set; get; } = new Dictionary<string, string>();
        public Dictionary<string, string> Data
        {
            get { return data; }
            set
            {
                data = value;
                OnPropertyChanged("Data");
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
        bool mes { set; get; } = true;
        public bool MES
        {
            get { return mes; }
            set
            {
                mes = value;
                OnPropertyChanged("MES");
            }
        }
        bool barcode { set; get; } = false;
        public bool Barcode
        {
            get { return barcode; }
            set
            {
                barcode = value;
                OnPropertyChanged("Barcode");
            }
        }
       
        #endregion

        #region - - - Commands - - -

        public ICommand Close { get; set; }
        private void CloseExecuted(object parameter)
        {

            Views.M1_DataPicker v = (Views.M1_DataPicker)iRS.GetView("M1_DataPicker");
            new ObjectAnimator().CloseDialog1(v, v.border);

        }

        public ICommand SelectMachineRecipe { get; set; }
        private void SelectMachineRecipeExecuted(object parameter)
        {

            ApplicationService.SetView("DialogRegion2", "Recipe_Selector", "MO_DataPicker");

        }

        public ICommand Load { get; set; }
        private void LoadExecuted(object parameter)
        {
            if (Order == "" || BarcodeNumber == "" || MR.Header.Id <= 0 ) { return; }

            if (MES) 
            {
                if (!Data.ContainsKey("MAT") || !Data.ContainsKey("BAT") || !Data.ContainsKey("HU") || !Data.ContainsKey("QTY") || !Data.ContainsKey("PO")) { return; }
            }

            ApplicationService.SetVariableValue("CPU1.PLC.Blocks.01 Basket feeding.01 LD.00 Main.DB LD HMI.PC.Data.from.Order#STRING20", Order);
            ApplicationService.SetVariableValue("CPU1.PLC.Blocks.01 Basket feeding.01 LD.00 Main.DB LD HMI.PC.Header.from.MR", MR.Header.Id);

            ApplicationService.SetVariableValue("CPU1.PLC.Blocks.01 Basket feeding.01 LD.00 Main.DB LD HMI.PC.Data.from.Barcode.On", Barcode);
            ApplicationService.SetVariableValue("CPU1.PLC.Blocks.01 Basket feeding.01 LD.00 Main.DB LD HMI.PC.Data.from.Barcode.Number#STRING20", BarcodeNumber);
            ApplicationService.SetVariableValue("CPU1.PLC.Blocks.01 Basket feeding.01 LD.00 Main.DB LD HMI.PC.Data.from.Barcode.Data#STRING254", Data.ContainsKey("BarcodeData") ? Data["BarcodeData"] : "");

            ApplicationService.SetVariableValue("CPU1.PLC.Blocks.01 Basket feeding.01 LD.00 Main.DB LD HMI.PC.Data.from.MES.On", MES);
            if (MES)
            {
                ApplicationService.SetVariableValue("CPU1.PLC.Blocks.01 Basket feeding.01 LD.00 Main.DB LD HMI.PC.Data.from.MES.MAT#STRING9", Data.ContainsKey("MAT") ? Data["MAT"] : "");
                ApplicationService.SetVariableValue("CPU1.PLC.Blocks.01 Basket feeding.01 LD.00 Main.DB LD HMI.PC.Data.from.MES.BAT#STRING10", Data.ContainsKey("BAT") ? Data["BAT"] : "");
                ApplicationService.SetVariableValue("CPU1.PLC.Blocks.01 Basket feeding.01 LD.00 Main.DB LD HMI.PC.Data.from.MES.HU#STRING4", Data.ContainsKey("HU") ? Data["HU"] : "");
                ApplicationService.SetVariableValue("CPU1.PLC.Blocks.01 Basket feeding.01 LD.00 Main.DB LD HMI.PC.Data.from.MES.QTY", Data.ContainsKey("QTY") ? Data["QTY"] : "");
                ApplicationService.SetVariableValue("CPU1.PLC.Blocks.01 Basket feeding.01 LD.00 Main.DB LD HMI.PC.Data.from.MES.PO#STRING8", Data.ContainsKey("PO") ? Data["PO"] : "");
            }
            else 
            {
                ApplicationService.SetVariableValue("CPU1.PLC.Blocks.01 Basket feeding.01 LD.00 Main.DB LD HMI.PC.Data.from.MES.MAT#STRING9","");
                ApplicationService.SetVariableValue("CPU1.PLC.Blocks.01 Basket feeding.01 LD.00 Main.DB LD HMI.PC.Data.from.MES.BAT#STRING10", "");
                ApplicationService.SetVariableValue("CPU1.PLC.Blocks.01 Basket feeding.01 LD.00 Main.DB LD HMI.PC.Data.from.MES.HU#STRING4", "");
                ApplicationService.SetVariableValue("CPU1.PLC.Blocks.01 Basket feeding.01 LD.00 Main.DB LD HMI.PC.Data.from.MES.QTY", "");
                ApplicationService.SetVariableValue("CPU1.PLC.Blocks.01 Basket feeding.01 LD.00 Main.DB LD HMI.PC.Data.from.MES.PO#STRING8", "");
            }

            CloseExecuted(null);
        }

        #endregion

        #region - - - Event handlers - - -

        protected override void OnViewLoaded(object sender, ViewLoadedEventArg e)
        {
            User = ApplicationService.GetVariableValue("__CURRENT_USER.FULLNAME").ToString();

            Views.M1_DataPicker v = (Views.M1_DataPicker)iRS.GetView("M1_DataPicker");
            new ObjectAnimator().OpenDialog(v, v.border);

            ViewUpdate();

            base.OnViewLoaded(sender, e);
        }

        void BarcodeData_Change(object sender, VariableEventArgs e)
        {
            if (Visible == Visibility.Visible && Barcode && e.Value.ToString() != "")
            {
                HMI.CO.PD.Barcode B = new HMI.CO.PD.Barcode(e.Value.ToString());
                
                if (
                   !B.Data.ContainsKey("MAT") ||
                   !B.Data.ContainsKey("BAT") ||
                   !B.Data.ContainsKey("HU") ||
                   !B.Data.ContainsKey("QTY") ||
                   !B.Data.ContainsKey("PO") ||
                   !B.Data.ContainsKey("PWG"))
                {
                    new MessageBoxTask("@Scanner.Text5", "@Scanner.Text4", MessageBoxIcon.Error);
                }

                BarcodeNumber = Data["MAT"] = B.Data.ContainsKey("MAT") ? B.Data["MAT"] : "";
                Data["BarcodeData"] = B.Value;
                Order = Data["PO"] = B.Data.ContainsKey("PO") ? B.Data["PO"] : "";

                if (MES)
                {
                    Data["BAT"] = B.Data.ContainsKey("BAT") ? B.Data["BAT"] : "";
                    Data["HU"] = B.Data.ContainsKey("HU") ? B.Data["HU"] : "";
                    Data["QTY"] = B.Data.ContainsKey("QTY") ? B.Data["QTY"] : "";
                }
                else 
                {
                    Data["BAT"] = "";
                    Data["HU"] = "";
                    Data["QTY"] = "";

                }
                ApplicationService.SetVariableValue("Main.Barcode", "");

                OnPropertyChanged("Data");
            }


        }

        #endregion

        #region - - - Methods - - -

        public void ViewUpdate()
        {
            Data = new Dictionary<string, string>();
            Barcode = (bool)ApplicationService.GetVariableValue("CPU1.PLC.Blocks.01 Basket feeding.01 LD.00 Main.DB LD HMI.PC.Data.from.Barcode.On");
            MES = (bool)ApplicationService.GetVariableValue("CPU1.PLC.Blocks.01 Basket feeding.01 LD.00 Main.DB LD HMI.PC.Data.from.MES.On");
            
            if (MES)
            {
                Data.Add("MAT", ApplicationService.GetVariableValue("CPU1.PLC.Blocks.01 Basket feeding.01 LD.00 Main.DB LD HMI.PC.Data.from.MES.MAT#STRING9").ToString());
                Data.Add("BAT", ApplicationService.GetVariableValue("CPU1.PLC.Blocks.01 Basket feeding.01 LD.00 Main.DB LD HMI.PC.Data.from.MES.BAT#STRING10").ToString());
                Data.Add("HU", ApplicationService.GetVariableValue("CPU1.PLC.Blocks.01 Basket feeding.01 LD.00 Main.DB LD HMI.PC.Data.from.MES.HU#STRING4").ToString());
                Data.Add("QTY", ApplicationService.GetVariableValue("CPU1.PLC.Blocks.01 Basket feeding.01 LD.00 Main.DB LD HMI.PC.Data.from.MES.QTY").ToString());
                Data.Add("PO", ApplicationService.GetVariableValue("CPU1.PLC.Blocks.01 Basket feeding.01 LD.00 Main.DB LD HMI.PC.Data.from.MES.PO#STRING8").ToString());

                Order = Data["PO"];
                BarcodeNumber = Data["MAT"];

                OnPropertyChanged("Data");
            }
            else 
            {
                Order = ApplicationService.GetVariableValue("CPU1.PLC.Blocks.01 Basket feeding.01 LD.00 Main.DB LD HMI.PC.Data.from.Order#STRING20").ToString();
                BarcodeNumber = ApplicationService.GetVariableValue("CPU1.PLC.Blocks.01 Basket feeding.01 LD.00 Main.DB LD HMI.PC.Data.from.Barcode.Number#STRING20").ToString();
            }
        }

        MR GetMRData(uint _mr_id)
        {
            MR temp = new MR();
            if (_mr_id > 0) 
            {
                DataTable DT = new MSSQLEAdapter("Recipes", "SELECT *" +
                                                         "FROM Recipes_MR " +
                                                         "WHERE Id = " + _mr_id + ";").DB_Output();
                if (DT.Rows.Count > 0)
                {
                    temp.Header = new RecipeInfo()
                    {
                        Id = (int)DT.Rows[0]["Id"],
                        Name = (string)DT.Rows[0]["Name"],
                        Description = (string)DT.Rows[0]["Description"]
                    };

                    temp.Article = GetArticleData((int)DT.Rows[0]["Article_Id"]);
                }
                else
                {
                    new MessageBoxTask("@RecipeSystem.Results.Text7", "@RecipeSystem.Results.Text2", MessageBoxIcon.Error);
                }
            }
          

            return temp;
        }
        Article GetArticleData(int _id)
        {
            Article temp = new Article();
            if (_id != -1)
            {
                DataTable DT = new MSSQLEAdapter("Recipes", "SELECT *  FROM Recipes_Article WHERE Id = " + _id + "; ").DB_Output();
                if (DT.Rows.Count > 0)
                {
                    temp = new Article()
                    {
                        Header = new RecipeInfo()
                        {
                            Id = _id,
                            Name = (string)DT.Rows[0]["Name"],
                            Description = (string)DT.Rows[0]["Description"],
                        },
                        Art_Id = DT.Rows[0]["Art_Id"].ToString()
                    };
                }
             
            }
            return temp;
        }
        MR GetMRbyBarcode(string _barcode) 
        {
            MR temp = new MR();
            DataTable DT = new MSSQLEAdapter("Recipes", "SELECT * " +
                                              "FROM Barcodes " +
                                              "WHERE Barcode ='" + _barcode + "'; ").DB_Output();
            if (DT.Rows.Count != 0)
            {

                temp = GetMRData((uint)(int)DT.Rows[0]["MR_Id"]);
            }
            else 
            { 
                new MessageBoxTask("@RecipeSystem.Results.Text7", "@RecipeSystem.Results.Text2", MessageBoxIcon.Error);
            }
            return temp;
        }
        #endregion


    }
}