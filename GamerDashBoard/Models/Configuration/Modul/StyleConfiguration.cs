using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamerDashBoard.Models.Configuration.Modul
{

    public class StyleConfiguration
    {
        public int color_r;
        public int color_g;
        public int color_b;

        public int b_color_r;
        public int b_color_g;
        public int b_color_b;
        public double b_opacity;

        public string wallpaper;

        public StyleConfiguration()
        {
            this.wallpaper = "example.png";
            color_r = 0;
            color_g = 255;
            color_b = 255;

            b_color_r = 0;
            b_color_g = 0;
            b_color_b = 0;
            b_opacity = 0.8;
        }
    }
}
