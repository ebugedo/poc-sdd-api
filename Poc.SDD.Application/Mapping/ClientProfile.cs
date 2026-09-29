using AutoMapper;
using Poc.SDD.Application.Clients;
using Poc.SDD.Domain.Clients;

namespace Poc.SDD.Application.Mapping;

public class ClientProfile : Profile
{
    public ClientProfile()
    {
        CreateMap<Client, ClientDto>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id.Value))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name.Value))
            .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email.Value))
            .ForMember(dest => dest.Phone, opt => opt.MapFrom(src => src.Phone.Value))
            .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => src.CreatedAt))
            .ForMember(dest => dest.UpdatedAt, opt => opt.MapFrom(src => src.UpdatedAt));

        CreateMap<CreateClientCommand, Client>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => ClientId.CreateUnique()))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => new ClientName(src.Name)))
            .ForMember(dest => dest.Email, opt => opt.MapFrom(src => new ClientEmail(src.Email)))
            .ForMember(dest => dest.Phone, opt => opt.MapFrom(src => new ClientPhone(src.Phone)));
    }
}