using System;
using System.ComponentModel.DataAnnotations;

namespace NIM.AccountantProfiles.Dto
{
    public class CreateAccountantAndUserInput
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

        // AccountantProfile fields
        [Required]
        [StringLength(15)]
        public string CNIC { get; set; }
        [Required]
        public DateTime DateOfJoining { get; set; }
        [Required]
        public int CampusId { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
