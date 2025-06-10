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
using NIM.TeacherProfiles.Dto;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Linq.Dynamic.Core;
using System;

namespace NIM.TeacherProfiles
{
    [AbpAuthorize(PermissionNames.Pages_TeacherProfiles)]
    public class TeacherProfileAppService : ApplicationService, ITeacherProfileAppService
    {
        private readonly IRepository<TeacherProfile, int> _teacherProfileRepository;
        private readonly IRepository<User, long> _userRepository;
        private readonly IRepository<Campus, int> _campusRepository;
        private readonly UserManager _userManager;
        private readonly RoleManager _roleManager;

        public TeacherProfileAppService(
            IRepository<TeacherProfile, int> teacherProfileRepository,
            IRepository<User, long> userRepository,
            IRepository<Campus, int> campusRepository,
            UserManager userManager,
            RoleManager roleManager)
        {
            _teacherProfileRepository = teacherProfileRepository;
            _userRepository = userRepository;
            _campusRepository = campusRepository;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        [AbpAuthorize(PermissionNames.Pages_TeacherProfiles)]
        public async Task<TeacherProfileDto> Get(int id)
        {
            var profile = await _teacherProfileRepository
                .GetAllIncluding(tp => tp.User, tp => tp.Campus)
                .FirstOrDefaultAsync(tp => tp.Id == id);
            return ObjectMapper.Map<TeacherProfileDto>(profile);
        }

        [AbpAuthorize(PermissionNames.Pages_TeacherProfiles)]
        public async Task<PagedResultDto<TeacherProfileDto>> GetAll(PagedTeacherProfileResultRequestDto input)
        {
            var query = _teacherProfileRepository
                .GetAllIncluding(tp => tp.User, tp => tp.Campus)
                .WhereIf(!string.IsNullOrWhiteSpace(input.Keyword),
                    x => x.User.UserName.Contains(input.Keyword) ||
                         x.CNIC.Contains(input.Keyword) ||
                         x.Campus.Name.Contains(input.Keyword))
                .WhereIf(input.CampusId.HasValue, x => x.CampusId == input.CampusId)
                .WhereIf(input.IsActive.HasValue, x => x.IsActive == input.IsActive);

            var totalCount = await query.CountAsync();
            var orderedQuery = string.IsNullOrEmpty(input.Sorting)
                ? query.OrderBy("User.UserName ASC")
                : query.OrderBy(input.Sorting);

            var items = await orderedQuery
                .PageBy(input)
                .ToListAsync();

            return new PagedResultDto<TeacherProfileDto>(
                totalCount,
                ObjectMapper.Map<List<TeacherProfileDto>>(items)
            );
        }

        [AbpAuthorize(PermissionNames.Pages_TeacherProfiles_Create)]
        public async Task<TeacherProfileDto> Create(CreateTeacherProfileDto input)
        {
            var profile = ObjectMapper.Map<TeacherProfile>(input);
            await _teacherProfileRepository.InsertAsync(profile);
            await CurrentUnitOfWork.SaveChangesAsync();
            return ObjectMapper.Map<TeacherProfileDto>(profile);
        }

        [AbpAuthorize(PermissionNames.Pages_TeacherProfiles_Edit)]
        public async Task<TeacherProfileDto> Update(UpdateTeacherProfileDto input)
        {
            var profile = await _teacherProfileRepository.GetAsync(input.Id);
            ObjectMapper.Map(input, profile);
            await _teacherProfileRepository.UpdateAsync(profile);
            await CurrentUnitOfWork.SaveChangesAsync();
            return ObjectMapper.Map<TeacherProfileDto>(profile);
        }

        [AbpAuthorize(PermissionNames.Pages_TeacherProfiles_Delete)]
        public async Task Delete(int id)
        {
            await _teacherProfileRepository.DeleteAsync(id);
        }

        [AbpAuthorize(PermissionNames.Pages_TeacherProfiles_Create)]
        public async Task<TeacherProfileDto> CreateUserAndTeacherProfile(CreateUserAndTeacherProfileInput input)
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

            // 2. Assign Teacher role
            var teacherRole = await _roleManager.Roles.FirstOrDefaultAsync(r => r.Name == "Teacher");
            if (teacherRole != null)
                await _userManager.AddToRoleAsync(user, teacherRole.Name);

            // 3. Create TeacherProfile
            var profile = new TeacherProfile
            {
                UserId = user.Id,
                CNIC = input.CNIC,
                DateOfJoining = input.DateOfJoining,
                CampusId = input.CampusId,
                Qualification = input.Qualification,
                IsActive = input.IsActive
            };
            await _teacherProfileRepository.InsertAsync(profile);
            await CurrentUnitOfWork.SaveChangesAsync();

            return ObjectMapper.Map<TeacherProfileDto>(profile);
        }
    }
}
