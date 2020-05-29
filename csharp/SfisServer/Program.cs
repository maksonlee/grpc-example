using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Grpc.Core;
using Sfisgrpc;

namespace SfisServer
{
    class SfisImpl : Sfis.SfisBase
    {
        public override Task<StationResponse> GetItemStations(Imei request, ServerCallContext context)
        {
            List<Station> stations = new List<Station>() { new Station{ Name = "download" }, new Station{ Name = "packing" } };
            StationResponse response = new StationResponse();
            response.Stations.Add(stations);
            return Task.FromResult(response);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Server server = new Server
            {
                Services = { Sfis.BindService(new SfisImpl()) },
                Ports = { new ServerPort("localhost", 50051, ServerCredentials.Insecure) }
            };
            server.Start();

            Console.WriteLine("Greeter server listening on port 50051");
            Console.WriteLine("Press any key to stop the server...");
            Console.ReadKey();

            server.ShutdownAsync().Wait();
        }
    }
}
