using System.ComponentModel.DataAnnotations;
using NIM.Entities;

namespace NIM.Classes.Dto
{
    public class CreateClassDto
    {
        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        public string Description { get; set; }

        [Required]
        public int CampusId { get; set; }

        public bool IsActive { get; set; } = true;
    }
}