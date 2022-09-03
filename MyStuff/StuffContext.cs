using Microsoft.EntityFrameworkCore;
using MyStuff.Models;

namespace MyStuff
{
    public class StuffContext : DbContext
    {
        public DbSet<Location> Locations { get; set; }
        public DbSet<Storage> Storages { get; set; }
        public DbSet<Item> Items { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseSqlServer("Server=(localdb)\\mssqllocaldb; Database=GavPossessions; Trusted_connection=True").UseLazyLoadingProxies();
            base.OnConfiguring(builder);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Location>().HasData(
                new Location() { Id = 1, Name = "Bedroom", Image = ""},
                new Location() { Id = 2, Name = "Kitchen", Image = ""}, 
                new Location() { Id = 3, Name = "Bathroom", Image = ""}
                );
            builder.Entity<Storage>().HasData(
                new Storage() { Id = 1, Name = "Bed", Image = "", PlacementNotes = "For items placed on the bed", LocationId = 1 },
                new Storage() { Id = 2, Name = "Silverware Drawer", Image = "", PlacementNotes = "", LocationId = 2 },
                new Storage() { Id = 3, Name = "Cabinet", Image = "", PlacementNotes = "", LocationId = 3 }
                );
            builder.Entity<Item>().HasData(
                new Item() { Id = 1, Name = "Pillow", Description = "Main pillow", Image = "", PlacementNotes = "At the head of the bed", StorageId = 1},
                new Item() { Id = 2, Name = "Forks", Description = "Forks", Image = "", PlacementNotes = "In the silverware drawer", StorageId = 2}
                );
        }
    }
}
