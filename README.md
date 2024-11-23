# MasstransitRabbitMQ-Repository

## Message Types and Buses

### Command Pattern
- **Command** (Verb + Noun)
  - Uses **CommandBus** (ISender)
  - Implemented through `IConsumer<IMessage>` : `Consumer<Command>` : `CommandConsumerHandler`
  - CommandBus sends message to specific Queue Address

### Query Pattern
- **Query**
  - Uses **QueryBus**

### Event Patterns
- **DomainEvent**
  - In-memory implementation using MediatR

- **IntegrationEvent**
  - Distributed System implementation using Masstransit
  - Uses **EventBus** (IPublishEndpoint)
  - Implemented through `IConsumer<IMessage>` : `Consumer<IMessage>` : `EventConsumerHandler`
  - EventBus sends messages to Exchanges which then route to queues

## Message Flow Structure

### IMessage Interface Implementations
1. **Command Messages**
   - Pattern: Verb + Noun
   - Bus: CommandBus (IBus)
   - Handler: CommandConsumerHandler
   - Routing: Direct to Queue Address

2. **Event Messages**
   - Pattern: Noun + Past Verb
   - Bus: EventBus (IPublishEndpoint)
   - Handler: EventConsumerHandler
   - Routing: Through Exchange to Queue
