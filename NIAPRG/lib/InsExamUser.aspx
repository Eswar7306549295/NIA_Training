﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InsExamUser.aspx.cs" Inherits="NIAPRG.lib.InsExamUser" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <%--<div>
        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
    <br />
         <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
    </div>--%>
        <div>
        <center>
            <h3>Exam Users Data</h3><br />
            <div ><asp:TextBox ID="txtfrom" runat="server" ></asp:TextBox></div>
            <div style="text-align:right;"> <asp:Button runat="server" ID="btnExport" Text="Export To Excel" OnClick="btnExport_Click" /></div>
        <asp:GridView ID="GdvExamUsers" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None">
            <AlternatingRowStyle BackColor="White" />
            <EditRowStyle BackColor="#2461BF" />
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#EFF3FB" />
            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#F5F7FB" />
            <SortedAscendingHeaderStyle BackColor="#6D95E1" />
            <SortedDescendingCellStyle BackColor="#E9EBEF" />
            <SortedDescendingHeaderStyle BackColor="#4870BE" />
        </asp:GridView>
    </center>
    </div>
    </form>
</body>
</html>
