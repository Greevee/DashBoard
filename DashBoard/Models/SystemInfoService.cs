using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DashBoard.Models.Hardware;

namespace DashBoard.Models
{
    class SystemInfoService:ISystemInfoService
    {
        private int count = 0;

        public HardwareInfo test()
        {
            count++;
            HardwareInfo hwi = new HardwareInfo();
            hwi.curram = 7;
            hwi.download = 200;
            return hwi;
        }
    }
}
