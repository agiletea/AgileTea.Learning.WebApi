using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AgileTea.Learning.Domain.Entities;
using AgileTea.Learning.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace AgileTea.Learning.WebApi.Controllers.V2
{
    [ApiController]
    [ApiVersion("2.0")]
    //[Route("v{version:apiVersion}/[controller]")]
    [Route("[controller]")]
    public class ClientController : ControllerBase
    {
        private readonly IClientService clientService;

        public ClientController(IClientService clientService)
        {
            this.clientService = clientService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Client>>> GetAsync()
        {
            return new ActionResult<IEnumerable<Client>>(await clientService.GetClientsAsync().ConfigureAwait(false));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Client>> GetAsync(Guid id)
        {
            return new ActionResult<Client>(await clientService.GetClientAsync(id).ConfigureAwait(false));
        }

        [HttpPost]
        public async Task<ActionResult> PostAsync([FromBody] Client client)
        {
            await clientService.CreateClientAsync(client).ConfigureAwait(false);

            return Created($"/Client/{client.Id}", client);
        }

        [HttpPut]
        public async Task<ActionResult> PutAsync([FromBody] Client client)
        {
            await clientService.UpdateClientAsync(client).ConfigureAwait(false);

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAsync(Guid id)
        {
            await clientService.DeleteClientAsync(id).ConfigureAwait(false);

            return Ok();
        }
    }
}
