// NIM.Application/Campuses/CampusAppService.cs
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using Microsoft.EntityFrameworkCore;
using NIM.Authorization;
using NIM.Campuses.Dto;
using NIM.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Linq.Dynamic.Core; // ✅ This is required for string-based OrderBy


namespace NIM.Campuses
{
    [AbpAuthorize(PermissionNames.Pages_Campuses)]
    public class CampusAppService : ApplicationService, ICampusAppService
    {
        private readonly IRepository<Campus, int> _campusRepository;

        public CampusAppService(IRepository<Campus, int> campusRepository)
        {
            _campusRepository = campusRepository;
        }

        [AbpAuthorize(PermissionNames.Pages_Campuses)]
        public async Task<CampusDto> Get(int id)
        {
            var campus = await _campusRepository.GetAsync(id);
            return ObjectMapper.Map<CampusDto>(campus);
        }

        [AbpAuthorize(PermissionNames.Pages_Campuses)]
        public async Task<PagedResultDto<CampusDto>> GetAll(PagedCampusResultRequestDto input)
        {
            var query = _campusRepository.GetAll()
                .WhereIf(!string.IsNullOrWhiteSpace(input.Keyword),
                    x => x.Name.Contains(input.Keyword) || x.Address.Contains(input.Keyword));

            var totalCount = await query.CountAsync();
            var items = await query
                .OrderBy(input.Sorting ?? "Id") // ✅ uses dynamic string
                .PageBy(input)
                .ToListAsync(); 

            return new PagedResultDto<CampusDto>(
                totalCount,
                ObjectMapper.Map<List<CampusDto>>(items)
            );
        }

        [AbpAuthorize(PermissionNames.Pages_Campuses_Create)]
        public async Task<CampusDto> Create(CreateCampusDto input)
        {
            var campus = ObjectMapper.Map<Campus>(input);
            await _campusRepository.InsertAsync(campus);
            await CurrentUnitOfWork.SaveChangesAsync();
            return ObjectMapper.Map<CampusDto>(campus);
        }

        [AbpAuthorize(PermissionNames.Pages_Campuses_Edit)]
        public async Task<CampusDto> Update(UpdateCampusDto input)
        {
            var campus = await _campusRepository.GetAsync(input.Id);
            ObjectMapper.Map(input, campus);
            await _campusRepository.UpdateAsync(campus);
            await CurrentUnitOfWork.SaveChangesAsync();
            return ObjectMapper.Map<CampusDto>(campus);
        }

        [AbpAuthorize(PermissionNames.Pages_Campuses_Delete)]
        public async Task Delete(int id)
        {
            await _campusRepository.DeleteAsync(id);
        }
    }
}