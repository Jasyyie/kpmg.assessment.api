using System.Collections.Generic;

namespace Kpmg.Assessment.Api.Responses
{
    public class DogApiResponse
    {
        public Dictionary<string, string[]> Message { get; set; }
        public string Status { get; set; }
    }
}
