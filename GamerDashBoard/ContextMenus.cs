using System;
using System.Windows.Forms;
using GamerDashBoard.Forms;
using GamerDashBoard.Properties;


namespace GamerDashBoard
{

    class ContextMenus
	{

        bool isAboutLoaded = false;
        bool isSettingsLoaded = false;
        private Server server;

        public ContextMenus(Server server)
        {
            this.server = server;
        }

        public ContextMenuStrip Create()
		{
			// Add the default menu options.
			ContextMenuStrip menu = new ContextMenuStrip();
			ToolStripMenuItem item;
			ToolStripSeparator sep;

            // Settings.
            item = new ToolStripMenuItem();
            item.Text = "Settings";
            item.Click += new EventHandler(Settings_Click);
            item.Image = Resources.settings;
            menu.Items.Add(item);



			// Separator.
			sep = new ToolStripSeparator();
			menu.Items.Add(sep);

			// Exit.
			item = new ToolStripMenuItem();
			item.Text = "Exit";
			item.Click += new System.EventHandler(Exit_Click);
			item.Image = Resources.exit;
			menu.Items.Add(item);

			return menu;
		}

        void Settings_Click(object sender, EventArgs e)
        {
            if (!isSettingsLoaded)
            {
                isSettingsLoaded = true;
                new Settings(server).ShowDialog();
                isSettingsLoaded = false;
            }
        }


		void Exit_Click(object sender, EventArgs e)
		{
			// Quit without further ado.
			Application.Exit();
		}
	}
}