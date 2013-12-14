<%@ Page CodeFile="AddTransaction.aspx.cs" Language="C#"  AutoEventWireup="True" CodeBehind="AddTransaction.aspx.cs" Inherits="Banking.Web.AddTransaction" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        Description: <asp:TextBox ID="description" runat="Server" /><br />
        Amount: <asp:TextBox ID="amount" runat="server" /><br />
        <asp:RadioButtonList ID="transactionType" runat="server" RepeatColumns="2">
            <asp:ListItem Text="Debit" Value="Debit" />
            <asp:ListItem Text="Credit" Value="Credit" />
        </asp:RadioButtonList><br />
        
        <asp:Button ID="submitBtn" runat="server" Text="Create Transaction" /> 
        
        <asp:Label ID="errorMsg" runat="server" ForeColor="Red" /> 
    </div>
    </form>
</body>
</html>
