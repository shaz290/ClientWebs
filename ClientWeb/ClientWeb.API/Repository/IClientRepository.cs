using ClientWeb.API.Models.Domain;

namespace ClientWeb.API.Repository
{
    public interface IClientRepository
    {
      Task<  IEnumerable<Client>> GetAllAsync();
    }
}
