using Microsoft.EntityFrameworkCore;
using RentVehiclePool.Models;

namespace RentVehiclePool.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) 
        { 
        
        }
        public DbSet<User> Users { get; set; }

        public DbSet<Roles> Roles { get; set; }

        public DbSet<Vehicle> Vehicles { get; set; }

        public DbSet<Transaction> Transactions { get; set; }

        public DbSet<Approval> Approvals { get; set; }

        public DbSet<ApprovalDetail> ApprovalDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("Users");
            modelBuilder.Entity<Vehicle>().ToTable("Vehicles");
            modelBuilder.Entity<Transaction>().ToTable("Transactions");
            modelBuilder.Entity<Approval>().ToTable("Approvals");
            modelBuilder.Entity<ApprovalDetail>().ToTable("ApprovalDetails");

            modelBuilder.Entity<Roles>().HasData(new Roles
            {
                RoleId = 1,
                RoleName = "Admin",
                IsActive = true,
                Description = "Dapat melakukan transaksi untuk sewa / pengambilan kendaraan.",
                CreatedBy = "EF Migration",
                CreatedDate = DateTime.Now,
                UpdatedBy = "EF Migration",
                UpdatedDate = DateTime.Now
            });

            modelBuilder.Entity<Roles>().HasData(new Roles
            {
                RoleId = 2,
                RoleName = "Approval 1",
                IsActive = true,
                Description = "Melakukan approval level 1",
                CreatedBy = "EF Migration",
                CreatedDate = DateTime.Now,
                UpdatedBy = "EF Migration",
                UpdatedDate = DateTime.Now
            });

            modelBuilder.Entity<Roles>().HasData(new Roles
            {
                RoleId = 3,
                RoleName = "Approval 2",
                IsActive = true,
                Description = "Melakukan approval level 2",
                CreatedBy = "EF Migration",
                CreatedDate = DateTime.Now,
                UpdatedBy = "EF Migration",
                UpdatedDate = DateTime.Now
            });
        }
    }
}
