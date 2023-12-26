using _2._web_API.Data.Dtos;
using _2._web_API.Models;
using AutoMapper;

namespace _2._web_API.Profiles;

public class SeriesProfile : Profile
{
   public SeriesProfile() 
   {
        CreateMap<CreateSeriesDto, Series>();  
        
        CreateMap<UpdateSeriesDto, Series>();

        CreateMap<Series, UpdateSeriesDto>();

        CreateMap<Series, ReadSeriesDto>();
   }
}
