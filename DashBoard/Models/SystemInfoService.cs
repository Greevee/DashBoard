using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DashBoard.Models.Hardware;
using DashBoard.Models.Hardware.CPU;
using DashBoard.Models.Hardware.Network;
using DashBoard.Models.Hardware.Ram;

namespace DashBoard.Models
{
    class SystemInfoService:ISystemInfoService
    {
        NetworkInfoFactory networkInfoFactory = new NetworkInfoFactory();

        public HardwareInfo GetHardwareInfo()
        {
            HardwareInfo hardwareInfo = new HardwareInfo();
            hardwareInfo.networkInfo=networkInfoFactory.GetNetworkInfo();

            return hardwareInfo;
        }

        public CPUInfo getCPUInfo()
        {
            throw new NotImplementedException();
        }

        public NetworkInfo GetNetworkInfo()
        {
            throw new NotImplementedException();
        }

        public RamInfo getRamInfo()
        {
            throw new NotImplementedException();
        }
    }
}
