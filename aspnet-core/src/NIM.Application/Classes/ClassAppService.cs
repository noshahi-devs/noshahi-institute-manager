using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using Microsoft.EntityFrameworkCore;
using NIM.Authorization;
using NIM.Classes.Dto;
using NIM.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Linq.Dynamic.Core; // ✅ This is required for string-based OrderBy

namespace NIM.Classes
{
    [AbpAuthorize(PermissionNames.Pages_Classes)]
    public class ClassAppService : ApplicationService, IClassAppService
    {
        private readonly IRepository<Class, int> _classRepository;
        private readonly IRepository<Campus, int> _campusRepository;

        public ClassAppService(
            IRepository<Class, int> classRepository,
            IRepository<Campus, int> campusRepository)
        {
            _classRepository = classRepository;
            _campusRepository = campusRepository;
        }

        [AbpAuthorize(PermissionNames.Pages_Classes)]
        public async Task<ClassDto> Get(int id)
        {
            var @class = await _classRepository
                .GetAllIncluding(c => c.Campus)
                .FirstOrDefaultAsync(c => c.Id == id);
                
            return ObjectMapper.Map<ClassDto>(@class);
        }

        [AbpAuthorize(PermissionNames.Pages_Classes)]
        public async Task<PagedResultDto<ClassDto>> GetAll(PagedClassResultRequestDto input)
        {
            var query = _classRepository
                .GetAllIncluding(c => c.Campus)
                .WhereIf(!string.IsNullOrWhiteSpace(input.Keyword),
                    x => x.Name.Contains(input.Keyword) || 
                         x.Description.Contains(input.Keyword) ||
                         x.Campus.Name.Contains(input.Keyword))
                .WhereIf(input.CampusId.HasValue, x => x.CampusId == input.CampusId)
                .WhereIf(input.IsActive.HasValue, x => x.IsActive == input.IsActive);

            var totalCount = await query.CountAsync();
            var items = await query
                .OrderBy(input.Sorting ?? "Name ASC")  // Add ASC for explicit ordering
                .PageBy(input)
                .ToListAsync(); 

            return new PagedResultDto<ClassDto>(
                totalCount,
                ObjectMapper.Map<List<ClassDto>>(items)
            );
        }

        [AbpAuthorize(PermissionNames.Pages_Classes_Create)]
        public async Task<ClassDto> Create(CreateClassDto input)
        {
            var @class = ObjectMapper.Map<Class>(input);
            await _classRepository.InsertAsync(@class);
            await CurrentUnitOfWork.SaveChangesAsync();
            return ObjectMapper.Map<ClassDto>(@class);
        }

        [AbpAuthorize(PermissionNames.Pages_Classes_Edit)]
        public async Task<ClassDto> Update(UpdateClassDto input)
        {
            var @class = await _classRepository.GetAsync(input.Id);
            ObjectMapper.Map(input, @class);
            await _classRepository.UpdateAsync(@class);
            await CurrentUnitOfWork.SaveChangesAsync();
            return ObjectMapper.Map<ClassDto>(@class);
        }

        [AbpAuthorize(PermissionNames.Pages_Classes_Delete)]
        public async Task Delete(int id)
        {
            await _classRepository.DeleteAsync(id);
        }
    }
}