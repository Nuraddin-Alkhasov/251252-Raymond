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
    [ExportService(typeof(IArticlePO))]
    [Export(typeof(IArticlePO))]
    public class Service_Article_BT : ServiceBase, IArticlePO
    {
        IVariableService VS;
        static IVariable A_BT_ToPLC;
        public Service_Article_BT()
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
            
            A_BT_ToPLC = VS.GetVariable("CPU1.PLC.Blocks.02 Basket handling.04 BT.00 Main.DB BT HMI.PC.Handshake.to.Request");
            A_BT_ToPLC.Change += A_BT_ToPLC_Change;

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

        void A_BT_ToPLC_Change(object sender, VariableEventArgs e)
        {
            if ((bool)e.Value)
            {

                Task obTask = Task.Run(async () =>
                {
                    await Task.Delay(1000);
                    ApplicationService.SetVariableValue("CPU1.PLC.Blocks.02 Basket handling.04 BT.00 Main.DB BT HMI.PC.Handshake.to.Request", false);

                    try
                    {
                        MR MR = GetMRData((uint)ApplicationService.GetVariableValue("CPU1.PLC.Blocks.02 Basket handling.04 BT.00 Main.DB BT PD.Header.MR"));

                        await MR.Article.BT.LoadToPLC();

                    }
                    catch (Exception ex)
                    {
                        ApplicationService.SetVariableValue("CPU1.PLC.Blocks.02 Basket handling.04 BT.00 Main.DB BT HMI.PC.Handshake.from.Not loaded", true);
                        new MessageBoxTask("@RecipeSystem.Results.Text8", "@RecipeSystem.Results.Text2", MessageBoxIcon.Error);

                        string Message = "Error at line - " + new StackTrace(ex, true).GetFrame(new StackTrace(ex, true).FrameCount - 1).GetFileLineNumber().ToString() + " - " + Environment.NewLine;
                        Message += "Message : " + ex.Message + Environment.NewLine;
                        Message += "Stacktrace : " + ex.StackTrace + Environment.NewLine;

                        File.WriteAllText("C:\\Backup\\VW_BT_" + DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss") + ".txt", Message);
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
                temp.Header = new RecipeInfo();
                temp.Layers = new List<MCP>();
                temp.Article = GetArticleData((int)DT.Rows[0]["Article_Id"]);
            }
            else
            {
                ApplicationService.SetVariableValue("CPU1.PLC.Blocks.02 Basket handling.04 BT.00 Main.DB BT HMI.PC.Handshake.from.Not loaded", true);
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
                        LD = new LD(),
                        BT = new BT()
                        {
                            Header = new RecipeInfo(),
                            VWRecipe = new VWRecipe("BT", (string)DT.Rows[0]["BT_VWRecipe"])
                        },
                        PO = new PO()
                    };
                }
                else
                {
                    ApplicationService.SetVariableValue("CPU1.PLC.Blocks.02 Basket handling.04 BT.00 Main.DB BT HMI.PC.Handshake.from.Not loaded", true);
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
        #endregion
    }
}
