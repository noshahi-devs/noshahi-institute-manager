using Abp.Application.Services;
using NIM.StudentAttendances.Dto;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;

namespace NIM.StudentAttendances
{
    public interface IStudentAttendanceAppService : IAsyncCrudAppService<
        StudentAttendanceDto,
        int,
        PagedStudentAttendanceResultRequestDto,
        CreateStudentAttendanceDto,
        UpdateStudentAttendanceDto>
    {
    }
}
