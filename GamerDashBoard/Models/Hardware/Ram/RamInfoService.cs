using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RainbowDashBoard.Models.Hardware.Ram
{
    class RamInfoService
    {

        PerformanceCounter ramCounter = new PerformanceCounter("Memory", "Available MBytes");

        public float GetMax()
        {
            return RamHelper.GetGlobalMemoryStatusEX() / 1024 / 1024;
        }

        public float GetAvailable()
        {
            return ramCounter.NextValue();
        }

    }
}
