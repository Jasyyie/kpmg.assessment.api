using System;
using Kpmg.Assessment.Api.Commands;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Linq;
using Kpmg.Assessment.Api.Responses;

namespace Kpmg.Assessment.Api.Services
{
    public interface IDogService
    {
        Task<DogApiResponse> GetDogList();
        Task<DogApiImageResponse> GetDogImages(DogImageRequest request);

    }
}

