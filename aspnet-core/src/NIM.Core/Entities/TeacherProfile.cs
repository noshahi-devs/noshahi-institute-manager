using Abp.Domain.Entities.Auditing;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using NIM.Authorization.Users;
namespace NIM.Entities
{
    public class TeacherProfile : FullAuditedEntity<int>
    {
        [Required]
        [ForeignKey("User")]
        public long UserId { get; set; }
        public virtual User User { get; set; }

        [Required]
        [StringLength(15)]
        public string CNIC { get; set; }

        [Required]
        public DateTime DateOfJoining { get; set; }

        [ForeignKey("Campus")]
        public int CampusId { get; set; }
        public virtual Campus Campus { get; set; }

        [StringLength(100)]
        public string Qualification { get; set; }

        public bool IsActive { get; set; } = true;
    }
}
