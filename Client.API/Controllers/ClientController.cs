using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Client.Model;
using Client.Service;

namespace Client.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IClientService _clientService;

        public ClientController(IClientService clientService) 
        {
            _clientService = clientService;
        }

        [HttpGet("{id}")]
        public IActionResult GetClient(int id)
        {
            var client = _clientService.GetClientById(id);
            return Ok(client);
        }

        // GET /api/clients/search?firstName={firstName}
        [HttpGet("search")]
        public IActionResult SearchClients(string? firstName, string? idNumber, string? phone)
        {
            
            var clients = _clientService.SearchClients(firstName,idNumber, phone);
            return Ok(clients);
        }
        // POST /api/clients
        [HttpPost]
        public IActionResult CreateClient(ClientModel client)
        {
            if (!ModelState.IsValid)
            {
                return UnprocessableEntity(ModelState);
            }
            _clientService.CreateClient(client);
            return CreatedAtAction(nameof(GetClient), new { id = client.Id }, client);
        }

        // PUT /api/clients/{id}
        [HttpPut("{id}")]
        public IActionResult UpdateClient(int id, ClientModel client)
        {
            if (!ModelState.IsValid)
            {
                return UnprocessableEntity(ModelState);
            }
            var updateClient = _clientService.UpdateClient(id, client);
            return Ok(updateClient);
        }

        
    }
}
