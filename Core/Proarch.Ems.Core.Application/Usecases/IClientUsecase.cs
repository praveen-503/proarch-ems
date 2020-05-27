using Proarch.Ems.Core.Application.Common;
using Proarch.Ems.Core.Application.Repositories;
using Proarch.Ems.Core.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Proarch.Ems.Core.Application.Usecases
{
    public interface IClientUsecase : IUsecase
    {
        Task<int> AddClientAsync(ClientModel client);

        Task<int> DeleteClientsAsync(int id);
        Task<List<ClientModel>> GetAllClientsAsync();
        Task<ClientModel> GetClientByIdAsync(int id);
        Task<ClientModel> UpdateClientAsync(ClientModel clientModel);
    }
    internal class ClientUsecase : Usecase, IClientUsecase
    {
        private readonly IClientRepository _clientRepository;

        public ClientUsecase(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        async Task<int> IClientUsecase.AddClientAsync(ClientModel client)
        {
            return await _clientRepository.AddClientAsync(client);
        }

        async Task<List<ClientModel>> IClientUsecase.GetAllClientsAsync()
        {
            return await _clientRepository.GetAllClientsAsync();
        }

        async Task<ClientModel> IClientUsecase.GetClientByIdAsync(int id)
        {
            return await _clientRepository.GetClientByIdAsync(id);
        }

        async Task<ClientModel> IClientUsecase.UpdateClientAsync(ClientModel clientModel)
        {
            return await _clientRepository.UpdateClientAsync(clientModel);
        }
        async Task<int> IClientUsecase.DeleteClientsAsync(int id)
        {
            return await _clientRepository.DeleteClientsAsync(id);
        }
    }
}
