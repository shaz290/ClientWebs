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

        public async Task<IEnumerable<Client>> GetAllAsync()
        {
          return  await clientDbContext.Clients.ToListAsync();
        }
    }
}
