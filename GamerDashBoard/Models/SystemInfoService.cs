using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RainbowDashBoard.Models.Hardware;
using RainbowDashBoard.Models.Hardware.CPU;
using RainbowDashBoard.Models.Hardware.Network;
using RainbowDashBoard.Models.Hardware.Ram;

namespace RainbowDashBoard.Models
{
    class SystemInfoService:ISystemInfoService
    {
        NetworkInfoFactory networkInfoFactory = new NetworkInfoFactory();
        RamInfoFactory ramInfoFactory = new RamInfoFactory();
        CPUInfoFactory cpuInfoFactory = new CPUInfoFactory();

        public HardwareInfo GetHardwareInfo()
        {
            HardwareInfo hardwareInfo = new HardwareInfo();
            hardwareInfo.networkInfo=networkInfoFactory.GetNetworkInfo();
            hardwareInfo.ramInfo = ramInfoFactory.GetRamInfo();
            hardwareInfo.cpuInfo = cpuInfoFactory.getCPUInfo();
            return hardwareInfo;
        }

        public CPUInfo getCPUInfo()
        {
            return cpuInfoFactory.getCPUInfo();
        }

        public NetworkInfo GetNetworkInfo()
        {
            return networkInfoFactory.GetNetworkInfo();
        }

        public RamInfo getRamInfo()
        {
            return ramInfoFactory.GetRamInfo();
        }
    }
}
