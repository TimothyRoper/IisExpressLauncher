using System;
using System.Diagnostics;
using System.IO;

namespace IisExpressWebServer
{
    public class IisExpress
    {
        private Process _process;
        private readonly WebApplication _application;

        public IisExpress(WebApplication application)
        {
            Argument.CheckIfNull(application,"WebApplication");
            _application = application;
        }

        public void Start(bool useShellExecute = false)
        {
            var info = GetProcessStartInfo(_application.Location.FullPath, _application.PortNumber, useShellExecute);
            _process = Process.Start(info);  
        }

        /// <summary>
        /// Stops this instance.
        /// </summary>
        public void Stop()
        {
            if (!_process.HasExited) _process.Kill();
            _process.Dispose();
        }

        private ProcessStartInfo GetProcessStartInfo(string applicationPath, int port, bool useShellExecute)
        {
            var iisPath = GetExePath();
            return new ProcessStartInfo
            {
                WindowStyle = ProcessWindowStyle.Normal,
                ErrorDialog = true,
                LoadUserProfile = true,
                CreateNoWindow = false,
                UseShellExecute = useShellExecute,
                Arguments = String.Format("/path:\"{0}\" /port:{1}", applicationPath, port),
                FileName = iisPath
            };
        }

        private string GetExePath()
        {
            var key = Environment.Is64BitOperatingSystem ? "programfiles(x86)" : "programfiles";
            var programfiles = Environment.GetEnvironmentVariable(key);

            //check file exists
            var iisPath = string.Format("{0}\\IIS Express\\iisexpress.exe", programfiles);
            if (!File.Exists(iisPath))
            {
                throw new ArgumentException("IIS Express executable not found", iisPath);
            }
            return iisPath;
        }
    }
}
