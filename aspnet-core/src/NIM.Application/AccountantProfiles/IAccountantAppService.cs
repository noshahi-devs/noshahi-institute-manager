using Abp.Application.Services;
using Abp.Application.Services.Dto;
using System.Threading.Tasks;
using NIM.AccountantProfiles.Dto;

namespace NIM.AccountantProfiles
{
    public interface IAccountantAppService : IApplicationService
    {
        Task<AccountantProfileDto> Get(int id);
        Task<PagedResultDto<AccountantProfileDto>> GetAll(PagedAccountantProfileResultRequestDto input);
        Task<AccountantProfileDto> Create(CreateAccountantProfileDto input);
        Task<AccountantProfileDto> Update(UpdateAccountantProfileDto input);
        Task Delete(int id);
        Task<AccountantProfileDto> CreateAccountantAndUserAsync(CreateAccountantAndUserInput input);
    }
}
