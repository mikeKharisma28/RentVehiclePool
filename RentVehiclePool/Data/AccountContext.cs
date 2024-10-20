using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RentVehiclePool.Models;

namespace RentVehiclePool.Data
{
    public class AccountContext : IdentityDbContext<User>
    {
        public AccountContext(DbContextOptions options) : base(options)
        {

        }
    }
}
