using Abp.Application.Services.Dto;

namespace NIM.Sections.Dto
{
    public class PagedSectionResultRequestDto : PagedAndSortedResultRequestDto
    {
        public string Keyword { get; set; }
        public int? ClassId { get; set; }
        public bool? IsActive { get; set; }
    }
}
