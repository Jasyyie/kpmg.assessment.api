using System;
using Kpmg.Assessment.Api.Commands;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Kpmg.Assessment.Api.Services
{
    public class DogService : IDogService
    {
        private readonly IHttpClientFactory _clientFactory;

        public DogService(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<DogApiResponse> GetDogList()
        {
            try
            {
                const string baseUrl = "https://dog.ceo/api/";
                var client = _clientFactory.CreateClient();
                client.BaseAddress = new Uri(baseUrl);
                var response = await client.GetStringAsync("breeds/list/all");
                var res = JsonConvert.DeserializeObject<DogApiResponse>(response);
                return res;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return null;
        }

        public async Task<string> GetDogByBreed(DogBreedRequest request)
        {
            try
            {
                const string SearchUrl = "https://dog.ceo/api/breeds/list/all";
                var client = _clientFactory.CreateClient();
                client.BaseAddress = new Uri(SearchUrl);
                var response = await client.GetStringAsync($"{request.Breed}");
                return response;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return null;
        }

    }
}