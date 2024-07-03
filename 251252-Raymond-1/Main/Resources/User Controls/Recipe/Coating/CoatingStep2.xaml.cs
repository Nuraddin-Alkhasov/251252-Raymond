using HMI.CO.General;
using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;
using VisiWin.ApplicationFramework;
using VisiWin.Recipe;

namespace HMI.Resources.UserControls
{
    public partial class CoatingStep2 : UserControl
    {
        public CoatingStep2()
        {
            if (ApplicationService.IsInDesignMode)
            {
                return;
            }
            InitializeComponent();
            Class.SetValue("CPU1.PLC.Blocks.03 Basket coating.01 CD.00 Main.DB CD PD.Station.CD.Step[1].Type", 2);
        }


        #region - - - Properties - - -

        public IRecipeClass Class = ApplicationService.GetService<IRecipeService>().GetRecipeClass("Coating");

        #endregion

        #region - - - Event Handlers - - -
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            new ObjectAnimator().ShowUIElement(this);
        }
        private void StepType_Changed(object sender, SelectionChangedEventArgs e)
        {
            ThicknessAnimation b;
          
            pic.SymbolResourceKey = "Spin";
            Task.Run(() =>
            {
                Application.Current.Dispatcher.InvokeAsync(delegate
                {
                    
                    Type2.Visibility = Visibility.Visible;
                    b = new ObjectAnimator().SetMargin(new Thickness(0, 710, 0, 0), new Thickness(0, 30, 0, 0), 400);
                    Type2.BeginAnimation(MarginProperty, b);
                });
            }); 
        }
        private void spin_ValueChanged(object sender, VisiWin.DataAccess.VariableEventArgs e)
        {
            if (e.Source == VisiWin.DataAccess.ChangeSource.Application || e.Source == VisiWin.DataAccess.ChangeSource.StopEdit)
            {
                SetSpinLimits();
            }
        }


        #endregion

        #region - - - Methods - - -
        private void SetSpinLimits()
        {
            object s1t1 = 0;
            Class.GetValue("CPU1.PLC.Blocks.03 Basket coating.01 CD.00 Main.DB CD PD.Station.CD.Step[1].Spinning.1.Time", out s1t1);
            object s1t2 = 0;
            Class.GetValue("CPU1.PLC.Blocks.03 Basket coating.01 CD.00 Main.DB CD PD.Station.CD.Step[1].Spinning.2.Time", out s1t2);
            object s1r2 = 0;
            Class.GetValue("CPU1.PLC.Blocks.03 Basket coating.01 CD.00 Main.DB CD PD.Station.CD.Step[1].Spinning.2.Rotor", out s1r2);
            object s1t3 = 0;
            Class.GetValue("CPU1.PLC.Blocks.03 Basket coating.01 CD.00 Main.DB CD PD.Station.CD.Step[1].Spinning.3.Time", out s1t3);
           

            if ((byte)s1t1 == 0 && (byte)s1t2 == 0 && (byte)s1t3 == 0)
            {
                s1t.RawLimitMin = s2t.RawLimitMin = s3t.RawLimitMin = 5;

                s1r.IsEnabled = false;
                s1r.RawLimitMin = 0;

                s2r.IsEnabled = false;
                s2r.RawLimitMin = 0;
                s2p.IsEnabled = false;

                s3r.IsEnabled = false;
                s3r.RawLimitMin = 0;
            }
            else
            {
                if ((byte)s1t1 != 0)
                {
                    if ((byte)s1t2 == 0 && (byte)s1t3 == 0)
                    {
                        s1t.RawLimitMin = 5;
                        s2t.RawLimitMin = s3t.RawLimitMin = 0;
                    }
                    else { s1t.RawLimitMin = s2t.RawLimitMin = s3t.RawLimitMin = 0; }

                    s1r.IsEnabled = true;
                    s1r.RawLimitMin = 130;
                }
                else
                {
                    s1r.IsEnabled = false;
                    s1r.RawLimitMin = 0;
                    Class.SetValue("CPU1.PLC.Blocks.03 Basket coating.01 CD.00 Main.DB CD PD.Station.CD.Step[1].Spinning.1.Rotor",0);
                }

                if ((byte)s1t2 != 0)
                {
                    if ((byte)s1t1 == 0 && (byte)s1t3 == 0)
                    {
                        s2t.RawLimitMin = 5;
                        s1t.RawLimitMin = s3t.RawLimitMin = 0;
                    }
                    else { s1t.RawLimitMin = s2t.RawLimitMin = s3t.RawLimitMin = 0; }

                    s2r.IsEnabled = true;
                    s2p.IsEnabled = true;
                    if ((float)s1r2 < 130)
                    {
                        s3t.RawLimitMin = 5;
                    }
                    else { s3t.RawLimitMin = 0; }
                }
                else
                {
                    s2r.IsEnabled = false;
                    s2r.RawLimitMin = 0;
                    Class.SetValue("CPU1.PLC.Blocks.03 Basket coating.01 CD.00 Main.DB CD PD.Station.CD.Step[1].Spinning.2.Rotor", 0);
                    s2p.IsEnabled = false;
                    Class.SetValue("CPU1.PLC.Blocks.03 Basket coating.01 CD.00 Main.DB CD PD.Station.CD.Step[1].Spinning.2.Planet", 0);
                }

                if ((byte)s1t3 != 0)
                {
                    if ((float)s1r2 < 130 || ((byte)s1t1 == 0 && (byte)s1t2 == 0))
                    {
                        s3t.RawLimitMin = 5;
                        s1t.RawLimitMin = s2t.RawLimitMin = 0;
                    }
                    else { s1t.RawLimitMin = s2t.RawLimitMin = s3t.RawLimitMin = 0; }


                    s3r.IsEnabled = true;
                    s3r.RawLimitMin = 130;
                }
                else
                {
                    s3r.IsEnabled = false;
                    s3r.RawLimitMin = 0;
                    Class.SetValue("CPU1.PLC.Blocks.03 Basket coating.01 CD.00 Main.DB CD PD.Station.CD.Step[1].Spinning.3.Rotor", 0);
                }
            }
        }
        
        #endregion


    }
}
