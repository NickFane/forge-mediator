using MediatorExamples_Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediatorExamples_Application.Services.GetBreeds
{
    public class GetBreedsRequest : IRequest<IList<Breed>>
    {
        public GetBreedsRequest()
        {
        }
    }
}
