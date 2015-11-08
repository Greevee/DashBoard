using System.Web.Http;
using RainbowDashBoard.Models;
using RainbowDashBoard.Models.Hardware;

namespace RainbowDashBoard.Controllers.Hardware
{
    public class HardwareInfoController : ApiController
    {
        private ISystemInfoService service;

        public HardwareInfoController(ISystemInfoService service)
        {
            this.service = service;
        }

        // GET: api/HardwareInfo
        public HardwareInfo Get()
        {
            return service.GetHardwareInfo();
        }
    }
}
