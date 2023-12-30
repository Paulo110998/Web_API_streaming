using _2._web_API.Data.Dtos;
using _2._web_API.Models;
using AutoMapper;

namespace _2._web_API.Profiles;

public class SessaoProfile : Profile
{
    public SessaoProfile()
    {
        CreateMap<CreateSessaoDto, Sessao>();

        CreateMap<Sessao, ReadSessaoDto>();
    }
}
