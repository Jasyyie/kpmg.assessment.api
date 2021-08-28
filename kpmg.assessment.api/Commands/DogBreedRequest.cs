using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Kpmg.Assessment.Api.Commands
{
    public class DogBreedRequest : IRequest<string>
    {
        [ModelBinder(Name = "breed")]
        public string Breed { get; set; }
        [ModelBinder(Name = "sub-breed")]
        public string SubBreed { get; set; }
    }
}