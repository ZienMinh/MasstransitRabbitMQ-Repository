using MassTransit;
using MasstransitRabbitMQ.Consumer.API.DependencyInjection.Options;
using System.Reflection;

namespace MasstransitRabbitMQ.Consumer.API.DependencyInjection.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddMediatR(this IServiceCollection services)
        => services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));

    public static IServiceCollection AddConfigureMasstransitRabbitMQ(this IServiceCollection services, IConfiguration configuration)
    {
        var masstransitConfiguration = new MasstransitConfiguration();
        configuration.GetSection(nameof(MasstransitConfiguration)).Bind(masstransitConfiguration);

        services.AddMassTransit(mt =>
        {
            //mt.AddConsumer<SendSmsWhenReceivedSmsEventConsumer>();

            mt.AddConsumers(Assembly.GetExecutingAssembly()); // Add consumer

            mt.UsingRabbitMq((context, bus) =>
            {
                bus.Host(masstransitConfiguration.Host, masstransitConfiguration.VHost, h =>
                {
                    h.Username(masstransitConfiguration.UserName);
                    h.Password(masstransitConfiguration.Password);
                });

                bus.ConfigureEndpoints(context);
            });
        });
        return services;
    }
}
