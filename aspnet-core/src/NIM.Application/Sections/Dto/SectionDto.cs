using Abp.Application.Services.Dto;

namespace NIM.Sections.Dto
{
    public class SectionDto : EntityDto<int>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int ClassId { get; set; }
        public string ClassName { get; set; } // For display
        public bool IsActive { get; set; }
    }
}
