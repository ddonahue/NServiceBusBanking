using NServiceBus;

namespace Messages
{
    public class AccountOverdrawnEvent : IMessage
    {   
        public decimal Balance { get; set; }
        public string EmailAddress { get; set; }
        public decimal TransactionAmount { get; set; }
    }
}