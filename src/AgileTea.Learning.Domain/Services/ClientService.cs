using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AgileTea.Learning.Domain.Entities;

namespace AgileTea.Learning.Domain.Services
{
    internal class ClientService : IClientService
    {
        public Task<IEnumerable<Client>> GetClientsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Client> GetClientAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task CreateClientAsync(Client client)
        {
            throw new NotImplementedException();
        }

        public Task UpdateClientAsync(Client client)
        {
            throw new NotImplementedException();
        }

        public Task DeleteClientAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
