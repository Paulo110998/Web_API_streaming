using _2._web_API.Data.Dtos;
using _2._web_API.Models;
using AutoMapper;
using System.Runtime.CompilerServices;

namespace _2._web_API.Profiles;

public class FilmeProfile : Profile // Herança profile
{
    public FilmeProfile()
    {
        // Mapeando um Dto para um Model (CREATE)
        CreateMap<CreateFilmeDto, Filme>();

        // Mapeando um Dto para consulta (READ)
        CreateMap<Filme, ReadFilmeDto>()
            .ForMember(filmeDto => filmeDto.ReadSessaoDto,
            opt => opt.MapFrom(filme => filme.Sessoes));

        // Mapeando um Dto para um Model (PUT)
        CreateMap<UpdateFilmeDto, Filme>();
            

        // Mapeando um Dto para um Model (PATCH)
        CreateMap<Filme, UpdateFilmeDto>(); // Conversão reversa para o patch

        


    }


}
