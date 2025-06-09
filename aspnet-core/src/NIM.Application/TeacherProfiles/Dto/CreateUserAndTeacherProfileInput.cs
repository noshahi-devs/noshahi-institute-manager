using System;
using System.ComponentModel.DataAnnotations;

namespace NIM.TeacherProfiles.Dto
{
    public class CreateUserAndTeacherProfileInput
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

        // TeacherProfile fields
        [Required]
        [StringLength(15)]
        public string CNIC { get; set; }
        [Required]
        public DateTime DateOfJoining { get; set; }
        [Required]
        public int CampusId { get; set; }
        [StringLength(100)]
        public string Qualification { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
