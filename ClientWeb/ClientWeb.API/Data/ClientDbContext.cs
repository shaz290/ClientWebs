using ClientWeb.API.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace ClientWeb.API.Data
{
    public class ClientDbContext:DbContext
    {
        public ClientDbContext(DbContextOptions<ClientDbContext> options): base(options)
        
        { 
        
        }

        public DbSet<Client> Clients { get; set; }  
        public DbSet<Clinician> Clinicians{ get;set; }

        public DbSet<Payer> Payers { get; set; }




    }
}
