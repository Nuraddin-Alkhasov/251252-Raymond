using HMI.CO.General;
using HMI.CO.Protocol;
using LiveCharts;
using LiveCharts.Wpf;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using VisiWin.Adapter;
using VisiWin.ApplicationFramework;
using VisiWin.Commands;


namespace HMI.DialogRegion.Protocol.Adapters
{
    [ExportAdapter("Protocol_Trend")]
    public class Protocol_Trend : AdapterBase
    {

        public Protocol_Trend()
        {

            if (ApplicationService.IsInDesignMode)
            {
                return;
            }

            Close = new ActionCommand(CloseExecuted);
        }

        #region - - - Properties - - -
        private readonly IRegionService iRS = ApplicationService.GetService<IRegionService>();
        private Layer selectedLayer = null;
        public Layer SelectedLayer
        {
            get { return selectedLayer; }
            set
            {
                if (!Equals(value, selectedLayer))
                {
                    selectedLayer = value;


                    FillTrendWithData();

                    OnPropertyChanged("SelectedLayer");
                }
            }
        }

        public List<string> labels { get; set; }
        public List<string> Labels
        {
            get { return labels; }
            set
            {
                if (!Equals(value, labels))
                {
                    labels = value;



                    OnPropertyChanged("Labels");
                }
            }
        }
        public SeriesCollection lastHourSeries { get; set; }
        public SeriesCollection LastHourSeries
        {
            get { return lastHourSeries; }
            set
            {
                if (!Equals(value, lastHourSeries))
                {
                    lastHourSeries = value;
                    OnPropertyChanged("LastHourSeries");
                }
            }
        }

        public int minValue { get; set; }
        public int MinValue
        {
            get { return minValue; }
            set
            {
                if (!Equals(value, minValue))
                {
                    minValue = value;
                    OnPropertyChanged("MinValue");
                }
            }
        }

        public int maxValue { get; set; }
        public int MaxValue
        {
            get { return maxValue; }
            set
            {
                if (!Equals(value, maxValue))
                {
                    maxValue = value;
                    OnPropertyChanged("MaxValue");
                }
            }
        }
        public DateTime from { get; set; }
        public DateTime From
        {
            get { return from; }
            set
            {
                if (!Equals(value, from))
                {
                    from = value;
                    OnPropertyChanged("From");
                }
            }
        }

        public DateTime to { get; set; }
        public DateTime To
        {
            get { return to; }
            set
            {
                if (!Equals(value, to))
                {
                    to = value;
                    OnPropertyChanged("To");
                }
            }
        }
        #endregion

        #region - - - Commands - - -
        public ICommand Close { get; set; }
        private void CloseExecuted(object parameter)
        {

            Views.Protocol_Trend v = (Views.Protocol_Trend)iRS.GetView("Protocol_Trend");
            new ObjectAnimator().CloseDialog2(v, v.border);
        }


        #endregion

        #region - - - Event handlers - - -

        protected override void OnViewLoaded(object sender, ViewLoadedEventArg e)
        {
            SelectedLayer = ApplicationService.ObjectStore.GetValue("Protocol_Trend_KEY") as Layer;
            ApplicationService.ObjectStore.Remove("Protocol_Trend_KEY");
            Views.Protocol_Trend v = (Views.Protocol_Trend)iRS.GetView("Protocol_Trend");
            new ObjectAnimator().OpenDialog(v, v.border);

            base.OnViewLoaded(sender, e);
        }
        protected override void OnViewUnloaded(object sender, ViewUnloadedEventArg e)
        {
            SelectedLayer = new Layer();
            base.OnViewUnloaded(sender, e);
        }
        #endregion

        #region - - - Methods - - -

        private void FillTrendWithData()
        {
            List<string> temp1 = new List<string>();
            SeriesCollection temp2 = new SeriesCollection
                    {
                        new LineSeries
                        {
                            Title = "",
                            AreaLimit = 0,
                            StrokeThickness = 2,
                            PointGeometrySize = 10,
                            LineSmoothness = 0,
                            Stroke = new SolidColorBrush(Color.FromRgb(255,188,73)),
                            Values = new ChartValues<double>()
                        }
                    };
            int min = 9999;
            int max = 0;
            try
            {
                Task obTask = Task.Run(() =>
                {
                    if (SelectedLayer.Id != -1)
                        switch (SelectedLayer.SelectedTrendId)
                        {
                            case 1:
                                foreach (HMI.CO.Protocol.Point p in SelectedLayer.PZTrend.Points)
                                {
                                    if (p.Value < min) { min = (int)p.Value; }
                                    if (p.Value > max) { max = (int)p.Value; }
                                    temp1.Add(p.TimeStamp.ToString("HH:mm:ss"));
                                    temp2[0].Values.Add(p.Value);

                                }
                                From = Convert.ToDateTime(SelectedLayer.PZ_S);
                                To = Convert.ToDateTime(SelectedLayer.PZ_E);
                                break;
                            case 2:
                                foreach (HMI.CO.Protocol.Point p in SelectedLayer.WZTrend.Points)
                                {
                                    if (p.Value < min) { min = (int)p.Value; }
                                    if (p.Value > max) { max = (int)p.Value; }
                                    temp1.Add(p.TimeStamp.ToString("HH:mm:ss"));
                                    temp2[0].Values.Add(p.Value);
                                }
                                From = Convert.ToDateTime(SelectedLayer.WZ_S);
                                To = Convert.ToDateTime(SelectedLayer.WZ_E);
                                break;
                            case 3:
                                foreach (HMI.CO.Protocol.Point p in SelectedLayer.HZTrend.Points)
                                {
                                    if (p.Value < min) { min = (int)p.Value; }
                                    if (p.Value > max) { max = (int)p.Value; }
                                    temp1.Add(p.TimeStamp.ToString("HH:mm:ss"));
                                    temp2[0].Values.Add(p.Value);
                                }
                                From = Convert.ToDateTime(SelectedLayer.HZ_S);
                                To = Convert.ToDateTime(SelectedLayer.HZ_E);
                                break;
                            case 4:
                                foreach (HMI.CO.Protocol.Point p in SelectedLayer.CZTrend.Points)
                                {
                                    if (p.Value < min) { min = (int)p.Value; }
                                    if (p.Value > max) { max = (int)p.Value; }
                                    temp1.Add(p.TimeStamp.ToString("HH:mm:ss"));
                                    temp2[0].Values.Add(p.Value);
                                }
                                From = Convert.ToDateTime(SelectedLayer.CZ_S);
                                To = Convert.ToDateTime(SelectedLayer.CZ_E);
                                break;
                        }

                });
                obTask.ContinueWith(x =>
                {
                    Application.Current.Dispatcher.Invoke(delegate
                    {
                        MinValue = min - 10;
                        MaxValue = max + 10;
                        Labels = temp1;
                        LastHourSeries = temp2;
                    });
                }, TaskContinuationOptions.OnlyOnRanToCompletion);
            }
            catch { }
                   



        }

        #endregion


    }
}