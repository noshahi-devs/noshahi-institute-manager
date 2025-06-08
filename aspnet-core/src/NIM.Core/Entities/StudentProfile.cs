using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using NIM.Authorization.Users;
namespace NIM.Entities
{
    public class StudentProfile : Entity<int>
    {
        public long UserId { get; set; }
        public int CampusId { get; set; }
        public string RollNumber { get; set; }
        public DateTime EnrollmentDate { get; set; }
        public DateTime? LeaveDate { get; set; }
        public string CNIC { get; set; }
        public bool IsActive { get; set; }
        public decimal MonthlyFee { get; set; }

        public int ClassId { get; set; }
        public int SectionId { get; set; }

        public virtual User User { get; set; }
        public virtual Campus Campus { get; set; }
        public virtual Class Class { get; set; }
        public virtual Section Section { get; set; }
        public virtual ICollection<StudentFee> FeeRecords { get; set; }
    }
}
