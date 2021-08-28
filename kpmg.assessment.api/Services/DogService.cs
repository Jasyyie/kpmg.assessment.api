using System;
using Kpmg.Assessment.Api.Commands;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Kpmg.Assessment.Api.Responses;

namespace Kpmg.Assessment.Api.Services
{
    public class DogService : IDogService
    {
        private readonly IHttpClientFactory _clientFactory;
        private const string BaseUrl = "https://dog.ceo/api/";

        public DogService(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }


        public async Task<DogApiResponse> GetDogList()
        {
            try
            {

                var client = _clientFactory.CreateClient();
                client.BaseAddress = new Uri(BaseUrl);
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

        public async Task<DogApiImageResponse> GetDogImages(DogImageRequest request)
        {
            try
            {
                //https://dog.ceo/api/breed/bulldog/french/images

                var client = _clientFactory.CreateClient();
                client.BaseAddress = new Uri(BaseUrl);
                var endpoint = $"breed/{request.Breed?.Trim()}";

                if (!string.IsNullOrWhiteSpace(request.SubBreed))
                {
                    endpoint = endpoint + $"/{request.SubBreed?.Trim()}";
                }
                var response = await client.GetStringAsync($"{endpoint}/images");
                var res = JsonConvert.DeserializeObject<DogApiImageResponse>(response);
                return res;



            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return null;
        }

    }
}