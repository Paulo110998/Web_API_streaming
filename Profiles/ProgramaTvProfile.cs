using _2._web_API.Data.Dtos;
using _2._web_API.Models;
using AutoMapper;

namespace _2._web_API.Profiles;

public class ProgramaTvProfile : Profile
{
    public ProgramaTvProfile() 
    {
        CreateMap<CreateProgramaTvDto, ProgramaTv>();

        CreateMap<UpdateProgramaTvDto, ProgramaTv>();
     
    }

}
