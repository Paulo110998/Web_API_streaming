using _2._web_API.Data.Dtos;
using _2._web_API.Models;
using AutoMapper;

namespace _2._web_API.Profiles;

public class GeneroProfile : Profile
{
    public GeneroProfile() 
    {
        CreateMap<CreateGeneroDto, Genero>();
        CreateMap<UpdateGeneroDto, Genero>();

        CreateMap<Genero,UpdateGeneroDto>();
    }
}
