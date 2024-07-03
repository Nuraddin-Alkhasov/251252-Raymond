using System;
using System.Windows;
using System.Windows.Controls;
using VisiWin.Controls;
using VisiWin.ApplicationFramework;
using HMI.CO.General;
using VisiWin.Language;

namespace HMI.TouchpadRegion
{
    [ExportView("NumericTouchpadView")]
    public partial class NumericTouchpadView
    {
        internal const string CHANNELNAME_TOUCHTARGET = "vw:TouchTarget";
        public NumericTouchpadView() { InitializeComponent(); this.Loaded += new RoutedEventHandler(View_Loaded); }

        private void View_Loaded(object sender, RoutedEventArgs e)
        {
            
            if (ApplicationService.ObjectStore.ContainsKey(CHANNELNAME_TOUCHTARGET))
            {
                numericVarIn = ApplicationService.ObjectStore.GetValue(CHANNELNAME_TOUCHTARGET) as NumericVarIn;
               
                if (numericVarIn != null)
                {
                    lblNumericPadDescription.Text = numericVarIn.LabelText;
                }
                ApplicationService.ObjectStore.Remove(CHANNELNAME_TOUCHTARGET);

            }
            new ObjectAnimator().OpenKeyboard(this, border);
            ILanguageService languageService = ApplicationService.GetService<ILanguageService>();
            switch (languageService.CurrentLanguage.LCID)
            {
                case 3081: touchkeyboard1.Style = (Style)FindResource("NumericTouchKeyboardEN");  break;
                case 1031: touchkeyboard1.Style = (Style)FindResource("NumericTouchKeyboard"); break;
                case 2058: touchkeyboard1.Style = (Style)FindResource("NumericTouchKeyboardEN"); break;
                case 1033: touchkeyboard1.Style = (Style)FindResource("NumericTouchKeyboardEN"); break;
            }

        }
        private void TouchKeyboard_Close(object sender, RoutedEventArgs e)
        {
            if (numericVarIn != null)
                if (numericVarIn.Value < numericVarIn.LimitMin || numericVarIn.Value > numericVarIn.LimitMax)
                {
                    var rand = new Random();
                    var temp = numericVarIn.Value;
                    numericVarIn.Value = rand.Next((int)numericVarIn.LimitMin, (numericVarIn.LimitMax < numericVarIn.LimitMin) ? (int)numericVarIn.LimitMin : (int)numericVarIn.LimitMax);
                    numericVarIn.Value = temp;
                }
            new ObjectAnimator().CloseKeyboard(this, border);
        }
    }
}