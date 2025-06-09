using System;
using System.ComponentModel.DataAnnotations;

namespace NIM.StudentProfiles.Dto
{
    public class CreateStudentProfileDto
    {
        [Required]
        public long UserId { get; set; }
        [Required]
        public int CampusId { get; set; }
        [Required]
        [StringLength(20)]
        public string RollNumber { get; set; }
        [Required]
        public DateTime EnrollmentDate { get; set; }
        public DateTime? LeaveDate { get; set; }
        [StringLength(15)]
        public string CNIC { get; set; }
        public bool IsActive { get; set; } = true;

        [Required]
        public int ClassId { get; set; }
        [Required]
        public int SectionId { get; set; }
    }
}
