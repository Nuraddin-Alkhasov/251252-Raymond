using HMI.CO.General;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;
using VisiWin.ApplicationFramework;
using VisiWin.Recipe;

namespace HMI.Resources.UserControls
{
    public partial class CoatingStep1 : UserControl
    {
        public CoatingStep1()
        {
            if (ApplicationService.IsInDesignMode)
            {
                return;
            }
            InitializeComponent();

            Class.SetValue("CPU1.PLC.Blocks.03 Basket coating.01 CD.00 Main.DB CD PD.Station.CD.Step[0].Type", 1);
            Class.SetValue("CPU1.PLC.Blocks.03 Basket coating.01 CD.00 Main.DB CD PD.Station.CD.Step[0].Dipping.DT", 1);
            Class.SetValue("CPU1.PLC.Blocks.03 Basket coating.01 CD.00 Main.DB CD PD.Station.CD.Step[0].Dipping.Angle", 0);
            
        }


        #region - - - Properties - - -

        public IRecipeClass Class = ApplicationService.GetService<IRecipeService>().GetRecipeClass("Coating");

        #endregion

        #region - - - Event Handlers - - -
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            new ObjectAnimator().ShowUIElement(this);
        }
        private void UserControl_Unloaded(object sender, RoutedEventArgs e)
        {
            List<string> VariableNames = Class.GetVariableNames();
            foreach (string vn in VariableNames)
            {
                Class.SetValue(vn, 0);
            }
        }
        private void StepType_Changed(object sender, SelectionChangedEventArgs e)
        {
            ThicknessAnimation b;

            pic.SymbolResourceKey = "Dip";
            Task.Run(() =>
            {
                Application.Current.Dispatcher.InvokeAsync(delegate
                {
                    
                    Type1.Visibility = Visibility.Visible;
                    b = new ObjectAnimator().SetMargin(new Thickness(0, 710, 0, 0), new Thickness(0, 30, 0, 0), 400);
                    Type1.BeginAnimation(MarginProperty, b);
                   

                });
            });
                    
            
        }
        private void DT_ValueChanged(object sender, VisiWin.DataAccess.VariableEventArgs e)
        {
            if (e.Source == VisiWin.DataAccess.ChangeSource.Application || e.Source == VisiWin.DataAccess.ChangeSource.StopEdit)
            {
                object d0t = 0;
                Class.GetValue("CPU1.PLC.Blocks.03 Basket coating.01 CD.00 Main.DB CD PD.Station.CD.Step[0].Dipping.DT", out d0t);

                if ((byte)d0t == 2)
                {
                    Class.SetValue("CPU1.PLC.Blocks.03 Basket coating.01 CD.00 Main.DB CD PD.Station.CD.Step[0].Dipping.Straight", 0);
                    Class.SetValue("CPU1.PLC.Blocks.03 Basket coating.01 CD.00 Main.DB CD PD.Station.CD.Step[0].Dipping.Straight time", 0);
                    Class.SetValue("CPU1.PLC.Blocks.03 Basket coating.01 CD.00 Main.DB CD PD.Station.CD.Step[0].Dipping.Angle", 50);
                }
            }
        }
        private void Angle_ValueChanged(object sender, VisiWin.DataAccess.VariableEventArgs e)
        {
            if (e.Source == VisiWin.DataAccess.ChangeSource.Application || e.Source == VisiWin.DataAccess.ChangeSource.StopEdit)
            {
                object d0a = 0;
                Class.GetValue("CPU1.PLC.Blocks.03 Basket coating.01 CD.00 Main.DB CD PD.Station.CD.Step[0].Dipping.Angle", out d0a);
                object d0t = 0;
                Class.GetValue("CPU1.PLC.Blocks.03 Basket coating.01 CD.00 Main.DB CD PD.Station.CD.Step[0].Dipping.DT", out d0t);

                if ((float)d0a == 0.0f) 
                {
                    Class.SetValue("CPU1.PLC.Blocks.03 Basket coating.01 CD.00 Main.DB CD PD.Station.CD.Step[0].Dipping.Straight", 0);
                    Class.SetValue("CPU1.PLC.Blocks.03 Basket coating.01 CD.00 Main.DB CD PD.Station.CD.Step[0].Dipping.Time", 0);
                    if ((byte)d0t == 1)
                    {
                        streight.Visibility = Visibility.Collapsed;
                        stime.Visibility = Visibility.Visible;
                        stime.LocalizableLabelText = "@RecipeSystem.Text56";
                        dtime.Visibility = Visibility.Collapsed;
                        border1.Visibility = Visibility.Collapsed;
                        stime.IsEnabled = true;
                    }
                    else { Class.SetValue("CPU1.PLC.Blocks.03 Basket coating.01 CD.00 Main.DB CD PD.Station.CD.Step[0].Dipping.Angle", 50); }
                }

                if ((float)d0a == 40.0f) 
                {
                    if ((byte)d0t == 1)
                    {
                        streight.Visibility = Visibility.Visible;
                        stime.Visibility = Visibility.Visible;
                        dtime.Visibility = Visibility.Visible;
                        stime.LocalizableLabelText = "@RecipeSystem.Text70";
                        border1.Visibility = Visibility.Visible;

                        object d0s = 0;
                        Class.GetValue("CPU1.PLC.Blocks.03 Basket coating.01 CD.00 Main.DB CD PD.Station.CD.Step[0].Dipping.Straight", out d0s);
                        if (!(bool)d0s)
                        {
                            stime.IsEnabled = false;
                            Class.SetValue("CPU1.PLC.Blocks.03 Basket coating.01 CD.00 Main.DB CD PD.Station.CD.Step[0].Dipping.Straight time", 0);
                        }
                        else { stime.IsEnabled = true; }
                    }
                    else { Class.SetValue("CPU1.PLC.Blocks.03 Basket coating.01 CD.00 Main.DB CD PD.Station.CD.Step[0].Dipping.Angle", 50); }
                }

                if ((float)d0a == 50.0f) 
                {
                    streight.Visibility = Visibility.Collapsed;
                    stime.Visibility = Visibility.Collapsed;
                    dtime.Visibility = Visibility.Visible;
                    border1.Visibility = Visibility.Collapsed;
                    Class.SetValue("CPU1.PLC.Blocks.03 Basket coating.01 CD.00 Main.DB CD PD.Station.CD.Step[0].Dipping.Straight", 0);
                    Class.SetValue("CPU1.PLC.Blocks.03 Basket coating.01 CD.00 Main.DB CD PD.Station.CD.Step[0].Dipping.Straight time", 0);
                }

                SetDipLimits();
            }
        }
        private void Straight_ValueChanged(object sender, VisiWin.DataAccess.VariableEventArgs e)
        {
            if (e.Source == VisiWin.DataAccess.ChangeSource.Application || e.Source == VisiWin.DataAccess.ChangeSource.StopEdit)
            {
                object d0a = 0;
                Class.GetValue("CPU1.PLC.Blocks.03 Basket coating.01 CD.00 Main.DB CD PD.Station.CD.Step[0].Dipping.Angle", out d0a);

                if ((float)d0a == 40.0f)
                {
                    object d0s = 0;
                    Class.GetValue("CPU1.PLC.Blocks.03 Basket coating.01 CD.00 Main.DB CD PD.Station.CD.Step[0].Dipping.Straight", out d0s);
                    if (!(bool)d0s)
                    {
                        stime.IsEnabled = false; stime.RawLimitMin = 0;
                        Class.SetValue("CPU1.PLC.Blocks.03 Basket coating.01 CD.00 Main.DB CD PD.Station.CD.Step[0].Dipping.Straight time", 0);
                    }
                    else { stime.IsEnabled = true; stime.RawLimitMin = 5; }
                }
                else
                {
                    Class.SetValue("CPU1.PLC.Blocks.03 Basket coating.01 CD.00 Main.DB CD PD.Station.CD.Step[0].Dipping.Straight", 0);
                    Class.SetValue("CPU1.PLC.Blocks.03 Basket coating.01 CD.00 Main.DB CD PD.Station.CD.Step[0].Dipping.Straight time", 0);
                }
            }
        }
        private void dip_ValueChanged(object sender, VisiWin.DataAccess.VariableEventArgs e)
        {
            if (e.Source == VisiWin.DataAccess.ChangeSource.Application || e.Source == VisiWin.DataAccess.ChangeSource.StopEdit)
            {
                SetDipLimits();
            }
        }
        #endregion

        #region - - - Methods - - -
        public void SetDipLimits()
        {
            object d0a = 0;
            Class.GetValue("CPU1.PLC.Blocks.03 Basket coating.01 CD.00 Main.DB CD PD.Station.CD.Step[0].Dipping.Angle", out d0a);
            object d0s = 0;
            Class.GetValue("CPU1.PLC.Blocks.03 Basket coating.01 CD.00 Main.DB CD PD.Station.CD.Step[0].Dipping.Straight", out d0s);
            object d0t = 0;
            Class.GetValue("CPU1.PLC.Blocks.03 Basket coating.01 CD.00 Main.DB CD PD.Station.CD.Step[0].Dipping.DT", out d0t);
            object d0st = 0;
            Class.GetValue("CPU1.PLC.Blocks.03 Basket coating.01 CD.00 Main.DB CD PD.Station.CD.Step[0].Dipping.Straight time", out d0st);
            object d0dt = 0;
            Class.GetValue("CPU1.PLC.Blocks.03 Basket coating.01 CD.00 Main.DB CD PD.Station.CD.Step[0].Dipping.Time", out d0dt);

            if ((byte)d0st == 0 && (byte)d0dt == 0)
            {
                stime.RawLimitMin = dtime.RawLimitMin = 5;

                if ((float)d0a == 40.0f)
                {
                    if ((bool)d0s)
                    {
                        stime.RawLimitMin = 5;
                    }
                    else
                    {
                        stime.RawLimitMin = 0;
                    }
                }

                dspeed.IsEnabled = false;
                reverse.IsEnabled = false;
            }
            else
            {
                dspeed.IsEnabled = true;
                reverse.IsEnabled = true;

                if ((bool)d0s || (float)d0a == 0.0f)
                {
                    stime.RawLimitMin = 5;
                }
                else { stime.RawLimitMin = 0; }



                if ((float)d0a == 40.0f)
                {
                    if ((bool)d0s) { stime.IsEnabled = true; }
                    else { stime.IsEnabled = false; }
                }
                else { stime.IsEnabled = true; }

            }


               
              
        }

        
        #endregion


    }
}
