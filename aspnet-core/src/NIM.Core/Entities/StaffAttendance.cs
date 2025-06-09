using Abp.Domain.Entities;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using NIM.Authorization.Users;

namespace NIM.Entities
{
    public class StaffAttendance : Entity<int>
    {
        public long UserId { get; set; }
        public DateTime CheckInTime { get; set; }
        public DateTime? CheckOutTime { get; set; } // Nullable, optional checkout

        [ForeignKey("UserId")]
        public User User { get; set; }
    }
}
