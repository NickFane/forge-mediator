using MediatR;

namespace MediatorExamples_Application.Commands
{
    public class SpeciesFetchedNotification : INotification
    {
        public SpeciesFetchedNotification(string species)
        {
            Species = species;
        }

        public string Species { get; }
    }
}
