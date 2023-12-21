using AutoMapper;
using _2._web_API.Data.Dtos;
using _2._web_API.Models;

namespace _2._web_API.Profiles
{
    public class UsuariosProfile : Profile
    {
        public UsuariosProfile()
        {
            CreateMap<CreateUsuariosDto, Usuario>();

            CreateMap<UpdateUsuariosDto, Usuario>();

        }
    }
}
