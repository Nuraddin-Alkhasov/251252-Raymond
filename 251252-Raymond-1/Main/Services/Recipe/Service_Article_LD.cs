using HMI.CO.General;
using HMI.CO.Protocol;
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
    [ExportService(typeof(IArticleLD))]
    [Export(typeof(IArticleLD))]
    public class Service_Article_LD : ServiceBase, IArticleLD
    {
        IVariableService VS;
        static IVariable A_LD_ToPLC;
        public Service_Article_LD()
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
            
            A_LD_ToPLC = VS.GetVariable("CPU1.PLC.Blocks.01 Basket feeding.01 LD.00 Main.DB LD HMI.PC.Handshake.to.Request");
            A_LD_ToPLC.Change += A_LD_ToPLC_Change;

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

        void A_LD_ToPLC_Change(object sender, VariableEventArgs e)
        {
            if ((bool)e.Value)
            {
                Task obTask = Task.Run(async () =>
                {
                    await Task.Delay(1000);
                    ApplicationService.SetVariableValue("CPU1.PLC.Blocks.01 Basket feeding.01 LD.00 Main.DB LD HMI.PC.Handshake.to.Request", false);

                    try
                    {
                        //MR MR = GetMRData((uint)ApplicationService.GetVariableValue("CPU1.PLC.Blocks.01 Basket feeding.01 LD.00 Main.DB LD PD.Header.MR"));
                        MR MR = GetMRData(GetMRbyBarcode(ApplicationService.GetVariableValue("CPU1.PLC.Blocks.01 Basket feeding.01 LD.00 Main.DB LD HMI.PC.Data.from.Barcode.Number#STRING20").ToString()));
                        if (MR.Header.Id > 0)
                        {
                            ApplicationService.SetVariableValue("CPU1.PLC.Blocks.01 Basket feeding.01 LD.00 Main.DB LD PD.Header.MR", MR.Header.Id);

                            int M1 = 0, M2 = 0;
                            for (int i = 0; i < MR.Layers.Count; i++)
                            {
                                if (MR.Layers[i].Coating.Header.Id != -1)
                                {
                                    if (MR.Layers[i].Machine == 1)
                                    {
                                        M1 = M1 + 1;
                                    }
                                    if (MR.Layers[i].Machine == 2)
                                    {
                                        M2 = M2 + 1;
                                    }
                                }
                            }

                            ApplicationService.SetVariableValue("CPU1.PLC.Blocks.01 Basket feeding.01 LD.00 Main.DB LD PD.Charge.Layer[0].Set", M1);
                            ApplicationService.SetVariableValue("CPU1.PLC.Blocks.01 Basket feeding.01 LD.00 Main.DB LD PD.Charge.Layer[1].Set", M2);
                            ApplicationService.SetVariableValue("CPU1.PLC.Blocks.01 Basket feeding.01 LD.00 Main.DB LD PD.Charge.Paint.Next", MR.Layers[0].Paint.Header.Id);
                            ApplicationService.SetVariableValue("CPU1.PLC.Blocks.01 Basket feeding.01 LD.00 Main.DB LD PD.Charge.Available", 1);
                            ApplicationService.SetVariableValue("CPU1.PLC.Blocks.01 Basket feeding.01 LD.00 Main.DB LD PD.Charge.Machine.Actual", 1);
                            ApplicationService.SetVariableValue("CPU1.PLC.Blocks.01 Basket feeding.01 LD.00 Main.DB LD PD.Charge.Machine.Next", MR.Layers[0].Machine);
                            await MR.Article.LD.LoadToPLC();
                        }
                    }
                    catch (Exception ex)
                    {
                        ApplicationService.SetVariableValue("CPU1.PLC.Blocks.01 Basket feeding.01 LD.00 Main.DB LD HMI.PC.Handshake.from.Not loaded", true);
                        new MessageBoxTask("@RecipeSystem.Results.Text8", "@RecipeSystem.Results.Text2", MessageBoxIcon.Error);

                        string Message = "Error at line - " + new StackTrace(ex, true).GetFrame(new StackTrace(ex, true).FrameCount - 1).GetFileLineNumber().ToString() + " - " + Environment.NewLine;
                        Message += "Message : " + ex.Message + Environment.NewLine;
                        Message += "Stacktrace : " + ex.StackTrace + Environment.NewLine;

                        File.WriteAllText("C:\\Backup\\VW_" + DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss") + ".txt", Message);
                    }
                });
            }
        }

        #endregion


        #region - - - Methods - - -

        MR GetMRData(uint mr_id)
        {
            MR temp = new MR();
            DataTable DT = new MSSQLEAdapter("Recipes", "SELECT *" +
                                                       "FROM Recipes_MR " +
                                                       "WHERE Id = " + mr_id + ";").DB_Output();
            if (DT.Rows.Count > 0)
            {
                temp.Header = new RecipeInfo() 
                {
                    Id = (int)DT.Rows[0]["Id"]
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
            else
            {
                ApplicationService.SetVariableValue("CPU1.PLC.Blocks.01 Basket feeding.01 LD.00 Main.DB LD HMI.PC.Handshake.from.Not loaded", true);
                new MessageBoxTask("@RecipeSystem.Results.Text7", "@RecipeSystem.Text3", MessageBoxIcon.Error);
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
                        LD = new LD()
                        {
                            Header = new RecipeInfo(),
                            VWRecipe = new VWRecipe("LD", (string)DT.Rows[0]["LD_VWRecipe"])
                        },
                        BT = new BT(),
                        PO = new PO()
                    };
                }
                else
                {
                    ApplicationService.SetVariableValue("CPU1.PLC.Blocks.01 Basket feeding.01 LD.00 Main.DB LD HMI.PC.Handshake.from.Not loaded", true);
                    new MessageBoxTask("@RecipeSystem.Results.Text7", "@RecipeSystem.Text5", MessageBoxIcon.Error);
                }
            }
            else
            {
                ApplicationService.SetVariableValue("CPU1.PLC.Blocks.02 Basket handling.04 BT.00 Main.DB BT HMI.PC.Handshake.from.Not loaded", true);
                new MessageBoxTask("@RecipeSystem.Results.Text7", "@RecipeSystem.Text5", MessageBoxIcon.Error);
            }

            return temp;
        }

        uint GetMRbyBarcode(string _barcode)
        {
            DataTable DT = new MSSQLEAdapter("Recipes", "SELECT * " +
                                              "FROM Barcodes " +
                                              "WHERE Barcode ='" + _barcode + "'; ").DB_Output();
            if (DT.Rows.Count != 0)
            {

                return (uint)(int)DT.Rows[0]["MR_Id"];
            }
            else { return 0; }
        }
        #endregion
    }
}
