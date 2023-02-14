using AutoMapper;

namespace ClientWeb.API.Profiles
{
    public class ClientsProfile : Profile

    {
        public ClientsProfile()
        {
            CreateMap<Models.Domain.Client, Models.DTO.Client>()
                .ReverseMap();
        }
       
    }
}
