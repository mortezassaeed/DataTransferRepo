// See https://aka.ms/new-console-template for more information

using DataAccess.SQL;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

await Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddHostedService<SubscriberWorker>();
    }).ConfigureServices((host, services) =>
    {
        services.AddDataAccessServices(host.Configuration);
    }).Build().RunAsync();





