<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Banking.Web._Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table border="1">
            <tr>
                <th>Date</th>
                <th>Description</th>
                <th>Debit</th>
                <th>Credit</th>           
            </tr>
        <asp:Repeater ID="transactionLog" runat="server">
            <ItemTemplate>
                <tr>
                    <td><%# Eval("TransactionDate") %></td>
                    <td><%# Eval("Description") %></td>
                    <td><asp:Literal ID="debit" runat="server" /></td>
                    <td><asp:Literal ID="credit" runat="server" /></td>
                </tr>
            </ItemTemplate>
        </asp:Repeater>
            <tr>
                <th colspan="4" style="text-align:right;">Balance: <asp:Literal ID="balance" runat="server" /></th>
            </tr>
        </table>
        
        <a href="AddTransaction.aspx">Add new transaction</a>
    </div>
    </form>
</body>
</html>
