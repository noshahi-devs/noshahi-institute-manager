using Abp.Application.Services.Dto;
using System;
using NIM.Entities;

namespace NIM.LeaveApplications.Dto
{
    public class PagedLeaveApplicationResultRequestDto : PagedResultRequestDto
    {
        public long? UserId { get; set; }
        public LeaveStatus? Status { get; set; }
        public LeavePaymentStatus? PaymentStatus { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}
