using System;
using NServiceBus;

namespace Messages
{
    public class CreateNewTransactionCommand : IMessage
    {
        public decimal Amount { get; set; }
        public string Description { get; set; }
        public DateTime TransactionDate { get; set; }
    }
}
