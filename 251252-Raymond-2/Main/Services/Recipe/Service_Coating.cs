using HMI.CO.General;
using HMI.CO.Recipe;
using HMI.Interfaces;
using HMI.Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using VisiWin.ApplicationFramework;
using VisiWin.DataAccess;

namespace HMI.Services
{
    [ExportService(typeof(ICoating))]
    [Export(typeof(ICoating))]
    public class Service_Coating : ServiceBase, ICoating
    {
        IVariableService VS;
        static IVariable C_CD_ToPLC;


        public Service_Coating()
        {
            if (ApplicationService.IsInDesignMode)
                return;
        }

        #region - - - OnProject - - - 


        // Hier stehen noch keine VisiWin Funktionen zur Verfügung
        protected override void OnLoadProjectStarted()
        {
            base.OnLoadProjectStarted();
        }

        // Hier kann auf die VisiWin Funktionen zugegriffen werden
        protected override void OnLoadProjectCompleted()
        {
            VS = ApplicationService.GetService<IVariableService>();

            C_CD_ToPLC = VS.GetVariable("CPU1.PLC.Blocks.03 Basket coating.01 CD.00 Main.DB CD HMI.PC.Handshake.to.Request");
            C_CD_ToPLC.Change += C_CD_ToPLC_Change;

            base.OnLoadProjectCompleted();
        }

        // Hier stehen noch die VisiWin Funktionen zur Verfügung
        protected override void OnUnloadProjectStarted()
        {
            base.OnUnloadProjectStarted();
        }

        // Hier sind keine VisiWin Funktionen mehr verfügbar. Bei C/S ist die Verbindung zum Server schon getrennt.
        protected override void OnUnloadProjectCompleted()
        {
            base.OnUnloadProjectCompleted();
        }

        #endregion

        #region - - - Event Handlers - - -
        void C_CD_ToPLC_Change(object sender, VariableEventArgs e)
        {
            if ((bool)e.Value)
            {

                Task obTask = Task.Run(async () =>
                {
                    await Task.Delay(1000);
                    ApplicationService.SetVariableValue("CPU1.PLC.Blocks.03 Basket coating.01 CD.00 Main.DB CD HMI.PC.Handshake.to.Request", false);

                    try
                    {
                        short Layer = (short)((byte)ApplicationService.GetVariableValue("CPU1.PLC.Blocks.03 Basket coating.01 CD.00 Main.DB CD PD.Charge.Layer[1].Actual") + (byte)ApplicationService.GetVariableValue("CPU1.PLC.Blocks.03 Basket coating.01 CD.00 Main.DB CD PD.Charge.Layer[0].Actual"));

                        MR MR = GetMRData((uint)ApplicationService.GetVariableValue("CPU1.PLC.Blocks.03 Basket coating.01 CD.00 Main.DB CD PD.Header.MR"), Layer);

                        if (Layer == 4)
                        {
                            ApplicationService.SetVariableValue("CPU1.PLC.Blocks.03 Basket coating.01 CD.00 Main.DB CD PD.Charge.Paint.Next", 0);
                            ApplicationService.SetVariableValue("CPU1.PLC.Blocks.03 Basket coating.01 CD.00 Main.DB CD PD.Charge.Machine.Next", 0);
                        }
                        else
                        {
                            ApplicationService.SetVariableValue("CPU1.PLC.Blocks.03 Basket coating.01 CD.00 Main.DB CD PD.Charge.Paint.Next", MR.Layers[Layer + 1].Paint.Header.Id);
                            ApplicationService.SetVariableValue("CPU1.PLC.Blocks.03 Basket coating.01 CD.00 Main.DB CD PD.Charge.Machine.Next", MR.Layers[Layer + 1].Machine);
                        }

                        await MR.Layers[Layer].Coating.LoadToPLC();

                    }
                    catch (Exception ex)
                    {
                        ApplicationService.SetVariableValue("CPU1.PLC.Blocks.03 Basket coating.01 CD.00 Main.DB CD HMI.PC.Handshake.from.Not loaded", true);
                        new MessageBoxTask("@RecipeSystem.Results.Text8", "@RecipeSystem.Results.Text2", MessageBoxIcon.Error);
                        string Message = "Error at line - " + new StackTrace(ex, true).GetFrame(new StackTrace(ex, true).FrameCount - 1).GetFileLineNumber().ToString() + " - " + Environment.NewLine;
                        Message += "Message : " + ex.Message + Environment.NewLine;
                        Message += "Stacktrace : " + ex.StackTrace + Environment.NewLine;

                        File.WriteAllText("C:\\Backup\\VW_C_" + DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss") + ".txt", Message);
                    }

                });
            }
        }

        #endregion

        #region - - - Methods - - -

         MR GetMRData(uint mr_id, short layer)
        {
            MR temp = new MR();
            DataTable DT = new MSSQLEAdapter("Recipes", "SELECT *" +
                                                       "FROM Recipes_MR " +
                                                       "WHERE Id = " + mr_id + ";").DB_Output();
            if (DT.Rows.Count > 0)
            {
                temp.Header = new RecipeInfo();

                temp.Layers = new List<MCP>()
                {
                   new MCP()
                    {
                        Machine = (int)DT.Rows[0]["M0_Id"] == -1 ? 0 : (int)DT.Rows[0]["M0_Id"],
                        Coating = new CO.Recipe.Coating() { Header = new RecipeInfo() { Id = (int)DT.Rows[0]["C0_Id"] } },
                        Paint = new CO.Recipe.Paint() { Header = new RecipeInfo() { Id = (int)DT.Rows[0]["P0_Id"] == -1 ? 0 : (int)DT.Rows[0]["P0_Id"]} }
                    },
                    new MCP()
                    {
                        Machine = (int)DT.Rows[0]["M1_Id"] == -1 ? 0 : (int)DT.Rows[0]["M1_Id"],
                        Coating = new CO.Recipe.Coating() { Header = new RecipeInfo() { Id = (int)DT.Rows[0]["C1_Id"] } },
                        Paint = new CO.Recipe.Paint() { Header = new RecipeInfo() { Id = (int)DT.Rows[0]["P1_Id"] == -1 ? 0 : (int)DT.Rows[0]["P1_Id"] } }
                    },
                    new MCP()
                    {
                        Machine = (int)DT.Rows[0]["M2_Id"] == -1 ? 0 : (int)DT.Rows[0]["M2_Id"],
                        Coating = new CO.Recipe.Coating() { Header = new RecipeInfo() { Id = (int)DT.Rows[0]["C2_Id"] } },
                        Paint = new CO.Recipe.Paint() { Header = new RecipeInfo() { Id = (int)DT.Rows[0]["P2_Id"] == -1 ? 0 : (int)DT.Rows[0]["P2_Id"] } }
                    },
                    new MCP()
                    {
                        Machine = (int)DT.Rows[0]["M3_Id"]== -1 ? 0 : (int)DT.Rows[0]["M3_Id"],
                        Coating = new CO.Recipe.Coating() { Header = new RecipeInfo() { Id = (int)DT.Rows[0]["C3_Id"] } },
                        Paint = new CO.Recipe.Paint() { Header = new RecipeInfo() { Id = (int)DT.Rows[0]["P3_Id"] == -1 ? 0 : (int)DT.Rows[0]["P3_Id"] } }
                    },
                    new MCP()
                    {
                        Machine = (int)DT.Rows[0]["M4_Id"] == -1 ? 0 : (int)DT.Rows[0]["M4_Id"],
                        Coating = new CO.Recipe.Coating() { Header = new RecipeInfo() { Id = (int)DT.Rows[0]["C4_Id"] } },
                        Paint = new CO.Recipe.Paint() { Header = new RecipeInfo() { Id = (int)DT.Rows[0]["P4_Id"] == -1 ? 0 : (int)DT.Rows[0]["P4_Id"]} }
                    }
                };

                temp.Layers[layer].Coating = GetCoatingData((int)DT.Rows[0]["C"+ layer + "_Id"]);
            }
            else 
            {
                ApplicationService.SetVariableValue("CPU1.PLC.Blocks.03 Basket coating.01 CD.00 Main.DB CD HMI.PC.Handshake.from.Not loaded", true);
                new MessageBoxTask("@RecipeSystem.Results.Text7", "@RecipeSystem.Text3", MessageBoxIcon.Error);
            }

            return temp;
        }
        Coating GetCoatingData(long _id)
        {
            Coating temp = new Coating();
            if (_id > 0)
            {
                DataTable DT = new MSSQLEAdapter("Recipes", "SELECT *  FROM Recipes_Coating WHERE Id = " + _id + "; ").DB_Output();

                if (DT.Rows.Count > 0)
                {
                    temp = new Coating()
                    {
                        Header = new RecipeInfo()
                        {
                            Id = (int)_id,
                            Name = (string)DT.Rows[0]["Name"],
                            Description = (string)DT.Rows[0]["Description"],
                        },
                        VWRecipe = new VWRecipe("Coating", (string)DT.Rows[0]["VWRecipe"])
                    };
                }
                else
                {
                    ApplicationService.SetVariableValue("CPU1.PLC.Blocks.03 Basket coating.01 CD.00 Main.DB CD HMI.PC.Handshake.from.Not loaded", true);
                    new MessageBoxTask("@RecipeSystem.Results.Text7", "@RecipeSystem.Text4", MessageBoxIcon.Error);
                }
            }
            else
            {
                ApplicationService.SetVariableValue("CPU1.PLC.Blocks.03 Basket coating.01 CD.00 Main.DB CD HMI.PC.Handshake.from.Not loaded", true);
                new MessageBoxTask("@RecipeSystem.Results.Text7", "@RecipeSystem.Text4", MessageBoxIcon.Error);
            }
            return temp;
        }

        #endregion

    }
}
