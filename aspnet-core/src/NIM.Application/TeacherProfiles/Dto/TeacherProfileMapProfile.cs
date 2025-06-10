using AutoMapper;
using NIM.Entities;

namespace NIM.TeacherProfiles.Dto
{
    public class TeacherProfileMapProfile : Profile
    {
        public TeacherProfileMapProfile()
        {
            CreateMap<TeacherProfile, TeacherProfileDto>()
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.User.UserName))
                .ForMember(dest => dest.CampusName, opt => opt.MapFrom(src => src.Campus.Name));
            CreateMap<CreateTeacherProfileDto, TeacherProfile>();
            CreateMap<UpdateTeacherProfileDto, TeacherProfile>();
        }
    }
}
