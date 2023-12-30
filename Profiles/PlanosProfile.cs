namespace _2._web_API.Profiles;

using _2._web_API.Data.Dtos;
using _2._web_API.Models;
using AutoMapper;

public class PlanosProfile : Profile
{
    public PlanosProfile()
    {
        // Create
        CreateMap<CreatePlanosDto, Planos>();

        // Read
        CreateMap<Planos, ReadPlanosDto>();

        // Update
        CreateMap<UpdatePlanosDto, Planos>();
    }
}
