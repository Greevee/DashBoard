using System.Web.Http;
using GamerDashBoard.Models;
using GamerDashBoard.Models.Hardware;

namespace GamerDashBoard.Controllers.Hardware
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
