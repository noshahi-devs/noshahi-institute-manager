using System.ComponentModel.DataAnnotations;
using Abp.Application.Services.Dto; // Ensure this is included
using NIM.Entities; // For Campus.MaxNameLength


namespace NIM.Campuses.Dto
{
    public class UpdateCampusDto : EntityDto<int>
    {
        [Required]
        [StringLength(Campus.MaxNameLength)]
        public string Name { get; set; }

        [StringLength(Campus.MaxAddressLength)]
        public string Address { get; set; }
    }
}