using Microsoft.EntityFrameworkCore;
using Proarch.Ems.Core.Application.Common;
using Proarch.Ems.Core.Application.Repositories;
using Proarch.Ems.Core.Domain.Models;
using Proarch.Ems.Infrastructure.Data.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Proarch.Ems.Infrastructure.Data.Repositories
{
    internal class ClientRepository : ExceptionHelper, IClientRepository
    {
        private readonly EmsDbContext _context;

        public ClientRepository(EmsDbContext context)
        {
            this._context = context;
        }

        async Task<List<ClientModel>> IClientRepository.GetAllClientsAsync()
        {
            return await _context.Clients.ToListAsync();
        }

        async Task<ClientModel> IClientRepository.GetClientByIdAsync(int id)
        {
            return await _context.Clients
                .SingleOrDefaultAsync(e => e.Id == id && e.IsDelete == false)
                .ConfigureAwait(false);
        }
        async Task<int> IClientRepository.AddClientAsync(ClientModel client)
        {
            var existClient = _context.Clients.SingleOrDefaultAsync(x => x.Id == client.Id || x.Name.ToLower() == client.Name.ToLower());
            if (existClient != null)
            {
                return 0;
            }
            _context.Clients.Add(client);
            await _context.SaveChangesAsync().ConfigureAwait(false);
            return client.Id;
        }
        async Task<ClientModel> IClientRepository.UpdateClientAsync(ClientModel clientModel)
        {
            var client = await _context.Clients.SingleOrDefaultAsync(c => c.Id == clientModel.Id && c.IsDelete == false).ConfigureAwait(false);
            if (client != null )
            {
                client.IsExisted = clientModel.IsExisted;
                client.Name = clientModel.Name;
                _context.Entry(client).State = EntityState.Modified;

                try
                {
                    await _context.SaveChangesAsync().ConfigureAwait(false);
                }
                catch (DbUpdateConcurrencyException)
                {
                    return null;
                }

                return client;
            }
            return null;

        }
        async Task<int> IClientRepository.DeleteClientsAsync(int id)
        {
            var existing = await this._context
                                   .Clients
                                   .SingleOrDefaultAsync(x => x.Id == id && x.IsDelete == false)
                                   .ConfigureAwait(false);
            if (existing != null)
            {
                existing.IsDelete = true;
                _context.Entry(existing).State = EntityState.Modified;
                // _context.Clients.Remove(existing);
                await _context.SaveChangesAsync().ConfigureAwait(false);
                return existing.Id;
            }
            return 0;
        }

    }
}


