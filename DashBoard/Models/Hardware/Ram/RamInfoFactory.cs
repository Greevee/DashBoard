using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DashBoard.Models.Hardware.Ram
{
    class RamInfoFactory
    {
        RamInfoService ramInfoService = new RamInfoService();

        public RamInfo GetRamInfo()
        {
            RamInfo ramInfo = new RamInfo();
            ramInfo.available = ramInfoService.GetAvailable();
            ramInfo.max = ramInfoService.GetMax();
            return ramInfo;
        }
    }
}
