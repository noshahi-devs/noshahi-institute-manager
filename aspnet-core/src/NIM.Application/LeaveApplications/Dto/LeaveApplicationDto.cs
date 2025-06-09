using System;
using Abp.Application.Services.Dto;
using NIM.Entities;

namespace NIM.LeaveApplications.Dto
{
    public class LeaveApplicationDto : EntityDto<int>
    {
        public long UserId { get; set; }
        public string LeaveType { get; set; }
        public string Reason { get; set; }
        public double? DurationInHours { get; set; }
        public LeavePaymentStatus PaymentStatus { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public LeaveStatus Status { get; set; }
        public DateTime CreationTime { get; set; }
        public DateTime? ApprovalTime { get; set; }
    }
}
