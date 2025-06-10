using AutoMapper;
using NIM.Entities;

namespace NIM.StudentFees.Dto
{
    public class StudentFeeMapProfile : Profile
    {
        public StudentFeeMapProfile()
        {
            CreateMap<StudentFee, StudentFeeDto>();
            CreateMap<CreateStudentFeeDto, StudentFee>();
            CreateMap<UpdateStudentFeeDto, StudentFee>();
        }
    }
}
