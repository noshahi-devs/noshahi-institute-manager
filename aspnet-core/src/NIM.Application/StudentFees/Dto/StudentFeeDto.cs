using System;
using Abp.Application.Services.Dto;

namespace NIM.StudentFees.Dto
{
    public class StudentFeeDto : EntityDto<int>
    {
        public int StudentProfileId { get; set; }
        public decimal Amount { get; set; }
        public string FeeType { get; set; }
        public DateTime IssuedDate { get; set; }
        public DateTime DueDate { get; set; }
        public bool IsPaid { get; set; }
        public DateTime? PaidDate { get; set; }
        public string Remarks { get; set; }
    }
}
