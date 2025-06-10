using Abp.Application.Services;
using NIM.LeaveApplications.Dto;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;

namespace NIM.LeaveApplications
{
    public interface ILeaveApplicationAppService : IAsyncCrudAppService<
        LeaveApplicationDto,
        int,
        PagedLeaveApplicationResultRequestDto,
        CreateLeaveApplicationDto,
        UpdateLeaveApplicationDto>
    {
    }
}
