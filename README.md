
# Results
|                          Method | IterationCountGet | IterationCountPost |     Mean |   Error |   StdDev |
|-------------------------------- |------------------ |------------------- |---------:|--------:|---------:|
|        RestGetSmallPayloadAsync |               200 |                 20 | 127.7 ms | 2.12 ms |  1.88 ms |
|       RestGetMediumPayloadAsync |               200 |                 20 | 129.1 ms | 1.32 ms |  1.17 ms |
|        RestGetLargePayloadAsync |               200 |                 20 | 129.0 ms | 2.13 ms |  1.99 ms |
|       RestPostSmallPayloadAsync |               200 |                 20 | 448.1 ms | 6.23 ms |  5.82 ms |
|      RestPostMediumPayloadAsync |               200 |                 20 | 454.0 ms | 7.91 ms |  7.40 ms |
|       RestPostLargePayloadAsync |               200 |                 20 | 463.2 ms | 9.20 ms | 12.29 ms |
|  GrpcGetSmallPayloadAsListAsync |               200 |                 20 | 317.9 ms | 3.92 ms |  3.67 ms |
| GrpcGetMediumPayloadAsListAsync |               200 |                 20 | 316.2 ms | 3.80 ms |  3.55 ms |
|  GrpcGetLargePayloadAsListAsync |               200 |                 20 | 315.1 ms | 4.32 ms |  4.04 ms |
|       GrpcPostSmallPayloadAsync |               200 |                 20 | 211.8 ms | 4.23 ms |  5.93 ms |
|      GrpcPostMediumPayloadAsync |               200 |                 20 | 220.5 ms | 4.22 ms |  5.33 ms |
|       GrpcPostLargePayloadAsync |               200 |                 20 | 215.0 ms | 4.17 ms |  3.90 ms |


### Read More - [https://medium.com/@EmperorRXF/evaluating-performance-of-rest-vs-grpc](https://medium.com/@EmperorRXF/evaluating-performance-of-rest-vs-grpc-1b8bdf0b22da?source=https://github.com/EmperorRXF/RESTvsGRPC)

# RESTvsGRPC
Evaluating Performance of REST vs. gRPC

## dotnet run -p RestAPI -c Release
Starts the ASP.NET MVC Core REST API

## dotnet run -p GrpcAPI -c Release
Starts the GRPC Service

## dotnet run -p RESTvsGRPC -c Release
Runs the benchmark on the above services
