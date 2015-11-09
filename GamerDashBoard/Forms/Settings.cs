using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RainbowDashBoard
{
    public partial class Settings : Form
    {
        private Server server;

        public Settings()
        {
            InitializeComponent();

        }

        public Settings(Server server)
        {
            this.server = server;
        }
    }
}
