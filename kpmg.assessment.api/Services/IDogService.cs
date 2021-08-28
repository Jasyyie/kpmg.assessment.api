using System;
using kpmg.assessment.api.commands;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Linq;

namespace kpmg.assessment.api.services
{
    public interface IDogService
    {
        Task<DogApiResponse> GetDogList();
        Task<string> GetDogByBreed(DogBreedRequest request);

    }
}

