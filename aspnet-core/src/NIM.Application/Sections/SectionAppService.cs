using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using Microsoft.EntityFrameworkCore;
using NIM.Authorization;
using NIM.Sections.Dto;
using NIM.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Linq.Dynamic.Core;

namespace NIM.Sections
{
    [AbpAuthorize(PermissionNames.Pages_Sections)]
    public class SectionAppService : ApplicationService, ISectionAppService
    {
        private readonly IRepository<Section, int> _sectionRepository;
        private readonly IRepository<Class, int> _classRepository;

        public SectionAppService(
            IRepository<Section, int> sectionRepository,
            IRepository<Class, int> classRepository)
        {
            _sectionRepository = sectionRepository;
            _classRepository = classRepository;
        }

        [AbpAuthorize(PermissionNames.Pages_Sections)]
        public async Task<SectionDto> Get(int id)
        {
            var section = await _sectionRepository
                .GetAllIncluding(s => s.Class)
                .FirstOrDefaultAsync(s => s.Id == id);
            return ObjectMapper.Map<SectionDto>(section);
        }

        [AbpAuthorize(PermissionNames.Pages_Sections)]
        public async Task<PagedResultDto<SectionDto>> GetAll(PagedSectionResultRequestDto input)
        {
            var query = _sectionRepository
                .GetAllIncluding(s => s.Class)
                .WhereIf(!string.IsNullOrWhiteSpace(input.Keyword),
                    x => x.Name.Contains(input.Keyword) ||
                         x.Description.Contains(input.Keyword) ||
                         x.Class.Name.Contains(input.Keyword))
                .WhereIf(input.ClassId.HasValue, x => x.ClassId == input.ClassId)
                .WhereIf(input.IsActive.HasValue, x => x.IsActive == input.IsActive);

            var totalCount = await query.CountAsync();
            var orderedQuery = string.IsNullOrEmpty(input.Sorting)
                ? query.OrderBy("Name ASC")
                : query.OrderBy(input.Sorting);

            var items = await orderedQuery
                .PageBy(input)
                .ToListAsync();

            return new PagedResultDto<SectionDto>(
                totalCount,
                ObjectMapper.Map<List<SectionDto>>(items)
            );
        }

        [AbpAuthorize(PermissionNames.Pages_Sections_Create)]
        public async Task<SectionDto> Create(CreateSectionDto input)
        {
            var section = ObjectMapper.Map<Section>(input);
            await _sectionRepository.InsertAsync(section);
            await CurrentUnitOfWork.SaveChangesAsync();
            return ObjectMapper.Map<SectionDto>(section);
        }

        [AbpAuthorize(PermissionNames.Pages_Sections_Edit)]
        public async Task<SectionDto> Update(UpdateSectionDto input)
        {
            var section = await _sectionRepository.GetAsync(input.Id);
            ObjectMapper.Map(input, section);
            await _sectionRepository.UpdateAsync(section);
            await CurrentUnitOfWork.SaveChangesAsync();
            return ObjectMapper.Map<SectionDto>(section);
        }

        [AbpAuthorize(PermissionNames.Pages_Sections_Delete)]
        public async Task Delete(int id)
        {
            await _sectionRepository.DeleteAsync(id);
        }
    }
}
