using Microsoft.EntityFrameworkCore;
using WhereWasI.Models;

namespace WhereWasI.Data
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {

        }

        public DbSet<Item> Items { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Anime> Animes { get; set; }
        public DbSet<ItemCategory> ItemCategories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.Entity<Item>().ToTable("Item");
            modelBuilder.Entity<Category>().ToTable("Category");
            modelBuilder.Entity<Anime>().ToTable("Anime");

            modelBuilder.Entity<ItemCategory>().ToTable("ItemCategory");
            modelBuilder.Entity<ItemCategory>()
                .HasKey(ic => new { ic.ItemID, ic.CategoryID });
            modelBuilder.Entity<ItemCategory>()
                .HasOne(ic => ic.Item)
                .WithMany(ic => ic.ItemCategories)
                .HasForeignKey(ic => ic.ItemID);
            modelBuilder.Entity<ItemCategory>()
                .HasOne(ic => ic.Category)
                .WithMany(ic => ic.ItemCategories)
                .HasForeignKey(ic => ic.CategoryID);
        }
    }
}
