using System;
using System.ComponentModel.DataAnnotations;
using NIM.Entities;

namespace NIM.StudentAttendances.Dto
{
    public class CreateStudentAttendanceDto
    {
        public int? TenantId { get; set; }
        [Required]
        public long UserId { get; set; }
        [Required]
        public DateTime AttendanceDate { get; set; }
        [Required]
        public AttendanceStatus Status { get; set; }
        public string Remarks { get; set; }
    }
}
