using Abp.Domain.Entities;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using NIM.Authorization.Users;

namespace NIM.Entities
{
    public class SmsNotification : Entity<int>
    {
        public long UserId { get; set; }  // Parent or student
        public string PhoneNumber { get; set; }  // To whom SMS was sent
        public string Message { get; set; }
        public DateTime SentTime { get; set; }
        public string Status { get; set; } // Success, Failed, Pending

        [ForeignKey("UserId")]
        public User User { get; set; }
    }
}
