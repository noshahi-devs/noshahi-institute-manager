using Abp.Zero.EntityFrameworkCore;
using NIM.Authorization.Roles;
using NIM.Authorization.Users;
using NIM.MultiTenancy;
using Microsoft.EntityFrameworkCore;
using NIM.Entities;

namespace NIM.EntityFrameworkCore;

public class NIMDbContext : AbpZeroDbContext<Tenant, Role, User, NIMDbContext>
{
    // Entity Framework Core DbSets
    public DbSet<Campus> Campuses { get; set; }
    public DbSet<Class> Classes { get; set; } // Also add this line for your Class entity
    public DbSet<Section> Sections { get; set; } // Add this line for your Section entity
    public DbSet<TeacherProfile> TeacherProfiles { get; set; } // Add this line for your TeacherProfile entity

    public NIMDbContext(DbContextOptions<NIMDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Class → Campus foreign key relationship
        modelBuilder.Entity<Class>(entity =>
        {
            entity.HasOne(d => d.Campus)
                  .WithMany()
                  .HasForeignKey(d => d.CampusId)
                  .OnDelete(DeleteBehavior.Restrict);
        });

        // TeacherProfile → User and Campus foreign key relationships
        modelBuilder.Entity<TeacherProfile>(entity =>
        {
            entity.HasOne(tp => tp.User)
                  .WithMany()
                  .HasForeignKey(tp => tp.UserId)
                  .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(tp => tp.Campus)
                  .WithMany()
                  .HasForeignKey(tp => tp.CampusId)
                  .OnDelete(DeleteBehavior.Restrict);
        });

        // Section → Class foreign key relationship
        modelBuilder.Entity<Section>(entity =>
        {
            entity.HasOne(d => d.Class)
                  .WithMany()
                  .HasForeignKey(d => d.ClassId)
                  .OnDelete(DeleteBehavior.Restrict);
        });
    }
}
