using Abp.Application.Services.Dto;
using NIM.Entities; // Make sure this using is at the top

namespace NIM.Campuses.Dto
{
    public class PagedCampusResultRequestDto : PagedAndSortedResultRequestDto
    {
        public string Keyword { get; set; }
    }
}

