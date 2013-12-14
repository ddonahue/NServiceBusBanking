using System;
using Messages;
using NServiceBus;

namespace EmailSender
{
    public class AccountOverdrawnEventHandler : IHandleMessages<AccountOverdrawnEvent>
    {
        public void Handle(AccountOverdrawnEvent message)
        {
            Console.WriteLine("TO: " + message.EmailAddress);
            Console.WriteLine("BODY:");
            Console.Write("Your last transaction of {0} has caused your account to be overdrawn.  Your current balance is {1}.", message.TransactionAmount.ToString("C"), message.Balance.ToString("C") );
        }
    }
}
