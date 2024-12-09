using Microsoft.EntityFrameworkCore;
using SweaterProductionOrders.Models;

namespace SweaterProductionOrders.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Order> ProductionOrders { get; set; }
    }
}
