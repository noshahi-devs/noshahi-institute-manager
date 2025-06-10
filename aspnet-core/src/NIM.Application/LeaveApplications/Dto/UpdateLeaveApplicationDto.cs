using System;
using System.ComponentModel.DataAnnotations;
using Abp.Application.Services.Dto;
using NIM.Entities;

namespace NIM.LeaveApplications.Dto
{
    public class UpdateLeaveApplicationDto : EntityDto<int>
    {
        [Required]
        public long UserId { get; set; }
        [Required]
        public string LeaveType { get; set; }
        public string Reason { get; set; }
        public double? DurationInHours { get; set; }
        [Required]
        public LeavePaymentStatus PaymentStatus { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        [Required]
        public LeaveStatus Status { get; set; }
        public DateTime? ApprovalTime { get; set; }
    }
}
