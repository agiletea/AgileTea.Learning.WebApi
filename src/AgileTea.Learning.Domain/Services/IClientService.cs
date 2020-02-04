using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AgileTea.Learning.Domain.Entities;

namespace AgileTea.Learning.Domain.Services
{
    /// <summary>
    /// Client service to provide basic CRUD operations on a client entity
    /// </summary>
    public interface IClientService
    {
        /// <summary>
        /// Gets all clients from the underlying source
        /// </summary>
        /// <returns>A collection of clients</returns>
        Task<IEnumerable<Client>> GetClientsAsync();

        /// <summary>
        /// Gets a client for the given id
        /// </summary>
        /// <param name="id">The id of the client</param>
        /// <returns>The matched client</returns>
        Task<Client> GetClientAsync(Guid id);

        /// <summary>
        /// Creates a new client
        /// </summary>
        /// <param name="client">The client to create</param>
        /// <returns>The task created</returns>
        Task CreateClientAsync(Client client);

        /// <summary>
        /// Updates an existing client
        /// </summary>
        /// <param name="client">The client to update</param>
        /// <returns>The task created</returns>
        Task UpdateClientAsync(Client client);

        /// <summary>
        /// Deletes an existing client
        /// </summary>
        /// <param name="id">The id of the client to delete</param>
        /// <returns>The task created</returns>
        Task DeleteClientAsync(Guid id);
    }
}