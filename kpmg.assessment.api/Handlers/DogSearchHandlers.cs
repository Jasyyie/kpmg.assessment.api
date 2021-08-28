using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Kpmg.Assessment.Api.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using Kpmg.Assessment.Api.Services;
using Microsoft.Extensions.Logging;

namespace Kpmg.Assessment.Api.Handlers
{
    public class DogSearchHandler : IRequestHandler<DogSearchRequest, DogSearchResponse>
    {
        private readonly IDogService _dogService;
        private readonly ILogger<DogSearchHandler> _logger;

        public DogSearchHandler(IDogService dogSearchService, ILogger<DogSearchHandler> logger)
        {
            _dogService = dogSearchService;
            _logger = logger;
        }

        public async Task<DogSearchResponse> Handle(DogSearchRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var dogList = await _dogService.GetDogList();
                DogSearchResponse dogSearchResponse = new DogSearchResponse();
                dogSearchResponse.Dogs = new List<DogDetail>();
                for (int i = 0; i < dogList.Message.Count; i++)
                {
                    var item = dogList.Message.ElementAt(i);

                    var a = 0;
                    do
                    {
                        var dogDetail = new DogDetail();
                        dogDetail.Breed = item.Key;
                        if (item.Value.Length > 0)
                        {
                            dogDetail.Subbreed = item.Value[a];
                        }
                        dogSearchResponse.Dogs.Add(dogDetail);
                        a = a + 1;
                    }
                    while (a < item.Value.Length);

                }
                return dogSearchResponse;
            }

            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            return null;

        }
    }
}