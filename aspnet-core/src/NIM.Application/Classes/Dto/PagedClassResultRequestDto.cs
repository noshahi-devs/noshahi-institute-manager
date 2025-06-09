using Abp.Application.Services.Dto;

namespace NIM.Classes.Dto
{
    public class PagedClassResultRequestDto : PagedAndSortedResultRequestDto
    {
        public string Keyword { get; set; }
        public int? CampusId { get; set; }
        public bool? IsActive { get; set; }
    }
}