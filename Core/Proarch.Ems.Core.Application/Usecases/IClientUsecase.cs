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

        Task<int> IClientUsecase.AddClientAsync(ClientModel client)
        {
            return _clientRepository.AddClientAsync(client);
        }

        Task<List<ClientModel>> IClientUsecase.GetAllClientsAsync()
        {
            return _clientRepository.GetAllClientsAsync();
        }

        Task<ClientModel> IClientUsecase.GetClientByIdAsync(int id)
        {
            return _clientRepository.GetClientByIdAsync(id);
        }

        Task<ClientModel> IClientUsecase.UpdateClientAsync(ClientModel clientModel)
        {
            return _clientRepository.UpdateClientAsync(clientModel);
        }
        Task<int> IClientUsecase.DeleteClientsAsync(int id)
        {
            return _clientRepository.DeleteClientsAsync(id);
        }
    }
}
