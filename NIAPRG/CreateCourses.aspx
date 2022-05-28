<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CreateCourses.aspx.cs" Inherits="NIAPRG.CreateCourses" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<style>
input[type=text], select {
  width: 100%;
  padding: 12px 20px;
  margin: 8px 0;
  display: inline-block;
  border: 1px solid #ccc;
  border-radius: 4px;
  box-sizing: border-box;
}

input[type=submit] {
  width: 50%;
  background-color: #4CAF50;
  color: white;
  padding: 14px 20px;
  margin: 8px 0;
  border: none;
  border-radius: 4px;
  cursor: pointer;
}

input[type=submit]:hover {
  background-color: #45a049;
}

div {
  border-radius: 5px;
}
#customers {
  font-family: Arial, Helvetica, sans-serif;
  border-collapse: collapse;
  width: 100%;
}

#customers td, #customers th {
  border: 1px solid #ddd;
  padding: 8px;
}

#customers tr:nth-child(even){background-color: #f2f2f2;}

#customers tr:hover {background-color: #ddd;}

#customers th {
  padding-top: 12px;
  padding-bottom: 12px;
  text-align: left;
  background-color: #04AA6D;
  color: white;
}
    .BorderColor {
        margin-left: 32px;
        margin-right: 0px;
    }
</style>
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="form-inline">
        <div class="form-group">
        <h2 style="text-align:center">Create Course</h2>
        <br /><br />
       &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
       External Event Type:
<asp:DropDownList id="ddlEventType" runat="server"  CssClass ="form-control" style="text-align:center;width:20%;" />
<br/><br/>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Course Code:
<asp:TextBox id="txtCourseCode"  runat="server" style="text-align:center;width:20%;" CssClass ="form-control"/>
<br/><br/>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Course Name:
<asp:TextBox id="txtCourseName"  runat="server" style="text-align:center;width:20%;" CssClass ="form-control"/>
<br/><br/>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;


<asp:Button id="btnSubmit"  runat="server" Text="Submit" style="text-align:center;" CssClass ="form-control" OnClick="btnSubmit_Click" Width="186px" />
<br/><br/>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            </div>
        </div>
        <div class="Table-Row" style="height: auto; width: auto; overflow: auto;" id="customers">
                                                <%--height:200px;width:1129px;--%>


                                                <asp:GridView ID="GvRpt" runat="server" AutoGenerateColumns="true" CssClass="BorderColor" Width="90%"
                                                    AllowPaging="true" PageSize="50"  
                                                    Font-Size="11pt" Height="16px">
                                                    <FooterStyle CssClass="FooterStyle" />
                                                    <EmptyDataRowStyle CssClass="EmptyDataRowStyle" />
                                                    <RowStyle CssClass="RowStyle" Font-Bold="False" />
                                                    <AlternatingRowStyle CssClass="AltRowStyle" />
                                                    <PagerStyle CssClass="PagerStyle" />
                                                    <HeaderStyle CssClass="HeaderStyle"></HeaderStyle>
                                                    <PagerSettings Mode="NumericFirstLast" Position="TopAndBottom" />

                                                   
                                                </asp:GridView>
                                                <br />

                                                <div runat="server" id="gvpager" style="display: none">
                                                    <table>
                                                        <tr>
                                                            <td>Records per page &nbsp;:&nbsp;
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txtPageRecords" runat="server"
                                                                    Height="30" AutoPostBack="true" CssClass="form-control" Text="10" MaxLength="5" Width="100px"></asp:TextBox>
                                                               
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
