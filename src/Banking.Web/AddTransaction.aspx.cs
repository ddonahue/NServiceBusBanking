using System;
using System.Web.UI;
using Messages;

namespace Banking.Web
{
    public partial class AddTransaction : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            submitBtn.Click += submitBtn_Click;
        }

        private void submitBtn_Click(object sender, EventArgs e)
        {
            errorMsg.Text = string.Empty;
            var transactionAmount = Convert.ToDecimal(amount.Text);
            var command = new CreateNewTransactionCommand
                              {
                                  Description = description.Text,
                                  TransactionDate = DateTime.Now,
                                  Amount =
                                      (transactionType.SelectedValue == "Debit")
                                          ? -transactionAmount
                                          : transactionAmount
                              };
            Global.Bus.Send(command).RegisterWebCallback<TransactionProcessedEvent>(
                result => TransactionProcessed(result), null);
        }

        private void TransactionProcessed(TransactionProcessedEvent transactionProcessedEvent)
        {
            if (transactionProcessedEvent == TransactionProcessedEvent.Success)
            {
                Response.Redirect("Default.aspx");
                return;
            }

            errorMsg.Text = "CANNOT COMPLETE TRANSACTION - IT WILL CAUSE ACCOUNT TO BE LOCKED!";
        }
    }
}