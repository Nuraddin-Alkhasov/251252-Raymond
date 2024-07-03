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
    public partial class CoatingStep3 : UserControl
    {
        public CoatingStep3()
        {
            if (ApplicationService.IsInDesignMode)
            {
                return;
            }
            InitializeComponent();
           // Class.SetValue("CPU1.PLC.Blocks.03 Basket coating.01 CD.00 Main.DB CD PD.Station.CD.Step[2].Type", 0);
          //  Class.SetValue("CPU1.PLC.Blocks.03 Basket coating.01 CD.00 Main.DB CD PD.Station.CD.Step[2].Dipping.DT", 1);
           // Class.SetValue("CPU1.PLC.Blocks.03 Basket coating.01 CD.00 Main.DB CD PD.Station.CD.Step[2].Dipping.Angle", 0);
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
            
            
            ThicknessAnimation a;
            ThicknessAnimation b;
            ResetData(_type.SelectedIndex);
           
            switch (_type.SelectedIndex)
            {
                case 0:
                    pic.SymbolResourceKey = "Nor";
                    Task obTask = Task.Run(() =>
                    {
                        Application.Current.Dispatcher.InvokeAsync(delegate
                        {
                            

                            a = new ObjectAnimator().SetMargin(new Thickness(0, 30, 0, 0), new Thickness(0, 710, 0, 0), 200);
                            if (Type1.Visibility == Visibility.Visible)
                            {
                                a.Completed += (o, s) => { Type1.Visibility = Visibility.Collapsed; };
                                Type1.BeginAnimation(MarginProperty, a);
                            }
                            else
                            {
                                a.Completed += (o, s) => { Type2.Visibility = Visibility.Collapsed; };
                                Type2.BeginAnimation(MarginProperty, a);
                            }
                        });
                    });
                    Class.SetValue("CPU1.PLC.Blocks.03 Basket coating.01 CD.00 Main.DB CD PD.Station.CD.Step[3].Type", 0);
                    break;
                case 1:
                    pic.SymbolResourceKey = "Dip";
                    obTask = Task.Run(() =>
                    {
                        Application.Current.Dispatcher.InvokeAsync(delegate
                        {
                            if (Type2.Visibility == Visibility.Visible)
                            {
                                a = new ObjectAnimator().SetMargin(new Thickness(0, 30, 0, 0), new Thickness(0, 710, 0, 0), 200);
                                a.Completed += (o, s) =>
                                {
                                    Type2.Visibility = Visibility.Collapsed;
                                    Type1.Visibility = Visibility.Visible;
                                    b = new ObjectAnimator().SetMargin(new Thickness(0, 710, 0, 0), new Thickness(0, 30, 0, 0), 400);
                                    Type1.BeginAnimation(MarginProperty, b);
                                };
                                Type2.BeginAnimation(MarginProperty, a);
                            }
                            else
                            {
                                Type1.Visibility = Visibility.Visible;
                                b = new ObjectAnimator().SetMargin(new Thickness(0, 710, 0, 0), new Thickness(0, 30, 0, 0), 400);
                                Type1.BeginAnimation(MarginProperty, b);
                            }

                        });
                    });
                    Class.SetValue("CPU1.PLC.Blocks.03 Basket coating.01 CD.00 Main.DB CD PD.Station.CD.Step[3].Type", 2);
                    break;
                case 2:
                    pic.SymbolResourceKey = "Spin";
                    obTask = Task.Run(() =>
                    {
                        Application.Current.Dispatcher.InvokeAsync(delegate
                        {
                            if (Type1.Visibility == Visibility.Visible)
                            {
                                a = new ObjectAnimator().SetMargin(new Thickness(0, 30, 0, 0), new Thickness(0, 710, 0, 0), 200);
                                a.Completed += (o, s) =>
                                {
                                    Type1.Visibility = Visibility.Collapsed;
                                    Type2.Visibility = Visibility.Visible;
                                    b = new ObjectAnimator().SetMargin(new Thickness(0, 710, 0, 0), new Thickness(0, 30, 0, 0), 400);
                                    Type2.BeginAnimation(MarginProperty, b);
                                };
                                Type1.BeginAnimation(MarginProperty, a);
                            }
                            else
                            {
                                Type2.Visibility = Visibility.Visible;
                                b = new ObjectAnimator().SetMargin(new Thickness(0, 710, 0, 0), new Thickness(0, 30, 0, 0), 400);
                                Type2.BeginAnimation(MarginProperty, b);
                            }

                        });
                    }); break;
                default:
                    break;
            }
        }
        private void DT_ValueChanged(object sender, VisiWin.DataAccess.VariableEventArgs e)
        {
            if (e.Source == VisiWin.DataAccess.ChangeSource.Application || e.Source == VisiWin.DataAccess.ChangeSource.StopEdit)
            {
                object d0t = 0;
                Class.GetValue("CPU1.PLC.Blocks.03 Basket coating.01 CD.00 Main.DB CD PD.Station.CD.Step[2].Dipping.DT", out d0t);

                if ((byte)d0t == 2)
                {
                    Class.SetValue("CPU1.PLC.Blocks.03 Basket coating.01 CD.00 Main.DB CD PD.Station.CD.Step[2].Dipping.Straight", 0);
                    Class.SetValue("CPU1.PLC.Blocks.03 Basket coating.01 CD.00 Main.DB CD PD.Station.CD.Step[2].Dipping.Straight time", 0);
                    Class.SetValue("CPU1.PLC.Blocks.03 Basket coating.01 CD.00 Main.DB CD PD.Station.CD.Step[2].Dipping.Angle", 50);
                }
            }
        }
        private void Angle_ValueChanged(object sender, VisiWin.DataAccess.VariableEventArgs e)
        {
            if (e.Source == VisiWin.DataAccess.ChangeSource.Application || e.Source == VisiWin.DataAccess.ChangeSource.StopEdit)
            {
                object d0a = 0;
                Class.GetValue("CPU1.PLC.Blocks.03 Basket coating.01 CD.00 Main.DB CD PD.Station.CD.Step[2].Dipping.Angle", out d0a);
                object d0t = 0;
                Class.GetValue("CPU1.PLC.Blocks.03 Basket coating.01 CD.00 Main.DB CD PD.Station.CD.Step[2].Dipping.DT", out d0t);
                
                if ((float)d0a == 0.0f) 
                {
                    Class.SetValue("CPU1.PLC.Blocks.03 Basket coating.01 CD.00 Main.DB CD PD.Station.CD.Step[2].Dipping.Straight", 0);
                    Class.SetValue("CPU1.PLC.Blocks.03 Basket coating.01 CD.00 Main.DB CD PD.Station.CD.Step[2].Dipping.Time", 0);
                    if ((byte)d0t == 1)
                    {
                        streight.Visibility = Visibility.Collapsed;
                        stime.Visibility = Visibility.Visible;
                        stime.LocalizableLabelText = "@RecipeSystem.Text56";
                        dtime.Visibility = Visibility.Collapsed;
                        border1.Visibility = Visibility.Collapsed;
                        stime.IsEnabled = true;
                    }
                    else { Class.SetValue("CPU1.PLC.Blocks.03 Basket coating.01 CD.00 Main.DB CD PD.Station.CD.Step[2].Dipping.Angle", 50); }
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
                        Class.GetValue("CPU1.PLC.Blocks.03 Basket coating.01 CD.00 Main.DB CD PD.Station.CD.Step[2].Dipping.Straight", out d0s);
                        if (!(bool)d0s)
                        {
                            stime.IsEnabled = false;
                            Class.SetValue("CPU1.PLC.Blocks.03 Basket coating.01 CD.00 Main.DB CD PD.Station.CD.Step[2].Dipping.Straight time", 0);
                        }
                        else { stime.IsEnabled = true; }
                    }
                    else { Class.SetValue("CPU1.PLC.Blocks.03 Basket coating.01 CD.00 Main.DB CD PD.Station.CD.Step[2].Dipping.Angle", 50); }
                }
                if ((float)d0a == 50.0f)
                {
                    streight.Visibility = Visibility.Collapsed;
                    stime.Visibility = Visibility.Collapsed;
                    dtime.Visibility = Visibility.Visible;
                    border1.Visibility = Visibility.Collapsed;
                    Class.SetValue("CPU1.PLC.Blocks.03 Basket coating.01 CD.00 Main.DB CD PD.Station.CD.Step[2].Dipping.Straight", 0);
                    Class.SetValue("CPU1.PLC.Blocks.03 Basket coating.01 CD.00 Main.DB CD PD.Station.CD.Step[2].Dipping.Straight time", 0);
                       
                }
                SetDipLimits();
            }
        }
        private void Straight_ValueChanged(object sender, VisiWin.DataAccess.VariableEventArgs e)
        {
            if (e.Source == VisiWin.DataAccess.ChangeSource.Application || e.Source == VisiWin.DataAccess.ChangeSource.StopEdit)
            {
                object d0a = 0;
                Class.GetValue("CPU1.PLC.Blocks.03 Basket coating.01 CD.00 Main.DB CD PD.Station.CD.Step[2].Dipping.Angle", out d0a);

                if ((float)d0a == 40.0f)
                {
                    object d0s = 0;
                    Class.GetValue("CPU1.PLC.Blocks.03 Basket coating.01 CD.00 Main.DB CD PD.Station.CD.Step[2].Dipping.Straight", out d0s);
                    if (!(bool)d0s)
                    {
                        stime.IsEnabled = false; stime.RawLimitMin = 0;
                        Class.SetValue("CPU1.PLC.Blocks.03 Basket coating.01 CD.00 Main.DB CD PD.Station.CD.Step[2].Dipping.Straight time", 0);
                    }
                    else { stime.IsEnabled = true; stime.RawLimitMin = 5; }
                }
                else 
                {
                    Class.SetValue("CPU1.PLC.Blocks.03 Basket coating.01 CD.00 Main.DB CD PD.Station.CD.Step[2].Dipping.Straight", 0);
                    Class.SetValue("CPU1.PLC.Blocks.03 Basket coating.01 CD.00 Main.DB CD PD.Station.CD.Step[2].Dipping.Straight time", 0);
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

        private void spin_ValueChanged(object sender, VisiWin.DataAccess.VariableEventArgs e)
        {
            if (e.Source == VisiWin.DataAccess.ChangeSource.Application || e.Source == VisiWin.DataAccess.ChangeSource.StopEdit)
            {
                SetSpinLimits();
            }
        }

        #endregion

        #region - - - Methods - - -

        private void ResetData(int _type)
        {
            switch (_type)
            {
                case 1: ResetSpinning(); break;
                case 2: ResetDipping(); break;
                default: ResetDipping(); ResetSpinning(); break;
            }
        }
        private void ResetDipping()
        {
            Class.SetValue("CPU1.PLC.Blocks.03 Basket coating.01 CD.00 Main.DB CD PD.Station.CD.Step[2].Dipping.Angle", 0);
            Class.SetValue("CPU1.PLC.Blocks.03 Basket coating.01 CD.00 Main.DB CD PD.Station.CD.Step[2].Dipping.Reverse", 0);
            Class.SetValue("CPU1.PLC.Blocks.03 Basket coating.01 CD.00 Main.DB CD PD.Station.CD.Step[2].Dipping.Time", 0);
            Class.SetValue("CPU1.PLC.Blocks.03 Basket coating.01 CD.00 Main.DB CD PD.Station.CD.Step[2].Dipping.Draining", 0);
            Class.SetValue("CPU1.PLC.Blocks.03 Basket coating.01 CD.00 Main.DB CD PD.Station.CD.Step[2].Dipping.Planet", 0);
            Class.SetValue("CPU1.PLC.Blocks.03 Basket coating.01 CD.00 Main.DB CD PD.Station.CD.Step[2].Dipping.Straight", 0);
            Class.SetValue("CPU1.PLC.Blocks.03 Basket coating.01 CD.00 Main.DB CD PD.Station.CD.Step[2].Dipping.Straight time", 0);
            Class.SetValue("CPU1.PLC.Blocks.03 Basket coating.01 CD.00 Main.DB CD PD.Station.CD.Step[2].Dipping.DT", 0);
        }
        private void ResetSpinning()
        {
            Class.SetValue("CPU1.PLC.Blocks.03 Basket coating.01 CD.00 Main.DB CD PD.Station.CD.Step[2].Spinning.1.Rotor", 0);
            Class.SetValue("CPU1.PLC.Blocks.03 Basket coating.01 CD.00 Main.DB CD PD.Station.CD.Step[2].Spinning.1.Time", 0);
            Class.SetValue("CPU1.PLC.Blocks.03 Basket coating.01 CD.00 Main.DB CD PD.Station.CD.Step[2].Spinning.2.Planet", 0);
            Class.SetValue("CPU1.PLC.Blocks.03 Basket coating.01 CD.00 Main.DB CD PD.Station.CD.Step[2].Spinning.2.Rotor", 0);
            Class.SetValue("CPU1.PLC.Blocks.03 Basket coating.01 CD.00 Main.DB CD PD.Station.CD.Step[2].Spinning.2.Time", 0);
            Class.SetValue("CPU1.PLC.Blocks.03 Basket coating.01 CD.00 Main.DB CD PD.Station.CD.Step[2].Spinning.3.Rotor", 0);
            Class.SetValue("CPU1.PLC.Blocks.03 Basket coating.01 CD.00 Main.DB CD PD.Station.CD.Step[2].Spinning.3.Time", 0);
        }
        private void SetDipLimits()
        {
            object d0a = 0;
            Class.GetValue("CPU1.PLC.Blocks.03 Basket coating.01 CD.00 Main.DB CD PD.Station.CD.Step[2].Dipping.Angle", out d0a);
            object d0s = 0;
            Class.GetValue("CPU1.PLC.Blocks.03 Basket coating.01 CD.00 Main.DB CD PD.Station.CD.Step[2].Dipping.Straight", out d0s);
            object d0t = 0;
            Class.GetValue("CPU1.PLC.Blocks.03 Basket coating.01 CD.00 Main.DB CD PD.Station.CD.Step[2].Dipping.DT", out d0t);
            object d0st = 0;
            Class.GetValue("CPU1.PLC.Blocks.03 Basket coating.01 CD.00 Main.DB CD PD.Station.CD.Step[2].Dipping.Straight time", out d0st);
            object d0dt = 0;
            Class.GetValue("CPU1.PLC.Blocks.03 Basket coating.01 CD.00 Main.DB CD PD.Station.CD.Step[2].Dipping.Time", out d0dt);
            object d0ddt = 0;
            Class.GetValue("CPU1.PLC.Blocks.03 Basket coating.01 CD.00 Main.DB CD PD.Station.CD.Step[2].Dipping.Draining", out d0ddt);


            if ((byte)d0st == 0 && (byte)d0dt == 0 && (byte)d0ddt == 0)
            {
                stime.RawLimitMin = dtime.RawLimitMin = draining.RawLimitMin = 5;
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
                if ((byte)d0st != 0 || (byte)d0dt != 0)
                {
                    draining.RawLimitMin = 0;
                    if ((bool)d0s)
                    {
                        stime.RawLimitMin = dtime.RawLimitMin = 5;
                    }
                    else { stime.RawLimitMin = 0; dtime.RawLimitMin = 5; }

                }
                else
                {
                    draining.RawLimitMin = 5;
                }


                if ((byte)d0ddt > 0)
                {
                    stime.RawLimitMin = dtime.RawLimitMin = 0;
                }
                if ((float)d0a == 40.0f)
                {
                    if ((bool)d0s) { stime.IsEnabled = true; }
                    else { stime.IsEnabled = false; }
                }
                else { stime.IsEnabled = true; }

            }

         
        }
        private void SetSpinLimits()
        {
            object s1t1 = 0;
            Class.GetValue("CPU1.PLC.Blocks.03 Basket coating.01 CD.00 Main.DB CD PD.Station.CD.Step[2].Spinning.1.Time", out s1t1);
            object s1t2 = 0;
            Class.GetValue("CPU1.PLC.Blocks.03 Basket coating.01 CD.00 Main.DB CD PD.Station.CD.Step[2].Spinning.2.Time", out s1t2);
            object s1r2 = 0;
            Class.GetValue("CPU1.PLC.Blocks.03 Basket coating.01 CD.00 Main.DB CD PD.Station.CD.Step[2].Spinning.2.Rotor", out s1r2);
            object s1t3 = 0;
            Class.GetValue("CPU1.PLC.Blocks.03 Basket coating.01 CD.00 Main.DB CD PD.Station.CD.Step[2].Spinning.3.Time", out s1t3);


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
                    Class.SetValue("CPU1.PLC.Blocks.03 Basket coating.01 CD.00 Main.DB CD PD.Station.CD.Step[2].Spinning.1.Rotor", 0);
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
                    Class.SetValue("CPU1.PLC.Blocks.03 Basket coating.01 CD.00 Main.DB CD PD.Station.CD.Step[2].Spinning.2.Rotor", 0);
                    s2p.IsEnabled = false;
                    Class.SetValue("CPU1.PLC.Blocks.03 Basket coating.01 CD.00 Main.DB CD PD.Station.CD.Step[2].Spinning.2.Planet", 0);
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
                    Class.SetValue("CPU1.PLC.Blocks.03 Basket coating.01 CD.00 Main.DB CD PD.Station.CD.Step[2].Spinning.3.Rotor", 0);
                }
            }
        }
        #endregion


    }
}
