<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CourseCompletion.aspx.cs" Inherits="NIAPRG.custom.CourseCompletion" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div style="text-align: center">
            <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>



            <asp:UpdatePanel runat="server" ID="UpdatePanel1">
                <ContentTemplate>
                    <br />
                    <br />
                    <asp:Button ID="btnCourseCompletion" runat="server" OnClick="btnCourseCompletion_Click" Text="Update Course Completion" Style="color: blue" />
                    <br />
                    <br />
                    <asp:Label ID="lblmessage" runat="server" Text="Label" Style="color: red;" Visible="false"></asp:Label>
                </ContentTemplate>
                <Triggers>
                </Triggers>
            </asp:UpdatePanel>
        </div>
    </form>
</body>
</html>
