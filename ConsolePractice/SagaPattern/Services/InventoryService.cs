using ConsolePractice.SagaPattern.Events;
using ConsolePractice.SagaPattern.MessageBus;

namespace ConsolePractice.SagaPattern.Services
{
    public class InventoryService
    {
        private readonly IMessageBus _messageBus;

        public InventoryService(IMessageBus messageBus)
        {
            _messageBus = messageBus;
        }

        public async Task UpdateInventory(PaymentProcessedEvent evt)
        {
            Console.WriteLine($"Updating inventory for Order {evt.OrderId}...");
            bool isStockAvailable = true; // Simulating stock availability

            await _messageBus.PublishAsync(new InventoryUpdatedEvent
            {
                OrderId = evt.OrderId,
                IsStockAvailable = isStockAvailable
            });
        }
    }
}
