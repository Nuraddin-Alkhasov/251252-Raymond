using VisiWin.ApplicationFramework;

namespace HMI.HeaderRegion.Views
{
    [ExportView("Header")]
    public partial class Header
    {
        public Header()
        {
            InitializeComponent();
            DataContext = new Adapters.Header();
        }
    }
}