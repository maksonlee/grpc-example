using Grpc.Core;
using Sfisgrpc;
using System;

namespace SfisClient
{
    class Program
    {
        static void Main(string[] args)
        {
            var channel = new Channel("127.0.0.1:50051", ChannelCredentials.Insecure);
            var client = new Sfis.SfisClient(channel);
            var reply = client.GetItemStations(new Imei{ Name = "12345678" });
            
            Console.WriteLine(reply);
        }
    }
}
