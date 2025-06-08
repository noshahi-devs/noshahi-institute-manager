using Abp.Application.Services.Dto;

namespace NIM.StudentResults.Dto
{
    public class PagedStudentResultResultRequestDto : PagedResultRequestDto
    {
        public int? TestId { get; set; }
        public long? StudentUserId { get; set; }
        public string Grade { get; set; }
    }
}
