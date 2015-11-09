using RainbowDashBoard;
using System;
using System.Windows.Forms;

namespace RainbowDashBoard
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            Server gdbServer = new Server();
            gdbServer.startServer();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Show the system tray icon.					
            using (SysTrayApp pi = new SysTrayApp(gdbServer))
            {
                pi.Display();

                // Make sure the application runs!
                Application.Run();
            }


        }
    }
}
