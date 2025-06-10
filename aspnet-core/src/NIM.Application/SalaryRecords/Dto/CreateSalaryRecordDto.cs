using System;
using System.ComponentModel.DataAnnotations;

namespace NIM.SalaryRecords.Dto
{
    public class CreateSalaryRecordDto
    {
        [Required]
        public long UserId { get; set; }
        [Required]
        public decimal SalaryAmount { get; set; }
        [Required]
        public DateTime Month { get; set; }
        public bool IsPaid { get; set; } = false;
        public DateTime? PaidDate { get; set; }
    }
}
