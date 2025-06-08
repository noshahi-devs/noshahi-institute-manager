using Abp.Application.Services;
using Abp.Domain.Repositories;
using NIM.StudentAttendances.Dto;
using NIM.Entities;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using System.Linq;
using System;
using System.Linq.Dynamic.Core;
using Abp.Linq.Extensions;

namespace NIM.StudentAttendances
{
    public class StudentAttendanceAppService : AsyncCrudAppService<
        StudentAttendance,
        StudentAttendanceDto,
        int,
        PagedStudentAttendanceResultRequestDto,
        CreateStudentAttendanceDto,
        UpdateStudentAttendanceDto>, IStudentAttendanceAppService
    {
        public StudentAttendanceAppService(IRepository<StudentAttendance, int> repository)
            : base(repository)
        {
        }

        protected override IQueryable<StudentAttendance> CreateFilteredQuery(PagedStudentAttendanceResultRequestDto input)
        {
            return Repository.GetAll()
                .WhereIf(input.TenantId.HasValue, a => a.TenantId == input.TenantId)
                .WhereIf(input.UserId.HasValue, a => a.UserId == input.UserId)
                .WhereIf(input.Status.HasValue, a => a.Status == input.Status)
                .WhereIf(input.FromDate.HasValue, a => a.AttendanceDate >= input.FromDate.Value)
                .WhereIf(input.ToDate.HasValue, a => a.AttendanceDate <= input.ToDate.Value);
        }
    }
}
