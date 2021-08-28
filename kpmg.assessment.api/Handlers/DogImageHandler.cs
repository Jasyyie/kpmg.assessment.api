using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Kpmg.Assessment.Api.Commands;
using System;
using Kpmg.Assessment.Api.Services;
using Microsoft.Extensions.Logging;
using Kpmg.Assessment.Api.Responses;

namespace Kpmg.Assessment.Api.Handlers
{
    public class DogImageHandler : IRequestHandler<DogImageRequest, DogImageResponse>
    {
        private readonly IDogService _dogService;
        private readonly ILogger<DogImageHandler> _logger;

        public DogImageHandler(IDogService dogService, ILogger<DogImageHandler> logger)
        {
            _dogService = dogService;
            _logger = logger;
        }

        public async Task<DogImageResponse> Handle(DogImageRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var dogImages = await _dogService.GetDogImages(request);
                if (dogImages.Status != "success")
                {
                    throw new OperationCanceledException();
                }

                var dogImageResponse = new DogImageResponse();
                dogImageResponse.ImageUrls = dogImages.Message;
                return dogImageResponse;
            }

            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            return null;
        }

    }
}