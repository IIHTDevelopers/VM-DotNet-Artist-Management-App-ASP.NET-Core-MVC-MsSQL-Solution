using Microsoft.EntityFrameworkCore;
using ArtistManagementApp.Models;

namespace ArtistManagementApp.DAL
{
    public class ArtistDbContext : DbContext
    {
        public ArtistDbContext(DbContextOptions<ArtistDbContext> options) : base(options)
        {
        }

        public DbSet<Artist> Artists { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // You can configure additional settings for your entities here
            // Example: modelBuilder.Entity<Artist>().Property(v => v.FirstName).IsRequired();
        }
    }
}