using Kpmg.Assessment.Api.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Kpmg.Assessment.Api.Commands
{
    public class DogImageRequest : IRequest<DogImageResponse>
    {
        [ModelBinder(Name = "breed")]
        public string Breed { get; set; }
        [ModelBinder(Name = "sub-breed")]
        public string SubBreed { get; set; }
    }
}