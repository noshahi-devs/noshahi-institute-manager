using Abp.Application.Services;
using Abp.Domain.Repositories;
using NIM.Tests.Dto;
using NIM.Entities;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using System.Linq;
using System;
using System.Linq.Dynamic.Core;
using Abp.Linq.Extensions;

namespace NIM.Tests
{
    public class TestAppService : AsyncCrudAppService<
        Test,
        TestDto,
        int,
        PagedTestResultRequestDto,
        CreateTestDto,
        UpdateTestDto>, ITestAppService
    {
        public TestAppService(IRepository<Test, int> repository)
            : base(repository)
        {
        }

        protected override IQueryable<Test> CreateFilteredQuery(PagedTestResultRequestDto input)
        {
            return Repository.GetAll()
                .WhereIf(!string.IsNullOrWhiteSpace(input.TestName), t => t.TestName.Contains(input.TestName))
                .WhereIf(input.SectionId.HasValue, t => t.SectionId == input.SectionId)
                .WhereIf(input.FromDate.HasValue, t => t.TestDate >= input.FromDate.Value)
                .WhereIf(input.ToDate.HasValue, t => t.TestDate <= input.ToDate.Value)
                .WhereIf(input.CreatedByUserId.HasValue, t => t.CreatedByUserId == input.CreatedByUserId);
        }
    }
}
