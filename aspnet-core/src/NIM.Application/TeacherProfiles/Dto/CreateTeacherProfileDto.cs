using System;
using System.ComponentModel.DataAnnotations;

namespace NIM.TeacherProfiles.Dto
{
    public class CreateTeacherProfileDto
    {
        [Required]
        public long UserId { get; set; }

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
