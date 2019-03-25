using Microsoft.EntityFrameworkCore;
using OrderReceiver.Domain.Entities;

namespace OrderReceiver.Data.Context
{
    public class ORContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies().UseSqlServer(@"Server=orderreceiver.database.windows.net;Database=ORDB;User ID=johseffer;Password=Brazilian@321!;Trusted_Connection=False;Encrypt=True;");
        }
    }

}
