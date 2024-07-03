using HMI.CO.General;
using HMI.MessageBoxRegion.Views;
using HMI.Resources;
using HMI.Resources.UserControls.MO;
using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using VisiWin.ApplicationFramework;
using VisiWin.DataAccess;
using VisiWin.Logging;

namespace HMI.MainRegion.MO.Views
{

    [ExportView("MO_MainView")]
    public partial class MO_MainView
    {
        
        public MO_MainView()
        {
            InitializeComponent();
            //pn_mv.SelectedPanoramaRegionIndex = 1;
        }

        private void pn_mv_SelectedPanoramaRegionChanged(object sender, VisiWin.Controls.SelectedPanoramaRegionChangedEventArgs e)
        {
            if (pn_mv.SelectedPanoramaRegionIndex == 0)
            {
                M1.Add(new MO_MainView_M2());
                foreach (UIElement C2 in M2.Views)
                {
                    M2.Remove(C2);
                    return;
                }
           
            }
            if (pn_mv.SelectedPanoramaRegionIndex == 1)
            {
                M2.Add(new MO_MainView_M1());
                foreach (UIElement C1 in M1.Views)
                {
                    M1.Remove(C1);
                    return;
                }
                
            }
        }

        private void View_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (!(bool)e.NewValue)
            {
                if (pn_mv.SelectedPanoramaRegionIndex == 0)
                    foreach (UIElement C2 in M2.Views)
                    {
                    
                        M2.Remove(C2);
                        M2 = new VisiWin.Controls.PanoramaRegion();
                    }

                if (pn_mv.SelectedPanoramaRegionIndex == 1)
                    foreach (UIElement C1 in M1.Views)
                    {
                        M1.Remove(C1);
                        M1 = new VisiWin.Controls.PanoramaRegion();
                    }
            }
        }
    }
}
