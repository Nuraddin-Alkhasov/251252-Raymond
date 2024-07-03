using HMI.CO.General;
using HMI.Resources;
using System;
using System.IO;
using System.Threading.Tasks;
using VisiWin.ApplicationFramework;
using VisiWin.Recipe;

namespace HMI.CO.Recipe
{
    public class LD
    {
        public LD()
        {
        }
        public LD(RecipeInfo _Header, VWRecipe _VWRecipe)
        {
            Header = _Header;
            VWRecipe = _VWRecipe;
        }
        private IRecipeClass Class = ApplicationService.GetService<IRecipeService>().GetRecipeClass("LD");
        public RecipeInfo Header { set; get; } = new RecipeInfo();
        public VWRecipe VWRecipe { set; get; } = new VWRecipe();

        public async Task LoadToPLC()
        {
            IRecipeClass Class = ApplicationService.GetService<IRecipeService>().GetRecipeClass(VWRecipe.Class);

            File.WriteAllText(Class.CurrentPath + @"\TempLD.R", VWRecipe.Data);
            LoadFromFileToProcessResult result = await Class.LoadFromFileToProcessAsync("TempLD");
            if (result.Result != SendRecipeResult.Succeeded)
            {
                ApplicationService.SetVariableValue("CPU1.PLC.Blocks.01 Basket feeding.01 LD.00 Main.DB LD HMI.PC.Handshake.from.Not loaded", true);
                new MessageBoxTask("@RecipeSystem.Results.LoadError", "@RecipeSystem.Results.Text2", MessageBoxIcon.Error);
            }
            else
            {
                await Task.Delay(1000);
                ApplicationService.SetVariableValue("CPU1.PLC.Blocks.01 Basket feeding.01 LD.00 Main.DB LD HMI.PC.Handshake.from.Loaded", true);
            }

        }

        public override string ToString()
        {
            return Header.Id.ToString() + " - " + Header.Name;
        }

        public int Check()
        {
            object o = null;

            Class.GetValue("CPU1.PLC.Blocks.01 Basket feeding.01 LD.00 Main.DB LD PD.Station.LD.Step[0].Open", out o);
            if (Convert.ToDouble(o) == 0) { return 2; }
            Class.GetValue("CPU1.PLC.Blocks.01 Basket feeding.01 LD.00 Main.DB LD PD.Station.LD.Step[0].Wait", out o);
            if (Convert.ToDouble(o) == 0) { return 3; }
            Class.GetValue("CPU1.PLC.Blocks.01 Basket feeding.01 LD.00 Main.DB LD PD.Station.LD.Step[1].Open", out o);
            if (Convert.ToDouble(o) != 0)
            {
                Class.GetValue("CPU1.PLC.Blocks.01 Basket feeding.01 LD.00 Main.DB LD PD.Station.LD.Step[1].Wait", out o);
                if (Convert.ToDouble(o) == 0) { return 4; }
            }
            Class.GetValue("CPU1.PLC.Blocks.01 Basket feeding.01 LD.00 Main.DB LD PD.Station.LD.Step[2].Open", out o);
            if (Convert.ToDouble(o) != 0)
            {
                Class.GetValue("CPU1.PLC.Blocks.01 Basket feeding.01 LD.00 Main.DB LD PD.Station.LD.Step[2].Wait", out o);
                if (Convert.ToDouble(o) == 0) { return 5; }
            }
            Class.GetValue("CPU1.PLC.Blocks.01 Basket feeding.01 LD.00 Main.DB LD PD.Station.LD.Step[3].Open", out o);
            if (Convert.ToDouble(o) != 0)
            {
                Class.GetValue("CPU1.PLC.Blocks.01 Basket feeding.01 LD.00 Main.DB LD PD.Station.LD.Step[3].Wait", out o);
                if (Convert.ToDouble(o) == 0) { return 6; }
            }

            Class.GetValue("CPU1.PLC.Blocks.01 Basket feeding.01 LD.00 Main.DB LD PD.Station.BS.Weight", out o);
            if (Convert.ToDouble(o) == 0) { return 7; }

            return 0;
        }
    }
}
