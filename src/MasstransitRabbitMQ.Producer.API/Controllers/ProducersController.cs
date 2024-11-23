using MassTransit;
using MasstransitRabbitMQ.Contract.Constants;
using MasstransitRabbitMQ.Contract.IntegrationEvents;
using Microsoft.AspNetCore.Mvc;

namespace MasstransitRabbitMQ.Producer.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProducersController : ControllerBase
    {
        private readonly IPublishEndpoint _publishEndpoint;

        public ProducersController(IPublishEndpoint publishEndpoint)
        {
            _publishEndpoint = publishEndpoint;
        }

        [HttpPost(Name = "publish-sms-notification")]
        public async Task<IActionResult> PublishSmsNotificationEvent()
        {
            await _publishEndpoint.Publish(new DomainEvent.SmsNotificationEvent()
            {
                Id = Guid.NewGuid(),
                Description = "Sms description",
                Name = "Sms notification",
                Timestamp = DateTime.UtcNow,
                TransactionId = Guid.NewGuid(),
                Type = NotificationType.sms,
            });

            return Accepted();
        }
    }
}
