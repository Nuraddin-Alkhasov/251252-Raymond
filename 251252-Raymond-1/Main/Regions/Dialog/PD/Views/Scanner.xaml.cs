using System.Windows;
using HMI.CO.General;
using HMI.Interfaces.PD;
using VisiWin.ApplicationFramework;


namespace HMI.DialogRegion.PD.Views
{
    /// <summary>
    /// Interaction logic for UserAdd.xaml
    /// </summary>
    [ExportView("Scanner")]
    public partial class Scanner
    {
        IS IBSService = ApplicationService.GetService<IS>();

        public Scanner()
        {
            InitializeComponent();

        }

        private void Border_Loaded(object sender, RoutedEventArgs e)
        {
            new ObjectAnimator().OpenDialog(this, border);

        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            new ObjectAnimator().CloseDialog1(this, border);
        }
        private void OpenConnection_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            IBSService.OpenConnection();

        }

        private void CloseConnection_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            IBSService.CloseConnection();

        }


        private void UpdateStatus_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            status.Value = IBSService.GetStatus();
        }

        private void View_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            ApplicationService.SetVariableValue("Main.Barcode", "");

        }
    }
}