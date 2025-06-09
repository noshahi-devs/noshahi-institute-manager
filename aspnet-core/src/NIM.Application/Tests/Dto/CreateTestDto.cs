using System;
using System.ComponentModel.DataAnnotations;

namespace NIM.Tests.Dto
{
    public class CreateTestDto
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
