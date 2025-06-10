using System;
using Abp.Application.Services.Dto;
using NIM.Entities;

namespace NIM.StudentAttendances.Dto
{
    public class StudentAttendanceDto : EntityDto<int>
    {
        public int? TenantId { get; set; }
        public long UserId { get; set; }
        public DateTime AttendanceDate { get; set; }
        public AttendanceStatus Status { get; set; }
        public string Remarks { get; set; }
        public DateTime CreationTime { get; set; }
    }
}
