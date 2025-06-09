using System;
using System.ComponentModel.DataAnnotations;
using Abp.Application.Services.Dto;

namespace NIM.AccountantProfiles.Dto
{
    public class UpdateAccountantProfileDto : EntityDto<int>
    {
        [Required]
        public long UserId { get; set; }
        [Required]
        public int CampusId { get; set; }
        [Required]
        [StringLength(15)]
        public string CNIC { get; set; }
        [Required]
        public DateTime DateOfJoining { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
