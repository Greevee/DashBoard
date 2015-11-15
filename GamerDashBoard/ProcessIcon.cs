using System;
using System.Diagnostics;
using System.Windows.Forms;
using GamerDashBoard.Properties;

namespace GamerDashBoard
{

	class SysTrayApp : IDisposable
	{

		NotifyIcon ni;
        Server server;


		public SysTrayApp(Server server)
		{
			ni = new NotifyIcon();
            this.server = server;
		}

		public void Display()
		{
			// Put the icon in the system tray and allow it react to mouse clicks.			
			ni.MouseClick += new MouseEventHandler(ni_MouseClick);
			ni.Icon = Resources.favicon;
			ni.Text = "GamerDashBoard";
			ni.Visible = true;

			ni.ContextMenuStrip = new ContextMenus(server).Create();
		}

		public void Dispose()
		{
			// When the application closes, this will remove the icon from the system tray immediately.
			ni.Dispose();
		}

		void ni_MouseClick(object sender, MouseEventArgs e)
		{
			// Handle mouse button clicks.
			if (e.Button == MouseButtons.Left)
			{
                System.Diagnostics.Process.Start("http://localhost:13337");
            }
		}
	}
}