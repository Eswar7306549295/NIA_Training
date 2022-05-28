<%@ Page Title="" Language="C#" AutoEventWireup="true" CodeBehind="CourseAdminUsersList.aspx.cs" Inherits="NIAPRGExams.lib.CourseAdminUsersList" %>


<head runat="server">
    <title></title>
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <link rel="stylesheet" href="./nia_files/bootstrap.min.css">
    <link rel="stylesheet" href="./nia_files/font-awesome.min.css">
    <link rel="stylesheet" href="./nia_files/style.css">
    <link rel="stylesheet" href="./nia_files/versatile.css">
    <link href="./nia_files/bootstrap-datetimepicker.min.css" rel="stylesheet" media="screen">
</head>


<form id="form1" runat="server">

    <br />
    <br />
    <br />
    <br />
    <div id="page-wrapper">
        <div id="Div1" runat="server" class="col-md-12 col-sm-12 col-xs-12 d-flex p-2">
            <div class="bd-m-p">
                Applicants List
                        <asp:label id="Label3" runat="server"></asp:label>


            </div>

            <div class="bs-example4" data-example-id="simple-responsive-table">
                <div class="Table-Row" id="spnsrRpt" runat="server">
                    <div class="Table-Row" style="height: 400px; width: auto; overflow: auto;">

                        <br />
                        <asp:gridview id="GvRpt" runat="server" width="100%" style="margin-left: 20px" autogeneratecolumns="False" cellpadding="3" forecolor="Black" gridlines="Vertical"
                            class="table table-bordered table-condensed table-responsive table-hover " allowpaging="true" pagesize="10"
                            datakeynames="Id" showheaderwhenempty="true" onrowdeleting="GvRpt_RowDeleting">
           
           
             <Columns>
                                        <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="SNo.">
                                            <ItemTemplate>
                                                <%#  Container.DataItemIndex + 1 %>
                                            </ItemTemplate>

                                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                        </asp:TemplateField>
                                             <asp:TemplateField HeaderText="Name" ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:Label ID="lblSalutation" runat="server" Text='<%#Eval("Name") %>'></asp:Label>
                                            </ItemTemplate>

                                           <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Mobile" ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:Label ID="lblName" runat="server" Text='<%#Eval("Mobile") %>'></asp:Label>
                                            </ItemTemplate>

<ItemStyle HorizontalAlign="Center"></ItemStyle>
                                        </asp:TemplateField>
                                               
                                        <asp:TemplateField HeaderText="Pan No" ItemStyle-HorizontalAlign="left">
                                            <ItemTemplate>
                                                <asp:Label ID="lblpanno" runat="server" Text='<%#Eval("PANNo") %>'></asp:Label>
                                            </ItemTemplate>

<ItemStyle HorizontalAlign="Left"></ItemStyle>
                                        </asp:TemplateField>
                                             <asp:TemplateField HeaderText="ModuleOpted" ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:Label ID="lblModuleOpted" runat="server" Text='<%#Eval("ModuleOpted") %>'></asp:Label>
                                            </ItemTemplate>

<ItemStyle HorizontalAlign="Center"></ItemStyle>
                                        </asp:TemplateField>
                                           <asp:TemplateField HeaderText="Exam Center" ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:Label ID="Label1" runat="server" Text='<%#Eval("ExamCentre") %>'></asp:Label>
                                            </ItemTemplate>

<ItemStyle HorizontalAlign="Center"></ItemStyle>
                                        </asp:TemplateField>
                                              <asp:TemplateField HeaderText="Payment Amount" ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:Label ID="lblAppliedfor" runat="server" Text='<%#Eval("PaymentAmount") %>'></asp:Label>
                                            </ItemTemplate>

<ItemStyle HorizontalAlign="Center"></ItemStyle>
                                        </asp:TemplateField>
                                             
                                             <asp:TemplateField HeaderText="Status" ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:Label ID="Label2" runat="server" Text='<%#Eval("Status") %>'></asp:Label>
                                            </ItemTemplate>

<ItemStyle HorizontalAlign="Center"></ItemStyle>
                                        </asp:TemplateField>
                                            

                                          
 
                                            <asp:TemplateField HeaderText="Remove">
<itemtemplate>
<span önclick="return confirm('Are you sure to Delete this Property?')">
<asp:LinkButton ID="lblID" runat="Server" CommandArgument='<%# Eval("Id") %>' CommandName="Delete" Text="Delete"></asp:LinkButton></span>

</itemtemplate></asp:TemplateField>

                                        </Columns>
            <EmptyDataTemplate>
        <div align="center">No records found.</div>
    </EmptyDataTemplate>
                   </asp:gridview>

                        <div runat="server" id="gvpager" style="display: none">
                        </div>
                    </div>
                </div>

            </div>



            <div class="row">
                <div id="dvamt" runat="server" class="col-md-12 col-sm-12 col-xs-12 d-flex p-2">
                    <div class="bd-m-p">
                        Total Amount :
                        <asp:label id="lbltotalamount" runat="server"></asp:label>


                    </div>
                </div>
                <br />
                <br />
                <asp:button id="bnprocessed" cssclass="form-control btn btn-success .btn-next" runat="server" backcolor="#009688" forecolor="#ffffff"
                    font-bold="true" validationgroup="vg" causesvalidation="true" text="PROCEED TO PAY" width="15%" height="7%" onclick="Proceed_Click" />
                <asp:hiddenfield id="hdngatewayreq" runat="server"></asp:hiddenfield>
            </div>

        </div>



</form>
