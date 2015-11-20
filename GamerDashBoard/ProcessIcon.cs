using System;
using System.Diagnostics;
using System.Windows.Forms;
using GamerDashBoard.Properties;
using GamerDashBoard.Forms;


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
            ni.BalloonTipTitle = "GamerDashBoardStarted";
            ni.BalloonTipText = "Click on the icon to get instructions";
            ni.BalloonTipClicked += new EventHandler(notifyIcon_BalloonTipClicked);

            ni.ShowBalloonTip(5);

            ni.ContextMenuStrip = new ContextMenus(server).Create();
		}

        private void notifyIcon_BalloonTipClicked(object sender, EventArgs e)
        {
           
                new Instructions(server).ShowDialog();


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
                new Instructions(server).ShowDialog();

            }
		}
	}
}