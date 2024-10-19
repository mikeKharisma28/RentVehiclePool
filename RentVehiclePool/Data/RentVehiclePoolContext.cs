using Microsoft.EntityFrameworkCore;
using RentVehiclePool.Models;

namespace RentVehiclePool.Data
{
    public class RentVehiclePoolContext : DbContext
    {
        public RentVehiclePoolContext(DbContextOptions<RentVehiclePoolContext> options) : base(options) 
        { 
        
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Role> Roles { get; set; }

        public DbSet<Vehicle> Vehicles { get; set; }

        public DbSet<Transaction> Transactions { get; set; }

        public DbSet<Approval> Approvals { get; set; }

        public DbSet<ApprovalDetail> ApprovalDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("Users");
            modelBuilder.Entity<Role>().ToTable("Roles");
            modelBuilder.Entity<Vehicle>().ToTable("Vehicles");
            modelBuilder.Entity<Transaction>().ToTable("Transactions");
            modelBuilder.Entity<Approval>().ToTable("Approvals");
            modelBuilder.Entity<ApprovalDetail>().ToTable("ApprovalDetails");
        }
    }
}
