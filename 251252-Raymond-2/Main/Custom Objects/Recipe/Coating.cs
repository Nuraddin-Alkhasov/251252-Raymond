using HMI.CO.General;
using HMI.Resources;
using System;
using System.IO;
using System.Threading.Tasks;
using VisiWin.ApplicationFramework;
using VisiWin.Recipe;

namespace HMI.CO.Recipe
{
    public class Coating
    {
        public Coating()
        {
        }
        public Coating(RecipeInfo _Header, VWRecipe _VWRecipe)
        {
            Header = _Header;
            VWRecipe = _VWRecipe;
        }
        private IRecipeClass Class = ApplicationService.GetService<IRecipeService>().GetRecipeClass("Coating");
        public RecipeInfo Header { set; get; } = new RecipeInfo();
        public VWRecipe VWRecipe { set; get; } = new VWRecipe();

        public async Task LoadToPLC()
        {
            IRecipeClass Class = ApplicationService.GetService<IRecipeService>().GetRecipeClass(VWRecipe.Class);

            File.WriteAllText(Class.CurrentPath + @"\TempCoating.R", VWRecipe.Data);
            LoadFromFileToProcessResult result = await Class.LoadFromFileToProcessAsync("TempCoating");
            if (result.Result != SendRecipeResult.Succeeded)
            {
                ApplicationService.SetVariableValue("CPU1.PLC.Blocks.03 Basket coating.01 CD.00 Main.DB CD HMI.PC.Handshake.from.Not loaded", true);
                new MessageBoxTask("@RecipeSystem.Results.LoadError", "@RecipeSystem.Results.Text2", MessageBoxIcon.Error);
            }
            else
            {
                //new MessageBoxTask("@RecipeSystem.Results.LoadOK", "@RecipeSystem.Results.Text2", MessageBoxIcon.Information);
                ApplicationService.SetVariableValue("CPU1.PLC.Blocks.03 Basket coating.01 CD.00 Main.DB CD HMI.PC.Handshake.from.Loaded", true);
            }

        }

        public override string ToString()
        {
            return Header.Id.ToString() + " - " + Header.Name;
        }

        public int Check()
        {
            object o = null;
            object o1 = null;

            Class.GetValue("CPU1.PLC.Blocks.03 Basket coating.01 CD.00 Main.DB CD PD.Station.CD.Step[0].Dipping.Angle", out o);
            if (Convert.ToDouble(o) == 0.0f)
            {
                Class.GetValue("CPU1.PLC.Blocks.03 Basket coating.01 CD.00 Main.DB CD PD.Station.CD.Step[0].Dipping.Straight time", out o);
                if ((byte)o < 5)
                {
                    return 1;
                }
            }
            if (Convert.ToDouble(o) >= 40.0f)
            {
                Class.GetValue("CPU1.PLC.Blocks.03 Basket coating.01 CD.00 Main.DB CD PD.Station.CD.Step[0].Dipping.Time", out o);
                if ((byte)o < 5)
                {
                    return 1;
                }
            }

            Class.GetValue("CPU1.PLC.Blocks.03 Basket coating.01 CD.00 Main.DB CD PD.Station.CD.Step[0].Dipping.Straight", out o);
            if ((bool)o)
            {
                Class.GetValue("CPU1.PLC.Blocks.03 Basket coating.01 CD.00 Main.DB CD PD.Station.CD.Step[0].Dipping.Straight time", out o);
                if ((byte)o < 5) { return 2; }
            }
            object st1 = null;
            object st2 = null;
            object st3 = null;

            Class.GetValue("CPU1.PLC.Blocks.03 Basket coating.01 CD.00 Main.DB CD PD.Station.CD.Step[1].Spinning.1.Time", out st1);
            Class.GetValue("CPU1.PLC.Blocks.03 Basket coating.01 CD.00 Main.DB CD PD.Station.CD.Step[1].Spinning.2.Time", out st2);
            Class.GetValue("CPU1.PLC.Blocks.03 Basket coating.01 CD.00 Main.DB CD PD.Station.CD.Step[1].Spinning.3.Time", out st3);

            if ((byte)st1 < 1 && (byte)st2 < 1 && (byte)st3 < 1) { return 3; }

            if ((byte)st1 >= 5) 
            {
                Class.GetValue("CPU1.PLC.Blocks.03 Basket coating.01 CD.00 Main.DB CD PD.Station.CD.Step[1].Spinning.1.Rotor", out o);
                if (Convert.ToDouble(o) < 130)
                { 

                    return 4; 
                }
            }
            if ((byte)st2 >= 5)
            {
                Class.GetValue("CPU1.PLC.Blocks.03 Basket coating.01 CD.00 Main.DB CD PD.Station.CD.Step[1].Spinning.2.Planet", out o1);
                if (Convert.ToDouble(o1) == 0)
                {

                    Class.GetValue("CPU1.PLC.Blocks.03 Basket coating.01 CD.00 Main.DB CD PD.Station.CD.Step[1].Spinning.2.Rotor", out o);
                    if (Convert.ToDouble(o) < 130)
                    {

                        return 5;
                    }
                }

                Class.GetValue("CPU1.PLC.Blocks.03 Basket coating.01 CD.00 Main.DB CD PD.Station.CD.Step[1].Spinning.2.Rotor", out o);

                if (Convert.ToDouble(o) < 130)
                {
                    if ((byte)st3 < 5)
                    {
                        return 3;
                    }
                }
            }
            if ((byte)st3 >= 5)
            {
                Class.GetValue("CPU1.PLC.Blocks.03 Basket coating.01 CD.00 Main.DB CD PD.Station.CD.Step[1].Spinning.3.Rotor", out o);
                if (Convert.ToDouble(o) < 130)
                {

                    return 6;
                }
            }
            Class.GetValue("CPU1.PLC.Blocks.03 Basket coating.01 CD.00 Main.DB CD PD.Station.CD.Step[2].Type", out o);
            if ((byte)o == 1) 
            {
                Class.GetValue("CPU1.PLC.Blocks.03 Basket coating.01 CD.00 Main.DB CD PD.Station.CD.Step[2].Dipping.Angle", out o);
                Class.GetValue("CPU1.PLC.Blocks.03 Basket coating.01 CD.00 Main.DB CD PD.Station.CD.Step[2].Dipping.Draining", out o1);
                if (Convert.ToDouble(o) == 0.0f)
                {
                    Class.GetValue("CPU1.PLC.Blocks.03 Basket coating.01 CD.00 Main.DB CD PD.Station.CD.Step[2].Dipping.Straight time", out o);
                    if ((byte)o < 5 && (byte)o1 < 5)
                    {
                        return 7;
                    }
                }
                if (Convert.ToDouble(o) >= 40.0f)
                {
                    Class.GetValue("CPU1.PLC.Blocks.03 Basket coating.01 CD.00 Main.DB CD PD.Station.CD.Step[2].Dipping.Time", out o);
                    if ((byte)o < 5 && (byte)o1 < 5)
                    {
                        return 7;
                    }
                }

                Class.GetValue("CPU1.PLC.Blocks.03 Basket coating.01 CD.00 Main.DB CD PD.Station.CD.Step[2].Dipping.Straight", out o);
                if ((bool)o)
                {
                    Class.GetValue("CPU1.PLC.Blocks.03 Basket coating.01 CD.00 Main.DB CD PD.Station.CD.Step[2].Dipping.Straight time", out o);
                    if ((byte)o < 5) { return 8; }
                }
            }

            Class.GetValue("CPU1.PLC.Blocks.03 Basket coating.01 CD.00 Main.DB CD PD.Station.CD.Step[2].Type", out o);
            if ((byte)o == 2) 
            {
                Class.GetValue("CPU1.PLC.Blocks.03 Basket coating.01 CD.00 Main.DB CD PD.Station.CD.Step[2].Spinning.1.Time", out st1);
                Class.GetValue("CPU1.PLC.Blocks.03 Basket coating.01 CD.00 Main.DB CD PD.Station.CD.Step[2].Spinning.2.Time", out st2);
                Class.GetValue("CPU1.PLC.Blocks.03 Basket coating.01 CD.00 Main.DB CD PD.Station.CD.Step[2].Spinning.3.Time", out st3);

                if ((byte)st1 < 1 && (byte)st2 < 1 && (byte)st3 < 1) { return 9; }

                if ((byte)st1 >= 5)
                {
                    Class.GetValue("CPU1.PLC.Blocks.03 Basket coating.01 CD.00 Main.DB CD PD.Station.CD.Step[2].Spinning.1.Rotor", out o);
                    if (Convert.ToDouble(o) < 130)
                    {

                        return 10;
                    }
                }
                if ((byte)st2 >= 5)
                {
                    Class.GetValue("CPU1.PLC.Blocks.03 Basket coating.01 CD.00 Main.DB CD PD.Station.CD.Step[2].Spinning.2.Planet", out o1);
                    if (Convert.ToDouble(o1) == 0)
                    {

                        Class.GetValue("CPU1.PLC.Blocks.03 Basket coating.01 CD.00 Main.DB CD PD.Station.CD.Step[2].Spinning.2.Rotor", out o);
                        if (Convert.ToDouble(o) < 130)
                        {

                            return 11;
                        }
                    }

                    Class.GetValue("CPU1.PLC.Blocks.03 Basket coating.01 CD.00 Main.DB CD PD.Station.CD.Step[2].Spinning.2.Rotor", out o);

                    if (Convert.ToDouble(o) < 130)
                    {
                        if ((byte)st3 < 5) 
                        {
                            return 3;
                        }
                    }
                }
                if ((byte)st3 >= 5)
                {
                    Class.GetValue("CPU1.PLC.Blocks.03 Basket coating.01 CD.00 Main.DB CD PD.Station.CD.Step[2].Spinning.3.Rotor", out o);
                    if (Convert.ToDouble(o) < 130)
                    {

                        return 12;
                    }
                }
            }

            Class.GetValue("CPU1.PLC.Blocks.03 Basket coating.01 CD.00 Main.DB CD PD.Station.CD.Step[3].Type", out o);
            if ((byte)o == 2) 
            {
                Class.GetValue("CPU1.PLC.Blocks.03 Basket coating.01 CD.00 Main.DB CD PD.Station.CD.Step[3].Spinning.1.Time", out st1);
                Class.GetValue("CPU1.PLC.Blocks.03 Basket coating.01 CD.00 Main.DB CD PD.Station.CD.Step[3].Spinning.2.Time", out st2);
                Class.GetValue("CPU1.PLC.Blocks.03 Basket coating.01 CD.00 Main.DB CD PD.Station.CD.Step[3].Spinning.3.Time", out st3);

                if ((byte)st1 < 1 && (byte)st2 < 1 && (byte)st3 < 1) { return 13; }

                if ((byte)st1 >= 5)
                {
                    Class.GetValue("CPU1.PLC.Blocks.03 Basket coating.01 CD.00 Main.DB CD PD.Station.CD.Step[3].Spinning.1.Rotor", out o);
                    if (Convert.ToDouble(o) < 130)
                    {

                        return 14;
                    }
                }
                if ((byte)st2 >= 5)
                {
                    Class.GetValue("CPU1.PLC.Blocks.03 Basket coating.01 CD.00 Main.DB CD PD.Station.CD.Step[3].Spinning.2.Planet", out o1);
                    if (Convert.ToDouble(o1) == 0)
                    {

                        Class.GetValue("CPU1.PLC.Blocks.03 Basket coating.01 CD.00 Main.DB CD PD.Station.CD.Step[3].Spinning.2.Rotor", out o);
                        if (Convert.ToDouble(o) < 130)
                        {

                            return 15;
                        }
                    }

                    Class.GetValue("CPU1.PLC.Blocks.03 Basket coating.01 CD.00 Main.DB CD PD.Station.CD.Step[3].Spinning.2.Rotor", out o);

                    if (Convert.ToDouble(o) < 130)
                    {
                        if ((byte)st3 < 5)
                        {
                            return 3;
                        }
                    }
                }
                if ((byte)st3 >= 5)
                {
                    Class.GetValue("CPU1.PLC.Blocks.03 Basket coating.01 CD.00 Main.DB CD PD.Station.CD.Step[3].Spinning.3.Rotor", out o);
                    if (Convert.ToDouble(o) < 130)
                    {

                        return 16;
                    }
                }
            }
               
            return 0;
        }
    }
}
