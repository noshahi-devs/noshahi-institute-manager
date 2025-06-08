using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using NIM.Authorization.Users;

namespace NIM.Entities
{
    public enum AttendanceStatus
    {
        Present = 1,
        Absent = 2,
        Leave = 3
    }

    public class StudentAttendance : Entity<int>, IMayHaveTenant, IHasCreationTime
    {
        public int? TenantId { get; set; }
        public long UserId { get; set; } // FK to User
        public DateTime AttendanceDate { get; set; } // Only date part is used
        public AttendanceStatus Status { get; set; } // Present, Absent, Leave
        public string Remarks { get; set; } // Optional reason
        public DateTime CreationTime { get; set; } = DateTime.Now;

        [ForeignKey("UserId")]
        public User User { get; set; }
    }
}
