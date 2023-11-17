using Microsoft.EntityFrameworkCore;

namespace RestaurantFaves.Models.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Order> Orders { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Order>().HasData(
            new Order { id = 1, description = "Whole Grain Tuscan Fresca", restaurant = "Olive Garden", rating = 4, orderAgain = true },
            new Order { id = 2, description = "McChicken", restaurant = "McDonalds", rating = 3, orderAgain = false },
            new Order { id = 3, description = "Lobster Thermidor", restaurant = "Red Lobster", rating = 5, orderAgain = true },
            new Order { id = 4, description = "Mac & Cheese", restaurant = "Olive Garden", rating = 2, orderAgain = false },
            new Order { id = 5, description = "Big Mac", restaurant = "McDonalds", rating = 4, orderAgain = true },
            new Order { id = 6, description = "Oysters", restaurant = "Red Lobster", rating = 3, orderAgain = false },
            new Order { id = 7, description = "Spaghetti", restaurant = "Olive Garden", rating = 5, orderAgain = true },
            new Order { id = 8, description = "McSalad", restaurant = "McDonalds", rating = 1, orderAgain = false },
            new Order { id = 9, description = "Shrimp Alfredo", restaurant = "Red Lobster", rating = 4, orderAgain = true },
            new Order { id = 10, description = "Breadsticks", restaurant = "Olive Garden", rating = 3, orderAgain = false }
            );
    }
}
