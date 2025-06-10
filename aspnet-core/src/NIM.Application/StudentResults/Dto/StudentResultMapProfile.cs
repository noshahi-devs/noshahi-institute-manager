using AutoMapper;
using NIM.Entities;

namespace NIM.StudentResults.Dto
{
    public class StudentResultMapProfile : Profile
    {
        public StudentResultMapProfile()
        {
            CreateMap<StudentResult, StudentResultDto>()
                .ForMember(dest => dest.Percentage, opt => opt.MapFrom(src => src.Test != null && src.Test.MaxMarks > 0 ? (decimal)src.ObtainedMarks / src.Test.MaxMarks * 100 : 0));
            CreateMap<CreateStudentResultDto, StudentResult>();
            CreateMap<UpdateStudentResultDto, StudentResult>();
        }
    }
}
