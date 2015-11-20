using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GamerDashBoard.Forms
{
    public partial class Instructions : Form
    {


        private Server server;
        bool isSettingsLoaded = false;



        private void settingsButton_Click(object sender, EventArgs e)
        {
            if (!isSettingsLoaded)
            {
                isSettingsLoaded = true;
                new Settings(server).ShowDialog();
                isSettingsLoaded = false;
            }
        }

        public Instructions(Server server)
        {
            this.server = server;
            InitializeComponent();
            this.product.Text = AssemblyProduct;
            this.version.Text = AssemblyVersion;
            this.Author.Text = "by Sebastian Gräser";
            ipBox.Text = "http://"+GetIP4Address()+":13337";

        }

        public string AssemblyProduct
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyProductAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyProductAttribute)attributes[0]).Product;
            }
        }
        public string AssemblyVersion
        {
            get
            {
                return Assembly.GetExecutingAssembly().GetName().Version.ToString();
            }
        }

        public static string GetIP4Address()
        {
            string IP4Address = String.Empty;

            foreach (IPAddress IPA in Dns.GetHostAddresses(Dns.GetHostName()))
            {
                if (IPA.AddressFamily == AddressFamily.InterNetwork)
                {
                    IP4Address = IPA.ToString();
                    break;
                }
            }

            return IP4Address;
        }

        private void preview_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(ipBox.Text);
        }

        private void b_wallpaper_Click(object sender, EventArgs e)
        {
            Process.Start(@"Style\Wallpapers\");
        }

        private void b_homepage_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/Greevee/DashBoard");
        }
    }
}
