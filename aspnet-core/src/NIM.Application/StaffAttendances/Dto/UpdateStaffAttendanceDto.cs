using System;
using System.ComponentModel.DataAnnotations;
using Abp.Application.Services.Dto;

namespace NIM.StaffAttendances.Dto
{
    public class UpdateStaffAttendanceDto : EntityDto<int>
    {
        [Required]
        public long UserId { get; set; }
        [Required]
        public DateTime CheckInTime { get; set; }
        public DateTime? CheckOutTime { get; set; }
    }
}
