using GamerDashBoard.Models;
using GamerDashBoard.Models.Hardware.Network;
using System.Web.Http;

namespace GamerDashBoard.Controllers.Hardware
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
