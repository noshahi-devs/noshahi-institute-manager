using Abp.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace NIM.Entities
{
    public class Campus : Entity<int>
    {
        public const int MaxNameLength = 128;
        public const int MaxAddressLength = 256;

        [Required]
        [StringLength(MaxNameLength)]
        public string Name { get; set; }

        [StringLength(MaxAddressLength)]
        public string Address { get; set; }

        // Parameterless constructor required by EF
        public Campus() { }

        public Campus(string name, string address)
        {
            Name = name;
            Address = address;
        }
    }
}