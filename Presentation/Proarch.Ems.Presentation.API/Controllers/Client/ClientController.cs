using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Proarch.Ems.Core.Domain.Models;
using Proarch.Ems.Infrastructure.Data.Common;

namespace Proarch.Ems.Presentation.API.Controllers.Client
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly EmsDbContext _context;

        public ClientController(EmsDbContext context)
        {
            _context = context;
        }

        // GET: api/Client
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClientModel>>> GetClientModel()
        {
            return await _context.ClientModel.ToListAsync();
        }

        // GET: api/Client/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ClientModel>> GetClientModel(int id)
        {
            var clientModel = await _context.ClientModel.FindAsync(id);

            if (clientModel == null)
            {
                return NotFound();
            }

            return clientModel;
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

            _context.Entry(clientModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClientModelExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Client
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<ClientModel>> PostClientModel(ClientModel clientModel)
        {
            _context.ClientModel.Add(clientModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetClientModel", new { id = clientModel.Id }, clientModel);
        }

        // DELETE: api/Client/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ClientModel>> DeleteClientModel(int id)
        {
            var clientModel = await _context.ClientModel.FindAsync(id);
            if (clientModel == null)
            {
                return NotFound();
            }

            _context.ClientModel.Remove(clientModel);
            await _context.SaveChangesAsync();

            return clientModel;
        }

        private bool ClientModelExists(int id)
        {
            return _context.ClientModel.Any(e => e.Id == id);
        }
    }
}
