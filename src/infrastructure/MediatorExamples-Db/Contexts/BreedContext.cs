using MediatorExamples_Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediatorExamples_Db.Contexts
{
    public class BreedContext : DbContext
    {
        public DbSet<Breed> Breeds { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseInMemoryDatabase("BreedsDb");
        }

        public BreedContext(DbContextOptions<BreedContext> options)
            : base(options)
        {
            this.Database.EnsureDeleted();
            this.Database.EnsureCreated();

            var breeds = new List<Breed>() {
        new("Maine Coon", Species.Cat),
        new("Labrador", Species.Dog),
        new("Blue Cattle", Species.Dog),
        new("Domestic Short Hair", Species.Cat)
    };
            this.AddRange(breeds);
            this.SaveChanges();
        }
    }
}
