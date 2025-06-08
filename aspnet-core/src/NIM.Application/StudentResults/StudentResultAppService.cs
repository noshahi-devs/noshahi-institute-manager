using Abp.Application.Services;
using Abp.Domain.Repositories;
using NIM.StudentResults.Dto;
using NIM.Entities;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using System.Linq;
using System;
using System.Linq.Dynamic.Core;
using Abp.Linq.Extensions;

namespace NIM.StudentResults
{
    public class StudentResultAppService : AsyncCrudAppService<
        StudentResult,
        StudentResultDto,
        int,
        PagedStudentResultResultRequestDto,
        CreateStudentResultDto,
        UpdateStudentResultDto>, IStudentResultAppService
    {
        public StudentResultAppService(IRepository<StudentResult, int> repository)
            : base(repository)
        {
        }

        protected override IQueryable<StudentResult> CreateFilteredQuery(PagedStudentResultResultRequestDto input)
        {
            return Repository.GetAll()
                .WhereIf(input.TestId.HasValue, r => r.TestId == input.TestId)
                .WhereIf(input.StudentUserId.HasValue, r => r.StudentUserId == input.StudentUserId)
                .WhereIf(!string.IsNullOrWhiteSpace(input.Grade), r => r.Grade == input.Grade);
        }
    }
}
