using System.Web.Http;
using DashBoard.Models;
using DashBoard.Models.Hardware;

namespace DashBoard.Controllers.Hardware
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
