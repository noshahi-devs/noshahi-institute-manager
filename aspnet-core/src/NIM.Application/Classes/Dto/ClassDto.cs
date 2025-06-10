using Abp.Application.Services.Dto;
using NIM.Entities;

namespace NIM.Classes.Dto
{
    public class ClassDto : EntityDto<int>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int CampusId { get; set; }
        public string CampusName { get; set; } // For display purposes
        public bool IsActive { get; set; }
    }
}