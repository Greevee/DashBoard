using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DashBoard.Models.Hardware.CPU
{
    class CPUInfoFactory
    {
        CPUInfoService cpuInfoService = new CPUInfoService();

        public CPUInfo getCPUInfo()
        {
            CPUInfo cpuInfo = new CPUInfo();
            cpuInfo.cpuLoadMap = cpuInfoService.GetCPULoadMap();
            cpuInfo.numberCores = cpuInfoService.getNumerOfInstances();
            return cpuInfo;
        }
    }
}
