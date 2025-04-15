using ConsolePractice.SagaPattern.Orchestrator;

namespace ConsolePractice.SagaPattern.Services
{
    public class OrderService
    {
        private readonly OrderSagaOrchestrator _sagaOrchestrator;

        public OrderService(OrderSagaOrchestrator sagaOrchestrator)
        {
            _sagaOrchestrator = sagaOrchestrator;
        }

        public async Task CreateOrder(Guid orderId, decimal amount)
        {
            Console.WriteLine($"Order {orderId} created.");
            await _sagaOrchestrator.StartSagaAsync(orderId, amount);
        }
    }
}
