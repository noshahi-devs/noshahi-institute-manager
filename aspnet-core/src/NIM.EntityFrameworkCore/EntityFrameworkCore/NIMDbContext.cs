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
    public DbSet<PrincipalProfile> PrincipalProfiles { get; set; } // Add this line for your PrincipalProfile entity
    public DbSet<AccountantProfile> AccountantProfiles { get; set; } // Add this line for your AccountantProfile entity
    public DbSet<StudentProfile> StudentProfiles { get; set; } // Add this line for your StudentProfile entity
    public DbSet<StudentFee> StudentFees { get; set; } // Add this line for your StudentFee entity
    public DbSet<SalaryRecord> SalaryRecords { get; set; } // Add this line for your SalaryRecord entity
    public DbSet<LeaveApplication> LeaveApplications { get; set; } // Add this line for your LeaveApplication entity
    public DbSet<StaffAttendance> StaffAttendances { get; set; } // Add this line for your StaffAttendance entity
    public DbSet<StudentAttendance> StudentAttendances { get; set; } // Add this line for your StudentAttendance entity

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

        modelBuilder.Entity<StudentProfile>()
            .HasOne(s => s.Section)
            .WithMany()
            .HasForeignKey(s => s.SectionId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<StudentFee>()
            .HasOne(f => f.StudentProfile)
            .WithMany(s => s.FeeRecords)
            .HasForeignKey(f => f.StudentProfileId)
            .OnDelete(DeleteBehavior.Restrict);

        // TeacherProfile → User and Campus foreign key relationships

        // PrincipalProfile → User and Campus foreign key relationships
        modelBuilder.Entity<PrincipalProfile>(entity =>
        {
            entity.HasOne(p => p.User)
                  .WithMany()
                  .HasForeignKey(p => p.UserId)
                  .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(p => p.Campus)
                  .WithMany()
                  .HasForeignKey(p => p.CampusId)
                  .OnDelete(DeleteBehavior.Restrict);
        });

        // PrincipalProfile → User and Campus foreign key relationships
        modelBuilder.Entity<PrincipalProfile>(entity =>
        {
            entity.HasOne(p => p.User)
                  .WithMany()
                  .HasForeignKey(p => p.UserId)
                  .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(p => p.Campus)
                  .WithMany()
                  .HasForeignKey(p => p.CampusId)
                  .OnDelete(DeleteBehavior.Restrict);
        });
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
