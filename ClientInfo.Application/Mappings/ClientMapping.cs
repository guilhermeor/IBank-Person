using AutoMapper;
using ClientInfo.Application.Mediators.Clients;
using ClientInfo.Application.Mediators.Clients.GetById;
using ClientInfo.Domain;

namespace ClientInfo.Application.Mappings
{
    public class ClientMapping : Profile
    {
        public ClientMapping()
        {
            CreateMap<Document, DocumentResponse>().ReverseMap();
            CreateMap<Address, AddressResponse>().ReverseMap();
            CreateMap<Client, ClientFull>().ReverseMap();
        }
    }
}
