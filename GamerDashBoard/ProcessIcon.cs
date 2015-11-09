using System;
using System.Diagnostics;
using System.Windows.Forms;
using RainbowDashBoard.Properties;

namespace RainbowDashBoard
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
			ni.Text = "RainbowDashBoard";
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

			}
		}
	}
}