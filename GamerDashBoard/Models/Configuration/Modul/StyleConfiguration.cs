using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RainbowDashBoard.Models.Configuration.Modul
{

    public class StyleConfiguration
    {
        public int color_r;
        public int color_g;
        public int color_b;

        public string wallpaper;

        public StyleConfiguration()
        {
            this.wallpaper = "example.png";
            color_r = 0;
            color_g = 255;
            color_b = 255;
        }
    }
}
