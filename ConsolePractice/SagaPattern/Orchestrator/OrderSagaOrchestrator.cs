using ConsolePractice.SagaPattern.Events;
using ConsolePractice.SagaPattern.MessageBus;

namespace ConsolePractice.SagaPattern.Orchestrator
{
    public class OrderSagaOrchestrator
    {
        private readonly IMessageBus _messageBus;

        public OrderSagaOrchestrator(IMessageBus messageBus)
        {
            _messageBus = messageBus;
        }

        public async Task StartSagaAsync(Guid orderId, decimal amount)
        {
            var orderCreatedEvent = new OrderCreatedEvent { OrderId = orderId, Amount = amount };
            await _messageBus.PublishAsync(orderCreatedEvent);
        }

        public async Task HandlePaymentProcessedAsync(PaymentProcessedEvent evt)
        {
            if (evt.IsSuccessful)
            {
                var inventoryUpdatedEvent = new InventoryUpdatedEvent { OrderId = evt.OrderId, IsStockAvailable = true };
                await _messageBus.PublishAsync(inventoryUpdatedEvent);
            }
            else
            {
                // Compensating action: Cancel order
                Console.WriteLine($"Payment failed for Order {evt.OrderId}, rolling back...");
            }
        }

        public async Task HandleInventoryUpdatedAsync(InventoryUpdatedEvent evt)
        {
            await Task.Delay(100);  //
            if (evt.IsStockAvailable)
            {
                Console.WriteLine($"Order {evt.OrderId} is successfully completed.");
            }
            else
            {
                // Compensating action: Refund payment
                Console.WriteLine($"Inventory unavailable for Order {evt.OrderId}, initiating refund...");
            }
        }
    }
}
