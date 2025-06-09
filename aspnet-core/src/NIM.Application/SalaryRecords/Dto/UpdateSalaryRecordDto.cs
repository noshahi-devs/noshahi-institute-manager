using System;
using System.ComponentModel.DataAnnotations;
using Abp.Application.Services.Dto;

namespace NIM.SalaryRecords.Dto
{
    public class UpdateSalaryRecordDto : EntityDto<int>
    {
        [Required]
        public long UserId { get; set; }
        [Required]
        public decimal SalaryAmount { get; set; }
        [Required]
        public DateTime Month { get; set; }
        public bool IsPaid { get; set; }
        public DateTime? PaidDate { get; set; }
    }
}
