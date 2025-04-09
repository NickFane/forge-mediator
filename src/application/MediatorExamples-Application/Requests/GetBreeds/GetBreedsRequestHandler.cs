using MediatorExamples_Application.Commands;
using MediatorExamples_Db.Repositories;
using MediatorExamples_Domain.Models;
using MediatR;

namespace MediatorExamples_Application.Services.GetBreeds
{
    public class GetBreedsRequestHandler : IRequestHandler<GetBreedsRequest, IList<Breed>>
    {
        private readonly IMediator _mediator;
        private readonly IBreedRepository _breedRepository;

        public GetBreedsRequestHandler(IMediator mediator, IBreedRepository breedRepository)
        {
            _mediator = mediator;
            _breedRepository = breedRepository;
        }

        async Task<IList<Breed>> IRequestHandler<GetBreedsRequest, IList<Breed>>.Handle(GetBreedsRequest request, CancellationToken cancellationToken)
        {
            var response = await _breedRepository.GetBreedsAsync();

            await _mediator.Publish(new SpeciesFetchedNotification("all"), cancellationToken);

            return response.ToList();
        }
    }
}
