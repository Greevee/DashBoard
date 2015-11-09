using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RainbowDashBoard.Models.Configuration;

namespace RainbowDashBoard.Models
{
    interface ISettingsService
    {
       Configuration.Configuration  getConfig();
    }
}
