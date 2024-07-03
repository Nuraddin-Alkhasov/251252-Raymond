using System;
using System.Threading.Tasks;
using HMI.CO.General;
using HMI.Resources;
using System.Diagnostics;
using System.Linq;

namespace HMI.CO.PD
{
    public class Camera
    {
       
        public Camera() 
        {

        }

        #region - - - Properties - - -

        static Process Stream = new Process();
        public string FileName { set; get; } = "";
        public string Path { set; get; } = "";
        public string Arguments { set; get; } = "";
        public string MainWindowTitle { set; get; } = "";

        #endregion

        #region - - - Event Handlers - - -

        #endregion

        #region - - - Methods - - -

        public async Task Kill()
        {
            int i = 0;

            try
            {
                Stream = Process.GetProcessesByName(FileName).FirstOrDefault();
                if (Stream != null)
                {
                    Stream.Kill();

                    while (Stream.HasExited != true && i < 100)
                    {
                        await Task.Delay(50);
                        Stream.Refresh();
                        i++;
                        if (i >= 100)
                        {
                            throw new Exception("Killing of the process time out.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                new MessageBoxTask(ex, "", MessageBoxIcon.Error);
            }
        }

        public async Task Start()
        {
            int i = 0;

            await Kill();

            try
            {
                Stream = new Process();
                Stream.StartInfo.FileName = Path + FileName;
                Stream.StartInfo.Arguments = Arguments;
                Stream.StartInfo.RedirectStandardOutput = true;
                Stream.StartInfo.RedirectStandardError = true;
                Stream.StartInfo.UseShellExecute = false;
                Stream.StartInfo.CreateNoWindow = true;
                Stream.EnableRaisingEvents = true;
                Stream.Start();

               // Stream.WaitForInputIdle();
                i = 0;
                while (Stream.MainWindowTitle != MainWindowTitle && i < 100)
                {
                    await Task.Delay(50);
                    Stream.Refresh();
                    i++;
                    if (i >= 100)
                    {
                        throw new Exception("Starting of the process time out.");
                    }
                }
               // await Task.Delay(5000);
            }
            catch (Exception ex)
            {
                new MessageBoxTask(ex, "", MessageBoxIcon.Error);
            }
        }

        public HwndHostEx GetHost() 
        {
            var handle = Stream?.MainWindowHandle;
            if (handle != null)
            {
                return new HwndHostEx(handle.Value);
            }
            else { return null; }

        }

        #endregion

    }
}
