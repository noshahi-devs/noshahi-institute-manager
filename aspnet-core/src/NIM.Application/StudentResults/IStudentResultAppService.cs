using Abp.Application.Services;
using NIM.StudentResults.Dto;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;

namespace NIM.StudentResults
{
    public interface IStudentResultAppService : IAsyncCrudAppService<
        StudentResultDto,
        int,
        PagedStudentResultResultRequestDto,
        CreateStudentResultDto,
        UpdateStudentResultDto>
    {
    }
}
