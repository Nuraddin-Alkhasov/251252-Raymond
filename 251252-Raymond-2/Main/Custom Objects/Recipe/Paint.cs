using HMI.CO.General;
using HMI.Resources;
using System;
using System.IO;
using System.Threading.Tasks;
using VisiWin.ApplicationFramework;
using VisiWin.Recipe;

namespace HMI.CO.Recipe
{
    public class Paint
    {
        public Paint()
        {
        }
        public Paint(RecipeInfo _Header, VWRecipe _VWRecipe)
        {
            Header = _Header;
            VWRecipe = _VWRecipe;
        }
        private IRecipeClass Class = ApplicationService.GetService<IRecipeService>().GetRecipeClass("Paint");
        public RecipeInfo Header { set; get; } = new RecipeInfo();
        public VWRecipe VWRecipe { set; get; } = new VWRecipe();

        public async Task LoadToPLC()
        {
            IRecipeClass Class = ApplicationService.GetService<IRecipeService>().GetRecipeClass(VWRecipe.Class);

            File.WriteAllText(Class.CurrentPath + @"\TempPaint.R", VWRecipe.Data);
            LoadFromFileToProcessResult result = await Class.LoadFromFileToProcessAsync("TempPaint");
            if (result.Result != SendRecipeResult.Succeeded)
            {
                ApplicationService.SetVariableValue("CPU1.PLC.Blocks.03 Basket coating.02 DT.00 Main.DB DT HMI.PC.Handshake.from.Not loaded", true);
                new MessageBoxTask("@RecipeSystem.Results.LoadError", "@RecipeSystem.Results.Text2", MessageBoxIcon.Error);
            }
            else
            {
                await Task.Delay(1000);
                ApplicationService.SetVariableValue("CPU1.PLC.Blocks.03 Basket coating.02 DT.00 Main.DB DT HMI.PC.Handshake.from.Loaded", true);
            }

        }

        public override string ToString()
        {
            return Header.Id.ToString() + " - " + Header.Name;
        }

        public int Check()
        {
            object o = null;
            object s1 = null;
            object s2 = null;
            object s3 = null;
            Class.GetValue("CPU1.PLC.Blocks.03 Basket coating.02 DT.00 Main.DB DT PD.Paint.Color", out o);
            if ((byte)o == 0) { return 1; }

            Class.GetValue("CPU1.PLC.Blocks.03 Basket coating.02 DT.00 Main.DB DT PD.Station.DT.Pump.isOn", out o);
            if ((bool)o)
            {
                Class.GetValue("CPU1.PLC.Blocks.03 Basket coating.02 DT.00 Main.DB DT PD.Station.DT.Pump.On.M", out s1);
                if ((byte)s1 < 1 || (byte)s1 > 250 ) { return 2; }

                Class.GetValue("CPU1.PLC.Blocks.03 Basket coating.02 DT.00 Main.DB DT PD.Station.DT.Pump.Off.M", out s1);
                if ((byte)s1 < 0 && (byte)s2 > 250) { return 3; }
            }
            
            Class.GetValue("CPU1.PLC.Blocks.03 Basket coating.02 DT.00 Main.DB DT PD.Station.DT.Viscosity.isOn", out o);
            if ((bool)o)
            {
                Class.GetValue("CPU1.PLC.Blocks.03 Basket coating.02 DT.00 Main.DB DT PD.Station.DT.Viscosity.Time.H", out s1);
                if ((uint)s1 < 1 || (uint)s1 > 10) { return 4; }
            }
            Class.GetValue("CPU1.PLC.Blocks.03 Basket coating.02 DT.00 Main.DB DT PD.Station.DT.Cool.isOn", out o);
            if ((bool)o)
            {
                Class.GetValue("CPU1.PLC.Blocks.03 Basket coating.02 DT.00 Main.DB DT PD.Station.DT.Cool.Set.Value", out s1);
                Class.GetValue("CPU1.PLC.Blocks.03 Basket coating.02 DT.00 Main.DB DT PD.Station.DT.Cool.Set.LL", out s2);
                Class.GetValue("CPU1.PLC.Blocks.03 Basket coating.02 DT.00 Main.DB DT PD.Station.DT.Cool.Set.UL", out s3);
                if ((float)s1 < 10 || (float)s1 > 30 || (float)s2 > (float)s1 || (float)s3 < (float)s1) { return 5; }
            }

            Class.GetValue("CPU1.PLC.Blocks.03 Basket coating.02 DT.00 Main.DB DT PD.Station.PZ.Preheat.isOn", out o);
            if ((bool)o)
            {
                Class.GetValue("CPU1.PLC.Blocks.03 Basket coating.02 DT.00 Main.DB DT PD.Station.PZ.Preheat.Set.Value", out s1);
                Class.GetValue("CPU1.PLC.Blocks.03 Basket coating.02 DT.00 Main.DB DT PD.Station.PZ.Preheat.Set.LL", out s2);
                Class.GetValue("CPU1.PLC.Blocks.03 Basket coating.02 DT.00 Main.DB DT PD.Station.PZ.Preheat.Set.UL", out s3);
                if ((float)s1 < 60 || (float)s1 > 90 || (float)s2 > (float)s1 || (float)s3 < (float)s1) { return 6; }
            }

            Class.GetValue("CPU1.PLC.Blocks.03 Basket coating.02 DT.00 Main.DB DT PD.Station.WZ.Heat.isOn", out o);
            if ((bool)o)
            {
                Class.GetValue("CPU1.PLC.Blocks.03 Basket coating.02 DT.00 Main.DB DT PD.Station.WZ.Heat.Set.Value", out s1);
                Class.GetValue("CPU1.PLC.Blocks.03 Basket coating.02 DT.00 Main.DB DT PD.Station.WZ.Heat.Set.LL", out s2);
                Class.GetValue("CPU1.PLC.Blocks.03 Basket coating.02 DT.00 Main.DB DT PD.Station.WZ.Heat.Set.UL", out s3);
                if ((float)s1 < 180 || (float)s1 > 320 || (float)s2 > (float)s1 || (float)s3 < (float)s1) { return 7; }
            }
            Class.GetValue("CPU1.PLC.Blocks.03 Basket coating.02 DT.00 Main.DB DT PD.Station.HZ.Hold.isOn", out o);
            if ((bool)o)
            {
                Class.GetValue("CPU1.PLC.Blocks.03 Basket coating.02 DT.00 Main.DB DT PD.Station.HZ.Hold.Set.Value", out s1);
                Class.GetValue("CPU1.PLC.Blocks.03 Basket coating.02 DT.00 Main.DB DT PD.Station.HZ.Hold.Set.LL", out s2);
                Class.GetValue("CPU1.PLC.Blocks.03 Basket coating.02 DT.00 Main.DB DT PD.Station.HZ.Hold.Set.UL", out s3);
                if ((float)s1 < 180 || (float)s1 > 320 || (float)s2 > (float)s1 || (float)s3 < (float)s1) { return 8; }
            }

            Class.GetValue("CPU1.PLC.Blocks.03 Basket coating.02 DT.00 Main.DB DT PD.Paint.Type", out o);
            if ((byte)o == 0) { return 9; }
            return 0;
        }
    }
}
