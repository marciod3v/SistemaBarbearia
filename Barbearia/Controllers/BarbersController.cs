using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Barbearia.Controllers
{
    public class BarbersController : ApiController
    {
        // GET: api/Barbers
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Barbers/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Barbers
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Barbers/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Barbers/5
        public void Delete(int id)
        {
        }
    }
}
