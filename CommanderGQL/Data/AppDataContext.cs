using CommanderGQL.Models;
using Microsoft.EntityFrameworkCore;

namespace CommanderGQL.Data
{
    public class AppDataContext : DbContext
    {
        public AppDataContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Platform> Platforms { get; set; }
        public DbSet<Command> Commands { get; set; }

        // Spefifing relations between tables
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Platform>()
                .HasMany(p => p.Commands)
                .WithOne(p => p.Platform!)
                .HasForeignKey(p => p.PlatformId);

            modelBuilder
                .Entity<Command>()
                .HasOne(c => c.Platform)
                .WithMany(c => c.Commands!)
                .HasForeignKey(p => p.PlatformId);
        }
    }
}
