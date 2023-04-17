using Microsoft.EntityFrameworkCore;
using NZWalks.API.Models.Domain;

namespace NZWalks.API.Data
{
    public class NZWalksDBContext : DbContext
    {
        public NZWalksDBContext(DbContextOptions options):base(options)
        {

        }
        public DbSet<Difficulty> difficulties { get; set; }
        public DbSet<Region> regions { get; set; }  
        public DbSet<Walk> walks { get; set; }
    }
}
