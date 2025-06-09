using Abp.Application.Services.Dto;
using System;

namespace NIM.SmsNotifications.Dto
{
    public class PagedSmsNotificationResultRequestDto : PagedResultRequestDto
    {
        public long? UserId { get; set; }
        public string Status { get; set; }
        public DateTime? FromSentTime { get; set; }
        public DateTime? ToSentTime { get; set; }
    }
}
