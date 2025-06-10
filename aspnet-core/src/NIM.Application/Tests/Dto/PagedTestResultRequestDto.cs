using Abp.Application.Services.Dto;
using System;

namespace NIM.Tests.Dto
{
    public class PagedTestResultRequestDto : PagedResultRequestDto
    {
        public string TestName { get; set; }
        public int? SectionId { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public long? CreatedByUserId { get; set; }
    }
}
