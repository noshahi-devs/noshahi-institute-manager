using System;
using Abp.Application.Services.Dto;

namespace NIM.SmsNotifications.Dto
{
    public class SmsNotificationDto : EntityDto<int>
    {
        public long UserId { get; set; }
        public string PhoneNumber { get; set; }
        public string Message { get; set; }
        public DateTime SentTime { get; set; }
        public string Status { get; set; }
    }
}
