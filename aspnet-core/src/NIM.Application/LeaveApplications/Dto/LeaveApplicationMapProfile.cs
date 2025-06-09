using AutoMapper;
using NIM.Entities;

namespace NIM.LeaveApplications.Dto
{
    public class LeaveApplicationMapProfile : Profile
    {
        public LeaveApplicationMapProfile()
        {
            CreateMap<LeaveApplication, LeaveApplicationDto>();
            CreateMap<CreateLeaveApplicationDto, LeaveApplication>();
            CreateMap<UpdateLeaveApplicationDto, LeaveApplication>();
        }
    }
}
