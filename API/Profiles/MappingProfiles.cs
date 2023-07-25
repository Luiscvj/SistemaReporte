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
        CreateMap<Lugar, LugarDto>().ReverseMap();
        CreateMap<Categoria , CategoriaDto>().ReverseMap();
        CreateMap<Hardware , HardwareDto>().ReverseMap();
        CreateMap<Software , SoftwareDto>().ReverseMap();
        CreateMap<Insidencia , InsidenciaCategoriaDto>().ReverseMap();
        CreateMap<Email , EmailDto>().ReverseMap();
        CreateMap<EmailTrainer , EmailTrainerDto>().ReverseMap();
        CreateMap<TipoHardware , TipoHardwareDto>().ReverseMap();
        CreateMap<Insidencia , InsidenciasDto>().ReverseMap();
        CreateMap<Trainer , TrainerDto>().ReverseMap();
        CreateMap<TipoSoftware , TipoSoftwareDto>().ReverseMap();
        CreateMap<Categoria , CategoriaUDto>().ReverseMap();
        CreateMap<Email , EmailUDto>().ReverseMap();
        CreateMap<Trainer , TrainerUDTO>().ReverseMap();


    } 
    
} 