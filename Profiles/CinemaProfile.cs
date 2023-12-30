using _2._web_API.Data.Dtos;
using _2._web_API.Models;
using AutoMapper;

namespace _2._web_API.Profiles;

public class CinemaProfile : Profile
{
    public CinemaProfile()
    {
        CreateMap<CreateCinemaDto, Cinema>();

        CreateMap<Cinema, ReadCinemaDto>()
           .ForMember(cinemaDto => cinemaDto.ReadEndereçoDto, 
            opt => opt.MapFrom(cinema => cinema.Endereco));

        CreateMap<UpdateCinemaDto, Cinema>();
    }
}
