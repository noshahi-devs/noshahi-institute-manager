using Abp.Application.Services;
using NIM.SmsNotifications.Dto;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;

namespace NIM.SmsNotifications
{
    public interface ISmsNotificationAppService : IAsyncCrudAppService<
        SmsNotificationDto,
        int,
        PagedSmsNotificationResultRequestDto,
        CreateSmsNotificationDto,
        UpdateSmsNotificationDto>
    {
    }
}
