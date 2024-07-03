using HMI.CO.General;
using HMI.Interfaces;
using HMI.Resources;
using System;
using System.ComponentModel.Composition;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using VisiWin.ApplicationFramework;

using VisiWin.DataAccess;

namespace HMI.Services
{
    [ExportService(typeof(ITimeSync))]
    [Export(typeof(ITimeSync))]
    public class Service_TimeSync : ServiceBase, ITimeSync
    {
        IVariableService VS;
        static IVariable CPU1ToggleBit;
        static IVariable CPU2ToggleBit;
        static IVariable CPU1Time;

        [DllImport("kernel32.dll", SetLastError = true)]
        private extern static uint SetSystemTime(ref SYSTEMTIME systime);
        [StructLayout(LayoutKind.Sequential)]
        public struct SYSTEMTIME
        {
            public ushort wYear;
            public ushort wMonth;
            public ushort wDayOfWeek;
            public ushort wDay;
            public ushort wHour;
            public ushort wMinute;
            public ushort wSecond;
            public ushort wMilliseconds;
        }

        public Service_TimeSync()
        {
            if (ApplicationService.IsInDesignMode)
                return;
        }

        #region OnProject


        // Hier stehen noch keine VisiWin Funktionen zur Verfügung
        protected override void OnLoadProjectStarted()
        {
           

            base.OnLoadProjectStarted();
        }

       

        // Hier kann auf die VisiWin Funktionen zugegriffen werden
        protected override void OnLoadProjectCompleted()
        {
            VS = ApplicationService.GetService<IVariableService>();

            CPU1ToggleBit = VS.GetVariable("CPU1.PLC.Blocks.00 Main.02 HMI.01 PC.DB PC.General.ToggleBit");
            CPU1ToggleBit.Change += CPU1ToggleBit_Change;
            CPU2ToggleBit = VS.GetVariable("CPU2.PLC.Blocks.00 Main.02 HMI.01 PC.DB PC.General.ToggleBit");
            CPU2ToggleBit.Change += CPU2ToggleBit_Change;

            CPU1Time = VS.GetVariable("CPU1.PLC.Blocks.00 Main.02 HMI.01 PC.DB PC.DateTime.to.Update");
            CPU1Time.Change += CPU1Time_Change;

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

        void CPU1ToggleBit_Change(object sender, VariableEventArgs e)
        {
            if ((bool)e.Value)
            {
                Task obTask = Task.Run(async () =>
                {
                    await Task.Delay(3000);
                    ApplicationService.SetVariableValue("CPU1.PLC.Blocks.00 Main.02 HMI.01 PC.DB PC.General.ToggleBit", false);
                });
                


            }

        }

        void CPU2ToggleBit_Change(object sender, VariableEventArgs e)
        {
            if ((bool)e.Value)
            {
                Task obTask = Task.Run(async () =>
                {
                    await Task.Delay(3000);
                    ApplicationService.SetVariableValue("CPU2.PLC.Blocks.00 Main.02 HMI.01 PC.DB PC.General.ToggleBit", false);
                });


            }

        }

        void CPU1Time_Change(object sender, VariableEventArgs e)
        {
            if ((bool)e.Value)
            {
                ApplicationService.SetVariableValue("CPU1.PLC.Blocks.00 Main.02 HMI.01 PC.DB PC.DateTime.to.Update", false);

                DateTime DaT = (DateTime)ApplicationService.GetVariableValue("CPU1.PLC.Blocks.00 Main.02 HMI.01 PC.DB PC.DateTime.to.Actual#DATE_AND_TIME");
                
                ApplicationService.SetVariableValue("CPU1.PLC.Blocks.00 Main.02 HMI.01 PC.DB PC.DateTime.from.Actual#DATE_AND_TIME", DaT.ToString());
                ApplicationService.SetVariableValue("CPU1.PLC.Blocks.00 Main.02 HMI.01 PC.DB PC.DateTime.from.Update", true);
                ApplicationService.SetVariableValue("CPU2.PLC.Blocks.00 Main.02 HMI.01 PC.DB PC.DateTime.from.Actual#DATE_AND_TIME", DaT.ToString());
                ApplicationService.SetVariableValue("CPU2.PLC.Blocks.00 Main.02 HMI.01 PC.DB PC.DateTime.from.Update", true);

                SYSTEMTIME st = new SYSTEMTIME();
                st.wYear = (ushort)DaT.Year; // must be short
                st.wMonth = (ushort)DaT.Month;
                st.wDayOfWeek = (ushort)DaT.DayOfWeek;
                st.wDay = (ushort)DaT.Day;
                st.wHour = (ushort)DaT.Hour;
                st.wMinute = (ushort)DaT.Minute;
                st.wSecond = (ushort)DaT.Second;
                st.wMilliseconds = (ushort)DaT.Millisecond;

                try
                {
                    SetSystemTime(ref st);
                }
                catch (Exception ex)
                {
                    new MessageBoxTask(ex, "", MessageBoxIcon.Error);
                }

            }

        }
        #endregion

    }
}
