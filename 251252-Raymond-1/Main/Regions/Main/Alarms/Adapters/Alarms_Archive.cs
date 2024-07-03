using HMI.CO.General;
using HMI.MainRegion.Alarms.Views;
using HMI.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using VisiWin.Alarm;
using VisiWin.ApplicationFramework;
using VisiWin.Commands;

namespace HMI.MainRegion.Alarms.Adapters
{
    [ExportAdapter("Alarms_Archive")]
    public class Alarms_Archive : AdapterBase
    {



        public Alarms_Archive()
        {
            if (ApplicationService.IsInDesignMode)
            {
                return;
            }
            alarmService = GetService<IAlarmService>();
            OpenFilter = new ActionCommand(OpenFilterExecuted);
        }

        #region - - - Properties - - -

        private readonly IRegionService iRS = ApplicationService.GetService<IRegionService>();
        private readonly IAlarmService alarmService;
        private IHistoricalAlarmRequest alarmRequest;
        private List<IHistoricalAlarmItem> historicalAlarms = new List<IHistoricalAlarmItem>();
        public List<IHistoricalAlarmItem> HistoricalAlarms
        {
            get { return historicalAlarms; }
            set
            {
                if (historicalAlarms != value)
                {
                    historicalAlarms = value;
                    OnPropertyChanged("HistoricalAlarms");
                }
            }
        }


        #endregion

        #region - - - Commands - - - 
        public ICommand OpenFilter { get; set; }

        private void OpenFilterExecuted(object parameter)
        {
            ApplicationService.SetView("DialogRegion1", "Alarms_Filter");
        }
        #endregion

        #region - - - Event Handlers - - -
        protected override void OnViewLoaded(object sender, ViewLoadedEventArg e)
        {
            if (sender.GetType().Name == e.View.GetType().Name)
            {
            }
            base.OnViewLoaded(sender, e);
        }

        protected override void OnViewUnloaded(object sender, ViewUnloadedEventArg e)
        {
            if (sender.GetType().Name == e.View.GetType().Name)
            {
            }
            base.OnViewUnloaded(sender, e);
        }
        private void GetHistoricalDataCompleted(object sender, GetHistoricalAlarmsCompletedEventArgs e)
        {
            if (Count == 0)
            {
                HistoricalAlarms = e.HistoricalAlarms.OrderByDescending(x => x.ActivationTime).ToList();
            }
            else 
            {
                HistoricalAlarms = e.HistoricalAlarms.OrderByDescending(x => x.ActivationTime).ToList().Where(s => s.Name == Count.ToString()).ToList();
            }

            Alarms_PN D_PN = (Alarms_PN)iRS.GetView("Alarms_PN");
            D_PN.wait.Visibility = System.Windows.Visibility.Hidden;
            alarmRequest.GetHistoricalDataCompleted -= new EventHandler<GetHistoricalAlarmsCompletedEventArgs>(GetHistoricalDataCompleted);

        }

        #endregion
        public int Count { get; set; } = 0;
        #region - - - Methods - - - 
        public void RequestHistoricalAlarms(IHistoricalAlarmFilter f, int Count)
        {
            this.Count = Count;
            alarmRequest = alarmService.CreateHistoricalAlarmRequest(f);
            alarmRequest.GetHistoricalDataCompleted += new EventHandler<GetHistoricalAlarmsCompletedEventArgs>(GetHistoricalDataCompleted);
            
            if (alarmRequest.GetHistoricalData())
            {
                Alarms_PN D_PN = (Alarms_PN)iRS.GetView("Alarms_PN");
                D_PN.wait.Visibility = System.Windows.Visibility.Visible;
            }
            else
            {
                new MessageBoxTask("@HistoricalAlarms.HistoricalAlarmFilterView.GetAlarmsError", "@HistoricalAlarms.HistoricalAlarmFilterView.Caption", MessageBoxIcon.Exclamation);
            }
        }

        public void LoadData()
        {

            RequestHistoricalAlarms(alarmService.GetHistoricalAlarmFilter(DateTime.Now.AddHours(-24), DateTime.Now, desiredGroups: "Error;Warning;", desiredStates: AlarmState.Cleared | AlarmState.Inactive), 0);

        }

        #endregion
    }

}
