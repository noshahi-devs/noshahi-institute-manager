using System;
using System.ComponentModel.DataAnnotations;

namespace NIM.StudentResults.Dto
{
    public class CreateStudentResultDto
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
