using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GamerDashBoard.Models.Hardware.Network;
using GamerDashBoard.Models.Hardware.CPU;
using GamerDashBoard.Models.Hardware.Ram;
using GamerDashBoard.Models.Hardware;

namespace GamerDashBoard.Models.Hardware
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
