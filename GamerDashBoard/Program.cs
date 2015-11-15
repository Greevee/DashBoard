using GamerDashBoard;
using System;
using System.Windows.Forms;
using System.Collections.ObjectModel;
using System.Management.Automation;
using System.IO;
using System.Management.Automation.Runspaces;

namespace GamerDashBoard
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            try
            {
                RunPsScript("openPort13337.ps1");
            }
            catch(Exception e)
            {

            }
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

        static Collection<PSObject> RunPsScript(string psScriptPath)
        {
            string psScript = string.Empty;
            if (File.Exists(psScriptPath))
                psScript = File.ReadAllText(psScriptPath);
            else
                throw new FileNotFoundException("Wrong path for the script file");

            Runspace runSpace = RunspaceFactory.CreateRunspace();
            runSpace.Open();

            RunspaceInvoke runSpaceInvoker = new RunspaceInvoke(runSpace);
            runSpaceInvoker.Invoke("Set-ExecutionPolicy Unrestricted");

            Pipeline pipeLine = runSpace.CreatePipeline();
            pipeLine.Commands.AddScript(psScript);
            pipeLine.Commands.Add("Out-String");

            Collection<PSObject> returnObjects = pipeLine.Invoke();
            runSpace.Close();

            return returnObjects;
        }
    }
}
