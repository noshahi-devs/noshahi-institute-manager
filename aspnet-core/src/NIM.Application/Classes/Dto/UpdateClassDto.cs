using System.ComponentModel.DataAnnotations;
using Abp.Application.Services.Dto;

namespace NIM.Classes.Dto
{
    public class UpdateClassDto : EntityDto<int>
    {
        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        public string Description { get; set; }

        [Required]
        public int CampusId { get; set; }

        public bool IsActive { get; set; }
    }
}