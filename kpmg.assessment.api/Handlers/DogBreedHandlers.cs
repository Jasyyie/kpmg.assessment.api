using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Kpmg.Assessment.Api.Commands;
using System;
using Kpmg.Assessment.Api.Services;
using Microsoft.Extensions.Logging;

namespace Kpmg.Assessment.Api.Handlers
{
    public class DogBreedHandler : IRequestHandler<DogBreedRequest, string>
    {
        private readonly IDogService _dogSearchService;
        private readonly ILogger<DogBreedHandler> _logger;

        public DogBreedHandler(IDogService dogSearchService, ILogger<DogBreedHandler> logger)
        {
            _dogSearchService = dogSearchService;
            _logger = logger;
        }

        public async Task<string> Handle(DogBreedRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var DogSearchBreed = await _dogSearchService.GetDogByBreed(request);
                return DogSearchBreed;
            }

            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            return null;
        }

    }
}