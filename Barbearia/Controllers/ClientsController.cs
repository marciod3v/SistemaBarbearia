using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace Barbearia.Controllers
{
    public class ClientsController : ApiController
    {
        Repositories.ClientRepository clientRepository = new Repositories.ClientRepository();
        // GET: api/Barbearias
        [HttpGet]
        [Route("client/GetAll")]
        public async Task<IHttpActionResult> Get()
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
        [HttpGet]
        [Route("client/GetByName")]
        public async Task<IHttpActionResult> Get(string name)
        {
            try
            {
                var Clients = await clientRepository.GetClientByName(name);
                return Ok(Clients);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpGet]
        [Route("client/GetByPhone")]
        public async Task<IHttpActionResult> GetByPhone(string phone)
        {
            try
            {
                var Clients = await clientRepository.GetClientByName(phone);
                return Ok(Clients);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPost]
        [Route("client/CreateClient")]
        public async Task<IHttpActionResult> Post([FromBody] Models.Client client)
        {
            try
            {
                if (await clientRepository.CreateClient(client))
                {
                    return Ok();
                }
                return BadRequest();
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPut]
        [Route("client/EditClient/{id}")]
        public async Task<IHttpActionResult> Put(int id, [FromBody] Models.Client client)
        {
            try
            {
                if (await clientRepository.EditClient(client))
                {
                    return Ok();
                }

                return BadRequest();
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpDelete]
        [Route("client/DeleteClient/{id}")]
        public async Task<IHttpActionResult> Delete(int id)
        {
            try
            {
                if (await clientRepository.DeleteClient(id))
                {
                    return Ok();
                }

                return BadRequest();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
