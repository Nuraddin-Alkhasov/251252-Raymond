using HMI.CO.PD;
using HMI.Interfaces.PD;
using System.ComponentModel.Composition;
using VisiWin.ApplicationFramework;


namespace HMI.Services.PD
{
    [ExportService(typeof(IS))]
    [Export(typeof(IS))]
    public class Service_BarcodeScanner : ServiceBase, IS
    {

        Scanner BS;

        public Service_BarcodeScanner()
        {
            if (ApplicationService.IsInDesignMode)
                return;
        }



        #region OnProject

        // Hier stehen noch keine VisiWin Funktionen zur Verfügung
        protected override void OnLoadProjectStarted()
        {
            base.OnLoadProjectStarted();
        }

        // Hier kann auf die VisiWin Funktionen zugegriffen werden
        protected override void OnLoadProjectCompleted()
        {
            BS = new Scanner(); ;
            BS.OpenConnection();

            base.OnLoadProjectCompleted();
        }



        // Hier stehen noch die VisiWin Funktionen zur Verfügung
        protected override void OnUnloadProjectStarted()
        {
            if (BS != null)
                BS.CloseConnection();
            base.OnUnloadProjectStarted();
        }

        // Hier sind keine VisiWin Funktionen mehr verfügbar. Bei C/S ist die Verbindung zum Server schon getrennt.
        protected override void OnUnloadProjectCompleted()
        {
            base.OnUnloadProjectCompleted();
        }

        public void OpenConnection()
        {
            if (BS != null)
                BS.OpenConnection();
        }

        public void CloseConnection()
        {
            if (BS != null)
                BS.CloseConnection();
        }

        public string GetStatus()
        {
            if (BS != null)
                return BS.GetStatus();
            else
                return "";
        }





        #endregion

    }
}
