using DashBoard.Models;
using DashBoard.Models.Hardware.Network;
using System.Web.Http;

namespace DashBoard.Controllers.Hardware
{
    public class NetworkInfoController : ApiController
    {
        private ISystemInfoService service;

        public NetworkInfoController(ISystemInfoService service)
        {
            this.service = service;
        }

        // GET: api/HardwareInfo
        public NetworkInfo Get()
        {
            return service.GetNetworkInfo();
        }
    }
}
