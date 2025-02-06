using Microsoft.AspNetCore.Mvc;
using Yape.Api.Core.Interfaces;
using Yape.Api.Core.Models;

namespace Yape.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientController : ControllerBase
    {
        private readonly IClientRepository _clientRepository;
        private readonly IPersonService _personService;

        public ClientController(IClientRepository clientRepository, IPersonService personService)
        {
            _clientRepository = clientRepository;
            _personService = personService;
        }

        [HttpPost]
        public async Task<IActionResult> RegisterClient([FromBody] Client client)
        {
            if (await _clientRepository.ExistsByDocumentAsync(client.DocumentType, client.DocumentNumber))
            {
                return BadRequest("El cliente ya está registrado.");
            }

            var persons = await _personService.GetPersonsByPhone(client.CellPhoneNumber);
            if (persons.Count == 0)
            {
                return BadRequest("El número de teléfono no está registrado en el servicio WCF.");
            }

            await _clientRepository.AddClientAsync(client);
            return Ok(new { client.Name });
        }
    }
}