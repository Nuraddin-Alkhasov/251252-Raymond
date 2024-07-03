using HMI.CO.General;
using HMI.Resources;
using System;
using System.IO;
using System.Threading.Tasks;
using VisiWin.ApplicationFramework;
using VisiWin.Recipe;

namespace HMI.CO.Recipe
{
    public class BT
    {
        public BT()
        {
        }
        public BT(RecipeInfo _Header, VWRecipe _VWRecipe)
        {
            Header = _Header;
            VWRecipe = _VWRecipe;
        }
        private IRecipeClass Class = ApplicationService.GetService<IRecipeService>().GetRecipeClass("BT");
        public RecipeInfo Header { set; get; } = new RecipeInfo();
        public VWRecipe VWRecipe { set; get; } = new VWRecipe();

        public async Task LoadToPLC()
        {
            IRecipeClass Class = ApplicationService.GetService<IRecipeService>().GetRecipeClass(VWRecipe.Class);

            File.WriteAllText(Class.CurrentPath + @"\TempBT.R", VWRecipe.Data);
            LoadFromFileToProcessResult result = await Class.LoadFromFileToProcessAsync("TempBT");
            if (result.Result != SendRecipeResult.Succeeded)
            {
                ApplicationService.SetVariableValue("CPU1.PLC.Blocks.02 Basket handling.04 BT.00 Main.DB BT HMI.PC.Handshake.from.Not loaded", true);
                new MessageBoxTask("@RecipeSystem.Results.LoadError", "@RecipeSystem.Results.Text2", MessageBoxIcon.Error);
            }
            else
            {
                await Task.Delay(1000);
                ApplicationService.SetVariableValue("CPU1.PLC.Blocks.02 Basket handling.04 BT.00 Main.DB BT HMI.PC.Handshake.from.Loaded", true);
            }

        }

        public override string ToString()
        {
            return Header.Id.ToString() + " - " + Header.Name;
        }
        public int Check()
        {
            object o = null;

            Class.GetValue("CPU1.PLC.Blocks.02 Basket handling.04 BT.00 Main.DB BT PD.Station.BT.Angle", out o);
            if (Convert.ToDouble(o) == 0) { return 8; }
            object a1 = null;
            Class.GetValue("CPU1.PLC.Blocks.02 Basket handling.04 BT.00 Main.DB BT PD.Station.BT.Step[0].Angle", out a1);
            if (Convert.ToDouble(o) == 0) { return 9; }
            Class.GetValue("CPU1.PLC.Blocks.02 Basket handling.04 BT.00 Main.DB BT PD.Station.BT.Step[0].Speed", out o);
            if (Convert.ToDouble(o) == 0) { return 10; }
            Class.GetValue("CPU1.PLC.Blocks.02 Basket handling.04 BT.00 Main.DB BT PD.Station.BT.Step[0].Wait", out o);
            if (Convert.ToDouble(o) == 0) { return 11; }
            object a2 = null;
            Class.GetValue("CPU1.PLC.Blocks.02 Basket handling.04 BT.00 Main.DB BT PD.Station.BT.Step[1].Angle", out a2);
            if (Convert.ToDouble(a2) != 0)
            {
                if (Convert.ToDouble(a2) <= Convert.ToDouble(a1)) { return 12; }
                Class.GetValue("CPU1.PLC.Blocks.02 Basket handling.04 BT.00 Main.DB BT PD.Station.BT.Step[1].Speed", out o);
                if (Convert.ToDouble(o) == 0) { return 13; }
                Class.GetValue("CPU1.PLC.Blocks.02 Basket handling.04 BT.00 Main.DB BT PD.Station.BT.Step[1].Wait", out o);
                if (Convert.ToDouble(o) == 0) { return 14; }
            }
            object a3 = null;
            Class.GetValue("CPU1.PLC.Blocks.02 Basket handling.04 BT.00 Main.DB BT PD.Station.BT.Step[2].Angle", out a3);
            if (Convert.ToDouble(a3) != 0)
            {
                if (Convert.ToDouble(a3) <= Convert.ToDouble(a2)) { return 15; }
                Class.GetValue("CPU1.PLC.Blocks.02 Basket handling.04 BT.00 Main.DB BT PD.Station.BT.Step[2].Speed", out o);
                if (Convert.ToDouble(o) == 0) { return 16; }
                Class.GetValue("CPU1.PLC.Blocks.02 Basket handling.04 BT.00 Main.DB BT PD.Station.BT.Step[2].Wait", out o);
                if (Convert.ToDouble(o) == 0) { return 17; }
            }
            Class.GetValue("CPU1.PLC.Blocks.02 Basket handling.04 BT.00 Main.DB BT PD.Station.BT.Step[3].Angle", out o);
            if (Convert.ToDouble(o) != 0)
            {
                if (Convert.ToDouble(o) <= Convert.ToDouble(a3)) { return 18; }
                Class.GetValue("CPU1.PLC.Blocks.02 Basket handling.04 BT.00 Main.DB BT PD.Station.BT.Step[3].Speed", out o);
                if (Convert.ToDouble(o) == 0) { return 19; }
                Class.GetValue("CPU1.PLC.Blocks.02 Basket handling.04 BT.00 Main.DB BT PD.Station.BT.Step[3].Wait", out o);
                if (Convert.ToDouble(o) == 0) { return 20; }
            }

            return 0;
        }
    }
}
