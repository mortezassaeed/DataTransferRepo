
using DataAccess.SQL.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using StackExchange.Redis;

internal class SubscriberWorker : BackgroundService
{
    private readonly IDataRepository _repo;
    private readonly IConfiguration _configuration;

    public SubscriberWorker(IDataRepository repo,IConfiguration configuration)
    {
        _repo = repo;
        _configuration = configuration;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        var redisConnectionString = _configuration.GetConnectionString("Redis");
        ConnectionMultiplexer redis = ConnectionMultiplexer.Connect(redisConnectionString);

        ISubscriber sub = redis.GetSubscriber();
        
        int i = 1;
        await sub.SubscribeAsync("data", async (_, message) =>
        {
            await _repo.SaveAsync(message.ToString());
            Console.WriteLine($"[{i++}] {message}");
        });
        Console.WriteLine("subscribed messages");

    }
}