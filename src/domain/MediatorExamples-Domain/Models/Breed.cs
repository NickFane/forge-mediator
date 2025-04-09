using MediatorExamples_Domain.Models;
using System.Runtime.CompilerServices;

namespace MediatorExamples_Domain.Models
{
    public record Breed(string name, string species);

    public static class BreedsDb
    {
        public static void UpdateFetchCount(string species)
        {
            // This method would update the fetch count for the given species in a database or some other storage.
            // For simplicity, we are just printing it here.
            Console.WriteLine($"Species {species} fetched.");
        }

        public static Breed[] Breeds = [
    new("Maine Coon", Species.Cat),
        new("Labrador", Species.Dog),
        new("Blue Cattle", Species.Dog),
        new("Domestic Short Hair", Species.Cat),
    ];
    }

    public static class Species
    {
        public static string Dog = "Dog";
        public static string Cat = "Cat";

    }

}