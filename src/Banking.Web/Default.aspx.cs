using System;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Banking.Web
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            transactionLog.ItemDataBound += transactionLog_ItemDataBound;
            if(!IsPostBack)
            {
                LoadTransactions();
            }
        }

        private void transactionLog_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType != ListItemType.Item && e.Item.ItemType != ListItemType.AlternatingItem) return;

            var transaction = (Transaction)e.Item.DataItem;

            var debitLiteral = (Literal)e.Item.FindControl("debit");
            var creditLiteral = (Literal)e.Item.FindControl("credit");

            debitLiteral.Text = (transaction.Amount < 0) ? transaction.Amount.ToString("C") : "&nbsp;";
            creditLiteral.Text = (transaction.Amount > 0) ? transaction.Amount.ToString("C") : "&nbsp;";
        }

        private void LoadTransactions()
        {
            var transactions = new TransactionsDataContext().Transactions.OrderBy(x => x.TransactionDate);
            transactionLog.DataSource = transactions;
            transactionLog.DataBind();

            balance.Text = transactions.Sum(x => x.Amount).ToString("C");
        }
    }
}
