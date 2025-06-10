using Abp.Application.Services;
using NIM.Tests.Dto;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;

namespace NIM.Tests
{
    public interface ITestAppService : IAsyncCrudAppService<
        TestDto,
        int,
        PagedTestResultRequestDto,
        CreateTestDto,
        UpdateTestDto>
    {
    }
}
