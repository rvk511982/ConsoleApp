using ConsolePractice.SagaPattern.Events;
using ConsolePractice.SagaPattern.MessageBus;

namespace ConsolePractice.SagaPattern.Services
{
    public class PaymentService
    {
        private readonly IMessageBus _messageBus;

        public PaymentService(IMessageBus messageBus)
        {
            _messageBus = messageBus;
        }

        public async Task ProcessPayment(OrderCreatedEvent evt)
        {
            Console.WriteLine($"Processing payment for Order {evt.OrderId}...");
            bool isPaymentSuccessful = true; // Simulating success

            await _messageBus.PublishAsync(new PaymentProcessedEvent
            {
                OrderId = evt.OrderId,
                IsSuccessful = isPaymentSuccessful
            });
        }
    }
}
