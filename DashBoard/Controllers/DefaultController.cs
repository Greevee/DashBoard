using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DashBoard.Models;
using DashBoard.Models.Hardware;

namespace DashBoard.Controllers
{
    public class DefaultController : ApiController
    {
        private ISystemInfoService service;

        public DefaultController(ISystemInfoService service)
        {
            this.service = service;
        }

        // GET: api/Default
        public HardwareInfo Get()
        {
            return service.test();
        }

        // GET: api/Default/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Default
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Default/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Default/5
        public void Delete(int id)
        {
        }
    }
}
