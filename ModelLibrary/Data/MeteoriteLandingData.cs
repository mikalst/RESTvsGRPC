using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace ModelLibrary.Data
{
    public enum MeteoriteLandingDataSize
    {
        Small = 1,
        Medium = 2,
        Large = 3
    }


    public static class MeteoriteLandingData
    {

        private static MeteoriteLandingDataSize _size = MeteoriteLandingDataSize.Large;
        public static MeteoriteLandingDataSize Size { 
            get
            {
                return _size;
            } 
            set
            {
                if (value != _size)
                {
                    meteoriteLandingsJson = null;
                    _size = value;
                }
            }
        }

        static string meteoriteLandingsJson;
        public static string MeteoriteLandingsJson
        {
            get
            {
                if (meteoriteLandingsJson == null)
                {
                    var assembly = Assembly.GetExecutingAssembly();
                    var dataLocation = $"ModelLibrary.Data.MeteoriteLandings{_size}.json";
                    var resourceStream = assembly.GetManifestResourceStream(dataLocation);

                    using (var reader = new StreamReader(resourceStream, Encoding.UTF8))
                    {
                        meteoriteLandingsJson = reader.ReadToEnd();
                    }
                }
                return meteoriteLandingsJson;
            }
        }

        static List<REST.MeteoriteLanding> restMeteoriteLandings;
        public static List<REST.MeteoriteLanding> RestMeteoriteLandings
        {
            get
            {
                if (restMeteoriteLandings == null)
                {
                    restMeteoriteLandings = JsonConvert.DeserializeObject<List<REST.MeteoriteLanding>>(MeteoriteLandingsJson);
                }
                return restMeteoriteLandings;
            }
        }

        static List<GRPC.MeteoriteLanding> grpcMeteoriteLandings;
        public static List<GRPC.MeteoriteLanding> GrpcMeteoriteLandings
        {
            get
            {
                if (grpcMeteoriteLandings == null)
                {
                    grpcMeteoriteLandings = JsonConvert.DeserializeObject<List<GRPC.MeteoriteLanding>>(MeteoriteLandingsJson, new ProtobufJsonConvertor());
                }
                return grpcMeteoriteLandings;
            }
        }

        static GRPC.MeteoriteLandingList grpcMeteoriteLandingList;
        public static GRPC.MeteoriteLandingList GrpcMeteoriteLandingList
        {
            get
            {
                if (grpcMeteoriteLandingList == null)
                {
                    grpcMeteoriteLandingList = new GRPC.MeteoriteLandingList();
                    grpcMeteoriteLandingList.MeteoriteLandings.AddRange(GrpcMeteoriteLandings);
                }
                return grpcMeteoriteLandingList;
            }
        }
    }
}
