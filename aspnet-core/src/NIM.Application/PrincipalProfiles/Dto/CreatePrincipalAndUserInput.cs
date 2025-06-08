using System;
using System.ComponentModel.DataAnnotations;

namespace NIM.PrincipalProfiles.Dto
{
    public class CreatePrincipalAndUserInput
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

        // PrincipalProfile fields
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
