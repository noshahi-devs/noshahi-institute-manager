using System;
using System.ComponentModel.DataAnnotations;
using Abp.Application.Services.Dto;

namespace NIM.StudentFees.Dto
{
    public class UpdateStudentFeeDto : EntityDto<int>
    {
        [Required]
        public int StudentProfileId { get; set; }
        [Required]
        public decimal Amount { get; set; }
        [Required]
        [StringLength(50)]
        public string FeeType { get; set; }
        [Required]
        public DateTime IssuedDate { get; set; }
        [Required]
        public DateTime DueDate { get; set; }
        public bool IsPaid { get; set; }
        public DateTime? PaidDate { get; set; }
        [StringLength(250)]
        public string Remarks { get; set; }
    }
}
