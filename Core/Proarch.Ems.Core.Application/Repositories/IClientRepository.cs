using Proarch.Ems.Core.Application.Common;
using Proarch.Ems.Core.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Proarch.Ems.Core.Application.Repositories
{
    public interface IClientRepository : IRepository
    {
        Task<List<ClientModel>> GetAllClientsAsync();
        Task<ClientModel> GetClientByIdAsync(int id);
        Task<int> AddClientAsync(ClientModel client);
        Task<ClientModel> UpdateClientAsync(ClientModel clientModel);
        Task<int> DeleteClientsAsync(int id);

    }
}
