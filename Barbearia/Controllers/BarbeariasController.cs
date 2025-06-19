using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace Barbearia.Controllers
{
    public class BarbeariasController : ApiController
    {
        Repositories.ClientRepository clientRepository = new Repositories.ClientRepository();
        // GET: api/Barbearias
        [HttpGet]
        [Route("api/GetAllClients")]
        public async Task<IHttpActionResult> GetAllClient()
        {
            try
            {
                var Clients = await clientRepository.GetAllClients();
                return Ok(Clients);
            }
            catch (Exception)
            {

                throw;
            }
        }

        // GET: api/Barbearias/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Barbearias
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Barbearias/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Barbearias/5
        public void Delete(int id)
        {
        }
    }
}
