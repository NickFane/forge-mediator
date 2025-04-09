using MediatorExamples_Db.Contexts;
using MediatorExamples_Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediatorExamples_Db.Repositories
{
    public class BreedRepository : IBreedRepository
    {
        //private readonly BreedContext _context;
        private readonly IList<Breed> _context;

        
        public BreedRepository()
        {
            var breeds = new List<Breed>() {
        new("Maine Coon", Species.Cat),
        new("Labrador", Species.Dog),
        new("Blue Cattle", Species.Dog),
        new("Domestic Short Hair", Species.Cat)
            };

            _context = new List<Breed>();

            foreach (var breed in breeds)
            {
                _context.Add(breed);
            }
        }

        public async Task<IList<Breed>> GetBreedsAsync()
        {
                var result = _context.ToList();
                return result;

        }

        public async Task<IList<Breed>> GetBreedsBySpeciesAsync(string species)
        {
                var result = _context.Where(breed => string.Equals(breed.species, species, StringComparison.OrdinalIgnoreCase)).ToList();
                return result;
        }
    }

    public interface IBreedRepository
    {
        Task<IList<Breed>> GetBreedsAsync();
        Task<IList<Breed>> GetBreedsBySpeciesAsync(string species);
    }
}
