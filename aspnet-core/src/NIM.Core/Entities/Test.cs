using Abp.Domain.Entities;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace NIM.Entities
{
    public class Test : Entity<int>
    {
        public string TestName { get; set; }
        public DateTime TestDate { get; set; }
        public int MaxMarks { get; set; }

        public int SectionId { get; set; }
        [ForeignKey("SectionId")]
        public Section Section { get; set; }

        public long CreatedByUserId { get; set; }
    }
}
