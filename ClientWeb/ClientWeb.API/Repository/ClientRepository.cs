using ClientWeb.API.Data;
using ClientWeb.API.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace ClientWeb.API.Repository
{
    public class ClientRepository : IClientRepository
    {
        private readonly ClientDbContext clientDbContext;

        public ClientRepository(ClientDbContext clientDbContext)
        {
            this.clientDbContext = clientDbContext;
        }

        public async Task<Client> AddAsync(Client client)
        {
            client.Id = Guid.NewGuid();
            await clientDbContext.AddAsync(client);
            await clientDbContext.SaveChangesAsync();
            return client;
        }

        public async Task<Client> DeleteAsync(Guid id)
        {
            var client = await clientDbContext.Clients.FirstOrDefaultAsync(x => x.Id == id);
            if (client == null)
            {
                return null;
            }
            clientDbContext.Clients.Remove(client);
            await clientDbContext.SaveChangesAsync();
            return client;
        }

        public async Task<Client> DeleteAsync(string Name)
        {
            var client = await clientDbContext.Clients.FirstOrDefaultAsync(x => x.Name == Name);
            if (client == null)
            {
                return null;
            }
            clientDbContext.Clients.Remove(client);
            await clientDbContext.SaveChangesAsync();
            return client;
        }

        public async Task<IEnumerable<Client>> GetAllAsync()
        {
            return await clientDbContext.Clients.ToListAsync();
        }

        public async Task<Client> GetAsync(Guid id)
        {
            return await clientDbContext.Clients.FirstOrDefaultAsync(x => x.Id == id);

        }

        public async Task<Client> GetAsync(string PatientId)
        {
            return await clientDbContext.Clients.FirstOrDefaultAsync(x => x.PatientId == PatientId);
        }

        public async Task<Client> UpdateAsync(Guid id, Client client)
        {

            var existClient = await clientDbContext.Clients.FirstOrDefaultAsync(x => x.Id == id);

            if (existClient == null)
            {
                return null;
            }
            existClient.PatientId = client.PatientId;
            existClient.Name = client.Name;
            existClient.Age = client.Age;
            existClient.Sex = client.Sex;
            existClient.Location = client.Location;
            existClient.Phone = client.Phone;
            existClient.SSN = client.SSN;
            existClient.Email = client.Email;

            await clientDbContext.SaveChangesAsync();
            return existClient;

        }
    }
}
