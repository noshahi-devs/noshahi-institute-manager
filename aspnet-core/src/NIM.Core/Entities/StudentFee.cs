using Abp.Domain.Entities;
using System;

namespace NIM.Entities
{
    public class StudentFee : Entity<int>
    {
        public int StudentProfileId { get; set; }
        public decimal Amount { get; set; }
        public string FeeType { get; set; } // Tuition, Admission, etc.
        public DateTime IssuedDate { get; set; }
        public DateTime DueDate { get; set; }
        public bool IsPaid { get; set; }
        public DateTime? PaidDate { get; set; }
        public string Remarks { get; set; }

        public virtual StudentProfile StudentProfile { get; set; }
    }
}
