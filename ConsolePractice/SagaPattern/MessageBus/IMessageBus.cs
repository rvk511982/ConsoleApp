namespace ConsolePractice.SagaPattern.MessageBus
{
    public interface IMessageBus
    {
        Task PublishAsync<T>(T message);
    }
}
