using System;

namespace NotificationService
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main()
        {
#if DEBUG
            var notifier = new Notifier(); // Create object of your Service's class.
            while (true)
            {
                var key = Convert.ToChar(Console.Read());
                if (key == 's' || key == 'S')
                {
                    notifier.StartService(); // Call the public StartService() method.
                }
                else if (key == 't' || key == 'T')
                {
                    notifier.StopService(); // Call the public StopService() method.
                }
                else if (key == 'e' || key == 'E')
                {
                    notifier.ShutdownService(); // Call the public ShutdownService() method.
                    break;
                }
            }
#else
            // Normal code to start your service
            var servicesToRun = new ServiceBase[]
            {
                new Notifier()
            };
            ServiceBase.Run(servicesToRun);
#endif
        }
    }
}
