# MasstransitRabbitMQ-Repository

Command - CommandBus (ISender)
Query - QueryBus
Event - EventBus

DomainEvent => Inmemory => MediatR
IntegrationEvent => Distributed System => Masstransit

IMessage:
    IMessage : Command (V+N) => CommandBus (IBus) => IConsumer<IMessage> : Consumer<Command> : CommandConsumerHandler
    IMessage: Event (N + Ved) => EventBus (IPublishEndpoint) => IConsumer<IMessage> : Consumer<IMessage> : EventConsumerHandler
    CommandBus => Send message to Queue: Address
    EventBus => Send message to Exchanges => Route queue
