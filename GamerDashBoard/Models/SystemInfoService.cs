using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GamerDashBoard.Models.Hardware;
using GamerDashBoard.Models.Hardware.CPU;
using GamerDashBoard.Models.Hardware.Network;
using GamerDashBoard.Models.Hardware.Ram;

namespace GamerDashBoard.Models
{
    public class SystemInfoService:ISystemInfoService
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

        public string[] getNetworkInterfaces()
        {
            return networkInfoFactory.getNetworkInterfaces();
        }

        public void changeNetworkInterface(string networkInterface)
        {
            networkInfoFactory.ChangeNetworkInterface(networkInterface);
        }

    }
}
