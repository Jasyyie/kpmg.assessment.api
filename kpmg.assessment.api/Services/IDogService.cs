using System;
using Kpmg.Assessment.Api.Commands;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Linq;

namespace Kpmg.Assessment.Api.Services
{
    public interface IDogService
    {
        Task<DogApiResponse> GetDogList();
        Task<string> GetDogByBreed(DogBreedRequest request);

    }
}

