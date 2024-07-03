using System;
using VisiWin.ApplicationFramework;
using OposScanner_CCO;
using System.Threading.Tasks;
using HMI.CO.General;
using HMI.Resources;

namespace HMI.CO.PD
{
    public class Scanner
    {
       
        public Scanner() 
        {
          
        }

        #region - - - Properties - - -

        OPOSScanner mScanner;
        private readonly string Device = "Honeywell";
        private readonly int WatchDog = 5000;
        private readonly IRegionService iRS = ApplicationService.GetService<IRegionService>();
        Barcode Barcode = new Barcode("");
        #endregion

        #region - - - Event Handlers - - -
        private void DataEvent(int status)
        {
            mScanner.DataEventEnabled = true;
            DialogRegion.MO.Views.M1_DataPicker v1 = (DialogRegion.MO.Views.M1_DataPicker)iRS.GetView("M1_DataPicker");
            DialogRegion.PD.Views.Scanner v2 = (DialogRegion.PD.Views.Scanner)iRS.GetView("Scanner");
            if (v1.Visibility == System.Windows.Visibility.Visible || v2.Visibility == System.Windows.Visibility.Visible)
            {
                ApplicationService.SetVariableValue("Main.Barcode", mScanner.ScanData.ToString());
            }
            else 
            {
                ApplicationService.SetVariableValue("Main.Barcode", "");
            }
        }

        #endregion

        #region - - - Methods - - -
        public string GetStatus()
        {
            if (mScanner != null)
            {
                try
                {
                    return mScanner.State.ToString();
                }
                catch (Exception e)
                {
                    new MessageBoxTask(e, "", MessageBoxIcon.Error);
                    return "Exception";
                }
            }
            else { return "Null"; }
            

        }
        public void OpenConnection()
        {
            mScanner = new OPOSScanner();
            mScanner.DataEvent += new _IOPOSScannerEvents_DataEventEventHandler(DataEvent);
            Task obTask = Task.Run(async () =>
            {
                await Task.Delay(4000);
                try
                {
                    if (mScanner != null) 
                    {
                        if (mScanner.State == 1)
                        {
                            mScanner.Open(Device);
                        }

                        if (mScanner.Claimed == false)
                        {
                            mScanner.ClaimDevice(WatchDog);
                        }

                        if (mScanner.DeviceEnabled == false)
                        {
                            mScanner.DeviceEnabled = true;
                        }

                        mScanner.DataEventEnabled = true;
                    }
                }
                catch (Exception e)
                {
                    new MessageBoxTask(e, "", MessageBoxIcon.Error);
                }
            });
        }
        public void CloseConnection()
        {
            if (mScanner != null)
            {
                try
                {
                    mScanner.DataEvent -= DataEvent;
                }
                catch (Exception e)
                {
                    new MessageBoxTask(e, "", MessageBoxIcon.Error);
                }

                Task obTask = Task.Run(() =>
                {
                    try
                    {
                        if (mScanner.DeviceEnabled == true)
                        {
                            mScanner.DeviceEnabled = false;
                        }

                        mScanner.DataEventEnabled = false;
                        
                        if (mScanner.Claimed == true)
                        {
                            mScanner.ReleaseDevice();
                        }
                        
                        if (mScanner.State == 2)
                        {
                            mScanner.Close();
                        }

                        mScanner = null;
                    }
                    catch (Exception e)
                    {
                        new MessageBoxTask(e, "", MessageBoxIcon.Error);
                    }
                });
            }
               
        }

        #endregion

    }
}
