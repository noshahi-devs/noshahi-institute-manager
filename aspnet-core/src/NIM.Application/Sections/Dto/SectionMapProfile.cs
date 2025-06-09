using AutoMapper;
using NIM.Sections.Dto;
using NIM.Entities;

namespace NIM.Sections.Dto
{
    public class SectionMapProfile : Profile
    {
        public SectionMapProfile()
        {
            // Section -> SectionDto
            CreateMap<Section, SectionDto>()
                .ForMember(dest => dest.ClassName, opt => opt.MapFrom(src => src.Class.Name));
            // CreateSectionDto -> Section
            CreateMap<CreateSectionDto, Section>();
            // UpdateSectionDto -> Section
            CreateMap<UpdateSectionDto, Section>();
        }
    }
}
