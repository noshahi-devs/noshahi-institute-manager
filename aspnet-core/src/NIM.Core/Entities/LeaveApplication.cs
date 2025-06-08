using Abp.Domain.Entities;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using NIM.Authorization.Users;

namespace NIM.Entities
{
    public enum LeavePaymentStatus
    {
        Paid,
        Unpaid
    }

    public enum LeaveStatus
    {
        Pending,
        Approved,
        Rejected
    }

    public class LeaveApplication : Entity<int>
    {
        public long UserId { get; set; }  // FK to User
        public string LeaveType { get; set; }  // e.g. "Full Day", "Half Day", "Hourly"
        public string Reason { get; set; }
        public double? DurationInHours { get; set; }  // used especially if LeaveType == "Hourly"
        public LeavePaymentStatus PaymentStatus { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }  // nullable if hourly or single day
        public LeaveStatus Status { get; set; }  // e.g. Pending, Approved, Rejected
        public DateTime CreationTime { get; set; }
        public DateTime? ApprovalTime { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }
    }
}
