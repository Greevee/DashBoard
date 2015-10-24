using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DashBoard.Models.Hardware.Network;
using DashBoard.Models.Hardware.CPU;
using DashBoard.Models.Hardware.Ram;
using DashBoard.Models.Hardware;

namespace DashBoard.Models.Hardware
{
    public class HardwareInfo : IHardwareInfo
    {
        public NetworkInfo networkInfo { get; set; }
        public RamInfo ramkInfo { get; set; }
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
