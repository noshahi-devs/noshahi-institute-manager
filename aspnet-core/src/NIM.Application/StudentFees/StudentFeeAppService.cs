using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using Microsoft.EntityFrameworkCore;
using NIM.Authorization;
using NIM.Entities;
using NIM.StudentFees.Dto;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;

namespace NIM.StudentFees
{
    [AbpAuthorize(PermissionNames.Pages_StudentProfiles)] // You may want a separate permission for fees
    public class StudentFeeAppService : ApplicationService, IStudentFeeAppService
    {
        private readonly IRepository<StudentFee, int> _studentFeeRepository;
        private readonly IRepository<StudentProfile, int> _studentProfileRepository;

        public StudentFeeAppService(
            IRepository<StudentFee, int> studentFeeRepository,
            IRepository<StudentProfile, int> studentProfileRepository)
        {
            _studentFeeRepository = studentFeeRepository;
            _studentProfileRepository = studentProfileRepository;
        }

        public async Task<StudentFeeDto> Get(int id)
        {
            var fee = await _studentFeeRepository.GetAllIncluding(f => f.StudentProfile)
                .FirstOrDefaultAsync(f => f.Id == id);
            return ObjectMapper.Map<StudentFeeDto>(fee);
        }

        public async Task<PagedResultDto<StudentFeeDto>> GetAll(PagedStudentFeeResultRequestDto input)
        {
            var query = _studentFeeRepository.GetAllIncluding(f => f.StudentProfile)
                .WhereIf(input.StudentProfileId.HasValue, f => f.StudentProfileId == input.StudentProfileId)
                .WhereIf(!string.IsNullOrWhiteSpace(input.FeeType), f => f.FeeType == input.FeeType)
                .WhereIf(input.IsPaid.HasValue, f => f.IsPaid == input.IsPaid);

            var totalCount = await query.CountAsync();
            var items = await query.ToListAsync();

            return new PagedResultDto<StudentFeeDto>(
                totalCount,
                ObjectMapper.Map<List<StudentFeeDto>>(items)
            );
        }

        public async Task<StudentFeeDto> Create(CreateStudentFeeDto input)
        {
            var fee = ObjectMapper.Map<StudentFee>(input);
            await _studentFeeRepository.InsertAsync(fee);
            await CurrentUnitOfWork.SaveChangesAsync();
            return ObjectMapper.Map<StudentFeeDto>(fee);
        }

        public async Task<StudentFeeDto> Update(UpdateStudentFeeDto input)
        {
            var fee = await _studentFeeRepository.GetAsync(input.Id);
            ObjectMapper.Map(input, fee);
            await _studentFeeRepository.UpdateAsync(fee);
            await CurrentUnitOfWork.SaveChangesAsync();
            return ObjectMapper.Map<StudentFeeDto>(fee);
        }

        public async Task Delete(int id)
        {
            await _studentFeeRepository.DeleteAsync(id);
        }
    }
}
