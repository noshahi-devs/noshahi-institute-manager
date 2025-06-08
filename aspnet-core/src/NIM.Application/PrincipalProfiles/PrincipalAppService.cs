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
using NIM.PrincipalProfiles.Dto;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Linq.Dynamic.Core;
using System;

namespace NIM.PrincipalProfiles
{
    [AbpAuthorize(PermissionNames.Pages_Principals)]
    public class PrincipalAppService : ApplicationService, IPrincipalAppService
    {
        private readonly IRepository<PrincipalProfile, int> _principalProfileRepository;
        private readonly IRepository<User, long> _userRepository;
        private readonly IRepository<Campus, int> _campusRepository;
        private readonly UserManager _userManager;
        private readonly RoleManager _roleManager;

        public PrincipalAppService(
            IRepository<PrincipalProfile, int> principalProfileRepository,
            IRepository<User, long> userRepository,
            IRepository<Campus, int> campusRepository,
            UserManager userManager,
            RoleManager roleManager)
        {
            _principalProfileRepository = principalProfileRepository;
            _userRepository = userRepository;
            _campusRepository = campusRepository;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        [AbpAuthorize(PermissionNames.Pages_Principals)]
        public async Task<PrincipalProfileDto> Get(int id)
        {
            var profile = await _principalProfileRepository
                .GetAllIncluding(p => p.User, p => p.Campus)
                .FirstOrDefaultAsync(p => p.Id == id);
            return ObjectMapper.Map<PrincipalProfileDto>(profile);
        }

        [AbpAuthorize(PermissionNames.Pages_Principals)]
        public async Task<PagedResultDto<PrincipalProfileDto>> GetAll(PagedPrincipalProfileResultRequestDto input)
        {
            var query = _principalProfileRepository
                .GetAllIncluding(p => p.User, p => p.Campus)
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

            return new PagedResultDto<PrincipalProfileDto>(
                totalCount,
                ObjectMapper.Map<List<PrincipalProfileDto>>(items)
            );
        }

        [AbpAuthorize(PermissionNames.Pages_Principals_Create)]
        public async Task<PrincipalProfileDto> Create(CreatePrincipalProfileDto input)
        {
            var profile = ObjectMapper.Map<PrincipalProfile>(input);
            await _principalProfileRepository.InsertAsync(profile);
            await CurrentUnitOfWork.SaveChangesAsync();
            return ObjectMapper.Map<PrincipalProfileDto>(profile);
        }

        [AbpAuthorize(PermissionNames.Pages_Principals_Edit)]
        public async Task<PrincipalProfileDto> Update(UpdatePrincipalProfileDto input)
        {
            var profile = await _principalProfileRepository.GetAsync(input.Id);
            ObjectMapper.Map(input, profile);
            await _principalProfileRepository.UpdateAsync(profile);
            await CurrentUnitOfWork.SaveChangesAsync();
            return ObjectMapper.Map<PrincipalProfileDto>(profile);
        }

        [AbpAuthorize(PermissionNames.Pages_Principals_Delete)]
        public async Task Delete(int id)
        {
            await _principalProfileRepository.DeleteAsync(id);
        }

        [AbpAuthorize(PermissionNames.Pages_Principals_Create)]
        public async Task<PrincipalProfileDto> CreatePrincipalAndUserAsync(CreatePrincipalAndUserInput input)
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

            // 2. Assign Principal role
            var principalRole = await _roleManager.Roles.FirstOrDefaultAsync(r => r.Name == "Principal");
            if (principalRole != null)
                await _userManager.AddToRoleAsync(user, principalRole.Name);

            // 3. Create PrincipalProfile
            var profile = new PrincipalProfile
            {
                UserId = user.Id,
                CNIC = input.CNIC,
                DateOfJoining = input.DateOfJoining,
                CampusId = input.CampusId,
                IsActive = input.IsActive
            };
            await _principalProfileRepository.InsertAsync(profile);
            await CurrentUnitOfWork.SaveChangesAsync();

            return ObjectMapper.Map<PrincipalProfileDto>(profile);
        }
    }
}
