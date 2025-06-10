using System;
using System.ComponentModel.DataAnnotations;

namespace NIM.StaffAttendances.Dto
{
    public class CreateStaffAttendanceDto
    {
        [Required]
        public long UserId { get; set; }
        [Required]
        public DateTime CheckInTime { get; set; }
        public DateTime? CheckOutTime { get; set; }
    }
}
