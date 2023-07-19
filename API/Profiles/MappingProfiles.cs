using API.Dtos;
using AutoMapper;
using Core.Entities;

namespace API.Controllers;

public class MappingProfiles : Profile
{   
    public MappingProfiles()
    {
        CreateMap<Area, AreaDto>().ReverseMap();
        CreateMap<Area, AreaUDto>().ReverseMap();
    } 
    
} 