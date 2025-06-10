using Abp.Application.Services;
using Abp.Domain.Repositories;
using NIM.StaffAttendances.Dto;
using NIM.Entities;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using System.Linq;
using System;
using System.Linq.Dynamic.Core;
using Abp.Linq.Extensions;

namespace NIM.StaffAttendances
{
    public class StaffAttendanceAppService : AsyncCrudAppService<
        StaffAttendance,
        StaffAttendanceDto,
        int,
        PagedStaffAttendanceResultRequestDto,
        CreateStaffAttendanceDto,
        UpdateStaffAttendanceDto>, IStaffAttendanceAppService
    {
        public StaffAttendanceAppService(IRepository<StaffAttendance, int> repository)
            : base(repository)
        {
        }

        protected override IQueryable<StaffAttendance> CreateFilteredQuery(PagedStaffAttendanceResultRequestDto input)
        {
            return Repository.GetAll()
                .WhereIf(input.UserId.HasValue, a => a.UserId == input.UserId)
                .WhereIf(input.FromDate.HasValue, a => a.CheckInTime >= input.FromDate.Value)
                .WhereIf(input.ToDate.HasValue, a => a.CheckInTime <= input.ToDate.Value);
        }
    }
}
