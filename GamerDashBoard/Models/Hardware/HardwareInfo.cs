using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RainbowDashBoard.Models.Hardware.Network;
using RainbowDashBoard.Models.Hardware.CPU;
using RainbowDashBoard.Models.Hardware.Ram;
using RainbowDashBoard.Models.Hardware;

namespace RainbowDashBoard.Models.Hardware
{
    public class HardwareInfo : IHardwareInfo
    {
        public NetworkInfo networkInfo { get; set; }
        public RamInfo ramInfo { get; set; }
        public CPUInfo cpuInfo { get; set; }

        public HardwareInfo(NetworkInfo networkInfo)
        {
            this.networkInfo = networkInfo;
            
        }

        public HardwareInfo()
        {

        }
    }

}
