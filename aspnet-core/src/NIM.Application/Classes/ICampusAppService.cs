using Abp.Application.Services;
using Abp.Application.Services.Dto;
using NIM.Classes.Dto;
using System.Threading.Tasks;

namespace NIM.Classes
{
    public interface IClassAppService : IApplicationService
    {
        Task<ClassDto> Get(int id);
        Task<PagedResultDto<ClassDto>> GetAll(PagedClassResultRequestDto input);
        Task<ClassDto> Create(CreateClassDto input);
        Task<ClassDto> Update(UpdateClassDto input);
        Task Delete(int id);
    }
}