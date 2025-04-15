using ConsolePractice.SagaPattern.Events;

namespace ConsolePractice.SagaPattern.MessageBus
{
    public class InMemoryMessageBus : IMessageBus
    {
        public event Func<OrderCreatedEvent, Task>? OnOrderCreated;
        public event Func<PaymentProcessedEvent, Task>? OnPaymentProcessed;
        public event Func<InventoryUpdatedEvent, Task>? OnInventoryUpdated;

        public async Task PublishAsync<T>(T message)
        {
            switch (message)
            {
                case OrderCreatedEvent evt:
                    if (OnOrderCreated != null) await OnOrderCreated.Invoke(evt);
                    break;
                case PaymentProcessedEvent evt:
                    if (OnPaymentProcessed != null) await OnPaymentProcessed.Invoke(evt);
                    break;
                case InventoryUpdatedEvent evt:
                    if (OnInventoryUpdated != null) await OnInventoryUpdated.Invoke(evt);
                    break;
            }
        }
    }
}
