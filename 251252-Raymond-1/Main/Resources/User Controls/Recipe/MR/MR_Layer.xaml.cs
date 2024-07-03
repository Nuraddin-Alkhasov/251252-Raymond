using HMI.CO.General;
using HMI.CO.Recipe;
using System;
using System.Data;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using VisiWin.ApplicationFramework;
using VisiWin.Controls;
using VisiWin.Language;

namespace HMI.Resources.UserControls
{
    public partial class MR_Layer : UserControl
    {
        public MR_Layer()
        {
            InitializeComponent();
            DataContext = null;
        }
        ILanguageService textService = ApplicationService.GetService<ILanguageService>();
        public string LocalizableLabelText
        {
            set
            {
                A.LocalizableLabelText = value;
            }
        }

        public int Id { set; get; }
        private MCP mcp = new MCP();
        public MCP MCP
        {
            set
            {
                mcp = value;
                if (mcp != null)
                {                   
                    _name.Value = value.Coating.Header.Name;
                    _descr.Value = value.Coating.Header.Description;
                    if (value.Paint.Header.Id == -1) { _paint.SelectedItem = null; }
                    if (value.Machine == 0) { _machine.SelectedItem = null; }
                    if (value.Coating.VWRecipe.Data != "")
                    {
                        VWVariable aa = value.Coating.VWRecipe.VWVariables.First(x => x.Item.ToString() == "CPU1.PLC.Blocks.03 Basket coating.01 CD.00 Main.DB CD PD.Station.CD.Step[0].Dipping.DT");
                        _tank.Value = textService.GetText("@Lists.Tank.Text" + aa.Value.ToString());
                    }
                    else { _tank.Value = ""; }
                   
                    if (value.Coating.Header.Name.Length > 1)
                    {
                        _img.SymbolResourceKey = "R_Coating";

                    }
                    else
                    {
                        _img.SymbolResourceKey = "Nor";

                    }
                }

            }
            get { return mcp; }
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            new ObjectAnimator().ShowUIElement(this);
            _paint.ItemsSource = null;
            _paint.StateList = GetPaintTypes();
            foreach (State i in _paint.StateList)
            {
                if (i.Value == MCP.Paint.Header.Id.ToString()) { _paint.SelectedItem = i; }
            }

            _machine.ItemsSource = null;
            _machine.StateList = GetMachines();

            foreach (State i in _machine.StateList)
            {
                if (i.Value == MCP.Machine.ToString()) { _machine.SelectedItem = i; }
            }
        }


        public override string ToString() { return "MR_Layer"; }

        private void _paint_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (_paint.SelectedItem != null) 
            {
                MCP.Paint.Header.Id = Convert.ToInt32(((State)_paint.SelectedItem).Value);

            }
            
        }
        private void _machine_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (_machine.SelectedItem != null)
            {
                MCP.Machine = (byte)Convert.ToSByte(((State)_machine.SelectedItem).Value);
            }

        }
        private StateCollection GetPaintTypes()
        {
            StateCollection Temp_SC = new StateCollection();

            DataTable DT = new MSSQLEAdapter("Recipes", "SELECT *  FROM Recipes_Paint; ").DB_Output();
            foreach(DataRow r in DT.Rows)
            if (DT.Rows.Count > 0)
            {
                Temp_SC.Add(new State()
                {
                    Text = (string)r["Name"],
                    Value = r["Id"].ToString()
                });
            }
            return Temp_SC;
        }
        private StateCollection GetMachines()
        {
            StateCollection Temp_SC = new StateCollection() 
            {
                new State()
                {
                    Text = "1",
                    Value = "1"
                },
                 new State()
                {
                    Text = "2",
                    Value = "2"
                }
            };

            return Temp_SC;
        }
    }
}
