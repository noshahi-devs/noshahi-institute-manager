using AutoMapper;
using NIM.Entities;

namespace NIM.PrincipalProfiles.Dto
{
    public class PrincipalMapProfile : Profile
    {
        public PrincipalMapProfile()
        {
            CreateMap<PrincipalProfile, PrincipalProfileDto>()
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.User.UserName))
                .ForMember(dest => dest.CampusName, opt => opt.MapFrom(src => src.Campus.Name));
            CreateMap<CreatePrincipalProfileDto, PrincipalProfile>();
            CreateMap<UpdatePrincipalProfileDto, PrincipalProfile>();
        }
    }
}
