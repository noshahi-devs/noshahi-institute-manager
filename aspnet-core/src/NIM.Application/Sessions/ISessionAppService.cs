using Abp.Application.Services;
using NIM.Sessions.Dto;
using System.Threading.Tasks;

namespace NIM.Sessions;

public interface ISessionAppService : IApplicationService
{
    Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
}
