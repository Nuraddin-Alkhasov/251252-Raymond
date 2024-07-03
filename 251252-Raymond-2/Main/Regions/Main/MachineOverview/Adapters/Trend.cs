﻿using HMI.CO.Trend;
using System;
using System.Collections;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using VisiWin.Adapter;
using VisiWin.ApplicationFramework;
using VisiWin.Commands;
using VisiWin.Controls;
using VisiWin.DataAccess;
using VisiWin.Trend;

namespace HMI.MainRegion.MO.Adapters
{
    [ExportAdapter("Trend")]
    public class Trend : AdapterBase
    {


        public Trend()
        {

            if (ApplicationService.IsInDesignMode)
                return;

            IVariableService VS = ApplicationService.GetService<IVariableService>();
            Min = VS.GetVariable("Trend.Min");
            Min.Change += Min_Charge;
            Max = VS.GetVariable("Trend.Max");
            Max.Change += Max_Charge;

            Back = new ActionCommand(BackExecuted);
            LoadChartInstance = new ActionCommand(LoadChartInstanceExecuted);

        }
        #region - - - Properties - - -
        public IVariable Min { set; get; }
        public IVariable Max { set; get; }

        private TrendChart trendChart;

        public TrendData trendData { set; get; } = new TrendData();
        public TrendData TrendData
        {
            get { return trendData; }
            set
            {
                trendData = value;
                OnPropertyChanged("TrendData");

            }
        }

        public ObservableCollection<TimeSpan> Resolutions { get; } = new ObservableCollection<TimeSpan>()
                               {
                                   TimeSpan.FromMinutes(2),
                                   TimeSpan.FromMinutes(5),
                                   TimeSpan.FromMinutes(15),
                                   TimeSpan.FromMinutes(30),
                                   TimeSpan.FromMinutes(60),
                                   TimeSpan.FromMinutes(5*60),
                               };

        private bool isOnline { get; set; } = false;
        public bool IsOnline
        {
            get { return isOnline; }
            set
            {
                isOnline = value;
                OnPropertyChanged("IsOnline");
            }
        }
        #endregion

        #region - - - Event Handlers - - - 
        private void Min_Charge(object sender, VariableEventArgs e)
        {
            if (e.Quality.Data == DataQuality.Good && e.Value != e.PreviousValue)
            {
                TrendData.Min = Convert.ToInt32(e.RawValue);
                OnPropertyChanged("TrendData");
            }
        }
        private void Max_Charge(object sender, VariableEventArgs e)
        {
            if (e.Quality.Data == DataQuality.Good && e.Value != e.PreviousValue)
            {
                TrendData.Max = Convert.ToInt32(e.RawValue);
                OnPropertyChanged("TrendData");
            }
        }
        #endregion

        #region - - - Commands - - -

        public ICommand LoadChartInstance { get; }

        //public ICommand ShowReportCommand { get; }


        private void LoadChartInstanceExecuted(object parameter)
        {
            var chart = parameter as TrendChart;
            if (chart == null)
                return;

            if (trendChart == chart)
                return;

            trendChart = chart;

            trendChart.CurvesContainers.CollectionChanged += CurvesContainers_CollectionChanged;
            InitCurveInformations();

            trendChart.Markers.CollectionChanged += Markers_CollectionChanged;
            AttachMarkers(trendChart.Markers);
        }

        public ICommand Back { get; }




        private void BackExecuted(object parameter)
        {
            ApplicationService.SetView("MainRegion", TrendData.BackViewName);
        }

        #endregion

        public TrendCurveInformationCollection CurveInformations { get; } = new TrendCurveInformationCollection();






        //private void ShowReportCommandExecuted(object parameter)
        //{
        //    var curve = parameter as TrendCurve2;
        //    var trendCurvesContainerDateTime = this.trendChart.CurvesContainers.First(c => c is TrendCurvesContainerDateTime) as TrendCurvesContainerDateTime;
        //    ChartScaleDateTime scaleDateTime = trendCurvesContainerDateTime?.Scale as ChartScaleDateTime;
        //    if (scaleDateTime == null)
        //        return;

        //    var scalePoints = scaleDateTime.ScalePoints;

        //    var minTimePoint = ((ScalePoint<DateTime>)scalePoints.First(p => p.IsMinMaxValue)).Value;
        //    var maxTimePoint = ((ScalePoint<DateTime>)scalePoints.Last(p => p.IsMinMaxValue)).Value;

        //    Func<CancellationToken, Task<ReportConfiguration>> config = (t) => TrendReport.GetReportConfiguration(curve, minTimePoint, maxTimePoint, t);

        //    var adapter = ApplicationService.GetAdapter("ReportViewAdapter") as ReportViewAdapter;
        //    if (adapter != null)
        //    {
        //        adapter.OpenView("MainRegion", config);
        //    }
        //}



        private void UpdateCurveInformation(ChartMarker marker)
        {

            if (marker == null)
                return;

            // Nur für den selektierten Marker die Werte anzeigen.
            if (!marker.IsSelected)
                return;

            foreach (var markerPoints in marker.MarkerPoints.GroupBy(mp => mp.Curve))
            {
                ICurve actualCurve = markerPoints.Key;
                var firstMarkerPoint = markerPoints.First();
                if (marker.Orientation == Orientation.Horizontal)
                {
                    CurveInformations[actualCurve].MarkedXValues = firstMarkerPoint.XValue.Value.ToString();
                    CurveInformations[actualCurve].MarkedYValues = string.Join("; ", markerPoints.OrderBy(mp => mp.YValue.RawValue).Select(mp => mp.YValue.ValueFormatted));
                }
                else
                {
                    CurveInformations[actualCurve].MarkedXValues = string.Join("; ", markerPoints.OrderBy(mp => mp.XValue.RawValue).Select(mp => mp.XValue.ValueFormatted));
                    CurveInformations[actualCurve].MarkedYValues = firstMarkerPoint.YValue.ValueFormatted;
                }
            }
        }
        #region - - - Event Handlers - - -
        protected override void OnViewLoaded(object sender, ViewLoadedEventArg e)
        {
            if (sender.GetType().Name == e.View.GetType().Name)
            {

                TrendData = ApplicationService.ObjectStore.GetValue("Trend_KEY") as TrendData;
                ApplicationService.ObjectStore.Remove("Trend_KEY");

                InitCurveInformations();

                int maxIfNull = TrendData.Max;

                ITrendService trendService = ApplicationService.GetService<ITrendService>();
                float a = (float)ApplicationService.GetVariableValue((trendService.GetArchive(TrendData.ArchiveName)).GetTrend(TrendData.TrendName_1).GetDefinition().TrendVariableName);
                float b = (float)ApplicationService.GetVariableValue((trendService.GetArchive(TrendData.ArchiveName)).GetTrend(TrendData.TrendName_2).GetDefinition().TrendVariableName);

                if (a < b)
                {
                    ApplicationService.SetVariableValue("Trend.Min", Math.Floor(a - b * 0.05 < 0 ? 0 : a - b * 0.05));
                    ApplicationService.SetVariableValue("Trend.Max", Math.Ceiling(b + b * 0.05) == 0 ? TrendData.Max : Math.Ceiling(b + b * 0.05));
                }
                else
                {
                    ApplicationService.SetVariableValue("Trend.Min", Math.Floor(b - a * 0.05 < 0 ? 0 : b - a * 0.05));
                    ApplicationService.SetVariableValue("Trend.Max", Math.Ceiling(a + a * 0.05) == 0 ? TrendData.Max : Math.Ceiling(a + a * 0.05));
                }

                Task.Run(async () =>
                {
                    await Task.Delay(500);
                    await Dispatcher.InvokeAsync(delegate
                    {
                        IsOnline = true;
                    });
                });
            }
            base.OnViewLoaded(sender, e);
        }

        protected override void OnViewUnloaded(object sender, ViewUnloadedEventArg e)
        {
            if (sender.GetType().Name == e.View.GetType().Name)
            {
                IsOnline = false;
            }

            base.OnViewUnloaded(sender, e);
        }

        private void CurvesContainers_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.OldItems != null)
                AttachCurvesContainers(e.OldItems);

            if (e.NewItems != null)
                DetachCurvesContainers(e.NewItems);

            InitCurveInformations();
        }

        private void CurvesContainer_CurvesCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            InitCurveInformations();
        }
        private void Markers_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.OldItems != null)
                DetachMarkers(e.OldItems);

            if (e.NewItems != null)
                AttachMarkers(e.NewItems);
        }

        private void Marker_MarkerPointsChanged(object sender, RoutedEventArgs e)
        {
            UpdateCurveInformation(sender as ChartMarker);
        }

        #endregion

        #region - - - Methods - - -
        public void InitCurveInformations()
        {
            CurveInformations.Clear();

            if (trendChart == null)
                return;

            var curvesContainer = trendChart.CurvesContainers[0];

            TrendCurve2 iW = curvesContainer.Curves[0] as TrendCurve2;
            TrendCurve2 sW = curvesContainer.Curves[1] as TrendCurve2;

            CurveInformations.Add(iW);
            CurveInformations.Add(sW);

        }
        private void AttachMarkers(IEnumerable markers)
        {
            foreach (ChartMarker marker in markers)
            {
                marker.MarkerPointsChanged += Marker_MarkerPointsChanged;
                UpdateCurveInformation(marker);
            }
        }

        private void DetachMarkers(IEnumerable markers)
        {
            foreach (ChartMarker marker in markers)
                marker.MarkerPointsChanged -= Marker_MarkerPointsChanged;
        }

        private void AttachCurvesContainers(IEnumerable curvesContainers)
        {
            foreach (ICurvesContainer curvesContainer in curvesContainers)
                curvesContainer.CurvesCollectionChanged += CurvesContainer_CurvesCollectionChanged;
        }

        private void DetachCurvesContainers(IEnumerable curvesContainers)
        {
            foreach (ICurvesContainer curvesContainer in curvesContainers)
                curvesContainer.CurvesCollectionChanged -= CurvesContainer_CurvesCollectionChanged;
        }

        #endregion
    }
}
