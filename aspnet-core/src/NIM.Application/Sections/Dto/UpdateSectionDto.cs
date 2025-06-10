using System.ComponentModel.DataAnnotations;
using Abp.Application.Services.Dto;

namespace NIM.Sections.Dto
{
    public class UpdateSectionDto : EntityDto<int>
    {
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        public string Description { get; set; }
        [Required]
        public int ClassId { get; set; }
        public bool IsActive { get; set; }
    }
}
