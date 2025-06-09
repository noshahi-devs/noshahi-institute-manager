using AutoMapper;
using Abp.Application.Services.Dto;
using NIM.Entities;
using NIM.StudentProfiles.Dto;

namespace NIM.StudentProfiles.Dto
{
    public class StudentMapProfile : Profile
    {
        public StudentMapProfile()
        {
            CreateMap<StudentProfile, StudentProfileDto>();
            CreateMap<CreateStudentProfileDto, StudentProfile>();
            CreateMap<UpdateStudentProfileDto, StudentProfile>();
            CreateMap<CreateStudentAndUserInput, StudentProfile>();
        }
    }
}
