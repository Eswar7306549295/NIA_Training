<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ExamUsers.aspx.cs" Inherits="NIAPRG.lib.ExamUsers" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
     
    <style type="text/css">
    .GridDock
    {
        overflow-x: auto;
        overflow-y: hidden;
        width: 100%;
        padding: 0 0 17px 0;
    }
</style>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server" CombineScripts="false">
        <Scripts>

            <asp:ScriptReference Path="../js/webkit.js" />
        </Scripts>

    </asp:ToolkitScriptManager>
        <div class="GridDock" id="dvGridWidth">
    <div>
        <center>
            <h3>Exam Users Data</h3><br />
            <div ><asp:TextBox ID="txtfrom" runat="server" ></asp:TextBox></div>
            <div style="text-align:right;"> <asp:Button runat="server" ID="btnExport" Text="Export To Excel" OnClick="btnExport_Click" /></div>
          <asp:GridView ID="GdvExamUsers" runat="server" AllowPaging="true" Width="100%" PageSize="5"  CssClass="BorderColor" >
              <FooterStyle CssClass="FooterStyle" />
                                        <EmptyDataRowStyle CssClass="EmptyDataRowStyle" />
                                        <RowStyle CssClass="RowStyle" Font-Bold="False" />
                                        <AlternatingRowStyle CssClass="AltRowStyle" />
                                        <PagerStyle CssClass="PagerStyle" />
                                        <HeaderStyle CssClass="HeaderStyle"></HeaderStyle>
                                        <PagerSettings Mode="NumericFirstLast" />
           <%-- <AlternatingRowStyle BackColor="White" />
            <EditRowStyle BackColor="#2461BF" />
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#EFF3FB" />
            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#F5F7FB" />
            <SortedAscendingHeaderStyle BackColor="#6D95E1" />
            <SortedDescendingCellStyle BackColor="#E9EBEF" />
            <SortedDescendingHeaderStyle BackColor="#4870BE" />--%>
               <PagerTemplate>
                                        </PagerTemplate>
        </asp:GridView>
    </center>
    </div>
        <div runat="server" id="gvpager">
                                        <table>
                                            <tr>
                                                <td>Records per page &nbsp;:&nbsp;
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtPageRecords" runat="server" 
                                                        Height="30" AutoPostBack="true" CssClass="form-control" Text="10" MaxLength="5" Width="100px"></asp:TextBox>
                                                    <asp:FilteredTextBoxExtender ID="txtPinPageRecords_FTE" runat="server" Enabled="true"
                                                        TargetControlID="txtPageRecords" ValidChars="0123456789">
                                                    </asp:FilteredTextBoxExtender>
                                                </td>
                                                <td style="padding-left: 10px;">
                                                    <font color="red">Page </font>
                                                </td>
                                                <td style="padding-left: 10px;">
                                                    <asp:DropDownList ID="ddlPagingrpt" runat="server" AutoPostBack="true" CssClass="form-control"
                                                        Height="30" />
                                                </td>
                                                <td style="padding-left: 10px;">
                                                    <asp:Label ID="Lblpagesrpt" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
            </div>
    </form>
</body>
</html>
