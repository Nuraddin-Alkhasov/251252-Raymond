﻿using HMI.CO.General;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using VisiWin.ApplicationFramework;
using VisiWin.DataAccess;

namespace HMI.Resources.UserControls.MO
{
    public partial class LDBasket : UserControl
    {
        public LDBasket()
        {

            if (ApplicationService.IsInDesignMode)
            {
                return;
            }
            InitializeComponent();
        }

        private readonly IVariableService VS = ApplicationService.GetService<IVariableService>();
        private IVariable isBasket;
        public string IsBasket
        {
             get { return ""; } 
            set
            {
                if (VS.IsExistingVariable(value))
                {
                    isBasket = VS.GetVariable(value);
                    isBasket.Change += IsBasket_ValueChanged;
                }
            }
        }

        private void IsBasket_ValueChanged(object sender, VariableEventArgs e)
        {
            if (e.Quality.Data == DataQuality.Good)
            {
                if ((bool)e.Value)
                {
                    new ObjectAnimator().ShowMOElement(A);
                }
                else
                {
                    new ObjectAnimator().HideMOElement(A);
                }
            }

        }

        private IVariable isMaterial;
        public string IsMaterial
        {
             get { return ""; } 
            set
            {
                if (VS.IsExistingVariable(value))
                {
                    isMaterial = VS.GetVariable(value);
                    isMaterial.Change += IsMaterial_ValueChanged;
                }
            }
        }

        private void IsMaterial_ValueChanged(object sender, VariableEventArgs e)
        {
            if (e.Quality.Data == DataQuality.Good)
            {
                if ((bool)e.Value)
                {
                    new ObjectAnimator().ShowMOElement(ismaterial);
                }
                else
                {
                    new ObjectAnimator().HideMOElement(ismaterial);
                }
            }
        }
        IVariable isDischarge;
        public string IsDischarge
        {
             get { return ""; } 
            set
            {
                if (VS.IsExistingVariable(value))
                {
                    isDischarge = VS.GetVariable(value);
                    isDischarge.Change += IsDischarge_ValueChanged;
                }
            }
        }

        private void IsDischarge_ValueChanged(object sender, VariableEventArgs e)
        {
            if (e.Quality.Data == DataQuality.Good)
            {
                if ((bool)e.Value)
                {
                    new ObjectAnimator().ShowMOElement(discharge);
                }
                else
                {
                    new ObjectAnimator().HideMOElement(discharge);
                }
            }
        }

        IVariable isWatch;
        public string IsWatch
        {
            get { return ""; }
            set
            {
                if (VS.IsExistingVariable(value))
                {
                    isWatch = VS.GetVariable(value);
                    isWatch.Change += IsWatch_ValueChanged;
                }
            }
        }

        private void IsWatch_ValueChanged(object sender, VariableEventArgs e)
        {
            if (e.Quality.Data == DataQuality.Good)
            {
                if ((bool)e.Value)
                {
                    new ObjectAnimator().ShowMOElement(watch);
                }
                else
                {
                    new ObjectAnimator().HideMOElement(watch);
                }
            }
        }
        IVariable isCheck;
        public string IsCheck
        {
            get { return ""; }
            set
            {
                if (VS.IsExistingVariable(value))
                {
                    isCheck = VS.GetVariable(value);
                    isCheck.Change += IsCheck_ValueChanged;
                }
            }
        }

        private void IsCheck_ValueChanged(object sender, VariableEventArgs e)
        {
            if (e.Quality.Data == DataQuality.Good)
            {
                if ((bool)e.Value)
                {
                    new ObjectAnimator().ShowMOElement(check);
                }
                else
                {
                    new ObjectAnimator().HideMOElement(check);
                }
            }
        }
        public string AS
        {
            get { return ""; }
            set
            {

                if (value == "Set") { ismaterial.VariableName = IVSetLayer.Name; }

                if (value == "Actual") { { ismaterial.VariableName = IVActualLayer.Name; } }
            }
        }

        IVariable IVActualLayer;
        public string ActualLayer
        {
            get { return ""; }
            set
            {
                if (VS.IsExistingVariable(value))
                {
                    IVActualLayer = VS.GetVariable(value);
                    IVActualLayer.Change += IVActualLayer_Change;
                }
            }
        }

        private void IVActualLayer_Change(object sender, VariableEventArgs e)
        {
            if (e.Quality.Data == DataQuality.Good)
            {
                if ((byte)e.Value == 0)
                {
                    ismaterial.Background = new SolidColorBrush(Colors.White);
                }
                if ((byte)e.Value == (byte)IVSetLayer.Value && (byte)IVSetLayer.Value != 0)
                {
                    ismaterial.Background = (Brush)Application.Current.FindResource("FP_Green_Gradient");
                }
                if ((byte)e.Value != (byte)IVSetLayer.Value && (byte)e.Value != 0)
                {
                    ismaterial.Background = (Brush)Application.Current.FindResource("FP_Yellow_Gradient");
                }
            }
        }

        IVariable IVSetLayer;
        public string SetLayer
        {
            get { return ""; }
            set
            {
                if (VS.IsExistingVariable(value))
                {
                    IVSetLayer = VS.GetVariable(value);
                }
            }
        }

        public override string ToString() { return "Basket"; }

        #region - - - Status - - -
        public int Station { set; get; } = 0;
        public string Header { set; get; } = "";
        public string Type { set; get; } = "";
        public string CPU { set; get; } = "";
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            new SP
            {
                CPU = CPU,
                Station = Station,
                Header = Header,
                Type = Type
            }.Open();
        }
        #endregion
    }



}
