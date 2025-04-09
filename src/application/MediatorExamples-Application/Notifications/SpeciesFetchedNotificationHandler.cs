using MediatorExamples_Application.Commands;
using MediatorExamples_Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediatorExamples_Application.Notifications
{
    public class SpeciesFetchedNotificationHandler : INotificationHandler<SpeciesFetchedNotification>
    {
        public async Task Handle(SpeciesFetchedNotification notification, CancellationToken cancellationToken)
        {
            BreedsDb.UpdateFetchCount(notification.Species);
            return;
        }
    }
}
