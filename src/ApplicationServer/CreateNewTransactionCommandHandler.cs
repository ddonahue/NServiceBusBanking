using System;
using System.Linq;
using Messages;
using NServiceBus;

namespace ApplicationServer
{
    public class CreateNewTransactionCommandHandler : IHandleMessages<CreateNewTransactionCommand>
    {
        public IBus Bus { get; set; }

        public void Handle(CreateNewTransactionCommand message)
        {
            var dataContext = new TransactionsDataContext();
            
            var accountBalance = dataContext.Transactions.Sum(x => x.Amount);
            if (accountBalance <= -100 && message.Amount < 0)
            {
                Bus.Return((int)TransactionProcessedEvent.Failure);
                return;
            }
 
            var transaction = new Transaction
                                  {
                                      Amount = message.Amount,
                                      Description = message.Description,
                                      TransactionDate = message.TransactionDate
                                  };
            dataContext.Transactions.InsertOnSubmit(transaction);
            dataContext.SubmitChanges();
            Console.WriteLine(string.Format("New transaction added: {0}", transaction.TransactionId));
            Bus.Return((int)TransactionProcessedEvent.Success);

            accountBalance += transaction.Amount;
            if (accountBalance >= 0) return;

            var accountOverdrawnEvent = new AccountOverdrawnEvent
                                            {
                                                Balance = accountBalance,
                                                EmailAddress = "me@email.com",
                                                TransactionAmount = transaction.Amount
                                            };
            Bus.Publish(accountOverdrawnEvent);
        }
    }
}
