using GamerDashBoard;
using System;
using System.Windows.Forms;
using System.Collections.ObjectModel;
using System.Management.Automation;
using System.IO;
using System.Management.Automation.Runspaces;
using GamerDashBoard.Util;

namespace GamerDashBoard
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {


            GDBLogger.logger.Info("Starting GamerDashBoard Server");

            
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
