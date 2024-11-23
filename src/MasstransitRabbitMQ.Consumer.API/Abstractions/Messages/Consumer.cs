using MassTransit;
using MasstransitRabbitMQ.Contract.Abstractions.Messages;
using MediatR;

namespace MasstransitRabbitMQ.Consumer.API.Abstractions.Messages;

public abstract class Consumer<TMessage> : IConsumer<IMessage>
    where TMessage : class, INotificationEvent
{
    private readonly ISender _sender;

    protected Consumer(ISender sender)
    {
        _sender = sender;
    }

    public async Task Consume(ConsumeContext<IMessage> context)
        => await _sender.Send(context.Message);
}
