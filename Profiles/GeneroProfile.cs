using _2._web_API.Data.Dtos;
using _2._web_API.Models;
using AutoMapper;

namespace _2._web_API.Profiles;

public class GeneroProfile : Profile
{
    public GeneroProfile() 
    {
        // Mapeando um Dto para um Model (POST)
        CreateMap<CreateGeneroDto, Genero>();

        // Mapeando um Dto para um Model (PUT)
        CreateMap<UpdateGeneroDto, Genero>();

        // Mapeando um Dto para um Model (PATCH)
        CreateMap<Genero,UpdateGeneroDto>();

        // Mapeando um Dto para consulta (READ)
        CreateMap<Genero, ReadGeneroDto>();
    }
}
