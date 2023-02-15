using AutoMapper;
using ClientWeb.API.Models.Domain;
using ClientWeb.API.Models.DTO;
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

        public async Task<IActionResult> GetAllClientsAsync()
        {
            var clients = await clientRepository.GetAllAsync();
            var clientsDTO = mapper.Map<List<Models.DTO.Client>>(clients);
            return Ok(clientsDTO);

        }

        [HttpGet]
        [Route("{id:guid}")]
        [ActionName("GetAllClientsAsync")]
        public async Task<IActionResult> GetAllClientsAsync(Guid id)
        {
            var client = await clientRepository.GetAsync(id);

            var clientDTO = mapper.Map<Models.DTO.Client>(client);
            if (clientDTO == null)
            {
                return NotFound();
            }
            return Ok(clientDTO);

        }

        [HttpGet]
        [Route("{PatientId}")]
        public async Task<IActionResult> GetAllClientsAsync(string PatientId)
        {
            var client = await clientRepository.GetAsync(PatientId);

            var clientDTO = mapper.Map<Models.DTO.Client>(client);
            if (clientDTO == null)
            {
                return NotFound();
            }
            return Ok(clientDTO);

        }


        [HttpPost]
        public async Task<IActionResult> AddClientAsync(Models.DTO.AddClientRequest addClientRequest)
        {
            var client = new Models.Domain.Client()
            {
                PatientId = addClientRequest.PatientId,
                Name = addClientRequest.Name,
                Age = addClientRequest.Age,
                Sex = addClientRequest.Sex,
                Location = addClientRequest.Location,
                SSN = addClientRequest.SSN,
                Email = addClientRequest.Email,
                Phone = addClientRequest.Phone
            };

            client = await clientRepository.AddAsync(client);

            var clientDTO = new Models.DTO.Client
            {
                PatientId = client.PatientId,
                Name = client.Name,
                Age = client.Age,
                Sex = client.Sex,
                Location = client.Location,
                SSN = client.SSN,
                Email = client.Email,
                Phone = client.Phone
            };
            return CreatedAtAction(nameof(GetAllClientsAsync), new { id = clientDTO.Id }, clientDTO);
        }



        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeleteClientAsync(Guid id)
        {
            //Get region from DB
            var client = await clientRepository.DeleteAsync(id);

            //If null Notfound

            if(client == null)
            {
                return NotFound();
            }
            //Convert response back to DTO

            var clientDTO = new Models.Domain.Client()
            {
                Id=client.Id,
                PatientId = client.PatientId,
                Name = client.Name,
                Age = client.Age,
                Sex = client.Sex,
                Location = client.Location,
                SSN = client.SSN,
                Email = client.Email,
                Phone = client.Phone
            };

            //Return Ok response
            return Ok(clientDTO);
        }


        [HttpDelete]
        [Route("{Name}")]
        public async Task<IActionResult> DeleteClientAsync(string Name)
        {
            //Get region from DB
            var client = await clientRepository.DeleteAsync(Name);

            //If null Notfound

            if (client == null)
            {
                return NotFound();
            }
            //Convert response back to DTO

            var clientDTO = new Models.Domain.Client()
            {
                Id = client.Id,
                PatientId = client.PatientId,
                Name = client.Name,
                Age = client.Age,
                Sex = client.Sex,
                Location = client.Location,
                SSN = client.SSN,
                Email = client.Email,
                Phone = client.Phone
            };

            //Return Ok response
            return Ok(clientDTO);
        }


        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult>UpdateClientAsync([FromRoute]Guid id,[FromBody]Models.DTO.UpdateClientRequest updateClientRequest)
        {
            //Convert DTO to Domain model

            var client = new Models.Domain.Client
            {
                PatientId = updateClientRequest.PatientId,
                Name = updateClientRequest.Name,
                Age = updateClientRequest.Age,
                Sex = updateClientRequest.Sex,
                Location = updateClientRequest.Location,
                SSN = updateClientRequest.SSN,
                Email = updateClientRequest.Email,
                Phone = updateClientRequest.Phone
            };
            //Update Region using repository

           client = await clientRepository.UpdateAsync(id, client);
            //If null then not found

            if(client== null)
            {
                return NotFound();  
            }

            //COnvert Domain to DTO
            var clientDTO = new Models.DTO.Client
            {
                PatientId = client.PatientId,
                Name = client.Name,
                Age = client.Age,
                Sex = client.Sex,
                Location = client.Location,
                SSN = client.SSN,
                Email = client.Email,
                Phone = client.Phone
            };
            //Return OK reposne

            return Ok(clientDTO);
        }

    }
}

