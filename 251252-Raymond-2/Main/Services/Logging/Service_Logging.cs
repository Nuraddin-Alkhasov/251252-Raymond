using HMI.Interfaces.Logging;
using HMI.Services.Custom_Objects;
using System.ComponentModel.Composition;
using VisiWin.ApplicationFramework;
using VisiWin.DataAccess;
using VisiWin.Logging;
using VisiWin.Parameter;

namespace HMI.Services.Logging
{
    [ExportService(typeof(ILogging))]
    [Export(typeof(ILogging))]
    public class Service_Logging : ServiceBase, ILogging
    {

        public Service_Logging()
        {
            if (ApplicationService.IsInDesignMode)
            {
                return;
            }
        }

        IVariableService VS;
        ILoggingService LS;
        IVariable CPU1_Log;
        IVariable CPU2_Log;

        #region OnProject

        protected override void OnLoadProjectStarted()
        {
            
            base.OnLoadProjectStarted();

           
        }

        protected override void OnLoadProjectCompleted()
        {
            VS = ApplicationService.GetService<IVariableService>();
            LS = ApplicationService.GetService<ILoggingService>();
            CPU1_Log = VS.GetVariable("CPU1.PLC.Blocks.00 Main.02 HMI.01 PC.DB PC.Logging.to.Start");
            CPU1_Log.Change += CPU1_Log_Change;

            CPU2_Log = VS.GetVariable("CPU2.PLC.Blocks.00 Main.02 HMI.01 PC.DB PC.Logging.to.Start");
            CPU2_Log.Change += CPU2_Log_Change;
            base.OnLoadProjectCompleted();
        }

        protected override void OnUnloadProjectStarted()
        {
            base.OnUnloadProjectStarted();
        }

        protected override void OnUnloadProjectCompleted()
        {
            base.OnUnloadProjectCompleted();
        }

        void CPU1_Log_Change(object sender, VariableEventArgs e)
        {
            if (e.Value != e.PreviousValue && bool.Parse(e.Value.ToString()))
            {

                CPU1_Log.Value = false;

                byte Type = (byte)ApplicationService.GetVariableValue("CPU1.PLC.Blocks.00 Main.02 HMI.01 PC.DB PC.Logging.to.Type");
                byte Drive = (byte)ApplicationService.GetVariableValue("CPU1.PLC.Blocks.00 Main.02 HMI.01 PC.DB PC.Logging.to.Drive");



                switch (Type)
                {

                    case 1:
                        LS.Log("Machine", "Reference", "@Logging.Machine.Reference.Text" + Drive.ToString(), System.DateTime.Now);
                        break;
                    case 2:
                        LS.Log("Machine", "Parameter", "@Logging.Machine.Parameter.Text" + Drive.ToString(), System.DateTime.Now);
                        break;
                    default: break;
                }
            }

        }
        void CPU2_Log_Change(object sender, VariableEventArgs e)
        {
            if (e.Value != e.PreviousValue && bool.Parse(e.Value.ToString()))
            {

                CPU2_Log.Value = false;

                byte Type = (byte)ApplicationService.GetVariableValue("CPU2.PLC.Blocks.00 Main.02 HMI.01 PC.DB PC.Logging.to.Type");
                byte Drive = (byte)ApplicationService.GetVariableValue("CPU2.PLC.Blocks.00 Main.02 HMI.01 PC.DB PC.Logging.to.Drive");



                switch (Type)
                {

                    case 1:
                        LS.Log("Machine", "Reference", "@Logging.Machine.Reference.Text" + Drive.ToString(), System.DateTime.Now);
                        break;
                    case 2:
                        LS.Log("Machine", "Parameter", "@Logging.Machine.Parameter.Text" + Drive.ToString(), System.DateTime.Now);
                        break;
                    default: break;
                }
            }

        }
        #endregion

    }
}
