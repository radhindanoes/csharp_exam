using Microsoft.EntityFrameworkCore;

namespace WeddingPlannerRadhin.Models
{
    public class WeddingPlannerRadhinContext : DbContext
    {
        // base() calls the parent class' constructor passing the "options" parameter along
        public WeddingPlannerRadhinContext(DbContextOptions options) : base(options) { }
        // "dishes (name of the table in my sql" table is represented by this DbSet "Dish (model class"
        public DbSet<User> Users { get; set; }
        public DbSet<RSVP> RSVPs { get; set; }
        public DbSet<Wedding> Weddings { get; set; }
    }
}
