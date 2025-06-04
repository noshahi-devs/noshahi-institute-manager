using Abp.Application.Services;
using NIM.Authorization.Accounts.Dto;
using System.Threading.Tasks;

namespace NIM.Authorization.Accounts;

public interface IAccountAppService : IApplicationService
{
    Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

    Task<RegisterOutput> Register(RegisterInput input);
}
