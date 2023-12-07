using Microsoft.EntityFrameworkCore;
using Qwiik_BookingAgency.Models;

namespace Qwiik_BookingAgency.Context
{
    public class BookingDbContext : DbContext
    {
        public DbSet<Booking>? Bookings { get; set; }
        public DbSet<Customer>? Customer { get; set; }

        protected override void OnConfiguring (DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseCosmos(
                "https://kivlancosmosdb.documents.azure.com:443/",
                "SVKOlJru7jJdK3G8xsrjyc3u2XRj9IVMV7vh91jmAy1UU0LGwHrpIG4kKrzBzeM4BVs1R7rSzrQgACDbJziT9A==",
                "kivlancosmosdb"
                );
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Booking>()
                .ToContainer("Bookings")
                .HasPartitionKey(x => x.Id);

            modelBuilder.Entity<Customer>()
                .ToContainer("Customers")
                .HasPartitionKey(x => x.Id);
        }
    }
}
