using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using Microsoft.EntityFrameworkCore;
using NIM.Authorization;
using NIM.Entities;
using NIM.AccountantProfiles.Dto;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;
using NIM.Campuses;
using NIM.Users;
using Abp.AutoMapper;
using Microsoft.AspNetCore.Identity;
using NIM.Authorization.Users;
using NIM.Authorization.Roles;

namespace NIM.AccountantProfiles
{
    [AbpAuthorize(PermissionNames.Pages_AccountantProfiles)]
    public class AccountantAppService : ApplicationService, IAccountantAppService
    {
        private readonly NIM.Authorization.Users.UserManager _userManager;
        private readonly NIM.Authorization.Roles.RoleManager _roleManager;
        // Where:
        // using NIM.Authorization.Users;
        // using NIM.Authorization.Roles;
        // UserManager = UserManager<NIM.Authorization.Users.User>
        // RoleManager = RoleManager<NIM.Authorization.Roles.Role>

        private readonly IRepository<AccountantProfile, int> _accountantProfileRepository;
        private readonly IRepository<NIM.Authorization.Users.User, long> _userRepository;
        private readonly IRepository<Campus, int> _campusRepository;

        public AccountantAppService(
            IRepository<AccountantProfile, int> accountantProfileRepository,
            IRepository<NIM.Authorization.Users.User, long> userRepository,
            IRepository<Campus, int> campusRepository,
            UserManager userManager,
            RoleManager roleManager)
        {
            _accountantProfileRepository = accountantProfileRepository;
            _userRepository = userRepository;
            _campusRepository = campusRepository;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        [AbpAuthorize(PermissionNames.Pages_AccountantProfiles)]
        public async Task<AccountantProfileDto> Get(int id)
        {
            var profile = await _accountantProfileRepository
                .GetAllIncluding(p => p.User, p => p.Campus)
                .FirstOrDefaultAsync(p => p.Id == id);
            return ObjectMapper.Map<AccountantProfileDto>(profile);
        }

        [AbpAuthorize(PermissionNames.Pages_AccountantProfiles)]
        public async Task<PagedResultDto<AccountantProfileDto>> GetAll(PagedAccountantProfileResultRequestDto input)
        {
            var query = _accountantProfileRepository
                .GetAllIncluding(p => p.User, p => p.Campus)
                .WhereIf(!string.IsNullOrWhiteSpace(input.Keyword),
                    x => x.User.UserName.Contains(input.Keyword) ||
                         x.CNIC.Contains(input.Keyword));

            if (input.CampusId.HasValue)
                query = query.Where(x => x.CampusId == input.CampusId);
            if (input.IsActive.HasValue)
                query = query.Where(x => x.IsActive == input.IsActive);

            var totalCount = await query.CountAsync();
            var items = await query.ToListAsync();

            return new PagedResultDto<AccountantProfileDto>(
                totalCount,
                ObjectMapper.Map<List<AccountantProfileDto>>(items)
            );
        }

        [AbpAuthorize(PermissionNames.Pages_AccountantProfiles_Create)]
        public async Task<AccountantProfileDto> Create(CreateAccountantProfileDto input)
        {
            var profile = ObjectMapper.Map<AccountantProfile>(input);
            await _accountantProfileRepository.InsertAsync(profile);
            await CurrentUnitOfWork.SaveChangesAsync();
            return ObjectMapper.Map<AccountantProfileDto>(profile);
        }

        [AbpAuthorize(PermissionNames.Pages_AccountantProfiles_Edit)]
        public async Task<AccountantProfileDto> Update(UpdateAccountantProfileDto input)
        {
            var profile = await _accountantProfileRepository.GetAsync(input.Id);
            ObjectMapper.Map(input, profile);
            await _accountantProfileRepository.UpdateAsync(profile);
            await CurrentUnitOfWork.SaveChangesAsync();
            return ObjectMapper.Map<AccountantProfileDto>(profile);
        }

        [AbpAuthorize(PermissionNames.Pages_AccountantProfiles_Delete)]
        public async Task Delete(int id)
        {
            await _accountantProfileRepository.DeleteAsync(id);
        }

        [AbpAuthorize(PermissionNames.Pages_AccountantProfiles_Create)]
        public async Task<AccountantProfileDto> CreateAccountantAndUserAsync(Dto.CreateAccountantAndUserInput input)
        {
            // 1. Create User
            var user = new NIM.Authorization.Users.User
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

            // 2. Assign Accountant role
            var accountantRole = await _roleManager.Roles.FirstOrDefaultAsync(r => r.Name == "Accountant");
            if (accountantRole != null)
                await _userManager.AddToRoleAsync(user, accountantRole.Name);

            // 3. Create AccountantProfile
            var profile = new AccountantProfile
            {
                UserId = user.Id,
                CNIC = input.CNIC,
                DateOfJoining = input.DateOfJoining,
                CampusId = input.CampusId,
                IsActive = input.IsActive
            };
            await _accountantProfileRepository.InsertAsync(profile);
            await CurrentUnitOfWork.SaveChangesAsync();

            return ObjectMapper.Map<AccountantProfileDto>(profile);
        }
    }
}

