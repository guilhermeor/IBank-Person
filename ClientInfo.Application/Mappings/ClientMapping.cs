using AutoMapper;
using ClientInfo.Application.Mediators.Clients.GetById;
using ClientInfo.Domain;

namespace ClientInfo.Application.Mappings
{
    public class ClientMapping : Profile
    {
        public ClientMapping()
        {
            CreateMap<Client, ClientFull>().ReverseMap(); 
        }
    }
}
