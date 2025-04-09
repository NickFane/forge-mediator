using MediatorExamples_Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediatorExamples_Application.Services.GetBreedsBySpecies
{
    public class GetBreedsBySpeciesRequest : IRequest<IList<Breed>>
    {
        public GetBreedsBySpeciesRequest(string species)
        {
            Species = species;
        }

        public string Species { get; }
    }
}
