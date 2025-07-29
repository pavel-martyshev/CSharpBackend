using Grpc.Net.Client;
using GRPCServer;

namespace GRPCClient;

internal class Program
{
    static async Task Main(string[] args)
    {
        using var channel = GrpcChannel.ForAddress("https://localhost:44349");

        // Greeter Client
        var greeterClient = new Greeter.GreeterClient(channel);
        var greeterReply = await greeterClient.SayHelloAsync(new HelloRequest { Name = "Pavel" });
        Console.WriteLine($"Greeter: {greeterReply.Message}");

        // RandomNumberFromRange Client
        var randomNumberClient = new RandomNumberFromRange.RandomNumberFromRangeClient(channel);
        var randomNumberReply = await randomNumberClient.GetRandomNumberFromRangeAsync(new RandomNumberFromRangeRequest
        {
            StartNumber = 1,
            EndNumber = 100
        });

        Console.WriteLine($"Random Number: {randomNumberReply.Message}");
    }
}
