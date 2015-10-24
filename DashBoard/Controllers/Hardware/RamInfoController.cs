using DashBoard.Models;
using DashBoard.Models.Hardware.Ram;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DashBoard.Controllers.Hardware
{
    public class RamInfoController : ApiController
    {
        private ISystemInfoService service;

        public RamInfoController(ISystemInfoService service)
        {
            this.service = service;
        }

        // GET: api/HardwareInfo
        public RamInfo Get()
        {
            return service.getRamInfo();
        }
    }
}
