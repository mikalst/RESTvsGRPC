using BenchmarkDotNet.Running;
using ModelLibrary.Data;
using System;

namespace RESTvsGRPC
{
    class Program
    {
        static void Main(string[] args)
        {
            MeteoriteLandingData.Size = MeteoriteLandingDataSize.Small;

            BenchmarkRunner.Run<BenchmarkHarness>();
            Console.ReadKey();
        }
    }
}
