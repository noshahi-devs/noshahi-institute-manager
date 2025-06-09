using Abp.Application.Services;
using Abp.Application.Services.Dto;
using NIM.Sections.Dto;
using System.Threading.Tasks;

namespace NIM.Sections
{
    public interface ISectionAppService : IApplicationService
    {
        Task<SectionDto> Get(int id);
        Task<PagedResultDto<SectionDto>> GetAll(PagedSectionResultRequestDto input);
        Task<SectionDto> Create(CreateSectionDto input);
        Task<SectionDto> Update(UpdateSectionDto input);
        Task Delete(int id);
    }
}
