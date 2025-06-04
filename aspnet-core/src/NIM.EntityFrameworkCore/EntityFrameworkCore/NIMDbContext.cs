using Abp.Zero.EntityFrameworkCore;
using NIM.Authorization.Roles;
using NIM.Authorization.Users;
using NIM.MultiTenancy;
using Microsoft.EntityFrameworkCore;

namespace NIM.EntityFrameworkCore;

public class NIMDbContext : AbpZeroDbContext<Tenant, Role, User, NIMDbContext>
{
    /* Define a DbSet for each entity of the application */

    public NIMDbContext(DbContextOptions<NIMDbContext> options)
        : base(options)
    {
    }
}
