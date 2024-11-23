using Microsoft.EntityFrameworkCore;
using Users.API.Entities;

namespace Users.API.Context;

public class DatabaseContext : DbContext
{
    public DbSet<PermissionEntity> Permissions { get; set; }
    public DbSet<UserEntity> Users { get; set; }
    public DbSet<UserPermissionsEntity> UsersPermissions { get; set; }
    
    public DatabaseContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<UserEntity>()
            .HasMany(u => u.UserPermissions)
            .WithOne(up => up.User)
            .HasForeignKey(up => up.PermissionId);

        modelBuilder.Entity<PermissionEntity>()
            .HasMany(p => p.UsersPermissions)
            .WithOne(up => up.Permission)
            .HasForeignKey(up => up.PermissionId);
        
        base.OnModelCreating(modelBuilder);
    }
}