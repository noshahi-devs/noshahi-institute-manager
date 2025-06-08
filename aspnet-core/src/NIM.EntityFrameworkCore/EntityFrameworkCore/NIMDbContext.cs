using Abp.Zero.EntityFrameworkCore;
using NIM.Authorization.Roles;
using NIM.Authorization.Users;
using NIM.MultiTenancy;
using Microsoft.EntityFrameworkCore;
using NIM.Entities; // Make sure this using is at the top

namespace NIM.EntityFrameworkCore;

public class NIMDbContext : AbpZeroDbContext<Tenant, Role, User, NIMDbContext>
{
    // Entity Framework Core DbSets
    //Campuses
    public DbSet<Campus> Campuses { get; set; }

    public NIMDbContext(DbContextOptions<NIMDbContext> options)
        : base(options)
    {

    }
}
