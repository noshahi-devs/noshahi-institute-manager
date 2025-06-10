using System.ComponentModel.DataAnnotations;
using NIM.Entities; // Make sure this using is at the top


namespace NIM.Campuses.Dto
{
    public class CreateCampusDto
    {
        [Required]
        [StringLength(Campus.MaxNameLength)]
        public string Name { get; set; }

        [StringLength(Campus.MaxAddressLength)]
        public string Address { get; set; }
    }
}