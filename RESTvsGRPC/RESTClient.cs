using ModelLibrary.Data;
using ModelLibrary.REST;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace RESTvsGRPC
{
    public class RESTClient
    {
        private readonly HttpClient client;

        public RESTClient()
        {
            client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<List<MeteoriteLanding>> GetPayloadAsync(MeteoriteLandingDataSize Size)
        {
            return await client.GetFromJsonAsync<List<MeteoriteLanding>>(
                $"http://localhost:5000/api/MeteoriteLandings/Payload/{(int)Size}");
        }

        public async Task PostPayloadAsync(List<MeteoriteLanding> meteoriteLandings)
        {
            var response = await client.PostAsJsonAsync("http://localhost:5000/api/MeteoriteLandings/Payload", meteoriteLandings);

            // response.EnsureSuccessStatusCode();
        }
    }
}
