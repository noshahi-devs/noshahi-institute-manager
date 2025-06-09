using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NIM.Entities
{
    public class Class : FullAuditedEntity<int>
    {
        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        public string Description { get; set; }

        // Foreign Key to Campus
        [ForeignKey("Campus")]
        public int CampusId { get; set; }
        public virtual Campus Campus { get; set; }

        public bool IsActive { get; set; } = true;
    }
}
