using Microsoft.EntityFrameworkCore;
using Qwiik_BookingAgency.Models;

namespace Qwiik_BookingAgency.Context
{
    /// <summary>
    /// Db Context for Cosmos DB
    /// </summary>
    public class BookingDbContext : DbContext
    {
        /// <summary>
        /// Bookings DbSet
        /// </summary>
        public DbSet<Booking>? Bookings { get; set; }
        /// <summary>
        /// Customer DbSet
        /// </summary>
        public DbSet<Customer>? Customer { get; set; }

        /// <summary>
        /// Override OnConfiguring Method
        /// </summary>
        /// <param name="optionsBuilder"></param>
        protected override void OnConfiguring (DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseCosmos(
                "https://kivlancosmosdb.documents.azure.com:443/",
                "SVKOlJru7jJdK3G8xsrjyc3u2XRj9IVMV7vh91jmAy1UU0LGwHrpIG4kKrzBzeM4BVs1R7rSzrQgACDbJziT9A==",
                "KivlanCosmosDB"
                );
        }

        /// <summary>
        /// Override OnModelCreating Method
        /// </summary>
        /// <param name="modelBuilder"></param>
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
