using AutoMapper;
using NIM.Entities;

namespace NIM.SmsNotifications.Dto
{
    public class SmsNotificationMapProfile : Profile
    {
        public SmsNotificationMapProfile()
        {
            CreateMap<SmsNotification, SmsNotificationDto>();
            CreateMap<CreateSmsNotificationDto, SmsNotification>();
            CreateMap<UpdateSmsNotificationDto, SmsNotification>();
        }
    }
}
