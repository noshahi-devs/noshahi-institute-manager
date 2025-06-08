using System;
using Abp.Application.Services.Dto;

namespace NIM.StudentResults.Dto
{
    public class StudentResultDto : EntityDto<int>
    {
        public int TestId { get; set; }
        public long StudentUserId { get; set; }
        public int ObtainedMarks { get; set; }
        public decimal Percentage { get; set; }
        public string Grade { get; set; }
    }
}
