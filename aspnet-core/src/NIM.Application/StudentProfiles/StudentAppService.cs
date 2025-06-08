using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using NIM.Authorization;
using NIM.Authorization.Roles;
using NIM.Authorization.Users;
using NIM.Entities;
using NIM.StudentProfiles.Dto;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Linq.Dynamic.Core;
using System;

namespace NIM.StudentProfiles
{
    [AbpAuthorize(PermissionNames.Pages_StudentProfiles)]
    public class StudentAppService : ApplicationService, IStudentAppService
    {
        private readonly IRepository<StudentProfile, int> _studentProfileRepository;
        private readonly IRepository<User, long> _userRepository;
        private readonly IRepository<Campus, int> _campusRepository;
        private readonly UserManager _userManager;
        private readonly RoleManager _roleManager;

        public StudentAppService(
            IRepository<StudentProfile, int> studentProfileRepository,
            IRepository<User, long> userRepository,
            IRepository<Campus, int> campusRepository,
            UserManager userManager,
            RoleManager roleManager)
        {
            _studentProfileRepository = studentProfileRepository;
            _userRepository = userRepository;
            _campusRepository = campusRepository;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        [AbpAuthorize(PermissionNames.Pages_StudentProfiles)]
        public async Task<StudentProfileDto> Get(int id)
        {
            var profile = await _studentProfileRepository
                .GetAllIncluding(p => p.User, p => p.Campus)
                .FirstOrDefaultAsync(p => p.Id == id);
            return ObjectMapper.Map<StudentProfileDto>(profile);
        }

        [AbpAuthorize(PermissionNames.Pages_StudentProfiles)]
        public async Task<PagedResultDto<StudentProfileDto>> GetAll(PagedStudentProfileResultRequestDto input)
        {
            var query = _studentProfileRepository
                .GetAllIncluding(p => p.User, p => p.Campus)
                .WhereIf(!string.IsNullOrWhiteSpace(input.Keyword),
                    x => x.User.UserName.Contains(input.Keyword) ||
                         x.RollNumber.Contains(input.Keyword) ||
                         x.CNIC.Contains(input.Keyword) ||
                         x.Campus.Name.Contains(input.Keyword))
                .WhereIf(input.CampusId.HasValue, x => x.CampusId == input.CampusId)
                .WhereIf(input.IsActive.HasValue, x => x.IsActive == input.IsActive);

            var totalCount = await query.CountAsync();
            var orderedQuery = string.IsNullOrEmpty(input.Keyword)
                ? query.OrderBy("User.UserName ASC")
                : query.OrderBy(input.Keyword);

            var items = await orderedQuery
                .PageBy(input)
                .ToListAsync();

            return new PagedResultDto<StudentProfileDto>(
                totalCount,
                ObjectMapper.Map<List<StudentProfileDto>>(items)
            );
        }

        [AbpAuthorize(PermissionNames.Pages_StudentProfiles_Create)]
        public async Task<StudentProfileDto> Create(CreateStudentProfileDto input)
        {
            var profile = ObjectMapper.Map<StudentProfile>(input);
            profile.ClassId = input.ClassId;
            profile.SectionId = input.SectionId;
            await _studentProfileRepository.InsertAsync(profile);
            await CurrentUnitOfWork.SaveChangesAsync();
            return ObjectMapper.Map<StudentProfileDto>(profile);
        }

        [AbpAuthorize(PermissionNames.Pages_StudentProfiles_Edit)]
        public async Task<StudentProfileDto> Update(UpdateStudentProfileDto input)
        {
            var profile = await _studentProfileRepository.GetAsync(input.Id);
            ObjectMapper.Map(input, profile);
            profile.ClassId = input.ClassId;
            profile.SectionId = input.SectionId;
            await _studentProfileRepository.UpdateAsync(profile);
            await CurrentUnitOfWork.SaveChangesAsync();
            return ObjectMapper.Map<StudentProfileDto>(profile);
        }

        [AbpAuthorize(PermissionNames.Pages_StudentProfiles_Delete)]
        public async Task Delete(int id)
        {
            await _studentProfileRepository.DeleteAsync(id);
        }

        [AbpAuthorize(PermissionNames.Pages_StudentProfiles_Create)]
        public async Task<StudentProfileDto> CreateStudentAndUserAsync(CreateStudentAndUserInput input)
        {
            // 1. Create User
            var user = new User
            {
                UserName = input.UserName,
                Name = input.Name,
                Surname = input.Surname,
                EmailAddress = input.EmailAddress,
                IsEmailConfirmed = true,
                IsActive = true
            };
            user.SetNormalizedNames();

            var userResult = await _userManager.CreateAsync(user, input.Password);
            if (!userResult.Succeeded)
                throw new Exception(string.Join("; ", userResult.Errors.Select(e => e.Description)));

            // 2. Assign Student role
            var studentRole = await _roleManager.Roles.FirstOrDefaultAsync(r => r.Name == "Student");
            if (studentRole != null)
                await _userManager.AddToRoleAsync(user, studentRole.Name);

            // 3. Create StudentProfile
            var profile = new StudentProfile
            {
                UserId = user.Id,
                RollNumber = input.RollNumber,
                EnrollmentDate = input.EnrollmentDate,
                LeaveDate = input.LeaveDate,
                CNIC = input.CNIC,
                CampusId = input.CampusId,
                ClassId = input.ClassId,
                SectionId = input.SectionId,
                IsActive = input.IsActive
            };
            await _studentProfileRepository.InsertAsync(profile);
            await CurrentUnitOfWork.SaveChangesAsync();

            return ObjectMapper.Map<StudentProfileDto>(profile);
        }
    }
}
