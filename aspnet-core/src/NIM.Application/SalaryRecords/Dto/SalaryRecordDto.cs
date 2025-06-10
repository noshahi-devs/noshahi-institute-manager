using System;
using Abp.Application.Services.Dto;

namespace NIM.SalaryRecords.Dto
{
    public class SalaryRecordDto : EntityDto<int>
    {
        public long UserId { get; set; }
        public decimal SalaryAmount { get; set; }
        public DateTime Month { get; set; }
        public bool IsPaid { get; set; }
        public DateTime? PaidDate { get; set; }
    }
}
