using System;
using Abp.Application.Services.Dto;

namespace NIM.Tests.Dto
{
    public class TestDto : EntityDto<int>
    {
        public string TestName { get; set; }
        public DateTime TestDate { get; set; }
        public int MaxMarks { get; set; }
        public int SectionId { get; set; }
        public long CreatedByUserId { get; set; }
    }
}
