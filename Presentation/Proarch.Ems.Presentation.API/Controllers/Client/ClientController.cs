using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Proarch.Ems.Core.Application.Usecases;
using Proarch.Ems.Core.Domain.Models;

namespace Proarch.Ems.Presentation.API.Controllers.Client
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IClientUsecase _clientUsecase;

        public ClientController(IClientUsecase clientUsecase)
        {
            _clientUsecase = clientUsecase;
        }

        // GET: api/Client
        [HttpGet]
        public async Task<ActionResult> GetAllClientsAsync()
        {
            var clients = await _clientUsecase.GetAllClientsAsync().ConfigureAwait(false);
            if (clients == null)
            {
                return NotFound();
            }
            return Ok(clients);
        }

        // GET: api/Client/5
        [HttpGet("{id}")]
        public async Task<ActionResult> GetClientByIdAsync(int id)
        {
            var clientModel = await _clientUsecase.GetClientByIdAsync(id).ConfigureAwait(true);

            if (clientModel == null)
            {
                return NotFound();
            }

            return Ok(clientModel);
        }

        // POST: api/Client
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult> PostClientAs(ClientModel clientModel)
        {
            var clientId =await _clientUsecase.AddClientAsync(clientModel).ConfigureAwait(true);
            if(clientId == 0)
            {
                return BadRequest("client is already existed with this Name or Id");
            }
            return Created("created new client", new { url = "https//localhost:44399/client/" + clientId });
        }
        // PUT: api/Client/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutClientModel(int id, ClientModel clientModel)
        {
            if (id != clientModel.Id)
            {
                return BadRequest();
            }
            var client = await _clientUsecase.UpdateClientAsync(clientModel).ConfigureAwait(true);
            if(client == null)
            {
                return NotFound();
            }

            // return NoContent();
            return Ok(client);
        }
        // DELETE: api/Client/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ClientModel>> DeleteClientModel(int id)
        {
            var clientId = await _clientUsecase.DeleteClientsAsync(id).ConfigureAwait(true);
            if (clientId == 0)
            {
                return NotFound();
            }
           
            return Ok("Client Deleted Successfully with client id:"+clientId);
        }
    }
}
