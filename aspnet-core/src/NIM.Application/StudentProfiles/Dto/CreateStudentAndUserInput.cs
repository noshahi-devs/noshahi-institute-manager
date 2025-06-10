using System;
using System.ComponentModel.DataAnnotations;

namespace NIM.StudentProfiles.Dto
{
    public class CreateStudentAndUserInput
    {
        // User fields
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }
        [Required]
        public string EmailAddress { get; set; }
        [Required]
        public string Password { get; set; }

        // StudentProfile fields
        [Required]
        [StringLength(20)]
        public string RollNumber { get; set; }
        [Required]
        public DateTime EnrollmentDate { get; set; }
        public DateTime? LeaveDate { get; set; }
        [StringLength(15)]
        public string CNIC { get; set; }
        [Required]
        public int CampusId { get; set; }
        public bool IsActive { get; set; } = true;

        [Required]
        public int ClassId { get; set; }
        [Required]
        public int SectionId { get; set; }
    }
}
