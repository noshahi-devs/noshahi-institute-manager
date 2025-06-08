using Abp.Application.Services.Dto;
using System;
using NIM.Entities;

namespace NIM.StudentAttendances.Dto
{
    public class PagedStudentAttendanceResultRequestDto : PagedResultRequestDto
    {
        public int? TenantId { get; set; }
        public long? UserId { get; set; }
        public AttendanceStatus? Status { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
    }
}
