// NIM.Application/Campuses/ICampusAppService.cs
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using NIM.Campuses.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NIM.Campuses
{
    public interface ICampusAppService : IApplicationService
    {
        Task<CampusDto> Get(int id);
        Task<PagedResultDto<CampusDto>> GetAll(PagedCampusResultRequestDto input);
        Task<CampusDto> Create(CreateCampusDto input);
        Task<CampusDto> Update(UpdateCampusDto input);
        Task Delete(int id);
    }
}