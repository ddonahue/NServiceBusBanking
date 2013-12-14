using NServiceBus;

namespace Messages
{
    public enum TransactionProcessedEvent
    {
        Success = 1,
        Failure = 2
    }
}