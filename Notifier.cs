using System;
using System.Configuration;
using System.ServiceProcess;

namespace NotificationService
{
    public partial class Notifier : ServiceBase
    {
        private readonly System.Timers.Timer timer = null;

        public Notifier()
        {
            InitializeComponent();

            timer = new System.Timers.Timer();
            timer.Elapsed += new System.Timers.ElapsedEventHandler(timer_Elapsed);
            timer.Interval = 10000;
            timer.Enabled = false;

        }

        /// <summary>
        /// This class is used for debugging purpose, so we can call it to start the service code during debugging
        /// </summary>
        public void StartService()
        {
            OnStart(null);
        }

        /// <summary>
        /// This class is used for debugging purpose, so we can call it to stop the service code during debugging
        /// </summary>
        public void StopService()
        {
            OnStop();
        }

        /// <summary>
        /// This class is used for debugging purpose, so we can call it to stop the service code during debugging
        /// </summary>
        public void ShutdownService()
        {
            OnShutdown();
        }


        protected override void OnStart(string[] args)
        {
            int interval = Convert.ToInt32(ConfigurationManager.AppSettings["NotificationInterval"]);

            timer.Enabled = true;
            timer.Interval = interval;
            timer.Start();
            Console.WriteLine("Service started.");
        }

        protected override void OnStop()
        {
            timer.Stop();
            Console.WriteLine("Service stopped.");
        }

        protected override void OnShutdown()
        {
            timer.Stop();
            timer.Dispose();
            Console.WriteLine("Service shutdown.");
        }

        private void SendNotification()
        {
            // Do the work here
            Console.WriteLine("SendNotification called.");
        }

        private void timer_Elapsed(Object sender, System.Timers.ElapsedEventArgs e)
        {
            try
            {
                //stop timer.
                timer.Stop();

                SendNotification();
            }
            catch (Exception ex)
            {
                // Log the error
                Console.WriteLine(ex.Message);
            }
            finally
            {
                // Start timer again.
                timer.Start();
            }
        }
    }
}
