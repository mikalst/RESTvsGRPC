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
        [Params(1)]
        public int IterationCountGet;
        [Params(1)]
        public int IterationCountPost;


        readonly RESTClient restClient = new RESTClient();
        readonly GRPCClient grpcClient = new GRPCClient();

        [Benchmark]
        public async Task RestGetSmallPayloadAsync()
        {
            for (int i = 0; i < IterationCountGet; i++)
            {
                await restClient.GetPayloadAsync(MeteoriteLandingDataSize.Small);
            }
        }
        
        [Benchmark]
        public async Task RestGetMediumPayloadAsync()
        {
            for (int i = 0; i < IterationCountGet; i++)
            {
                await restClient.GetPayloadAsync(MeteoriteLandingDataSize.Medium);
            }
        }

        [Benchmark]
        public async Task RestGetLargePayloadAsync()
        {
            for (int i = 0; i < IterationCountGet; i++)
            {
                await restClient.GetPayloadAsync(MeteoriteLandingDataSize.Large);
            }
        }
        
        [Benchmark]
        public async Task RestPostSmallPayloadAsync()
        {
            MeteoriteLandingData.Size = MeteoriteLandingDataSize.Small;
            for (int i = 0; i < IterationCountPost; i++)
            {
                await restClient.PostPayloadAsync(MeteoriteLandingData.RestMeteoriteLandings);
            }
        }

        [Benchmark]
        public async Task RestPostMediumPayloadAsync()
        {
            MeteoriteLandingData.Size = MeteoriteLandingDataSize.Medium;
            for (int i = 0; i < IterationCountPost; i++)
            {
                await restClient.PostPayloadAsync(MeteoriteLandingData.RestMeteoriteLandings);
            }
        }

        [Benchmark]
        public async Task RestPostLargePayloadAsync()
        {
            MeteoriteLandingData.Size = MeteoriteLandingDataSize.Large;
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
            for (int i = 0; i < IterationCountGet; i++)
            {
                await grpcClient.GetPayloadAsListAsync(MeteoriteLandingDataSize.Small);
            }
        }

        [Benchmark]
        public async Task GrpcGetMediumPayloadAsListAsync()
        {
            for (int i = 0; i < IterationCountGet; i++)
            {
                await grpcClient.GetPayloadAsListAsync(MeteoriteLandingDataSize.Medium);
            }
        }

        [Benchmark]
        public async Task GrpcGetLargePayloadAsListAsync()
        {
            for (int i = 0; i < IterationCountGet; i++)
            {
                await grpcClient.GetPayloadAsListAsync(MeteoriteLandingDataSize.Large);
            }
        }

        [Benchmark]
        public async Task GrpcPostSmallPayloadAsync()
        {
            MeteoriteLandingData.Size = MeteoriteLandingDataSize.Small;
            for (int i = 0; i < IterationCountPost; i++)
            {
                await grpcClient.PostPayloadAsync(MeteoriteLandingData.GrpcMeteoriteLandingList);
            }
        }

        [Benchmark]
        public async Task GrpcPostMediumPayloadAsync()
        {
            MeteoriteLandingData.Size = MeteoriteLandingDataSize.Medium;
            for (int i = 0; i < IterationCountPost; i++)
            {
                await grpcClient.PostPayloadAsync(MeteoriteLandingData.GrpcMeteoriteLandingList);
            }
        }
        
        [Benchmark]
        public async Task GrpcPostLargePayloadAsync()
        {
            MeteoriteLandingData.Size = MeteoriteLandingDataSize.Large;
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
