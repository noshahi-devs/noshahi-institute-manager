using System;
using System.ComponentModel.DataAnnotations;
using Abp.Application.Services.Dto;

namespace NIM.Tests.Dto
{
    public class UpdateTestDto : EntityDto<int>
    {
        [Required]
        public string TestName { get; set; }
        [Required]
        public DateTime TestDate { get; set; }
        [Required]
        public int MaxMarks { get; set; }
        [Required]
        public int SectionId { get; set; }
        [Required]
        public long CreatedByUserId { get; set; }
    }
}
