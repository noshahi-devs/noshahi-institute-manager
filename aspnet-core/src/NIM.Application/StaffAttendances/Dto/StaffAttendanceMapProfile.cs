using AutoMapper;
using NIM.Entities;

namespace NIM.StaffAttendances.Dto
{
    public class StaffAttendanceMapProfile : Profile
    {
        public StaffAttendanceMapProfile()
        {
            CreateMap<StaffAttendance, StaffAttendanceDto>();
            CreateMap<CreateStaffAttendanceDto, StaffAttendance>();
            CreateMap<UpdateStaffAttendanceDto, StaffAttendance>();
        }
    }
}
