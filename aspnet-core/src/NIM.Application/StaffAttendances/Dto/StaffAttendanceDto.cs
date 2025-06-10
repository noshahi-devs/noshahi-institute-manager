using System;
using Abp.Application.Services.Dto;

namespace NIM.StaffAttendances.Dto
{
    public class StaffAttendanceDto : EntityDto<int>
    {
        public long UserId { get; set; }
        public DateTime CheckInTime { get; set; }
        public DateTime? CheckOutTime { get; set; }
    }
}
