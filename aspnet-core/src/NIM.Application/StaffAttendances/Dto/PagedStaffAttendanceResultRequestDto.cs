using Abp.Application.Services.Dto;
using System;

namespace NIM.StaffAttendances.Dto
{
    public class PagedStaffAttendanceResultRequestDto : PagedResultRequestDto
    {
        public long? UserId { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
    }
}
