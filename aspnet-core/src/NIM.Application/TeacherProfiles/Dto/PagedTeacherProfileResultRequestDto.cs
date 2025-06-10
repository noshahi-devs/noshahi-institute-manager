using Abp.Application.Services.Dto;

namespace NIM.TeacherProfiles.Dto
{
    public class PagedTeacherProfileResultRequestDto : PagedAndSortedResultRequestDto
    {
        public string Keyword { get; set; }
        public int? CampusId { get; set; }
        public bool? IsActive { get; set; }
    }
}
