using _2._web_API.Data.Dtos;
using _2._web_API.Models;
using AutoMapper;

namespace _2._web_API.Profiles
{
    public class PerfilProfile : Profile
    {
        public PerfilProfile()
        {
            // Create
            CreateMap<CreatePerfilDto, Perfil>();

            // Read
            CreateMap<Perfil, ReadPerfilDto>()
                .ForMember(perfilDto => perfilDto.ReadPlanosDto,
                opt => opt.MapFrom(perfil => perfil.Planos));

            // Update
            CreateMap<UpdatePerfilDto, Planos>();

        }
    }
}
