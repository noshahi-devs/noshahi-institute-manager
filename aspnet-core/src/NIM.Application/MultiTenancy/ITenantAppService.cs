using Abp.Application.Services;
using NIM.MultiTenancy.Dto;

namespace NIM.MultiTenancy;

public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedTenantResultRequestDto, CreateTenantDto, TenantDto>
{
}

