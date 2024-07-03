using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;
using VisiWin.ApplicationFramework;

namespace HMI.CO.General
{
    public class SP
    {

        public SP()
        {
            
        }
        public int Station { set; get; } = 0;
        public int Place { set; get; } = 0;
        public string Header { set; get; } = "";
        public string Type { set; get; } = "";

        public string CPU { set; get; } = "";

        private string VStation = "";
        private string VPlace = "";

        public void Open()
        {
            
            VStation = CPU + ".PLC.Blocks.00 Main.02 HMI.01 PC.DB PC.State.from.Station"; 
            switch (Station) 
            {
                case 6: VPlace = CPU + ".PLC.Blocks.00 Main.02 HMI.01 PC.DB PC.State.from.ST"; break;
                case 12: VPlace = CPU + ".PLC.Blocks.00 Main.02 HMI.01 PC.DB PC.State.from.TO"; break;
                case 13: case 14: VPlace = CPU + ".PLC.Blocks.00 Main.02 HMI.01 PC.DB PC.State.from.HZ"; break;
                case 15: case 16: case 17: case 18: VPlace = CPU + ".PLC.Blocks.00 Main.02 HMI.01 PC.DB PC.State.from.CZ"; break;
            }


            if (VStation != "") { ApplicationService.SetVariableValue(VStation, Station); }
            if (VPlace != "") { ApplicationService.SetVariableValue(VPlace, Place); }

            switch (CPU) 
            {
                case "CPU1":
                    Task.Run(async () =>
                    {
                        await Task.Delay(1000);

                        await Application.Current.Dispatcher.InvokeAsync(delegate
                        {
                            ApplicationService.SetView("DialogRegion1", "M1_Status_1", this);
                        });
                    });
                    break;
                case "CPU2":
                    Task.Run(async () =>
                    {
                        await Task.Delay(1000);

                        await Application.Current.Dispatcher.InvokeAsync(delegate
                        {
                            ApplicationService.SetView("DialogRegion1", "M1_Status_2", this);
                        });
                    });
                    break;
                case "CPU3":
                    Task.Run(async () =>
                    {
                        await Task.Delay(1000);

                        await Application.Current.Dispatcher.InvokeAsync(delegate
                        {
                            ApplicationService.SetView("DialogRegion1", "M2_Status_1", this);
                        });
                    });
                    break;
                case "CPU4":
                    Task.Run(async () =>
                    {
                        await Task.Delay(1000);

                        await Application.Current.Dispatcher.InvokeAsync(delegate
                        {
                            ApplicationService.SetView("DialogRegion1", "M2_Status_2", this);
                        });
                    });
                    break;
                default: break;
            }
            
        }
        public void Close() 
        {
            if (VStation != "") { ApplicationService.SetVariableValue(VStation, 0); }
            if (VPlace != "") { ApplicationService.SetVariableValue(VPlace, 0); }
        }
    }
}
