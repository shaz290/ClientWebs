using AutoMapper;
using ClientWeb.API.Models.Domain;
using ClientWeb.API.Repository;
using Microsoft.AspNetCore.Mvc;

namespace ClientWeb.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClientsController : Controller
    {
        private readonly IClientRepository clientRepository;
        private readonly IMapper mapper;

        public ClientsController(IClientRepository clientRepository, IMapper mapper)
        {
            this.clientRepository = clientRepository;
            this.mapper = mapper;
        }



        [HttpGet]

        public async Task<IActionResult> GetAllClients()
        {
            var clients = await clientRepository.GetAllAsync();
            var clientsDTO = mapper.Map<List<Models.DTO.Client>>(clients);
            return Ok(clientsDTO);

        }

    }
}
