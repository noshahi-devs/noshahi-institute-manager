using Abp.Application.Services.Dto;

namespace NIM.StudentProfiles.Dto
{
    public class PagedStudentProfileResultRequestDto : PagedResultRequestDto
    {
        public string Keyword { get; set; }
        public int? CampusId { get; set; }
        public bool? IsActive { get; set; }
        public int? ClassId { get; set; }
        public int? SectionId { get; set; }
    }
}
