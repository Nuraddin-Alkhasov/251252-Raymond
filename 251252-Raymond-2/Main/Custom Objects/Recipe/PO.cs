using HMI.CO.General;
using HMI.Resources;
using System;
using System.IO;
using System.Threading.Tasks;
using VisiWin.ApplicationFramework;
using VisiWin.Recipe;

namespace HMI.CO.Recipe
{
    public class PO
    {
        public PO()
        {
        }
        public PO(RecipeInfo _Header, VWRecipe _VWRecipe)
        {
            Header = _Header;
            VWRecipe = _VWRecipe;
        }
        private IRecipeClass Class = ApplicationService.GetService<IRecipeService>().GetRecipeClass("PO");
        public RecipeInfo Header { set; get; } = new RecipeInfo();
        public VWRecipe VWRecipe { set; get; } = new VWRecipe();

        public async Task LoadToPLC()
        {
            IRecipeClass Class = ApplicationService.GetService<IRecipeService>().GetRecipeClass(VWRecipe.Class);

            File.WriteAllText(Class.CurrentPath + @"\TempPO.R", VWRecipe.Data);
            LoadFromFileToProcessResult result = await Class.LoadFromFileToProcessAsync("TempPO");
            if (result.Result != SendRecipeResult.Succeeded)
            {
                ApplicationService.SetVariableValue("CPU2.PLC.Blocks.04 Tray handling.08 PO.00 Main.DB PO HMI.PC.Handshake.from.Not loaded", true);
                new MessageBoxTask("@RecipeSystem.Results.LoadError", "@RecipeSystem.Results.Text2", MessageBoxIcon.Error);
            }
            else
            {
                await Task.Delay(1000);
                ApplicationService.SetVariableValue("CPU2.PLC.Blocks.04 Tray handling.08 PO.00 Main.DB PO HMI.PC.Handshake.from.Loaded", true);
            }

        }

        public override string ToString()
        {
            return Header.Id.ToString() + " - " + Header.Name;
        }
        public int Check()
        {
            object o = null;

            Class.GetValue("CPU2.PLC.Blocks.04 Tray handling.08 PO.00 Main.DB PO PD.Station.PO.Angle", out o);
            if (Convert.ToDouble(o) == 0) { return 21; }
            Class.GetValue("CPU2.PLC.Blocks.04 Tray handling.08 PO.00 Main.DB PO PD.Station.PO.Speed", out o);
            if (Convert.ToDouble(o) == 0) { return 22; }
            return 0;
        }
    }
}
