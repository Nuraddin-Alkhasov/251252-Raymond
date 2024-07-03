using VisiWin.Adapter;
using VisiWin.ApplicationFramework;

namespace HMI.DialogRegion.UM.Views
{
    /// <summary>
    /// Interaction logic for UserAdd.xaml
    /// </summary>
    [ExportView("UM_AddChangeGroup")]
    public partial class UM_AddChangeGroup
    {
        public UM_AddChangeGroup()
        {
            InitializeComponent();
            DataContext = ApplicationService.GetAdapter("UM_AddChangeGroup");
        }

        private void CheckBox_Checked(object sender, System.Windows.RoutedEventArgs e)
        {
           
            if (((VisiWin.Adapter.UserRightDataClass)((VisiWin.Controls.CheckBox)e.Source).DataContext).Right == "MOPOperator") 
            {
                foreach (UserRightDataClass r in rList.Items)
                {
                    if (r.Right == "MOPAdministrator") { r.On = false; }
                }
            }
            if (((VisiWin.Adapter.UserRightDataClass)((VisiWin.Controls.CheckBox)e.Source).DataContext).Right == "MOPAdministrator")
            {
                foreach (UserRightDataClass r in rList.Items)
                {
                    if (r.Right == "MOPOperator") { r.On = false; }
                }
            }
        }
    }
}