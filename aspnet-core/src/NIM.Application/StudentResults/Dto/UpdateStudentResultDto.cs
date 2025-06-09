using System;
using System.ComponentModel.DataAnnotations;
using Abp.Application.Services.Dto;

namespace NIM.StudentResults.Dto
{
    public class UpdateStudentResultDto : EntityDto<int>
    {
        [Required]
        public int TestId { get; set; }
        [Required]
        public long StudentUserId { get; set; }
        [Required]
        public int ObtainedMarks { get; set; }
        public string Grade { get; set; }
    }
}
