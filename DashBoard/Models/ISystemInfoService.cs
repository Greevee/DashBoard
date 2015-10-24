using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DashBoard.Models.Hardware;

namespace DashBoard.Models
{
    public interface ISystemInfoService
    {
        HardwareInfo test();
    }
}
