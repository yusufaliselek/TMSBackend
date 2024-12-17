using Microsoft.EntityFrameworkCore;
using System.Reflection;
using TaskManagementSystemBackend.DataAccess.Entities;
using TaskManagementSystemBackend.DataAccess.SeedData;

namespace TaskManagementSystemBackend.DataAccess
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Organization> Organizations { get; set; }
        public DbSet<Token> Tokens { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<OrganizationProjectTask> OrganizationProjectTasks { get; set; }
        public DbSet<OrganizationProjectTaskUpdate> OrganizationProjectTaskUpdates { get; set; }
        public DbSet<OrganizationUser> OrganizationUsers { get; set; }
        public DbSet<OrganizationUserRole> OrganizationUserRoles { get; set; }
        public DbSet<OrganizationRole> OrganizationRoles { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<OrganizationRolePermission> OrganizationRolePermissions { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Permission>().HasData(PermissionSeed.GetPermissions());

        }
    }
}
