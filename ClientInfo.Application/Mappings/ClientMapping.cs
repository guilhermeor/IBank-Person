using AutoMapper;
using ClientInfo.Application.Mediators.Clients;
using ClientInfo.Application.Mediators.Clients.Add;
using ClientInfo.Application.Mediators.Clients.GetAll;
using ClientInfo.Application.Mediators.Clients.GetById;
using ClientInfo.Application.Mediators.Clients.Requests;
using ClientInfo.Domain;

namespace ClientInfo.Application.Mappings
{
    public class ClientMapping : Profile
    {
        public ClientMapping()
        {
            CreateMap<Document, DocumentResponse>().ReverseMap();
            CreateMap<Address, AddressResponse>().ReverseMap();
            CreateMap<Document, DocumentRequest>().ReverseMap();
            CreateMap<Address, AddressRequest>().ReverseMap();
            CreateMap<Client, ClientFull>().ReverseMap();
            CreateMap<Client, ClientShort>().ReverseMap();
            CreateMap<Client, ClientAddRequest>().ReverseMap();
        }
    }
}
