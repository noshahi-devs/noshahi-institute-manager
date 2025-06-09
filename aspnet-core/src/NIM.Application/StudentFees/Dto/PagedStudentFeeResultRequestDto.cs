using Abp.Application.Services.Dto;

namespace NIM.StudentFees.Dto
{
    public class PagedStudentFeeResultRequestDto : PagedResultRequestDto
    {
        public int? StudentProfileId { get; set; }
        public string FeeType { get; set; }
        public bool? IsPaid { get; set; }
    }
}
