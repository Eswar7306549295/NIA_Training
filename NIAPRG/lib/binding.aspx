<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Binding.aspx.cs" Inherits="NIAPRG.lib.Binding" %>

<link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css" />


<link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css" />

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

    <style>
 .panel
{
width: 1129px;
padding: 10px;
/*min-height: 20px;*/
/*border: 1px solid black;*/
margin-left:auto;
margin-right:auto;
}
    </style>  

</head>
<body>
    <form id="form1" runat="server">
     
       <%-- <asp:Panel ID="pnlGrid" CssClass="panel" runat="server">--%>
            <div class="panel" style="padding-top:150px;">
        <asp:GridView ID="GvRpt" runat="server"  Width="100%" PageSize="50" CssClass="BorderColor" AutoGenerateColumns="False" CellPadding="3" ForeColor="Black" GridLines="Vertical" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" >
            <FooterStyle CssClass="FooterStyle" BackColor="#CCCCCC"/>
            <EmptyDataRowStyle CssClass="EmptyDataRowStyle" />
            <RowStyle CssClass="RowStyle" />
            <AlternatingRowStyle CssClass="AltRowStyle" BackColor="#CCCCCC" />
            <PagerStyle CssClass="PagerStyle" BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
            <HeaderStyle CssClass="HeaderStyle" BackColor="Black" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" ></HeaderStyle>
            <PagerTemplate>
            </PagerTemplate>
            <Columns>
       <%--         <asp:TemplateField HeaderText="Course ID" ItemStyle-HorizontalAlign="left">
                    <ItemTemplate>
                        <asp:Label ID="lblCourseId" runat="server" Text='<%#Eval("CourseID") %>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Left"></ItemStyle>
                </asp:TemplateField>--%>


                <asp:TemplateField HeaderText="Course Title" ItemStyle-HorizontalAlign="left">
                    <ItemTemplate>
                        <asp:Label ID="lblCourseTitle" runat="server" Text='<%#Eval("CourseTitle") %>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Left"></ItemStyle>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Last Accessed Date" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:Label ID="lblLastAccessDate" runat="server" Text='<%#Eval("LastAccessDate") %>'  ></asp:Label>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Left"></ItemStyle>

                </asp:TemplateField>
                <asp:TemplateField HeaderText="Completed Date" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:Label ID="lblCompleteDate" runat="server" Text='<%#Eval("CompleteDate") %>'></asp:Label>
                    </ItemTemplate>

                    <ItemStyle HorizontalAlign="Left"></ItemStyle>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Total Time (HH:MM)" ItemStyle-HorizontalAlign= "Center" ItemStyle-VerticalAlign="Middle">
                    <ItemTemplate  >
                        <asp:Label ID="lblElapsedTime" runat="server" Text='<%#Eval("ElapsedTime") %>'  ></asp:Label>
                    </ItemTemplate>

<ItemStyle HorizontalAlign="Left"></ItemStyle>
                </asp:TemplateField>
            </Columns>
            <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F1F1F1" />
            <SortedAscendingHeaderStyle BackColor="#808080" />
            <SortedDescendingCellStyle BackColor="#CAC9C9" />
            <SortedDescendingHeaderStyle BackColor="#383838" />
        </asp:GridView>
    </div>
     <%--    </asp:Panel>    --%>
    </form>
</body>
</html>
