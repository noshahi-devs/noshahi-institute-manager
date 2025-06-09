using AutoMapper;
using NIM.Classes.Dto;
using NIM.Entities;

namespace NIM.Classes.Dto
{
    public class ClassMapProfile : Profile
    {
        public ClassMapProfile()
        {
            // Class -> ClassDto
            CreateMap<Class, ClassDto>()
                .ForMember(dest => dest.CampusName, opt => opt.MapFrom(src => src.Campus.Name));

            // CreateClassDto -> Class
            CreateMap<CreateClassDto, Class>();

            // UpdateClassDto -> Class
            CreateMap<UpdateClassDto, Class>();
        }
    }
}