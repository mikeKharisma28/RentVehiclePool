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

        //public override int SaveChanges()
        //{
        //    DateTime now = DateTime.Now;
        //    AutoCreatedDate(now);
        //    AutoUpdatedDate(now);

        //    return base.SaveChanges();
        //}

        //private void AutoCreatedDate(DateTime time)
        //{
        //    foreach (var entity in ChangeTracker.Entries<User>()
        //            .Where(e => e.State == EntityState.Added)
        //            .Select(e => e.Entity))
        //    {
        //        entity.CreatedDate = time;
        //        entity.UpdatedDate = time;
        //    }

        //    foreach (var entity in ChangeTracker.Entries<Role>()
        //            .Where(e => e.State == EntityState.Added)
        //            .Select(e => e.Entity))
        //    {
        //        entity.CreatedDate = time;
        //        entity.UpdatedDate = time;
        //    }

        //    foreach (var entity in ChangeTracker.Entries<Vehicle>()
        //            .Where(e => e.State == EntityState.Added)
        //            .Select(e => e.Entity))
        //    {
        //        entity.CreatedDate = time;
        //        entity.UpdatedDate = time;
        //    }

        //    foreach (var entity in ChangeTracker.Entries<Transaction>()
        //            .Where(e => e.State == EntityState.Added)
        //            .Select(e => e.Entity))
        //    {
        //        entity.CreatedDate = time;
        //        entity.UpdatedDate = time;
        //    }

        //    foreach (var entity in ChangeTracker.Entries<Approval>()
        //            .Where(e => e.State == EntityState.Added)
        //            .Select(e => e.Entity))
        //    {
        //        entity.CreatedDate = time;
        //        entity.UpdatedDate = time;
        //    }

        //    foreach (var entity in ChangeTracker.Entries<ApprovalDetail>()
        //            .Where(e => e.State == EntityState.Added)
        //            .Select(e => e.Entity))
        //    {
        //        entity.CreatedDate = time;
        //        entity.UpdatedDate = time;
        //    }
        //}

        //private void AutoUpdatedDate(DateTime time)
        //{
        //    foreach (var entity in ChangeTracker.Entries<User>()
        //            .Where(e => e.State == EntityState.Modified)
        //            .Select(e => e.Entity))
        //    {
        //        entity.UpdatedDate = time;
        //    }

        //    foreach (var entity in ChangeTracker.Entries<Role>()
        //            .Where(e => e.State == EntityState.Modified)
        //            .Select(e => e.Entity))
        //    {
        //        entity.UpdatedDate = time;
        //    }

        //    foreach (var entity in ChangeTracker.Entries<Vehicle>()
        //            .Where(e => e.State == EntityState.Modified)
        //            .Select(e => e.Entity))
        //    {
        //        entity.UpdatedDate = time;
        //    }

        //    foreach (var entity in ChangeTracker.Entries<Transaction>()
        //            .Where(e => e.State == EntityState.Modified)
        //            .Select(e => e.Entity))
        //    {
        //        entity.UpdatedDate = time;
        //    }

        //    foreach (var entity in ChangeTracker.Entries<Approval>()
        //            .Where(e => e.State == EntityState.Modified)
        //            .Select(e => e.Entity))
        //    {
        //        entity.UpdatedDate = time;
        //    }

        //    foreach (var entity in ChangeTracker.Entries<ApprovalDetail>()
        //            .Where(e => e.State == EntityState.Modified)
        //            .Select(e => e.Entity))
        //    {
        //        entity.UpdatedDate = time;
        //    }
        //}
    }
}
