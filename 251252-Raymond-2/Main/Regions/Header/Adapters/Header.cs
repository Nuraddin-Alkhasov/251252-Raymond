using HMI.CO.General;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using VisiWin.Alarm;
using VisiWin.ApplicationFramework;
using VisiWin.Commands;
using VisiWin.DataAccess;

namespace HMI.HeaderRegion.Adapters
{
    [ExportAdapter("Header")]
    public class Header : AdapterBase
    {



        public Header()
        {
            if (ApplicationService.IsInDesignMode)
            {
                return;
            }

            OpenEKS = new ActionCommand(OpenEKSExecuted);
            OpenBarcode = new ActionCommand(OpenBarcodeExecuted);
            OpenCamera = new ActionCommand(OpenCameraExecuted);
        }
        #region - - - Properties - - -

        private readonly IVariableService VS = ApplicationService.GetService<IVariableService>();
        private readonly IRegionService iRS = ApplicationService.GetService<IRegionService>();

        IVariable VW_CPU1;
        IVariable VW_CPU2;
        IVariable VW_CPU3;
        IVariable VW_CPU4;
        ICurrentAlarms2 CurrentAlarmList;
        IAlarmItem CurrentAlarm;

        private string alarmText = "";
        public string AlarmText
        {
            get { return alarmText; }
            set { alarmText = value; OnPropertyChanged("AlarmText"); }
        }


        #endregion

        #region - - - Commands - - - 
        public ICommand OpenEKS { get; set; }

        private void OpenEKSExecuted(object parameter)
        {
            ApplicationService.SetView("DialogRegion1", "EKS");
        }
        public ICommand OpenBarcode { get; set; }

        private void OpenBarcodeExecuted(object parameter)
        {
            ApplicationService.SetView("DialogRegion1", "Scanner");
        }
        public ICommand OpenCamera{ get; set; }
        private void OpenCameraExecuted(object parameter)
        {
            ApplicationService.SetView("DialogRegion1", "Camera");
        }
        #endregion

        #region - - - Event Handlers - - -

        protected override void OnViewLoaded(object sender, ViewLoadedEventArg e)
        {
            if (sender.GetType().Name == e.View.GetType().Name)
            {

                VW_CPU1 = VS.GetVariable("CPU3.PLC.Blocks.00 Main.02 HMI.01 PC.DB PC.General.ToggleBit");
                VW_CPU1.Change += VW_CPU1_Change;
                VW_CPU2 = VS.GetVariable("CPU4.PLC.Blocks.00 Main.02 HMI.01 PC.DB PC.General.ToggleBit");
                VW_CPU2.Change += VW_CPU2_Change;
                VW_CPU3 = VS.GetVariable("CPU1.PLC.Blocks.00 Main.02 HMI.01 PC.DB PC.General.ToggleBit");
                VW_CPU3.Change += VW_CPU3_Change;
                VW_CPU4 = VS.GetVariable("CPU2.PLC.Blocks.00 Main.02 HMI.01 PC.DB PC.General.ToggleBit");
                VW_CPU4.Change += VW_CPU4_Change;
                CurrentAlarmList = ApplicationService.GetService<IAlarmService>().GetCurrentAlarms2();
                CurrentAlarmList.ChangeAlarm += SetAlarmLineData;
                CurrentAlarmList.NewAlarm += SetAlarmLineData;
                CurrentAlarmList.ClearAlarm += SetAlarmLineData;

                SetAlarmLineData(null, null);
            }
            base.OnViewLoaded(sender, e);
        }
        protected override void OnViewUnloaded(object sender, ViewUnloadedEventArg e)
        {
            base.OnViewUnloaded(sender, e);
        }

        private void VW_CPU1_Change(object sender, VariableEventArgs e)
        {
            Views.Header v = (Views.Header)iRS.GetView("Header");
            if (e.Quality.Data == DataQuality.Good )
            {
                new ObjectAnimator().HideUIElement(v.CPU1);
            }
            else { new ObjectAnimator().ShowUIElement(v.CPU1); }

        }

        private void VW_CPU2_Change(object sender, VariableEventArgs e)
        {
            Views.Header v = (Views.Header)iRS.GetView("Header");
            if (e.Quality.Data == DataQuality.Good)
            {           
                new ObjectAnimator().HideUIElement(v.CPU2);
            }
            else { new ObjectAnimator().ShowUIElement(v.CPU2); }

        }
        private void VW_CPU3_Change(object sender, VariableEventArgs e)
        {
            Views.Header v = (Views.Header)iRS.GetView("Header");
            if (e.Quality.Data == DataQuality.Good)
            {
                new ObjectAnimator().HideUIElement(v.CPU3);
            }
            else { new ObjectAnimator().ShowUIElement(v.CPU3); }

        }

        private void VW_CPU4_Change(object sender, VariableEventArgs e)
        {
            Views.Header v = (Views.Header)iRS.GetView("Header");
            if (e.Quality.Data == DataQuality.Good)
            {
                new ObjectAnimator().HideUIElement(v.CPU4);
            }
            else { new ObjectAnimator().ShowUIElement(v.CPU4); }

        }

        #endregion

        #region - - - Methods - - -

        void SetAlarmLineData(object sender, AlarmEventArgs e)
        {
            IAlarmItem[] TT = CurrentAlarmList.Alarms.Where(x => x.Group.Name == "Error" && x.AlarmState == AlarmState.Active).ToArray();

            CurrentAlarm = (TT.Length > 0) ? TT[0] : null;
            Views.Header v = (Views.Header)iRS.GetView("Header");
            if (CurrentAlarm != null)
            {
                AlarmText = CurrentAlarm.ActivationTime.ToString() + "  -  " + ApplicationService.GetText(CurrentAlarm.LocalizableText);

                new ObjectAnimator().ShowUIElement(v.AlarmText);
            }
            else
            {
                new ObjectAnimator().HideUIElement(v.AlarmText);
            }
        }

        #endregion
    }

}
