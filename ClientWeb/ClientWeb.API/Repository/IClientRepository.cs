using ClientWeb.API.Models.Domain;

namespace ClientWeb.API.Repository
{
    public interface IClientRepository
    {
        Task<IEnumerable<Client>> GetAllAsync();

        Task<Client> GetAsync(Guid id);

        Task<Client> GetAsync(string PatientId);

        Task<Client> AddAsync(Client client);

       Task<Client> DeleteAsync(Guid id);

        Task<Client> DeleteAsync(string Name);

        Task<Client> UpdateAsync(Guid id,Client client);

    }
}
