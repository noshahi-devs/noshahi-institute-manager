using Abp.Application.Services;
using Abp.Domain.Repositories;
using NIM.LeaveApplications.Dto;
using NIM.Entities;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using System.Linq;
using System;
using System.Linq.Dynamic.Core;
using Abp.Linq.Extensions;

namespace NIM.LeaveApplications
{
    public class LeaveApplicationAppService : AsyncCrudAppService<
        LeaveApplication,
        LeaveApplicationDto,
        int,
        PagedLeaveApplicationResultRequestDto,
        CreateLeaveApplicationDto,
        UpdateLeaveApplicationDto>, ILeaveApplicationAppService
    {
        public LeaveApplicationAppService(IRepository<LeaveApplication, int> repository)
            : base(repository)
        {
        }

        protected override IQueryable<LeaveApplication> CreateFilteredQuery(PagedLeaveApplicationResultRequestDto input)
        {
            return Repository.GetAll()
                .WhereIf(input.UserId.HasValue, l => l.UserId == input.UserId)
                .WhereIf(input.Status.HasValue, l => l.Status == input.Status)
                .WhereIf(input.PaymentStatus.HasValue, l => l.PaymentStatus == input.PaymentStatus)
                .WhereIf(input.StartDate.HasValue, l => l.StartDate >= input.StartDate.Value)
                .WhereIf(input.EndDate.HasValue, l => l.EndDate <= input.EndDate.Value);
        }
    }
}
