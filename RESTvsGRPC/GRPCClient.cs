using Grpc.Core;
using ModelLibrary.Data;
using ModelLibrary.GRPC;
using System.Collections.Generic;
using System.Threading.Tasks;
using static ModelLibrary.GRPC.MeteoriteLandingsService;

namespace RESTvsGRPC
{
    public class GRPCClient
    {
        private readonly Channel channel;
        private readonly MeteoriteLandingsServiceClient client;

        public GRPCClient()
        {
            channel = new Channel("localhost:6000", ChannelCredentials.Insecure);
            client = new MeteoriteLandingsServiceClient(channel);
        }


        public async Task<string> GetSmallPayloadAsync()
        {
            return (await client.GetVersionAsync(new EmptyRequest())).ApiVersion;
        }

        public async Task<List<MeteoriteLanding>> StreamLargePayloadAsync()
        {
            List<MeteoriteLanding> meteoriteLandings = new List<MeteoriteLanding>();

            using (var response = client.GetLargePayload(new EmptyRequest()).ResponseStream)
            {
                while (await response.MoveNext())
                {
                    meteoriteLandings.Add(response.Current);
                }
            }

            return meteoriteLandings;
        }

        public async Task<IList<MeteoriteLanding>> GetPayloadAsListAsync(MeteoriteLandingDataSize Size)
        {
            return (
                await client.GetLargePayloadAsListAsync(
                    new EmptyRequest()
                    {
                        Size = (int)Size
                    }
                )
            ).MeteoriteLandings;
        }

        public async Task PostPayloadAsync(MeteoriteLandingList meteoriteLandings)
        {
            await client.PostLargePayloadAsync(meteoriteLandings);
        }
    }
}
