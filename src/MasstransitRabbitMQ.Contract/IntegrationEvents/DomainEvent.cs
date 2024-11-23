using MasstransitRabbitMQ.Contract.Abstractions.Messages;

namespace MasstransitRabbitMQ.Contract.IntegrationEvents;

public static class DomainEvent
{
    public record EmailNotification : INotificationEvent
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public Guid TransactionId { get; set; }
        public Guid Id { get; set; }
        public DateTimeOffset Timestamp { get; set; }
    }

    public record SmsNotificationEvent : INotificationEvent
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public Guid TransactionId { get; set; }
        public Guid Id { get; set; }
        public DateTimeOffset Timestamp { get; set; }
    }
}
