using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Validators;
using ModelLibrary.Data;
using System.Linq;
using System.Threading.Tasks;

namespace RESTvsGRPC
{
    [AsciiDocExporter]
    [CsvExporter]
    [HtmlExporter]
    public class BenchmarkHarness
    {
        [Params(200)]
        public int IterationCountGet;
        [Params(20)]
        public int IterationCountPost;


        readonly RESTClient restClient = new RESTClient();
        readonly GRPCClient grpcClient = new GRPCClient();

        [Benchmark]
        public async Task RestGetSmallPayloadAsync()
        {
            restClient.Size = MeteoriteLandingDataSize.Small;
            for (int i = 0; i < IterationCountGet; i++)
            {
                await restClient.GetPayloadAsync();
            }
        }
        
        [Benchmark]
        public async Task RestGetMediumPayloadAsync()
        {
            restClient.Size = MeteoriteLandingDataSize.Medium;
            for (int i = 0; i < IterationCountGet; i++)
            {
                await restClient.GetPayloadAsync();
            }
        }

        [Benchmark]
        public async Task RestGetLargePayloadAsync()
        {
            restClient.Size = MeteoriteLandingDataSize.Large;
            for (int i = 0; i < IterationCountGet; i++)
            {
                await restClient.GetPayloadAsync();
            }
        }
        
        [Benchmark]
        public async Task RestPostSmallPayloadAsync()
        {
            restClient.Size = MeteoriteLandingDataSize.Small;
            for (int i = 0; i < IterationCountPost; i++)
            {
                await restClient.PostPayloadAsync(MeteoriteLandingData.RestMeteoriteLandings);
            }
        }

        [Benchmark]
        public async Task RestPostMediumPayloadAsync()
        {
            restClient.Size = MeteoriteLandingDataSize.Medium;
            for (int i = 0; i < IterationCountPost; i++)
            {
                await restClient.PostPayloadAsync(MeteoriteLandingData.RestMeteoriteLandings);
            }
        }

        [Benchmark]
        public async Task RestPostLargePayloadAsync()
        {
            restClient.Size = MeteoriteLandingDataSize.Large;
            for (int i = 0; i < IterationCountPost; i++)
            {
                await restClient.PostPayloadAsync(MeteoriteLandingData.RestMeteoriteLandings);
            }
        }

        // [Benchmark]
        // public async Task GrpcStreamLargePayloadAsync()
        // {
        //     for (int i = 0; i < IterationCount; i++)
        //     {
        //         await grpcClient.StreamLargePayloadAsync();
        //     }
        // }

        [Benchmark]
        public async Task GrpcGetSmallPayloadAsListAsync()
        {
            grpcClient.Size = MeteoriteLandingDataSize.Small;
            for (int i = 0; i < IterationCountGet; i++)
            {
                await grpcClient.GetPayloadAsListAsync();
            }
        }

        [Benchmark]
        public async Task GrpcGetMediumPayloadAsListAsync()
        {
            grpcClient.Size = MeteoriteLandingDataSize.Medium;
            for (int i = 0; i < IterationCountGet; i++)
            {
                await grpcClient.GetPayloadAsListAsync();
            }
        }

        [Benchmark]
        public async Task GrpcGetLargePayloadAsListAsync()
        {
            grpcClient.Size = MeteoriteLandingDataSize.Large;
            for (int i = 0; i < IterationCountGet; i++)
            {
                await grpcClient.GetPayloadAsListAsync();
            }
        }

        [Benchmark]
        public async Task GrpcPostSmallPayloadAsync()
        {
            grpcClient.Size = MeteoriteLandingDataSize.Small;
            for (int i = 0; i < IterationCountPost; i++)
            {
                await grpcClient.PostPayloadAsync(MeteoriteLandingData.GrpcMeteoriteLandingList);
            }
        }

        [Benchmark]
        public async Task GrpcPostMediumPayloadAsync()
        {
            grpcClient.Size = MeteoriteLandingDataSize.Medium;
            for (int i = 0; i < IterationCountPost; i++)
            {
                await grpcClient.PostPayloadAsync(MeteoriteLandingData.GrpcMeteoriteLandingList);
            }
        }
        
        [Benchmark]
        public async Task GrpcPostLargePayloadAsync()
        {
            grpcClient.Size = MeteoriteLandingDataSize.Large;
            for (int i = 0; i < IterationCountPost; i++)
            {
                await grpcClient.PostPayloadAsync(MeteoriteLandingData.GrpcMeteoriteLandingList);
            }
        }
    }

    public class AllowNonOptimized : ManualConfig
    {
        public AllowNonOptimized()
        {
            AddValidator(JitOptimizationsValidator.DontFailOnError);

            // AddValidator(DefaultConfig.Instance.GetLoggers().Select(());
            // AddValidator(DefaultConfig.Instance.GetExporters().ToArray());
            // AddValidator(DefaultConfig.Instance.GetColumnProviders().ToArray());
        }
    }
}
