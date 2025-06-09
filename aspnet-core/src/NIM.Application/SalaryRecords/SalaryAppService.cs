using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using Microsoft.EntityFrameworkCore;
using NIM.Authorization;
using NIM.Entities;
using NIM.SalaryRecords.Dto;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;
using System.Linq.Dynamic.Core;
using Abp.AutoMapper;
using NIM.Authorization.Users;


namespace NIM.SalaryRecords
{
    [AbpAuthorize(PermissionNames.Pages_Users)] // You can refine permissions as needed
    public class SalaryAppService : ApplicationService, ISalaryAppService
    {
        private readonly IRepository<SalaryRecord, int> _salaryRepository;
        private readonly IRepository<User, long> _userRepository;

        public SalaryAppService(
            IRepository<SalaryRecord, int> salaryRepository,
            IRepository<User, long> userRepository)
        {
            _salaryRepository = salaryRepository;
            _userRepository = userRepository;
        }

        public async Task<SalaryRecordDto> Get(int id)
        {
            var record = await _salaryRepository.GetAllIncluding(r => r.User)
                .FirstOrDefaultAsync(r => r.Id == id);
            return ObjectMapper.Map<SalaryRecordDto>(record);
        }

        public async Task<PagedResultDto<SalaryRecordDto>> GetAll(PagedSalaryRecordResultRequestDto input)
        {
            var query = _salaryRepository.GetAllIncluding(r => r.User)
                .WhereIf(input.UserId.HasValue, r => r.UserId == input.UserId)
                .WhereIf(input.IsPaid.HasValue, r => r.IsPaid == input.IsPaid)
                .WhereIf(input.Month.HasValue, r => r.Month == input.Month.Value);

            var totalCount = await query.CountAsync();
            var items = await query.ToListAsync();

            return new PagedResultDto<SalaryRecordDto>(
                totalCount,
                ObjectMapper.Map<List<SalaryRecordDto>>(items)
            );
        }

        public async Task<SalaryRecordDto> Create(CreateSalaryRecordDto input)
        {
            var record = ObjectMapper.Map<SalaryRecord>(input);
            await _salaryRepository.InsertAsync(record);
            await CurrentUnitOfWork.SaveChangesAsync();
            return ObjectMapper.Map<SalaryRecordDto>(record);
        }

        public async Task<SalaryRecordDto> Update(UpdateSalaryRecordDto input)
        {
            var record = await _salaryRepository.GetAsync(input.Id);
            ObjectMapper.Map(input, record);
            await _salaryRepository.UpdateAsync(record);
            await CurrentUnitOfWork.SaveChangesAsync();
            return ObjectMapper.Map<SalaryRecordDto>(record);
        }

        public async Task Delete(int id)
        {
            await _salaryRepository.DeleteAsync(id);
        }
    }
}
