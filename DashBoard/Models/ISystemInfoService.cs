using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DashBoard.Models.Hardware;
using DashBoard.Models.Hardware.Network;
using DashBoard.Models.Hardware.CPU;
using DashBoard.Models.Hardware.Ram;

namespace DashBoard.Models
{
    public interface ISystemInfoService
    {
        HardwareInfo GetHardwareInfo();
        NetworkInfo GetNetworkInfo();
        RamInfo getRamInfo();
        CPUInfo getCPUInfo();
    }
}
