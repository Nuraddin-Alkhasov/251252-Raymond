using HMI.CO.General;
using HMI.CO.Trend;
using System;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Animation;
using VisiWin.ApplicationFramework;
using VisiWin.Controls;
using VisiWin.DataAccess;
using VisiWin.Language;

namespace HMI.MainRegion.MO.Views
{

    [ExportView("M1_CD")]
    public partial class M1_CD
    {
       
        public M1_CD()
        {
            InitializeComponent();

            DTPosition = VS.GetVariable("CPU1.PLC.Blocks.03 Basket coating.02 DT.01 Lift.DB DT Lift HMI.Actual.Drive.Position");
            DTPosition.Change += DTPosition_Change;
            IsDT = VS.GetVariable("CPU1.PLC.Blocks.03 Basket coating.02 DT.00 Main.DB DT PD.Tank.Available");
            IsDT.Change += IsDT_Change;
            VC = VS.GetVariable("CPU1.PLC.Blocks.03 Basket coating.02 DT.00 Main.DB DT HMI.Actual.Viscosity.Expired");
            VC.Change += VC_Change;
            Paint = VS.GetVariable("CPU1.PLC.Blocks.03 Basket coating.02 DT.00 Main.DB DT PD.Header.Paint");
            Paint.Change += Paint_Change;
            
            languageService.LanguageChanged += LanguageService_LanguageChanged;
            LanguageService_LanguageChanged(null, null);
        }

        #region - - - Properties - - - 
        private readonly ILanguageService languageService = ApplicationService.GetService<ILanguageService>();
        readonly IVariableService VS = ApplicationService.GetService<IVariableService>();
        readonly IVariable DTPosition;
        readonly IVariable IsDT;
        IVariable StepType;
        readonly IVariable VC;
        readonly IVariable Paint;

        double Oldpos = 0;

        #endregion

        #region - - - Event Handlers - - -
        private void IsDT_Change(object sender, VariableEventArgs e)
        {
            if (e.Quality.Data == DataQuality.Good) 
            {
                if ((bool)e.Value)
                {
                    new ObjectAnimator().ShowUIElement(LTB);
                   
                }
                else
                {
                    new ObjectAnimator().HideUIElement(LTB);
                }
            }
           
        }
        private void DTPosition_Change(object sender, VariableEventArgs e)
        {
            double pos = Math.Round(((float)e.Value) * 0.2208);

            if (Oldpos != pos)
            {
               
                LTB.Margin = new Thickness(746, 0, 0, pos + 34);
                Oldpos = pos;
            }
        }
        private void CoatingStep_Change(object sender, VariableEventArgs e)
        {
            if (e.Quality.Data == DataQuality.Good)
            {
                object content;
                switch ((byte)e.Value)
                {
                    case 1: content = new M1_CD_Dip(); break;
                    case 2: content = new M1_CD_Spin(); break;
                    default: content = null; break;
                }
                Dispatcher.InvokeAsync((Action)delegate
                {
                    region.Content = content;
                });
            }

        }
        private void VC_Change(object sender, VariableEventArgs e)
        {
            if (e.Quality.Data == DataQuality.Good)
            {
                if ((bool)e.Value)
                {
                    vgroup.IsBlinkEnabled = true;
                    vgroup.LocalizableHeaderText = "@MachineOverview.Text52";
                }
                else
                {
                    vgroup.LocalizableHeaderText = "@MachineOverview.Text51";
                    vgroup.IsBlinkEnabled = false;
                }
            }
        }
        private void Paint_Change(object sender, VariableEventArgs e)
        {
            if (e.Quality.Data == DataQuality.Good)
            {

                PaintTyp.Value = GetPaintTypes().ToList().Where(x => x.Value == e.Value.ToString()).First().Text;

            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ApplicationService.SetView("MainRegion", "Trend",
            new TrendData()
            {
                ArchiveName = "M1DT",
                TrendName_1 = "AV",
                CurveTag_1 = "@TrendSystem.Text1",
                TrendName_2 = "SV",
                CurveTag_2 = "@TrendSystem.Text2",
                Header = "@TrendSystem.Text3",
                Min = 0,
                Max = 50,
                BackViewName = "M1_CD"
            });

        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            new SP
            {
                CPU= "CPU1",
                Station = 10,
                Header = "@Status.Text38",
                Type = "Basket"
            }.Open();
        }


        private void Region_Loaded(object sender, RoutedEventArgs e)
        {
            StepType = VS.GetVariable("CPU1.PLC.Blocks.03 Basket coating.01 CD.00 Main.Program.DB Program control.Set.Data.Type");
            StepType.Change += CoatingStep_Change;
        }
        #endregion

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            ApplicationService.SetView("DialogRegion1", "M1_Coating_DT");
            
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            ApplicationService.SetView("DialogRegion1", "M1_Coating_VC");
        }

        private void LanguageService_LanguageChanged(object sender, LanguageChangedEventArgs e)
        {

            switch (languageService.CurrentLanguage.LCID)
            {
                case 1033:
                    //DT.RawLimitMin = 32;
                    //DT.RawLimitMax = 122;
                    DTL1.StartValue = 32;
                    DTL1.EndValue = 68;
                    DTL2.StartValue = 68;
                    DTL2.EndValue = 86;
                    DTL3.StartValue = 86;
                    DTL3.EndValue = 122;
                    break;

                default:
                    //DT.RawLimitMin = 0;
                    //DT.RawLimitMax = 50;
                    DTL1.StartValue = 0;
                    DTL1.EndValue = 20;
                    DTL2.StartValue = 20;
                    DTL2.EndValue = 30;
                    DTL3.StartValue = 30;
                    DTL3.EndValue = 50;
                    break;
            }
        }
        
        private StateCollection GetPaintTypes()
        {
            StateCollection Temp_SC = new StateCollection
            {
                new State()
                {
                    Text = " - - - ",
                    Value = "0"
                }
            };
            DataTable DT = new MSSQLEAdapter("Recipes", "SELECT *  FROM Recipes_Paint; ").DB_Output();
            foreach (DataRow r in DT.Rows)
                if (DT.Rows.Count > 0)
                {
                    Temp_SC.Add(new State()
                    {
                        Text = (string)r["Name"],
                        Value = r["Id"].ToString()
                    });
                }
            return Temp_SC;
        }
    }
}



