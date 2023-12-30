using _2._web_API.Data.Dtos;
using _2._web_API.Models;
using AutoMapper;

namespace _2._web_API.Profiles;

public class EnderecoProfile : Profile
{
    public EnderecoProfile()
    {
        CreateMap<CreateEndereçoDto, Endereco>();
        CreateMap<Endereco, ReadEndereçoDto>();
        CreateMap<UpdateEndereçoDto, Endereco>();
    }
}
