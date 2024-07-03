﻿using HMI.CO.General;
using System.ComponentModel.Composition;
using VisiWin.ApplicationFramework;

namespace HMI.MainRegion.Dashboard.Widgets
{
    [ExportDashboardWidget("DB_Widget_CZT3", "Dashboard.Text33", "@Dashboard.Text11", 1, 1)]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public partial class DB_Widget_CZT3
    {


        public DB_Widget_CZT3()
        {
            if (ApplicationService.IsInDesignMode)
            {
                return;
            }
            InitializeComponent();

            UC.DoWork();
        }

        private void Border_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            new ObjectAnimator().OpenDialog(this, border);
        }


    }
}
