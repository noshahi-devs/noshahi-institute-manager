using Abp.Domain.Entities;
using System;
using NIM.Authorization.Users;

namespace NIM.Entities
{
    public class AccountantProfile : Entity<int>
    {
        public decimal MonthlySalary { get; set; }

        public long UserId { get; set; }
        public int CampusId { get; set; }
        public string CNIC { get; set; }
        public DateTime DateOfJoining { get; set; }
        public bool IsActive { get; set; }

        public virtual User User { get; set; }
        public virtual Campus Campus { get; set; }
    }
}
