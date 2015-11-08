using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RainbowDashBoard.Models.Hardware;
using RainbowDashBoard.Models.Hardware.Network;
using RainbowDashBoard.Models.Hardware.CPU;
using RainbowDashBoard.Models.Hardware.Ram;

namespace RainbowDashBoard.Models
{
    public interface ISystemInfoService
    {
        HardwareInfo GetHardwareInfo();
        NetworkInfo GetNetworkInfo();
        RamInfo getRamInfo();
        CPUInfo getCPUInfo();
    }
}
