using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using NZWalks.API.Models.Domain;

namespace NZWalks.API.Data
{
    public class NZWalksDBContext : DbContext
    {
        public NZWalksDBContext(DbContextOptions<NZWalksDBContext> options):base(options)
        {

        }
        public DbSet<Difficulty> difficulties { get; set; }
        public DbSet<Region> regions { get; set; }  
        public DbSet<Walk> walks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //seed data for difficulty

            var difficulty = new List<Difficulty>()
            {
                new Difficulty()
                {
                    Id=Guid.Parse("365ccc81-6e57-49ac-9c2c-150be3684e6d"),
                    Name="Easy",
                },
                new Difficulty()
                {
                    Id=Guid.Parse("fcfa58a6-50bb-4658-b00b-4121c18b7630"),
                    Name="Medium",
                },
                new Difficulty()
                {
                    Id=Guid.Parse("9c8a9ee2-f3bd-46b6-b093-7e9d969df9f2"),
                    Name="Hard",
                }
            }; 

            modelBuilder.Entity<Difficulty>().HasData(difficulty);

            //seed data for regions
            var regions = new List<Region>()
            {
                new Region()
                {
                    Id=Guid.Parse("dddf7948-4edf-4cb6-abe6-3ff003034a95"),
                    Name="Atlanta",
                    Code="ATL",
                    RegionImageURL="atl.jpg"
                },
                new Region()
                {
                    Id=Guid.Parse("89b62bff-2d24-4196-be06-e38683471781"),
                    Name="Georgia",
                    Code="GRG",
                    RegionImageURL="grg.jpg"
                },
                new Region()
                {
                    Id=Guid.Parse("5e470af2-002b-4d1d-ac9e-33d822900e3b"),
                    Name="Columbia",
                    Code="CMB",
                    RegionImageURL="gh.jpg"
                },
                new Region()
                {
                    Id=Guid.Parse("8ac9c219-6e02-4364-97bf-5fca80fe9ebd"),
                    Name="Auckland",
                    Code="AKL",
                    RegionImageURL="akl.jpg"
                },
            };
            modelBuilder.Entity<Region>().HasData(regions);
        }
    }
}
