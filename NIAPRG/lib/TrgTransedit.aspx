<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TrgTransedit.aspx.cs" Inherits="NIAPRGExams.exam.TrgTransedit" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
     <meta name="viewport" content="width=device-width, initial-scale=1">
    <link rel="stylesheet" href="./nia_files/bootstrap.min.css">
  <link rel="stylesheet" href="./nia_files/font-awesome.min.css">
  <link rel="stylesheet" href="./nia_files/style.css">
  <link rel="stylesheet" href="./nia_files/versatile.css">

  <link href="./nia_files/bootstrap-datetimepicker.min.css" rel="stylesheet" media="screen">
       
    <!-- Custom CSS -->
   <%-- <link href="lib/css/style.css" rel="stylesheet">--%>
    <link href="lib/css/style.css" rel="stylesheet" />
    <style type="text/css">
        .educss label{      

            display:inline !important; 
        }
    </style>
  
</head>
<body>
     <form id="niaApp" runat="server" autocomplete="off" >
    <div class="container">
      <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
<!--Header-->
        
	<div class="row" id="header">
		<div class="col-xs-3 n-m-n-p"><img class="logo" src="./nia_files/logo.jpg"></div>
		<div class="col-xs-7" style="text-align:center; margin-bottom:20px;">
		<%--	<p id="school-address">EXAMINATION REGISTRATION FORM </p>--%>
			<%--<p id="school-name">Online Course for Insurance Brokers </p>--%>
		</div>		
		<div class="col-xs-3"></div>
	</div>
	 <div class="panel" style="display:block; padding: 18px;">
	<div class="tab-content" id="totalCont">
	  <div id="make-payment" >
	  <span style="color:red;" id="errorMsg" ng-bind="errMsg" class="ng-binding"></span>
		
		<!--Step 1: Identify Yourself-->
		
           <div class="row">
               <div class="col-md-6 col-sm-12 col-xs-12">
                  <div class="form-group">
                     <label>PAN No.(User Id) <font>*</font></label>
                     <asp:TextBox ID="txtpan" runat="server" class="form-control ng-pristine ng-untouched ng-valid ng-valid-maxlength" AutoPostBack="true"
                     EnableViewState="true"
                         placeholder="" ng-model="nia.txtpan" data-mandatory="1" data-validatefor="PAN" data-errtext="Invalid PAN number" maxlength="10"></asp:TextBox>
                              </div>
               </div>
              <div class="col-md-6 col-sm-12 col-xs-12">
                  <div class="form-group" >
                     <label>Name of the candidate <font>*</font></label>
                     <%-- <asp:DropDownList ID="ddlsalutation" runat="server" style="width:16%;float:left; font-weight:bold;" class="selectpicker form-control ng-pristine ng-untouched ng-valid" ng-init="nia.salutation = &#39;Mr.&#39;" >
                          <asp:ListItem Value="Mr." Text="Mr."></asp:ListItem>                        
                          <asp:ListItem Value="Ms." Text="Ms."></asp:ListItem> 
                          <asp:ListItem Value="Dr." Text="Dr."></asp:ListItem>
                      </asp:DropDownList>--%>
                     <asp:TextBox ID="txtnameOfCandidate" runat="server" style="float:left;width:83%;" class="form-control ng-pristine ng-untouched ng-valid ng-valid-maxlength" ng-model="nia.nameOfCandidate" data-mandatory="1" data-validatefor="name"
                          data-errtext="Invalid candidate name" placeholder="" maxlength="100"></asp:TextBox>
                                </div>
               </div>
               
            </div>
            <div class="row">
                 <div class="col-md-6 col-sm-12 col-xs-12">
                  <div class="form-group">
                     <label>Payment Ref <font>*</font></label>
                    <asp:TextBox ID="txtPaymnetRef" runat="server" class="form-control ng-pristine ng-untouched ng-valid ng-valid-maxlength" placeholder=""
                          maxlength="60"></asp:TextBox>
                 </div>
               </div>
                <div class="col-md-6 col-sm-12 col-xs-12">
								<div class="form-group">
									<label>Trans Status</label>
									<asp:TextBox id="txtTransStatus"  runat="server"
                                        class="form-control ng-pristine ng-untouched ng-valid ng-valid-maxlength"  placeholder="" maxlength="50" ></asp:TextBox>
								</div>
							</div>
               </div>
               
           <%-- </div>--%>
            
         
           <div class="row">

                <div class="col-md-6 col-sm-12 col-xs-12">
						<div class="form-group">
							<label>Broking Module Opted for <font>*</font></label>
							 <asp:DropDownList ID="ddlbrokingModule" runat="server" class="selectpicker form-control ng-pristine ng-untouched ng-valid" 
                                 ng-model="nia.ddlbrokingModule" data-mandatory="1" data-validatefor="alfanumeric" data-errtext="Please select Broking Module">
                          <asp:ListItem Value="0">Select</asp:ListItem>
                           <asp:ListItem Value="NIAC01">Direct Life Insurance</asp:ListItem>
                           <asp:ListItem Value="NIAC02">Direct General Insurance</asp:ListItem>
                                 <asp:ListItem Value="NIAC03">Direct Life and General Insurance</asp:ListItem>
                                  <asp:ListItem Value="NIAC04">Reinsurance</asp:ListItem>
                                  <asp:ListItem Value="NIAC05">Composite</asp:ListItem>
                                 <asp:ListItem Value="RenewalNiaC05">Brokers online course (for Renewal)</asp:ListItem>
                      </asp:DropDownList>
                            						</div>
					</div>

               <div class="col-md-6 col-sm-12 col-xs-12">
                  <div class="form-group">
                     <label>Status</label>
                      <asp:DropDownList  ID="ddlStatus" runat="server" class="form-control">
                            <asp:ListItem Value="10" Text="Select">Select</asp:ListItem>
                           <asp:ListItem Value="1">Registered</asp:ListItem>
                             <%-- <asp:ListItem Value="3">Certified</asp:ListItem>--%>
                             <asp:ListItem Value="2">Payment Failed</asp:ListItem>
                             <asp:ListItem Value="0">Payment Not Made</asp:ListItem>
                            <asp:ListItem Value="9">Payment Refund</asp:ListItem>

                      </asp:DropDownList>
                                     
                  </div>
               </div>
              
            </div>


           <div class="row">
               <div class="col-md-12 col-sm-12 col-xs-12 text-middle">
                  <div class="form-group">
						<%--<div class="bd-dis">--%>
                    <span style="color:red;" id="tc" ng-bind="tc" class="ng-binding"></span>
                           
					<input type="checkbox" visible="false" runat="server" id="CHKagree" value="Y" name="tandc" data-mandatory="1" 
                        ng-model="nia.selected" data-validatefor="alfanumeric" data-errtext="Please confirm to proceed" 
                        class="ng-pristine ng-untouched ng-valid" /> &nbsp; <asp:Label runat="server" ID="lblreg" Visible="false" >User Registration / Course Enrollment</asp:Label>
				<%--</div>--%>

                 
               </div>
              
            </div>
            
    
   </div>
	
   
        

            						
<div class="text-middle" style="text-align:center">
<asp:Button ID="btnSave" CssClass="form-control btn btn-success .btn-next" runat="server" OnClientClick="return ValidateForm();" BackColor="#009688"   ForeColor="#ffffff"
    Font-Bold="true" ValidationGroup="vg" CausesValidation="true"  Text="Save"   width="30%" Height="100%" OnClick="btnSave_Click"/>
</div>
				
	

</div>
</div>
     

            </div>  	<%--</container>--%>
   
        
 
<script type="text/javascript" src="./nia_files/jquery-1.11.2.min.js"></script>
<script type="text/javascript" src="./nia_files/angular.min.js"></script>
<script type="text/javascript" src="./nia_files/bootstrap.min.js"></script>
<script type="text/javascript" src="./nia_files/bootstrap-datetimepicker.js" charset="UTF-8"></script>
<script type="text/javascript" src="./nia_files/validateform.js" charset="UTF-8"></script>
    </form>
    <script type="text/javascript">

        var app = angular.module("niaApp", []);

        $(document).ready(function () {
            $('.form_date').datetimepicker({
                language: 'en',
                weekStart: 1,
                todayBtn: 1,
                autoclose: 1,
                todayHighlight: 1,
                startView: 2,
                minView: 2,
                forceParse: 0,
                todayBtn: 0,
                format: 'mm/dd/yyyy',
                endDate: new Date()
            });

        });

        function ValidateForm() {
            <%-- $("#<%=btnsubmit.ClientID %>").click(function () {--%>
            //Set value in flip1
            //if(field1 !="" && field2 !=""){

            if (!$("#totalCont").validateForm({ validate: "execute", error_align: "bottom" })) {

                return false;
            }

            else {
                var PaymnetRef = document.getElementById('txtPaymnetRef').value;
                if (PaymnetRef == "") {
                    alert("Please Enter Payment Reference Number");
                    document.getElementById('<%=txtPaymnetRef.ClientID %>').focus();
                    return false;
                }

                else {
                    var TransStatus = document.getElementById('txtTransStatus').value;
                    if (TransStatus == "") {
                        alert("Please Enter Trans Status");
                        document.getElementById('<%=txtTransStatus.ClientID %>').focus();
                        return false;
                    }

                    else {
                        var Status = document.getElementById('ddlStatus').value;
                        if (Status == "10") {
                            alert("Please Select Status");
                            document.getElementById('<%=ddlStatus.ClientID %>').focus();
                            return false;
                        }

                        else {
                            return true;
                        }

                    }
                }
            }
        }

  </script>
</body>
</html>
