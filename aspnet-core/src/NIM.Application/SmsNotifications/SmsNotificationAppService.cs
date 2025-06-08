using Abp.Application.Services;
using Abp.Domain.Repositories;
using NIM.SmsNotifications.Dto;
using NIM.Entities;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using System.Linq;
using System;
using System.Linq.Dynamic.Core;
using Abp.Linq.Extensions;

namespace NIM.SmsNotifications
{
    public class SmsNotificationAppService : AsyncCrudAppService<
        SmsNotification,
        SmsNotificationDto,
        int,
        PagedSmsNotificationResultRequestDto,
        CreateSmsNotificationDto,
        UpdateSmsNotificationDto>, ISmsNotificationAppService
    {
        public SmsNotificationAppService(IRepository<SmsNotification, int> repository)
            : base(repository)
        {
        }

        protected override IQueryable<SmsNotification> CreateFilteredQuery(PagedSmsNotificationResultRequestDto input)
        {
            return Repository.GetAll()
                .WhereIf(input.UserId.HasValue, n => n.UserId == input.UserId)
                .WhereIf(!string.IsNullOrWhiteSpace(input.Status), n => n.Status == input.Status)
                .WhereIf(input.FromSentTime.HasValue, n => n.SentTime >= input.FromSentTime.Value)
                .WhereIf(input.ToSentTime.HasValue, n => n.SentTime <= input.ToSentTime.Value);
        }
    }
}
