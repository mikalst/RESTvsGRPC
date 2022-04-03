using ModelLibrary.Data;
using ModelLibrary.REST;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace RESTvsGRPC
{
    public class RESTClient
    {
        private static readonly HttpClient client = new HttpClient(
            new HttpClientHandler() 
            {
                AllowAutoRedirect = false
            });

        public MeteoriteLandingDataSize Size { get; set; } = MeteoriteLandingDataSize.Medium;

        public async Task<List<MeteoriteLanding>> GetPayloadAsync()
        {
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            return await client.GetFromJsonAsync<List<MeteoriteLanding>>(
                $"http://localhost:5000/api/MeteoriteLandings/Payload/{(int)Size}");
        }

        public async Task PostPayloadAsync(List<MeteoriteLanding> meteoriteLandings)
        {
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var response = await client.PostAsJsonAsync("http://localhost:5000/api/MeteoriteLandings/Payload", meteoriteLandings);

            response.EnsureSuccessStatusCode();

        }
    }
}
