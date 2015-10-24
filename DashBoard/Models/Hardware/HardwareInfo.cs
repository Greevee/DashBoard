using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DashBoard.Models.Hardware
{
    public class HardwareInfo
    {
        public int upload { get; set; }
        public int download { get; set; }
        public int maxram { get; set; }
        public int curram { get; set; }
    }
}
