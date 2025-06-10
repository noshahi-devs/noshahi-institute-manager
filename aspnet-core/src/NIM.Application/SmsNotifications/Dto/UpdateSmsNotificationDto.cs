using System;
using System.ComponentModel.DataAnnotations;
using Abp.Application.Services.Dto;

namespace NIM.SmsNotifications.Dto
{
    public class UpdateSmsNotificationDto : EntityDto<int>
    {
        [Required]
        public long UserId { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        [Required]
        public string Message { get; set; }
        [Required]
        public DateTime SentTime { get; set; }
        [Required]
        public string Status { get; set; }
    }
}
