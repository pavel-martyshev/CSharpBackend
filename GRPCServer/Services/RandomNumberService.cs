using Grpc.Core;

namespace GRPCServer.Services;

public class RandomNumberService : RandomNumberFromRange.RandomNumberFromRangeBase
{
    private readonly Random _random = new();

    public override Task<RandomNumberReply> GetRandomNumberFromRange(RandomNumberFromRangeRequest request, ServerCallContext context)
    {
        return Task.FromResult(new RandomNumberReply
        {
            Message = $"Your random number - {_random.Next(request.StartNumber, request.EndNumber)}"
        });
    }
}
