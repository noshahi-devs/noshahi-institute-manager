// NIM.Application/Campuses/Dto/CampusMapProfile.cs
using AutoMapper;
using NIM.Campuses.Dto;
using NIM.Entities;

namespace NIM.Campuses.Dto
{
    public class CampusMapProfile : Profile
    {
        public CampusMapProfile()
        {
            // Campus -> CampusDto
            CreateMap<Campus, CampusDto>();

            // CreateCampusDto -> Campus
            CreateMap<CreateCampusDto, Campus>();

            // UpdateCampusDto -> Campus
            CreateMap<UpdateCampusDto, Campus>();
        }
    }
}