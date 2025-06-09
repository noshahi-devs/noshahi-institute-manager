using Abp.Application.Services;
using NIM.StaffAttendances.Dto;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;

namespace NIM.StaffAttendances
{
    public interface IStaffAttendanceAppService : IAsyncCrudAppService<
        StaffAttendanceDto,
        int,
        PagedStaffAttendanceResultRequestDto,
        CreateStaffAttendanceDto,
        UpdateStaffAttendanceDto>
    {
    }
}
