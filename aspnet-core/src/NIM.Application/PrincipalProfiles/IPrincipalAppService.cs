using Abp.Application.Services;
using Abp.Application.Services.Dto;
using System.Threading.Tasks;
using NIM.PrincipalProfiles.Dto;

namespace NIM.PrincipalProfiles
{
    public interface IPrincipalAppService : IApplicationService
    {
        Task<PrincipalProfileDto> Get(int id);
        Task<PagedResultDto<PrincipalProfileDto>> GetAll(PagedPrincipalProfileResultRequestDto input);
        Task<PrincipalProfileDto> Create(CreatePrincipalProfileDto input);
        Task<PrincipalProfileDto> Update(UpdatePrincipalProfileDto input);
        Task Delete(int id);
        Task<PrincipalProfileDto> CreatePrincipalAndUserAsync(CreatePrincipalAndUserInput input);
    }
}
