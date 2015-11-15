using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GamerDashBoard.Models.Configuration;

namespace GamerDashBoard.Models
{
    public interface IConfigurationService
    {
       Configuration.Configuration  getConfig();
    }
}
