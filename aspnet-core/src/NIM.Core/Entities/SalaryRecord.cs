using Abp.Domain.Entities;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using NIM.Authorization.Users;

namespace NIM.Entities
{
    public class SalaryRecord : Entity<int>
    {
        public long UserId { get; set; }  // FK to User
        public decimal SalaryAmount { get; set; } // Copy from profile
        public DateTime Month { get; set; }
        public bool IsPaid { get; set; }
        public DateTime? PaidDate { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }
    }
}
