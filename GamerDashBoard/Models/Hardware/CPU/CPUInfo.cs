using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamerDashBoard.Models.Hardware.CPU
{
    public class CPUInfo:IHardwareInfo
    {
        public Dictionary<string, float> cpuLoadMap = new Dictionary<string, float>();
        public int numberCores;
    }
}
