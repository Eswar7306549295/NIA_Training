<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="testEmail.aspx.cs" Inherits="NIAPRG.lib.testEmail" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
      TO:   <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox><br />
     Subject   <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox><br />
      Body  <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox><br />
        
        <asp:Button ID="Button1" runat="server" Text="send" OnClick="Button1_Click" />
    </div>
    </form>
</body>
</html>
