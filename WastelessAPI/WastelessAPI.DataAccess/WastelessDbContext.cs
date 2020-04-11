using Microsoft.EntityFrameworkCore;
using WastelessAPI.DataAccess.Models;

namespace WastelessAPI.DataAccess
{
    public class WastelessDbContext : DbContext
    {
        public WastelessDbContext(DbContextOptions<WastelessDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<GroceryItem> GroceryItems { get; set; }
        public DbSet<Groceries> GroceryLists { get; set; }
        public DbSet<Charity> Charities { get; set; }
        public DbSet<Donation> Donations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GroceryItem>()
                .HasOne<Groceries>(item => item.GroceryList)
                .WithMany(list => list.Items)
                .HasForeignKey(item => item.ListId);
        }
    }
}