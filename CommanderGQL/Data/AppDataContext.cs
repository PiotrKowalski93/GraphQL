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
    }
}
