using HMI.CO.General;
using HMI.CO.PD;
using HMI.CO.Protocol;
using HMI.Interfaces;
using HMI.Resources;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using VisiWin.ApplicationFramework;
using VisiWin.DataAccess;

namespace HMI.Services
{

    [ExportService(typeof(Service_Protocol))]
    [Export(typeof(Service_Protocol))]
    class Service_Protocol : ServiceBase, IProtocol
    {
        private int Machine;
        private Loading loading;
        private Charging charging;
        private Layering layering;
        private Coating coating;
        private Preheating preheating;
        private Heating heating;
        private Holding holding;
        private Cooling cooling;
        private Discharging discharging1;
        private Discharging discharging2;

        public Service_Protocol()
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
           
            IVariableService VS = ApplicationService.GetService<IVariableService>();
            
            Machine = 1;

            loading = new Loading("CPU1.PLC.Blocks.00 Main.02 HMI.01 PC.DB PC.Protocol.to.Loading")
            {
                Machine = Machine,
                Data_1 = VS.GetVariable("CPU1.PLC.Blocks.01 Basket feeding.01 LD.00 Main.DB LD HMI.PC.Data.from.Order#STRING20"),
                Data_2 = VS.GetVariable("CPU1.PLC.Blocks.01 Basket feeding.01 LD.00 Main.DB LD HMI.PC.Data.from.Barcode.Number#STRING20"),
                Data_3 = VS.GetVariable("CPU1.PLC.Blocks.01 Basket feeding.01 LD.00 Main.DB LD HMI.PC.Data.from.Barcode.Data#STRING254"),
                MR_Id = VS.GetVariable("CPU1.PLC.Blocks.01 Basket feeding.01 LD.00 Main.DB LD PD.Header.MR"),
                Order_Id = VS.GetVariable("CPU1.PLC.Blocks.01 Basket feeding.01 LD.00 Main.DB LD PD.Header.Order"),
                Box_Id = VS.GetVariable("CPU1.PLC.Blocks.01 Basket feeding.01 LD.00 Main.DB LD PD.Header.Box"),
            };

            
            charging = new Charging("CPU1.PLC.Blocks.00 Main.02 HMI.01 PC.DB PC.Protocol.to.Charging")
            {
                Machine = Machine,
                Box_Id = VS.GetVariable("CPU1.PLC.Blocks.02 Basket handling.01 BS.00 Main.DB BS PD.Header.Box"),
                Charge_Id = VS.GetVariable("CPU1.PLC.Blocks.02 Basket handling.01 BS.00 Main.DB BS PD.Header.Charge"),             
                Layer_Id = VS.GetVariable("CPU1.PLC.Blocks.02 Basket handling.01 BS.00 Main.DB BS PD.Header.Layer"),
                WeightL = VS.GetVariable("CPU1.PLC.Blocks.02 Basket handling.01 BS.00 Main.DB BS PD.Charge.Weight.Left"),
                WeightR = VS.GetVariable("CPU1.PLC.Blocks.02 Basket handling.01 BS.00 Main.DB BS PD.Charge.Weight.Right"),
                RMO = VS.GetVariable("CPU1.PLC.Blocks.02 Basket handling.01 BS.00 Main.DB BS PD.Charge.RMO")
            };

            coating = new Coating(
                "CPU1.PLC.Blocks.00 Main.02 HMI.01 PC.DB PC.Protocol.to.Coating.Start",
                "CPU1.PLC.Blocks.00 Main.02 HMI.01 PC.DB PC.Protocol.to.Coating.End",
                "CPU1.PLC.Blocks.00 Main.02 HMI.01 PC.DB PC.Protocol.to.Coating.Alarm")
            {

                Layer_Id = VS.GetVariable("CPU1.PLC.Blocks.03 Basket coating.01 CD.00 Main.DB CD PD.Header.Layer"),
                MR_Id = VS.GetVariable("CPU1.PLC.Blocks.03 Basket coating.01 CD.00 Main.DB CD PD.Header.MR"),
                ActualLayer= VS.GetVariable("CPU1.PLC.Blocks.03 Basket coating.01 CD.00 Main.DB CD PD.Charge.Layer[0].Actual"),
                SetPaintTemp = VS.GetVariable("CPU1.PLC.Blocks.03 Basket coating.02 DT.00 Main.DB DT PD.Station.DT.Cool.Set.Value"),
                ActualPaintTemp = VS.GetVariable("CPU1.PLC.Blocks.03 Basket coating.02 DT.03 Cooling.DB DT Cooling HMI.Actual.Temperature"),

            };

            preheating = new Preheating(
                "CPU2.PLC.Blocks.00 Main.02 HMI.01 PC.DB PC.Protocol.to.Preheating.Start",
                "CPU2.PLC.Blocks.00 Main.02 HMI.01 PC.DB PC.Protocol.to.Preheating.End",
                "CPU2.PLC.Blocks.00 Main.02 HMI.01 PC.DB PC.Protocol.to.Preheating.Alarm")
            {
                MC_Layer_Id = VS.GetVariable("CPU2.PLC.Blocks.04 Tray handling.01 MC.00 Main.DB MC PD.Header.Layer"),
                PZ_Layer_Id = new List<IVariable>()
                { 
                    VS.GetVariable("CPU2.PLC.Blocks.04 Tray handling.03 TO.00 Main.DB TO PD.Place[6].Header.Layer"),
                    VS.GetVariable("CPU2.PLC.Blocks.04 Tray handling.03 TO.00 Main.DB TO PD.Place[7].Header.Layer"),
                    VS.GetVariable("CPU2.PLC.Blocks.04 Tray handling.03 TO.00 Main.DB TO PD.Place[8].Header.Layer"),
                    VS.GetVariable("CPU2.PLC.Blocks.04 Tray handling.03 TO.00 Main.DB TO PD.Place[9].Header.Layer"),
                    VS.GetVariable("CPU2.PLC.Blocks.04 Tray handling.03 TO.00 Main.DB TO PD.Place[10].Header.Layer"),
                },
                SetTemp = VS.GetVariable("CPU2.PLC.Blocks.04 Tray handling.02 PZ.00 Main.DB PZ HMI.Parameter.Temperature.Set")
            };

            heating = new Heating(
                "CPU2.PLC.Blocks.00 Main.02 HMI.01 PC.DB PC.Protocol.to.Heating.Start",
                "CPU2.PLC.Blocks.00 Main.02 HMI.01 PC.DB PC.Protocol.to.Heating.End",
                "CPU2.PLC.Blocks.00 Main.02 HMI.01 PC.DB PC.Protocol.to.Heating.Alarm")
            {
                WZ_Layer_Id = new List<IVariable>()
                { 
                    VS.GetVariable("CPU2.PLC.Blocks.04 Tray handling.03 TO.00 Main.DB TO PD.Place[0].Header.Layer"),
                    VS.GetVariable("CPU2.PLC.Blocks.04 Tray handling.03 TO.00 Main.DB TO PD.Place[1].Header.Layer"),
                    VS.GetVariable("CPU2.PLC.Blocks.04 Tray handling.03 TO.00 Main.DB TO PD.Place[2].Header.Layer"),
                    VS.GetVariable("CPU2.PLC.Blocks.04 Tray handling.03 TO.00 Main.DB TO PD.Place[3].Header.Layer"),
                    VS.GetVariable("CPU2.PLC.Blocks.04 Tray handling.03 TO.00 Main.DB TO PD.Place[4].Header.Layer"),
                    VS.GetVariable("CPU2.PLC.Blocks.04 Tray handling.03 TO.00 Main.DB TO PD.Place[5].Header.Layer"),
                    VS.GetVariable("CPU2.PLC.Blocks.04 Tray handling.03 TO.00 Main.DB TO PD.Place[6].Header.Layer"),

                },
                TM_Layer_Id = VS.GetVariable("CPU2.PLC.Blocks.04 Tray handling.04 TM.00 Main.DB TM PD.Header.Layer"),
                SetTemp = VS.GetVariable("CPU2.PLC.Blocks.04 Tray handling.05 WZ.00 Main.DB WZ HMI.Parameter.Temperature.Set")
            };

            holding = new Holding(
                "CPU2.PLC.Blocks.00 Main.02 HMI.01 PC.DB PC.Protocol.to.Holding.Start",
                "CPU2.PLC.Blocks.00 Main.02 HMI.01 PC.DB PC.Protocol.to.Holding.End",
                "CPU2.PLC.Blocks.00 Main.02 HMI.01 PC.DB PC.Protocol.to.Holding.Alarm")
            {
                HZ = VS.GetVariable("CPU2.PLC.Blocks.04 Tray handling.06 HZ.00 Main.DB HZ HMI.Parameter.Stack[9].Id"),
                Place = VS.GetVariable("CPU2.PLC.Blocks.04 Tray handling.06 HZ.00 Main.DB HZ HMI.Parameter.Stack[9].Place"),
                HZ1_Layer_Id = new List<IVariable>()
                {
                    VS.GetVariable("CPU2.PLC.Blocks.04 Tray handling.06 HZ.01.00 Main.DB HZ 1 PD.Place[0].Header.Layer"),
                    VS.GetVariable("CPU2.PLC.Blocks.04 Tray handling.06 HZ.01.00 Main.DB HZ 1 PD.Place[1].Header.Layer"),
                    VS.GetVariable("CPU2.PLC.Blocks.04 Tray handling.06 HZ.01.00 Main.DB HZ 1 PD.Place[2].Header.Layer"),
                    VS.GetVariable("CPU2.PLC.Blocks.04 Tray handling.06 HZ.01.00 Main.DB HZ 1 PD.Place[3].Header.Layer"),
                    VS.GetVariable("CPU2.PLC.Blocks.04 Tray handling.06 HZ.01.00 Main.DB HZ 1 PD.Place[4].Header.Layer"),
                    VS.GetVariable("CPU2.PLC.Blocks.04 Tray handling.06 HZ.01.00 Main.DB HZ 1 PD.Place[5].Header.Layer"),
                    VS.GetVariable("CPU2.PLC.Blocks.04 Tray handling.06 HZ.01.00 Main.DB HZ 1 PD.Place[6].Header.Layer"),
                    VS.GetVariable("CPU2.PLC.Blocks.04 Tray handling.06 HZ.01.00 Main.DB HZ 1 PD.Place[7].Header.Layer"),
                    VS.GetVariable("CPU2.PLC.Blocks.04 Tray handling.06 HZ.01.00 Main.DB HZ 1 PD.Place[8].Header.Layer"),
                    VS.GetVariable("CPU2.PLC.Blocks.04 Tray handling.06 HZ.01.00 Main.DB HZ 1 PD.Place[9].Header.Layer"),
                },
                //HZ2_Layer_Id = new List<IVariable>()
                //{
                //    VS.GetVariable("CPU2.PLC.Blocks.04 Tray handling.06 HZ.02.00 Main.DB HZ 2 PD.Place[0].Header.Layer"),
                //    VS.GetVariable("CPU2.PLC.Blocks.04 Tray handling.06 HZ.02.00 Main.DB HZ 2 PD.Place[1].Header.Layer"),
                //    VS.GetVariable("CPU2.PLC.Blocks.04 Tray handling.06 HZ.02.00 Main.DB HZ 2 PD.Place[2].Header.Layer"),
                //    VS.GetVariable("CPU2.PLC.Blocks.04 Tray handling.06 HZ.02.00 Main.DB HZ 2 PD.Place[3].Header.Layer"),
                //    VS.GetVariable("CPU2.PLC.Blocks.04 Tray handling.06 HZ.02.00 Main.DB HZ 2 PD.Place[4].Header.Layer"),
                //    VS.GetVariable("CPU2.PLC.Blocks.04 Tray handling.06 HZ.02.00 Main.DB HZ 2 PD.Place[5].Header.Layer"),
                //    VS.GetVariable("CPU2.PLC.Blocks.04 Tray handling.06 HZ.02.00 Main.DB HZ 2 PD.Place[6].Header.Layer"),
                //    VS.GetVariable("CPU2.PLC.Blocks.04 Tray handling.06 HZ.02.00 Main.DB HZ 2 PD.Place[7].Header.Layer"),
                //    VS.GetVariable("CPU2.PLC.Blocks.04 Tray handling.06 HZ.02.00 Main.DB HZ 2 PD.Place[8].Header.Layer"),
                //    VS.GetVariable("CPU2.PLC.Blocks.04 Tray handling.06 HZ.02.00 Main.DB HZ 2 PD.Place[9].Header.Layer"),
                //},

                TM_Layer_Id = VS.GetVariable("CPU2.PLC.Blocks.04 Tray handling.04 TM.00 Main.DB TM PD.Header.Layer"),
                SetTemp = VS.GetVariable("CPU2.PLC.Blocks.04 Tray handling.06 HZ.00 Main.DB HZ HMI.Parameter.Hold.Set.Value")
            };

            cooling = new Cooling(
                "CPU2.PLC.Blocks.00 Main.02 HMI.01 PC.DB PC.Protocol.to.Cooling.Start",
                "CPU2.PLC.Blocks.00 Main.02 HMI.01 PC.DB PC.Protocol.to.Cooling.End",
                "CPU2.PLC.Blocks.00 Main.02 HMI.01 PC.DB PC.Protocol.to.Cooling.Alarm")
            {
                CZ = VS.GetVariable("CPU2.PLC.Blocks.04 Tray handling.07 CZ.00 Main.DB CZ HMI.Parameter.Stack[7].Id"),
                Place = VS.GetVariable("CPU2.PLC.Blocks.04 Tray handling.07 CZ.00 Main.DB CZ HMI.Parameter.Stack[7].Place"),
                CZ1_Layer_Id = new List<IVariable>()
                {
                    VS.GetVariable("CPU2.PLC.Blocks.04 Tray handling.07 CZ.01.00 Main.DB CZ 1 PD.Place[0].Header.Layer"),
                    VS.GetVariable("CPU2.PLC.Blocks.04 Tray handling.07 CZ.01.00 Main.DB CZ 1 PD.Place[1].Header.Layer"),
                },
                CZ2_Layer_Id = new List<IVariable>()
                {
                    VS.GetVariable("CPU2.PLC.Blocks.04 Tray handling.07 CZ.02.00 Main.DB CZ 2 PD.Place[0].Header.Layer"),
                    VS.GetVariable("CPU2.PLC.Blocks.04 Tray handling.07 CZ.02.00 Main.DB CZ 2 PD.Place[1].Header.Layer"),
                },
                CZ3_Layer_Id = new List<IVariable>()
                {
                    VS.GetVariable("CPU2.PLC.Blocks.04 Tray handling.07 CZ.03.00 Main.DB CZ 3 PD.Place[0].Header.Layer"),
                    VS.GetVariable("CPU2.PLC.Blocks.04 Tray handling.07 CZ.03.00 Main.DB CZ 3 PD.Place[1].Header.Layer"),
                },
                CZ4_Layer_Id = new List<IVariable>()
                {
                    VS.GetVariable("CPU2.PLC.Blocks.04 Tray handling.07 CZ.04.00 Main.DB CZ 4 PD.Place[0].Header.Layer"),
                    VS.GetVariable("CPU2.PLC.Blocks.04 Tray handling.07 CZ.04.00 Main.DB CZ 4 PD.Place[1].Header.Layer"),
                },
                TM_Layer_Id = VS.GetVariable("CPU2.PLC.Blocks.04 Tray handling.04 TM.00 Main.DB TM PD.Header.Layer"),
                SetTemp = VS.GetVariable("CPU2.PLC.Blocks.04 Tray handling.07 CZ.00 Main.DB CZ HMI.Parameter.Cool.Set.Value")
            };

            layering = new Layering("CPU1.PLC.Blocks.00 Main.02 HMI.01 PC.DB PC.Protocol.to.Layering")
            {
                Machine = Machine,
                Charge_Id = VS.GetVariable("CPU1.PLC.Blocks.02 Basket handling.05 CI.00 Main.DB CI PD.Header.Charge"),
                Layer_Id = VS.GetVariable("CPU1.PLC.Blocks.02 Basket handling.05 CI.00 Main.DB CI PD.Header.Layer"),
            };


            discharging1 = new Discharging("CPU2.PLC.Blocks.00 Main.02 HMI.01 PC.DB PC.Protocol.to.Discharging 1")
            {
                Layer_Id = VS.GetVariable("CPU2.PLC.Blocks.04 Tray handling.09 US.01.00 Main.DB US 1 PD.Customer.Header.Layer"),
                Order_US = VS.GetVariable("CPU2.PLC.Blocks.04 Tray handling.09 US.01.00 Main.DB US 1 HMI.PC.Data.from.Order#STRING20"),
                MES = VS.GetVariable("CPU1.PLC.Blocks.01 Basket feeding.01 LD.00 Main.DB LD HMI.PC.Data.from.MES.On"),
                Custom_PO = VS.GetVariable("CPU2.PLC.Blocks.04 Tray handling.09 US.01.00 Main.DB US 1 HMI.PC.Data.from.MES.PO#STRING8"),
                Custom_PWG = VS.GetVariable("CPU2.PLC.Blocks.04 Tray handling.09 US.01.00 Main.DB US 1 HMI.PC.Data.from.MES.PWG"),
                Custom_PT = VS.GetVariable("CPU2.PLC.Blocks.04 Tray handling.09 US.01.00 Main.DB US 1 HMI.PC.Data.from.MES.ProcessTime")
            };

            discharging2 = new Discharging("CPU2.PLC.Blocks.00 Main.02 HMI.01 PC.DB PC.Protocol.to.Discharging 2")
            {
                Layer_Id = VS.GetVariable("CPU2.PLC.Blocks.04 Tray handling.09 US.02.00 Main.DB US 2 PD.Customer.Header.Layer"),
                Order_US = VS.GetVariable("CPU2.PLC.Blocks.04 Tray handling.09 US.02.00 Main.DB US 2 HMI.PC.Data.from.Order#STRING20"),
                MES = VS.GetVariable("CPU1.PLC.Blocks.01 Basket feeding.01 LD.00 Main.DB LD HMI.PC.Data.from.MES.On"),
                Custom_PO = VS.GetVariable("CPU2.PLC.Blocks.04 Tray handling.09 US.02.00 Main.DB US 2 HMI.PC.Data.from.MES.PO#STRING8"),
                Custom_PWG = VS.GetVariable("CPU2.PLC.Blocks.04 Tray handling.09 US.02.00 Main.DB US 2 HMI.PC.Data.from.MES.PWG"),
                Custom_PT = VS.GetVariable("CPU2.PLC.Blocks.04 Tray handling.09 US.02.00 Main.DB US 2 HMI.PC.Data.from.MES.ProcessTime")
            };

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
        #region - - - Event Handlers - - -   

        #endregion

        #region - - - Private Methods - - -   



        #endregion


        #endregion
    }
}
