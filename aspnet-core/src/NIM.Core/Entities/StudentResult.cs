using Abp.Domain.Entities;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using NIM.Authorization.Users;

namespace NIM.Entities
{
    public class StudentResult : Entity<int>
    {
        public int TestId { get; set; }
        [ForeignKey("TestId")]
        public Test Test { get; set; }

        public long StudentUserId { get; set; }
        [ForeignKey("StudentUserId")]
        public User Student { get; set; }

        public int ObtainedMarks { get; set; }

        [NotMapped]
        public decimal Percentage => Test != null && Test.MaxMarks > 0 ? (decimal)ObtainedMarks / Test.MaxMarks * 100 : 0;

        public string Grade { get; set; } // Optional: auto-calculate based on % range
    }
}
