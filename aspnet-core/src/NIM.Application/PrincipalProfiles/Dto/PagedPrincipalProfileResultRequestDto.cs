using Abp.Application.Services.Dto;

namespace NIM.PrincipalProfiles.Dto
{
    public class PagedPrincipalProfileResultRequestDto : PagedAndSortedResultRequestDto
    {
        public string Keyword { get; set; }
        public int? CampusId { get; set; }
        public bool? IsActive { get; set; }
    }
}
