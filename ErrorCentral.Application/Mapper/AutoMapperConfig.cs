using AutoMapper;
using ErrorCentral.Application.DTOs;
using ErrorCentral.Domain.Model;
using Microsoft.AspNetCore.Identity;

namespace ErrorCentral.Application.Mapper
{
    public class AutoMapperConfig : Profile
    {
        public static MapperConfiguration RegisterMappings()
        {
            return new MapperConfiguration(x => x.AllowNullCollections = true);
        }

        public AutoMapperConfig()
        {
            CreateMap<Log, LogDTO>().ReverseMap();
            CreateMap<Organization, OrganizationDTO>().ReverseMap();

            CreateMap<Log, LogAddDTO>().ReverseMap();
            CreateMap<Organization, OrganizationAddDTO>().ReverseMap();

            CreateMap<Log, LogUpdateDTO>().ReverseMap();

            CreateMap<IdentityUser, UserDTO>().ReverseMap();
            CreateMap<IdentityUser, UserIdDTO>().ReverseMap();
            
        }
    }
}