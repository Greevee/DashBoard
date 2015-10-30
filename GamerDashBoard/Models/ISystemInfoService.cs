using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GamerDashBoard.Models.Hardware;
using GamerDashBoard.Models.Hardware.Network;
using GamerDashBoard.Models.Hardware.CPU;
using GamerDashBoard.Models.Hardware.Ram;

namespace GamerDashBoard.Models
{
    public interface ISystemInfoService
    {
        HardwareInfo GetHardwareInfo();
        NetworkInfo GetNetworkInfo();
        RamInfo getRamInfo();
        CPUInfo getCPUInfo();
    }
}
