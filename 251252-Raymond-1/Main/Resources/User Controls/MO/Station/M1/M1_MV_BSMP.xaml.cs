using HMI.CO.General;
using System;
using System.Windows;
using System.Windows.Controls;

using VisiWin.ApplicationFramework;
using VisiWin.DataAccess;

namespace HMI.Resources.UserControls.MO
{
    public partial class M1_MV_BSMP : UserControl
    {
        public M1_MV_BSMP()
        {
            InitializeComponent();
            ManipulatorPosition = "CPU1.PLC.Blocks.02 Basket handling.02 BM.00 Main.DB BM HMI.Actual.State";
            BHState = "CPU1.PLC.Blocks.02 Basket handling.00 Main.DB BH HMI.Actual.State";
        }
        IVariableService VS = ApplicationService.GetService<IVariableService>();

        IVariable maniPos;
        public string ManipulatorPosition
        {
             get { return ""; } 
            set
            {
                if (VS.IsExistingVariable(value))
                {
                    maniPos = VS.GetVariable(value);
                    maniPos.Change += maniPos_Change;
                }
            }
        }

        private void maniPos_Change(object sender, VariableEventArgs e)
        {
            //if (e.Source == ChangeSource.System) 
            {
                GridClear();
                switch ((byte)e.Value)
                {
                    case 0:
                        ManiPosition.SymbolResourceKey = "MV_MP1"; 
                        Dispatcher.InvokeAsync(delegate
                        {
                            B.Children.Add(GetBasket("R", new Thickness(116, 221, 0, 0), 0));
                            B.Children.Add(GetBasket("L", new Thickness(116, 262, 0, 0), 0));
                        });
                        

                        break;
                    case 1:
                        ManiPosition.SymbolResourceKey = "MV_MP2";
                        break;
                    case 2:
                        ManiPosition.SymbolResourceKey = "MV_MP3";
                        Dispatcher.InvokeAsync(delegate
                        {
                            B.Children.Add(GetBasket("L", new Thickness(145, 305, 0, 0), 2));
                            B.Children.Add(GetBasket("R", new Thickness(197, 322, 0, 0), 2));
                        });
                        break;
                    case 3:
                        ManiPosition.SymbolResourceKey = "MV_MP4";
                        Dispatcher.InvokeAsync(delegate
                        {
                            B.Children.Add(GetBasket("L", new Thickness(99, 411, 0, 0), 3));
                            B.Children.Add(GetBasket("R", new Thickness(150, 427, 0, 0), 3));
                        });
                        break;
                    case 4:
                        ManiPosition.SymbolResourceKey = "MV_MP5";
                        Dispatcher.InvokeAsync(delegate
                        {
                            B.Children.Add(GetBasket("R", new Thickness(216, 318, 0, 0), 4));
                            B.Children.Add(GetBasket("L", new Thickness(270, 310, 0, 0), 4));
                        });

                        break;
                    case 5:
                        ManiPosition.SymbolResourceKey = "MV_MP6";
                        break;
                    case 6:
                        ManiPosition.SymbolResourceKey = "MV_MP7";
                        Dispatcher.InvokeAsync(delegate
                        {
                            B.Children.Add(GetBasket("L", new Thickness(331, 231, 0, 0), 6));
                            B.Children.Add(GetBasket("R", new Thickness(331, 270, 0, 0), 6));
                        });
                        break;
                    case 7:
                        ManiPosition.SymbolResourceKey = "MV_MP8";
                        break;
                    case 8:
                        ManiPosition.SymbolResourceKey = "MV_MP9";
                        Dispatcher.InvokeAsync(delegate
                        {
                            B.Children.Add(GetBasket("L", new Thickness(446, 172, -3, 0), 7));
                            B.Children.Add(GetBasket("R", new Thickness(446, 212, -3, 0), 7));
                        });
                        break;
                }
            }
             
        }
        IVariable bHState;
        public string BHState
        {
            get { return ""; }
            set
            {
                if (VS.IsExistingVariable(value))
                {
                    bHState = VS.GetVariable(value);
                    bHState.Change += bHState_Change;
                }
            }
        }

        private void bHState_Change(object sender, VariableEventArgs e)
        {
            switch ((byte)e.Value)
            {
                case 0:
                    bhMode.LocalizableText = "@Lists.BH.Text1";
                    bhMode.Tag = (byte)3;
                    break;
                case 1:
                    bhMode.LocalizableText = "@Lists.BH.Text2";
                    bhMode.Tag = (byte)1;
                    break;
                case 2:
                    bhMode.LocalizableText = "@Lists.BH.Text3";
                    bhMode.Tag = (byte)1;
                    break;
                case 3:
                    bhMode.LocalizableText = "@Lists.BH.Text4";
                    bhMode.Tag = (byte)1;
                    break;
                case 4:
                    bhMode.LocalizableText = "@Lists.BH.Text5";
                    bhMode.Tag = (byte)2;
                    break;
                case 5:
                    bhMode.LocalizableText = "@Lists.BH.Text6";
                    bhMode.Tag = (byte)1;
                    break;
                default: break;
            }
        }
        private void GridClear()
        {
            for (int i = B.Children.Count - 1; i >= 0; i--)
            {
                B.Children.RemoveAt(i);
            }
        }
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            new ObjectAnimator().ShowMOElement(this);
        }
       
        #region - - - Status - - -
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            new SP
            {
                CPU = "CPU1",
                Station = 5,
                Header = "@Status.Text30",
                Type = "Basket"
            }.Open();

        }
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            new SP
            {
                CPU = "CPU1",
                Station = 4,
                Header = "@Status.Text25",
                Type = "Basket"
            }.Open();
        }

    

        #endregion
     
        private MVBasket GetBasket(string Basket, Thickness margin, int ManiPos) 
        {

            MVBasket temp = new MVBasket() 
            {
                CPU = "CPU1",
                Station = 5,
                Header = "@Status.Text30",
                Type = "Basket"
            };

            switch (Basket)
            {
                case "L":
                    temp.IsBasket = "CPU1.PLC.Blocks.02 Basket handling.02 BM.00 Main.DB BM PD.Baskets.Available";
                    temp.IsMaterial = "CPU1.PLC.Blocks.02 Basket handling.02 BM.00 Main.DB BM PD.Charge.Available";
                    temp.SetLayer = "CPU1.PLC.Blocks.02 Basket handling.02 BM.00 Main.DB BM PD.Charge.Layer[0].Set";
                    temp.ActualLayer = "CPU1.PLC.Blocks.02 Basket handling.02 BM.00 Main.DB BM PD.Charge.Layer[0].Actual";
                    temp.AS = "Set";
                    if (ManiPos >= 0 && ManiPos <= 2 || ManiPos == 4)
                    {
                        temp.IsDischarge = "CPU1.PLC.Blocks.02 Basket handling.02 BM.00 Main.DB BM PD.Baskets.Functions.Discharge";
                        temp.IsWatch = "CPU1.PLC.Blocks.02 Basket handling.02 BM.00 Main.DB BM PD.Baskets.Functions.Watch";
                        temp.IsCheck = "CPU1.PLC.Blocks.02 Basket handling.02 BM.00 Main.DB BM PD.Baskets.Functions.Check";
                    }
                    break;
                case "R":
                    temp.IsBasket = "CPU1.PLC.Blocks.02 Basket handling.02 BM.00 Main.DB BM PD.Baskets.Available";
                    temp.IsMaterial = "CPU1.PLC.Blocks.02 Basket handling.02 BM.00 Main.DB BM PD.Charge.Available";
                    temp.SetLayer = "CPU1.PLC.Blocks.02 Basket handling.02 BM.00 Main.DB BM PD.Charge.Layer[0].Set";
                    temp.ActualLayer = "CPU1.PLC.Blocks.02 Basket handling.02 BM.00 Main.DB BM PD.Charge.Layer[0].Actual";
                    temp.AS = "Actual";
                    if (ManiPos >= 3 && ManiPos <= 7 && ManiPos != 4)
                    {
                        temp.IsDischarge = "CPU1.PLC.Blocks.02 Basket handling.02 BM.00 Main.DB BM PD.Baskets.Functions.Discharge";
                        temp.IsWatch = "CPU1.PLC.Blocks.02 Basket handling.02 BM.00 Main.DB BM PD.Baskets.Functions.Watch";
                        temp.IsCheck = "CPU1.PLC.Blocks.02 Basket handling.02 BM.00 Main.DB BM PD.Baskets.Functions.Check";
                    }
                    break;
            }

            temp.VerticalAlignment = VerticalAlignment.Top;
            temp.HorizontalAlignment = HorizontalAlignment.Left;
            temp.Margin = margin;
            return temp;
        }

      
    }
}
