using System;
using System.IO;
using System.ServiceProcess;
using System.Threading;
using System.Timers;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Timer = System.Timers.Timer;
//using Timer = System.Threading.Timer;



namespace APIService
{
    public partial class Service1 : ServiceBase
    {
        Timer Timer = new Timer();
        int Interval = 10000;

        public Service1()
        {
            InitializeComponent();
            this.CanStop = true;
            this.CanPauseAndContinue = true;
            this.AutoLog = true;
        }

        protected override void OnStart(string[] args)
        {
            WriteLog("Service has been started");
            Timer.Elapsed += new ElapsedEventHandler(OnElapsedTime);
            Timer.Interval = Interval;
            Timer.Enabled = true;
        }

        private void OnElapsedTime(object source, ElapsedEventArgs e)
        {
            WriteLog(String.Format("{0} ms elapsed.", Interval));
        }


        protected override void OnStop()
        {
            Timer.Stop();
            WriteLog("Service has been stopped.");
        }


        public void WriteLog(string logMessage, bool addTimeStamp = true)
        {
            //var path = AppDomain.CurrentDomain.BaseDirectory;
            var path = "C:\\SunRisesAndSets\\data.txt";
            //if (!Directory.Exists(path))
            //    Directory.CreateDirectory(path);

            var filePath = String.Format("{0}\\{1}_{2}.txt",
                path,
                ServiceName,
                DateTime.Now.ToString("yyyyMMdd", CultureInfo.CurrentCulture)
                );

            if (addTimeStamp)
                logMessage = String.Format("[{0}] - {1}\r\n",
                    DateTime.Now.ToString("HH:mm:ss", CultureInfo.CurrentCulture),
                    logMessage);

            File.AppendAllText(filePath, logMessage);
        }

    }

}
