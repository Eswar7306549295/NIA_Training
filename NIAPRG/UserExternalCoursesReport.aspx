<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserExternalCoursesReport.aspx.cs" Inherits="NIAPRG.UserExternalCoursesReport" %>

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
    </style>



    <script type="text/javascript">
        function handleClick() {
            alert('handleClick');
            var dropDown = document.getElementById("ddltype");
            alert(dropDown);
            var dropValue = dropDown.options[dropDown.selectedIndex].value;
            var link = document.getElementById("detailswindow");
            if (dropDown.value == "02") {
                alert('pass');
                link.href = "sendrcpt.aspx?mode=modename&theme=Standard";
            }
        }


        $(document).ready(function () {
            $('.datepicker').datepicker({
                format: 'dd-mm-yyyy'

                //endDate: '1m'
            });
        });


    </script>

    <script type="text/javascript">

        function checkAll(objRef) {
            var GridView = objRef.parentNode.parentNode.parentNode;
            var inputList = GridView.getElementsByTagName("input");
            for (var i = 0; i < inputList.length; i++) {
                //Get the Cell To find out ColumnIndex
                var row = inputList[i].parentNode.parentNode;
                if (inputList[i].type == "checkbox" && objRef != inputList[i]) {
                    if (objRef.checked) {
                        //If the header checkbox is checked
                        //check all checkboxes
                        //and highlight all rows
                        //  row.style.backgroundColor = "aqua";
                        inputList[i].checked = true;
                    }
                    else {
                        //If the header checkbox is checked
                        //uncheck all checkboxes
                        //and change rowcolor back to original
                        if (row.rowIndex % 2 == 0) {
                            //Alternating Row Color
                            //   row.style.backgroundColor = "#C2D69B";
                        }
                        else {
                            //   row.style.backgroundColor = "white";
                        }
                        inputList[i].checked = false;
                    }
                }
            }
        }
    </script>

</head>
<body>
    <form id="form1" runat="server" >
        <div>
            <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server" CombineScripts="false">
                <Scripts>
                    <asp:ScriptReference Path="../lib/js/webkit.js" />
                    <%--<script src="../lib/js/webkit.js"></script>--%>
                </Scripts>

            </asp:ToolkitScriptManager>


            <asp:UpdatePanel runat="server" ID="UpdatePanel1">
                <ContentTemplate>


                    <div id="page-wrapper" id="customers">
                     
                        <div class="graphs">



                            <asp:Button runat="server" ID="hiddenTargetControlForModalPopup_Rpt" Style="display: none" />
                               <div>

                                <div class="bs-example4" data-example-id="simple-responsive-table">


                                    <button onclick="topFunction()" id="myBtn" title="Go to top">Top</button>
                                    <div class="Table-Row" id="spnsrRpt" runat="server">

                                        <div class="table-responsive">
                                            <table style="width: 90%;" >
                                                                                                    <h2 style="text-align: center;">User External Courses Report</h2>

                                                <tr>

                                                    <td style="text-align: left;">
                                                        <div class="form-inline">
                                                            <div class="form-group">
                                                                <label for="email" id="lbltype" runat="server">Type:</label>

                                                                <asp:DropDownList ID="ddltype" runat="server" CssClass="form-control" AutoPostBack="false" Height="34px" Width="130px">
                                                                    <%--<asp:ListItem Value="1">Registered</asp:ListItem>
                                                                    <asp:ListItem Value="Completed">Completed</asp:ListItem>
                                                                    <asp:ListItem Value="2">Payment Failed</asp:ListItem>
                                                                    <asp:ListItem Value="0">Payment Not Made</asp:ListItem>
                                                                    <asp:ListItem Value="9">Payment Refund</asp:ListItem>--%>
                                                                </asp:DropDownList>
                                                            </div>

                                                        </div>
                                                    </td>

                                                      <td style="text-align: left;">
                                                        <div class="form-inline">
                                                            <div class="form-group">
                                                                <label for="email" id="lblfrom" runat="server">Start Date:From</label>

                                                                <asp:TextBox ID="txtstart" runat="server" placeholder="DD/MM/YYYY" CssClass="form-control datepicker" Width="200px" />
                                                            </div>

                                                        </div>
                                                    </td>
                                                    <td style="text-align: left;">
                                                        <div class="form-inline">
                                                            <div class="form-group">
                                                                <label for="email" id="lblto" runat="server">To</label>

                                                                <asp:TextBox ID="txtto" runat="server" placeholder="DD/MM/YYYY" CssClass="form-control datepicker" Width="200px" />
                                                            </div>

                                                        </div>
                                                    </td>

                                                    <td style="text-align: left; padding-left: 5px">
                                                        <div class="form-inline">
                                                            <div class="form-group">
                                                                <label for="email" id="lblSearch" runat="server">Search(EmpID):</label>
                                                                <asp:TextBox ID="txtSearch" runat="server" CssClass="form-control" Width="400px" />
                                                            </div>
                                                        </div>
                                                    </td>


                                                    <td style="text-align: left; padding-top: 25px">

                                                        <asp:Button runat="server" ID="btngetdetails" Text="Get Details" placeholder="DD/MM/YYYY" CssClass="btn-primary" target="_blank" OnClick="btngetdetails_Click" />
                                                    </td>
                                                    <br />

                                                </tr>

                                            </table>
                                            <br />
                                            <br />
                                            <div class="row">
                                                <div class="col-md-2">

                                                    <asp:Button ID="btnUpdate" runat="server" OnClick="Update" CssClass="btn btn-success" Text="Certified" Visible="false" />


                                                </div>

                                                <div class="col-md-2">

                                                    <asp:Button runat="server" ID="btnExport" Text="Export Excel" CssClass="btn-primary btnexcel" Visible="false" OnClick="btnExport_Click" />

                                                </div>
                                                <%-- <div class="col-md-2">
                                                    <asp:Button ID="exportphotos" runat="server" CssClass="btn-primary btnphoto" Text="Export Photos" Visible="false" OnClick="exportphotos_Click" />


                                                </div>--%>
                                                <div class="col-md-2">
                                                    <asp:Button ID="exportpdf" runat="server" CssClass="btn btn-success" Text="Export Pdf's" Visible="false" />
                                                    <%--OnClick="exportpdf_Click"--%>
                                                    <asp:Label ID="lblpdf" runat="server" Style="padding-left: 30px" ForeColor="#CC0000"></asp:Label>
                                                </div>
                                                <div class="col-md-4">
                                                    <asp:Label ID="lblphotos" runat="server" Style="padding-left: 30px" ForeColor="#CC0000"></asp:Label>
                                                </div>
                                            </div>

                                            <%--  <div class="row clearfix"></div>
                                <div class="row"> </div>
                                <br />
                                <div class="row clearfix"></div>--%>
                                            <%--overflow property is for scrolling--%>
                                            <%--auto value means automatic in every where--%>


                                            <div class="Table-Row" style="height: auto; width: auto; overflow: auto;" id="customers">
                                                <%--height:200px;width:1129px;--%>


                                                <asp:GridView ID="GvRpt" runat="server" AutoGenerateColumns="false" CssClass="BorderColor" Width="100%"
                                                    AllowPaging="true" PageSize="50" OnPageIndexChanging="GvRpt_PageIndexChanging" OnRowDataBound="GvRpt_RowDataBound"
                                                    Font-Size="11pt" Height="16px">
                                                    <FooterStyle CssClass="FooterStyle" />
                                                    <EmptyDataRowStyle CssClass="EmptyDataRowStyle" />
                                                    <RowStyle CssClass="RowStyle" Font-Bold="False" />
                                                    <AlternatingRowStyle CssClass="AltRowStyle" />
                                                    <PagerStyle CssClass="PagerStyle" />
                                                    <HeaderStyle CssClass="HeaderStyle"></HeaderStyle>
                                                    <PagerSettings Mode="NumericFirstLast" Position="TopAndBottom" />

                                                    <Columns>
                                                        <asp:TemplateField HeaderText="Course Type" ItemStyle-HorizontalAlign="Center">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblCourseType" runat="server" Text='<%#Eval("CourseType") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="EmpID" ItemStyle-HorizontalAlign="Center">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblEmpID" runat="server" Text='<%#Eval("EmpID") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="FirstName" ItemStyle-HorizontalAlign="left">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblFirstName" runat="server" Text='<%#Eval("FirstName") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>


                                                        <asp:TemplateField HeaderText="LastName" ItemStyle-HorizontalAlign="left">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblLastName" runat="server" Text='<%# Eval("LastName") %>'></asp:Label>&nbsp;
                                                   
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Course Code" ItemStyle-HorizontalAlign="left">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblCourseCode" runat="server" Text='<%# Eval("Course Code") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="CourseName" ItemStyle-HorizontalAlign="left">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblCourseName" runat="server" Text='<%# Eval("CourseName") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="Start Date" ItemStyle-HorizontalAlign="left">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblStartDate" runat="server" Text='<%# Eval("Start Date") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="End Date" ItemStyle-HorizontalAlign="left">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblEndDate" runat="server" Text='<%# Eval("End Date") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Grade" ItemStyle-HorizontalAlign="left">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblGrade" runat="server" Text='<%# Eval("Grade") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Status %" ItemStyle-HorizontalAlign="left">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblStatus" runat="server" Text='<%# Eval("Status %") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Certificate" ItemStyle-HorizontalAlign="left">
                                                            <ItemTemplate>
                                                                <a target="_blank"  href='https://egurupmi.ntpclakshya.co.in<%#DataBinder.Eval(Container.DataItem, "Certificate")%>'>Download</a>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                    </Columns>
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
                    <asp:PostBackTrigger ControlID="btnExport" />
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

<script type="text/javascript">
    jQuery(function ($) {



    });

</script>
