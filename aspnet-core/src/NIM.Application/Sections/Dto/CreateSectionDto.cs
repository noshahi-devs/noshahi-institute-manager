using System.ComponentModel.DataAnnotations;

namespace NIM.Sections.Dto
{
    public class CreateSectionDto
    {
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        public string Description { get; set; }
        [Required]
        public int ClassId { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
