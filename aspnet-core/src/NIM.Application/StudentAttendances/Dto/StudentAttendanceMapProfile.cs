using AutoMapper;
using NIM.Entities;

namespace NIM.StudentAttendances.Dto
{
    public class StudentAttendanceMapProfile : Profile
    {
        public StudentAttendanceMapProfile()
        {
            CreateMap<StudentAttendance, StudentAttendanceDto>();
            CreateMap<CreateStudentAttendanceDto, StudentAttendance>();
            CreateMap<UpdateStudentAttendanceDto, StudentAttendance>();
        }
    }
}
