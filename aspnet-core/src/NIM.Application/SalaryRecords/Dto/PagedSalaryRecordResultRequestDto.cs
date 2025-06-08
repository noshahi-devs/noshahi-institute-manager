using Abp.Application.Services.Dto;
using System;

namespace NIM.SalaryRecords.Dto
{
    public class PagedSalaryRecordResultRequestDto : PagedResultRequestDto
    {
        public long? UserId { get; set; }
        public bool? IsPaid { get; set; }
        public DateTime? Month { get; set; }
    }
}
