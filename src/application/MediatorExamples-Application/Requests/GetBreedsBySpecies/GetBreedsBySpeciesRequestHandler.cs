using MediatorExamples_Application.Commands;
using MediatorExamples_Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediatorExamples_Application.Services.GetBreedsBySpecies
{
    public class GetBreedsBySpeciesRequestHandler : IRequestHandler<GetBreedsBySpeciesRequest, IList<Breed>>
    {
        private readonly IMediator _mediator;

        public GetBreedsBySpeciesRequestHandler(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IList<Breed>> Handle(GetBreedsBySpeciesRequest request, CancellationToken cancellationToken)
        {
            var breeds = BreedsDb.Breeds;

            var response = breeds.Where(b => string.Equals(b.species, request.Species, StringComparison.OrdinalIgnoreCase)).ToList();

            await _mediator.Publish(new SpeciesFetchedNotification(request.Species), cancellationToken);

            return response;
        }
    }
}
