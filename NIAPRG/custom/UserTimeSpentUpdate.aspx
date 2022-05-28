<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserTimeSpentUpdate.aspx.cs" Inherits="NIAPRG.Custom.UserTimeSpentUpdate" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <style type="text/css">
        .btnexcel {
            margin-left: -175px;
        }

        .btnphoto {
            margin-left: -175px;
        }
        /*.Pagingstyle
         {
              
              padding-top: -75px !important;
         }*/
    </style>
    <title></title>

    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css" />

    <%--  <script src="http://ajax.googleapis.com/ajax/libs/jquery/1.3.2/jquery.min.js"></script>--%>


    <link href="../lib/css/daterangepicker.min.css" rel="stylesheet" />
    <link href="../lib/css/bootstrap.min.css" rel="stylesheet" type='text/css' />

    <%--<link href="css/bootstrap-multiselect.min.css" rel="stylesheet" />--%>

    <link href="../lib/css/select2.min.css" rel="stylesheet" type='text/css' />

    <!-- Custom CSS -->
    <link href="../lib/css/style.css" rel="stylesheet" type='text/css' />

    <!-- Graph CSS -->
    <link href="../lib/css/font-awesome.css" rel="stylesheet" />
    <link href="../lib/css/Gridview.css" rel="stylesheet" />

    <!-- jQuery -->
    <!-- lined-icons -->
    <link rel="stylesheet" href="../lib/css/icon-font.min.css" type='text/css' />
    <link href="../lib/css/daterangepicker.min.css" rel="stylesheet" />

    <!-- //lined-icons -->

    <!-- chart -->

    <!-- //chart -->
    <!--animate-->

    <link href='//fonts.googleapis.com/css?family=Cabin:400,400italic,500,500italic,600,600italic,700,700italic' rel='stylesheet' type='text/css' />

    <link href="../lib/css/animate.css" rel="stylesheet" type="text/css" media="all" />
    <script src="../lib/js/jquery-1.10.2.min.js"></script>
    <style>
        #myBtn {
            display: none;
            position: fixed;
            bottom: 20px;
            right: 30px;
            z-index: 99;
            border: none;
            outline: none;
            background-color: #789fe4;
            color: white;
            cursor: pointer;
            padding: 15px;
            border-radius: 10px;
        }

            #myBtn:hover {
                background-color: #555;
            }

        .auto-style1 {
            width: 280px;
        }
    </style>



</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>



            <asp:UpdatePanel runat="server" ID="UpdatePanel1">
                <ContentTemplate>


                    <div id="page-wrapper">

                        <div class="graphs">




                            <div>

                                <div class="bs-example4" data-example-id="simple-responsive-table">


                                    <div class="Table-Row" id="spnsrRpt" runat="server">

                                        <div class="table-responsive">
                                            <table style="width: 80%;">
                                                <tr>
                                                    <td>
                                                        <div class="form-inline">
                                                            <div class="form-group">
                                                                <label id="lblsreach">Search</label>
                                                                <asp:TextBox ID="txtsearch" runat="server" placeholder="Username/UserID" CssClass="form-control">
                                                                 
                                                                </asp:TextBox>
                                                                <asp:Button ID="btnsearch" runat="server" OnClick="btnsearch_Click" Text="Get User Time Spent" Class="btn btn-success" />
                                                                &nbsp;&nbsp;&nbsp;
                                                            <span id="spnname" runat="server" style="color: blue;" visible="false">Name : </span>
                                                                <asp:Label ID="lblusernames" runat="server" Visible="false"> </asp:Label>&nbsp;&nbsp;&nbsp;
                                                           <span id="spntotaltime" runat="server" style="color: blue;" visible="false">Total Time (HH:MM) : </span>
                                                                <asp:Label ID="lblcoursetotaltime" runat="server" Visible="false"></asp:Label>&nbsp;&nbsp;&nbsp;
                                                                <br />
                                                          &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
							&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
							&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
							&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                            <asp:Label ID="lblmessage" runat="server" Text="Label" Style="color: red;" Visible="false"></asp:Label>

                                                            </div>
                                                        </div>
                                                    </td>
                                                </tr>


                                            </table>
                                            <div>
                                            </div>
                                            <br />
                                            <div class="Table-Row" style="height: auto; width: auto; overflow: auto;">

                                                <asp:GridView ID="GvRpt" runat="server" AutoGenerateColumns="False" CssClass="BorderColor" Width="100%" OnRowCommand="GridView2_RowCommand"
                                                    AllowPaging="True" PageSize="50"
                                                    Font-Size="11pt" Height="16px" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" ForeColor="Black" GridLines="Vertical">
                                                    <FooterStyle CssClass="FooterStyle" BackColor="#CCCCCC" />
                                                    <EmptyDataRowStyle CssClass="EmptyDataRowStyle" />
                                                    <RowStyle CssClass="RowStyle" />
                                                    <AlternatingRowStyle CssClass="AltRowStyle" BackColor="#CCCCCC" />
                                                    <HeaderStyle CssClass="HeaderStyle" BackColor="Black" Font-Bold="True" ForeColor="White"></HeaderStyle>

                                                    <Columns>

                                                        <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="SNo.">
                                                            <ItemTemplate>
                                                                <%#  Container.DataItemIndex + 1 %>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Center" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="UserID" ItemStyle-HorizontalAlign="Center" Visible="false">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lbluserid" runat="server" Text='<%#Eval("userid") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Center" />

                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="User Name" ItemStyle-HorizontalAlign="left">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblusername" runat="server" Text='<%#Eval("username") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Course ID" ItemStyle-HorizontalAlign="Center" Visible="false">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblcourseid" runat="server" Text='<%#Eval("courseid") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Center" />
                                                        </asp:TemplateField>


                                                        <asp:TemplateField HeaderText="Cousre Title" ItemStyle-HorizontalAlign="left">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblcourse" runat="server" Text='<%#Eval("course") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Lesson Title" ItemStyle-HorizontalAlign="left">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblTitle" runat="server" Text='<%#Eval("Title") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="ScoID" ItemStyle-HorizontalAlign="Center" Visible="false">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblscoid" runat="server" Text='<%#Eval("scoid") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Center" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Time (HHHH:MM:SS.MS)" ItemStyle-HorizontalAlign="left">
                                                            <ItemTemplate>
                                                                <asp:TextBox ID="txttotaltime" runat="server" Text='<%#Eval("TotalTime")  %>'></asp:TextBox>
                                                                <asp:Label ID="lbllinkusername" runat="server" Text='<%#Eval("username")  %>' Visible="false"></asp:Label>
                                                                <asp:Label ID="lbllinktotaltime" runat="server" Text='<%#Eval("TotalTime")  %>' Visible="false"></asp:Label>
                                                                <asp:Label ID="lbllinkscoid" runat="server" Text='<%#Eval("scoid")  %>' Visible="false"></asp:Label>
                                                                <asp:Label ID="lbllinkuserid" runat="server" Text='<%#Eval("userid")  %>' Visible="false"></asp:Label>
                                                                <asp:Label ID="lbllinkcourseid" runat="server" Text='<%#Eval("courseid") %>' Visible="false"></asp:Label>
                                                                <asp:LinkButton runat="server" ID="lblbtntotaltime" Text="Update" CommandArgument='<%# ((GridViewRow) Container).RowIndex %>' CommandName="TotalTime"
                                                                    Style="color: blue; font-weight: bold;"></asp:LinkButton>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                    </Columns>
                                                    <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                                                    <SortedAscendingCellStyle BackColor="#F1F1F1" />
                                                    <SortedAscendingHeaderStyle BackColor="#808080" />
                                                    <SortedDescendingCellStyle BackColor="#CAC9C9" />
                                                    <SortedDescendingHeaderStyle BackColor="#383838" />
                                                </asp:GridView>


                                            </div>


                                        </div>
                                        <%-- </div>--%>

                                        <asp:HiddenField ID="TabName" runat="server" />
                                        <%--</div>--%>
                                    </div>
                                </div>
                            </div>


                        </div>

                    </div>

                </ContentTemplate>
                <Triggers>
                </Triggers>
            </asp:UpdatePanel>

        </div>
    </form>
</body>
</html>

<script src="../lib/js/wow.min.js"></script>
<script src="../lib/js/Chart.js"></script>
<script src="../lib/js/jquery.nicescroll.js"></script>
<script src="../lib/js/scripts.js"></script>

<!-- Bootstrap Core JavaScript -->
<script src="../lib/js/bootstrap.min.js"></script>
<script src="../lib/js/bootstrap.js"></script>
<script src="../lib/js/moment.min.js"></script>
<script src="../lib/js/bootstrap-datepicker.min.js"></script>
<script src="../lib/js/bootstrap-datetimepicker.min.js"></script>
<script src="../lib/js/select2.min.js"></script>
<%--<script src="js/bootstrap-multiselect.min.js"></script>--%>

