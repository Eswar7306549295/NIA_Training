<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="newregrenewal.aspx.cs" Inherits="NIAPRG.lib.newregrenewal" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml" ng-app="niaApp" ng-controller="niaCtrl" class="ng-scope">
<head runat="server">
    <title></title>
     <meta name="viewport" content="width=device-width, initial-scale=1">
     <link rel="stylesheet" href="./nia_files/bootstrap.css" />
    <link rel="stylesheet" href="./nia_files/main.css" />  
    <link rel="stylesheet" href="./nia_files/bootstrap.min.css">
  <link rel="stylesheet" href="./nia_files/font-awesome.min.css">
  <link rel="stylesheet" href="./nia_files/style.css">
  <link rel="stylesheet" href="./nia_files/versatile.css">
  <link href="./nia_files/bootstrap-datetimepicker.min.css" rel="stylesheet" media="screen">
    
    <!-- Custom CSS -->
    <link href="lib/css/style.css" rel="stylesheet">
    <style type="text/css">
        .educss label{

            display:inline !important; 
        }
    </style>
    <script>
        $(document).ready(function () {


            $("#btnsubmit").hide();

            $("#btnregister").show();

        });
    </script>
    
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
    
</head>
<body style=" background-image: url(./nia_files/vgradpRenewal.gif);">
    <form id="niaApp" runat="server" >
    <div class="container">
       
<!--Header-->
            <button onclick="topFunction()" id="myBtn" title="Go to top">Top</button>

	<div class="row" id="header">
		<div class="col-xs-3 n-m-n-p"><img class="logo" src="./nia_files/logo.jpg"></div>
		<div class="col-xs-7" style="text-align:center; margin-bottom:20px;">
			<p id="school-address">REGISTRATION FORM </p>
			<p id="school-name">Online Course for Insurance Brokers </p>
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
                  <div class="form-group" >
                     <label>Name of the candidate <font>*</font></label>
                      <asp:DropDownList ID="ddlsalutation" runat="server"  style="width:16%;float:left" class="selectpicker form-control ng-pristine ng-untouched ng-valid" ng-init="nia.salutation = &#39;Mr.&#39;" >
                          <asp:ListItem Value="Mr.">Mr.</asp:ListItem>
                   <asp:ListItem Value="Ms.">Ms.</asp:ListItem>
                      </asp:DropDownList>
                     <asp:TextBox ID="txtnameOfCandidate" runat="server" oncopy="return false" onpaste="return false" oncut="return false" style="float:right;width:83%;" class="form-control ng-pristine ng-untouched ng-valid ng-valid-maxlength" ng-model="nia.nameOfCandidate" data-mandatory="1" data-validatefor="name"
                          data-errtext="Invalid candidate name" placeholder="" maxlength="100"></asp:TextBox>
                                </div>
               </div>
               <div class="col-md-6 col-sm-12 col-xs-12">
                  <div class="form-group">
                     <label>Date of Birth <font>*</font></label>
                   
                        <asp:TextBox ID="txtDob" runat="server"  class="form-control ng-pristine ng-untouched ng-valid ng-valid-maxlength" 
                            placeholder="DD/MM/YYYY" value="" data-mandatory="1"  ng-model="nia.txtDob"  data-validatefor="date"
                            data-errtext="Invalid date of birth" maxlength="10" AutoPostBack="false" readonly="false" autocomplete="off"></asp:TextBox>
                        <asp:Label ID="lbdob" runat="server"
 Visible="false"></asp:Label>         
                                        <span class="add-on"><i class="icon-remove"></i></span>
                        <span class="add-on"><i class="icon-th"></i></span>
                     
                     <!--input type="hidden" id="dtp_input2" value="" /--><br>
                  </div>
               </div>
            </div>
            <div class="row">
               <div class="col-md-6 col-sm-12 col-xs-12">
                  <div class="form-group">
                     <label>Address <font>*</font></label>
                          <asp:TextBox ID="txtAddress" runat="server" TextMode="MultiLine" Rows="2" class="form-control ng-pristine ng-untouched ng-valid ng-valid-maxlength" ng-model="nia.txtAddress" 
                              data-mandatory="1" data-validatefor="string" data-errtext="Invalid address" maxlength="110"></asp:TextBox>
                           </div>
               </div>
               <div class="col-md-6 col-sm-12 col-xs-12">
                  <div class="form-group">
                     <label>PIN <font>*</font></label>
                              <asp:TextBox ID="txtpin" runat="server" class="form-control ng-pristine ng-untouched ng-valid ng-valid-maxlength" 
                                  ng-model="nia.txtpin" placeholder="" data-mandatory="1" data-validatefor="pincode" data-errtext="Invalid pin" maxlength="6"></asp:TextBox>
                  </div>
               </div>
            </div>
            <div class="row">
               <div class="col-md-6 col-sm-12 col-xs-12">
                  <div class="form-group">
                     <label>Mobile <font>*</font></label>
                     <asp:TextBox ID="txtmobile" runat="server" oncopy="return false" onpaste="return false" oncut="return false" class="form-control ng-pristine ng-untouched ng-valid ng-valid-maxlength" type="text" ng-model="nia.txtmobile" placeholder=""  data-mandatory="1" data-validatefor="mobile" data-errtext="Invalid mobile number" maxlength="10"></asp:TextBox>
                              </div>
               </div>
               <div class="col-md-6 col-sm-12 col-xs-12">
                  <div class="form-group">
                     <label>Telephone <font>*</font></label>
                                  <asp:TextBox ID="txttel" runat="server" class="form-control ng-pristine ng-untouched ng-valid ng-valid-maxlength" 
                                     ng-model="nia.txttel" placeholder=""  data-mandatory="1" data-validatefor="phone" data-errtext="Invalid telephone number" maxlength="13"></asp:TextBox>
                           </div>
               </div>
            </div>
            <div class="row">
               <div class="col-md-6 col-sm-12 col-xs-12">
                  <div class="form-group">
                     <label>Email ID <font>*</font></label>
                    <asp:TextBox ID="txtemail" runat="server" oncopy="return false" onpaste="return false" oncut="return false" class="form-control ng-pristine ng-untouched ng-valid ng-valid-maxlength" placeholder="" ng-model="nia.txtemail"
                         data-mandatory="1" data-validatefor="email" data-errtext="Invalid email address" maxlength="60"></asp:TextBox>
                                     </div>
               </div>
               <div class="col-md-6 col-sm-12 col-xs-12">
                  <div class="form-group">
                     <label>PAN No.(User ID) <font>*</font></label>
                     <asp:TextBox ID="txtpan" runat="server" oncopy="return false" onpaste="return false" oncut="return false" class="form-control ng-pristine ng-untouched ng-valid ng-valid-maxlength" 
                         placeholder="" ng-model="nia.txtpan" data-mandatory="1" data-validatefor="PAN" data-errtext="Invalid PAN number" maxlength="12"></asp:TextBox>
                      <br/> <p style="font-family:Arial; color:red;">Note: Existing users Please Add PANNO-1 for Re-registration</p>
                              </div>
               </div>
            </div>
            <div class="row">
               <div class="col-md-6 col-sm-12 col-xs-12">
                  <div class="form-group">
                     <label>UIDAI Aadhaar Card No. <font>*</font></label>
                    <asp:TextBox ID="txtAdhar" runat="server" class="form-control ng-pristine ng-untouched ng-valid ng-valid-maxlength" type="text" 
                        placeholder="" ng-model="nia.txtAdhar" data-mandatory="1" data-validatefor="number" data-errtext="Invalid UIDAI Aadhaar number" 
                        maxlength="12"></asp:TextBox>
                                 </div>
               </div>
               <div class="col-md-6 col-sm-12 col-xs-12">
               </div>
            </div>
            <div class="row">
               <div class="sponship-detail-title">Sponsorship Details <font>*</font></div>
            </div>
            <div class="row">
               <div class="col-md-6 col-sm-12 col-xs-12">
                  <div class="form-group">
                     <label>Name of the Company </label>
                                            <asp:DropDownList  ID="ddlcompanylist" runat="server" class="form-control"></asp:DropDownList>

                                      <%--<asp:TextBox ID="txtNameCompany" runat="server" class="form-control ng-pristine ng-untouched ng-valid ng-valid-maxlength" 
                                          type="text" placeholder="" ng-model="nia.txtNameCompany" data-validatefor="nia_name_of_org" 
                                          data-errtext="Invalid company name" maxlength="100"></asp:TextBox>--%>
                  </div>
               </div>
               <div class="col-md-6 col-sm-12 col-xs-12">
                  <div class="form-group">
                     <label>Address </label>
                     <asp:TextBox ID="txtCmpAddress" runat="server" class="form-control ng-pristine ng-untouched ng-valid ng-valid-maxlength" rows="2" placeholder="" ng-model="nia.txtCmpAddress" data-validatefor="string" data-errtext="Invalid company address" maxlength="110"></asp:TextBox>
                            </div>
               </div>
                
            </div>
          <div class="row">
               <div class="col-md-6 col-sm-12 col-xs-12">
                  <div class="form-group">
                     <label>State <font>*</font></label>
                      <asp:DropDownList  ID="ddlstate" runat="server" class="form-control">
                           <asp:ListItem  Value="0">Select </asp:ListItem>
                           <asp:ListItem  Value="1">Andaman and Nicobar </asp:ListItem>
                           <asp:ListItem Value="2">Andhra Pradesh </asp:ListItem>
                           <asp:ListItem Value="3">Arunachal Pradesh </asp:ListItem>
                           <asp:ListItem Value="4">Andaman and Nicobar </asp:ListItem>
                           <asp:ListItem Value="5">Assam </asp:ListItem>
                           <asp:ListItem Value="6">Bihar </asp:ListItem>
                           <asp:ListItem Value="7">Chandigarh </asp:ListItem>
                           <asp:ListItem Value="8">Chhattisgarh </asp:ListItem>
                           <asp:ListItem Value="9">Dadra and Nagar Haveli </asp:ListItem>
                           <asp:ListItem Value="10">Daman and Diu </asp:ListItem>
                           <asp:ListItem Value="11">Delhi </asp:ListItem>
                           <asp:ListItem Value="12">Goa </asp:ListItem>
                           <asp:ListItem Value="13">Gujarat </asp:ListItem>
                           <asp:ListItem Value="14">Haryana </asp:ListItem>
                           <asp:ListItem Value="15">Himachal Pradesh </asp:ListItem>
                           <asp:ListItem Value="16">Jammu and Kashmir</asp:ListItem>
                           <asp:ListItem Value="17">Jharkhand </asp:ListItem>
                           <asp:ListItem Value="18">Karnataka </asp:ListItem>
                           <asp:ListItem Value="19">Kerala </asp:ListItem>
                           <asp:ListItem Value="20">Lakshadweep </asp:ListItem>
                           <asp:ListItem Value="21">Maharashtra </asp:ListItem>
                           <asp:ListItem Value="22">Manipur </asp:ListItem>
                           <asp:ListItem Value="23">Meghalaya </asp:ListItem>
                           <asp:ListItem Value="24">Mizoram </asp:ListItem>
                           <asp:ListItem Value="25">Nagaland </asp:ListItem>
                           <asp:ListItem Value="26">Odisha </asp:ListItem>
                           <asp:ListItem Value="27">Puducherry </asp:ListItem>
                           <asp:ListItem Value="28">Punjab </asp:ListItem>
                           <asp:ListItem Value="29">Rajasthan </asp:ListItem>
                           <asp:ListItem Value="30">Sikkim </asp:ListItem>
                           <asp:ListItem Value="31">Puducherry </asp:ListItem>
                           <asp:ListItem Value="32">Tamil Nadu </asp:ListItem>
                          <asp:ListItem Value="33">Telangana </asp:ListItem>
                           <asp:ListItem Value="34">Tripura </asp:ListItem>
                           <asp:ListItem Value="35">Uttar Pradesh </asp:ListItem>
                           <asp:ListItem Value="36">Uttarakhand </asp:ListItem>
                           <asp:ListItem Value="37">West Bengal </asp:ListItem>
                      </asp:DropDownList>
                           
                  </div>
               </div>
                <div class="col-md-6 col-sm-12 col-xs-12">
                  <div class="form-group">
                     <label>PIN <font>*</font></label>
                              <asp:TextBox ID="txtstatePin" runat="server" class="form-control ng-pristine ng-untouched ng-valid ng-valid-maxlength" 
                                  ng-model="nia.txtpin" placeholder="" data-mandatory="1" data-validatefor="pincode" data-errtext="Invalid pin" maxlength="6"></asp:TextBox>
                  </div>
               </div>
          </div>
            <div class="row">
               <div class="col-md-6 col-sm-12 col-xs-12">
                  <div class="form-group">
                     <label>Contact Person </label>
                    <asp:TextBox ID="txtContPerson" runat="server" class="form-control ng-pristine ng-untouched ng-valid ng-valid-maxlength" placeholder="" 
                        ng-model="nia.txtContPerson" data-validatefor="contact_person" data-errtext="Invalid contact person name" maxlength="100"></asp:TextBox>
             </div>
               </div>
               <div class="col-md-6 col-sm-12 col-xs-12">
                  <div class="form-group">
                     <label>Phone </label>
                                          <asp:TextBox ID="txtCmpPhone" runat="server" class="form-control ng-pristine ng-untouched ng-valid ng-valid-maxlength" placeholder="" ng-model="nia.txtCmpPhone" 
                                              data-validatefor="phone" data-errtext="Invalid phone number" maxlength="13"></asp:TextBox>
               </div>
               </div>
            </div>
            <div class="row">
               <div class="col-md-6 col-sm-12 col-xs-12">
                  <div class="form-group">
                     <label>Email ID</label>
                         <asp:TextBox ID="txtcmpEmail" runat="server" class="form-control ng-pristine ng-untouched ng-valid ng-valid-maxlength" placeholder="" ng-model="nia.txtcmpEmail" data-validatefor="email" data-errtext="Invalid email address" maxlength="60"></asp:TextBox>
               </div>
               </div>
               <div class="col-md-6 col-sm-12 col-xs-12">								
               </div>
            </div>
          <div class="col-md-12 border_sp"></div>

            <div class="row">
               <div class="bd-Eqd">
                  <div class="bd-eqd-title">
                     <span style="color:red;" id="errorChk" ng-bind="errorChk" class="ng-binding"></span>
                     <p>
                        Educational Qualification : <font style="color:blue">( Select Highest Educational Qualification from the list provided below ) <font style="color:red">*</font></font>
                     </p>
                  </div>
                    
                         
                        
                    <div class="bd-eqd-title">
                     <span style="color:red;" id="errorChk" ng-bind="errorChk" class="ng-binding"></span>
                    <asp:CheckBoxList ID="chkCourses" runat="server" TextAlign="Right" CssClass="educss" RepeatLayout="Flow" >                          
                               <asp:ListItem Value="1">Bachelors degree in Arts, Science, or Social Sciences or Commerce or its equivalent from any institution/ university recognized by any State Government or the Central Government</asp:ListItem>
                               <asp:ListItem Value="2">Bachelor's degree in engineering or its equivalent from any institution/university recognized by any State government or the Central Government</asp:ListItem>
                               <asp:ListItem Value="3">Bachelor's degree in law or its equivalent from any institution or university recognized by any State Government or the Central Government</asp:ListItem>
                               <asp:ListItem Value="4">Masters in Business Administration or its equivalent from any institution/ university recognized by any State Government or the Central Government</asp:ListItem>
                               <asp:ListItem Value="5">Associate/ Fellow of the Insurance Institute of India, Mumbai</asp:ListItem>
                               <asp:ListItem Value="6">Associate/Fellow of the Institute of Risk Management, Mumbai</asp:ListItem>
                               <asp:ListItem Value="7">Post graduate qualification of the Institute of Insurance and Risk Management, Hyderabad</asp:ListItem>
                               <asp:ListItem Value="8">Associate/ Fellow of the Institute of Chartered Accountants of India , New Delhi</asp:ListItem>
                               <asp:ListItem Value="9">Associate/ Fellow of the Institute of Cost and Works Accountants of India, Kolkata</asp:ListItem>
                               <asp:ListItem  Value="10">Associate/ Fellow of the Institute of Company Secretaries of India, New Delhi</asp:ListItem>
                             <asp:ListItem Value="11">Associate/ Fellow of the Institute of Actuaries of India</asp:ListItem>
                             <asp:ListItem Value="12">Associate/Fellow of Chartered Insurance Institute, London</asp:ListItem>
                             <asp:ListItem Value="13">Chartered Financial Analyst of Institute of Chartered Financial Analyst of India</asp:ListItem>
                               <asp:ListItem Value="14">Certified Associate ship of the Indian Institute of Bankers, Mumbai</asp:ListItem>
                               <asp:ListItem Value="15">Any other qualification specified from time to time by the Authority under these regulations</asp:ListItem>

                                   </asp:CheckBoxList>
                  </div>
               </div>
            </div>
               <div class="col-md-12 border_sp"></div>
 						<div class="row">					
							<div class="col-md-6 col-sm-12 col-xs-12">
								<div class="form-group">
									<label>Are you carrying any Reinsurance related activity ?   </label>
                      <asp:DropDownList ID="ddlreinsuranceReActi"  AutoPostBack="true" runat="server" class="selectpicker form-control ng-pristine ng-untouched ng-valid" >
                          <asp:ListItem Value="1" >No</asp:ListItem>
                           <asp:ListItem Value="2">Yes</asp:ListItem>
                          
                      </asp:DropDownList>
								 
								</div>
							</div>
							<div class="col-md-6 col-sm-12 col-xs-12">
								<div class="form-group">
									<label>Are you a principal underwriter for last 7 years ?   </label>
                                     <asp:DropDownList ID="ddlprincipleUnderwriter" runat="server" AutoPostBack="true" class="selectpicker form-control ng-pristine ng-untouched ng-valid" >
                         <asp:ListItem Value="1">No</asp:ListItem>
                           <asp:ListItem Value="2">Yes</asp:ListItem>
                           
                      </asp:DropDownList>
									
								</div>
							</div>
						</div>
							<br/>
						<div class="row">					
							<div class="col-md-6 col-sm-12 col-xs-12">
								<div class="form-group">
									<label>Are you an Insurance Consultant for a continuous period of 7 years ?   </label>
									<asp:DropDownList ID="ddlinsuranceConsultant" runat="server"  
                                        class="selectpicker form-control ng-pristine ng-untouched ng-valid" ng-model="nia.ddlinsuranceConsultant" AutoPostBack="true"
                                        data-errtext="Please select insurance consultant experience">
                        
                           <asp:ListItem Value="1">No</asp:ListItem>
                           <asp:ListItem Value="2">Yes</asp:ListItem>
                      </asp:DropDownList>
                                   
								</div>
							</div>						
							<div class="col-md-6 col-sm-12 col-xs-12">
								<div class="form-group">
									<label>Have you held the position of a Manager in any one of the nationalized insurance companies in India ?  </label>
									<asp:DropDownList ID="ddlpositionOfManager" runat="server" AutoPostBack="true"  
                                        class="selectpicker form-control ng-pristine ng-untouched ng-valid" ng-model="nia.ddlpositionOfManager" 
                                        data-validatefor="alfanumeric"  >
                         <asp:ListItem Value="1">No</asp:ListItem>
                           <asp:ListItem Value="2">Yes</asp:ListItem>
                      </asp:DropDownList>
                                   
								</div>
							</div>
						</div>
          <div class="row">					
							<div class="col-md-6 col-sm-12 col-xs-12">
								<div class="form-group">
									<label>Eligible for : </label>									
                                   <asp:TextBox ID="LbEligibleHours" ReadOnly="true" class="form-control ng-pristine ng-untouched ng-valid ng-valid-maxlength"  runat="server" Text="25 Hours" ></asp:TextBox>
								</div>
							</div>						
							<div class="col-md-6 col-sm-12 col-xs-12">
								<div class="form-group">
									<label>Required Hours :  </label>
									<asp:DropDownList ID="DdlReqHours" runat="server" 
                                        class="selectpicker form-control ng-pristine ng-untouched ng-valid" ng-model="nia.ddlpositionOfManager" 
                                        data-validatefor="alfanumeric" Enabled="false"  >
                           <asp:ListItem Value="25">25 Hours</asp:ListItem>
                      </asp:DropDownList>
                                   
								    </div>
							</div>
						</div>
						<div class="col-md-12 border_sp"></div>
						
						<div class="row">					
							<div class="col-md-6 col-sm-12 col-xs-12">
								<div class="form-group">
									<label>Professional Qualification </label>
									<asp:TextBox ID="txtprofessionalQuali" runat="server" class="form-control ng-pristine ng-untouched ng-valid ng-valid-maxlength" 
                                        ng-model="nia.txtprofessionalQuali" placeholder="" data-validatefor="string" 
                                        data-errtext="Please enter your professional qualification" maxlength="100"></asp:TextBox>

							
						</div>
						</div>

                          <%--  <div class="col-md-6 col-sm-12 col-xs-12">
						<div class="form-group">
							<label>Applied for <font>*</font></label>
                            <asp:DropDownList ID="ddlappliedFor" runat="server" class="selectpicker form-control ng-pristine ng-untouched ng-valid" 
                                ng-model="nia.ddlappliedFor" data-mandatory="1" data-validatefor="alfanumeric" data-errtext="Please select Applied for">
                          <asp:ListItem Value="0" Text="Select">Select</asp:ListItem>
                           <asp:ListItem Value="1" Text="Principal Officer"></asp:ListItem>
                           <asp:ListItem Value="2" Text="Broker Qualified Person"></asp:ListItem>
                                  <asp:ListItem Value="3" Text="Authorised Verifier"></asp:ListItem>
                      </asp:DropDownList>
							
						</div>
					</div>--%>
                            <div class="col-md-6 col-sm-12 col-xs-12">
						<div class="form-group">
							<label>Broking Module Opted for <font>*</font></label>
							 <asp:DropDownList ID="ddlbrokingModule" runat="server" class="selectpicker form-control ng-pristine ng-untouched ng-valid" 
                                 ng-model="nia.ddlbrokingModule" data-mandatory="1" data-validatefor="alfanumeric" data-errtext="Please select Broking Module">
                          <asp:ListItem Value="0">Select</asp:ListItem>
                           <asp:ListItem Value="2021_NIA06">Brokers online course (for Renewal)</asp:ListItem>
                      </asp:DropDownList>
                            						</div>
					</div>
						</div>
			
		<!--Step 3: Disclaimer-->
        
				<div class="row">
					<div class="col-md-12 col-sm-12 col-xs-12">
						<div class="bd-m-p">
                        <asp:Label ID="LBAMT" runat="server" Text="2596.00" Visible="false"></asp:Label>
							<input type="hidden" id="AMT" runat="server" ng-model="nia.txnAmt" value="2596.00"  class="ng-pristine ng-untouched ng-valid" /> Payment Amount : Rs.2596.00/-  ( Renewal Course Registration : Rs. 2200/- + 18% GST)
						</div>
					</div>
				</div>
			
		
		<!--Step 4: Payment-->
<div class="row">
	<div class="col-md-12 col-sm-12 col-xs-12"">
		<div style="padding:1% 0%; margin-left:auto; margin-right:auto;">
			<h5 class="title-pn">Please Upload Photo <font>*</font></h5>	
			<div class="please-none-dec">
				<p>Your photograph in jpeg format, file size below 30 kb. File name should be given as your PAN Number_Name (e.g. AJCPK1122R_PriyankaDeshmukh.jpeg)</p>
				

               
                <div class="col-md-12 col-sm-12 col-xs-12 text-middle">
                    
                        <div class="col-md-2 col-sm-12 col-xs-12 text-right">
                          Upload Photo : </div><div class="col-md-4 col-sm-12 col-xs-12 text-middle">
                <asp:FileUpload ID="FlPhoto" runat="server"  Width="100%" Height="100%" /></div>
                       <div class="col-md-6 col-sm-12 col-xs-12 text-left">
                            <asp:Button ID="btnimage" runat="server" Text="Upload" Width="30%" Height="100%"  OnClick="btnimage_Click"/> 
                            <asp:Label ID="lbimage" runat="server" Text=""></asp:Label>
                            <asp:Label ID="lbimagename" runat="server" Visible="false" Text=""></asp:Label>
                               </div>
              
                    </div>
              <br /><br />
                <p> Upload your Brokers’ Exam Passing certificate and renewal certificate in pdf format,file size below 100KB. File name should be given as your PAN Number_Name_degree (e.g. AJCPK1122R_PriyankaDeshmukh_degree.pdf)</p>
                 <div class="col-md-12 col-sm-12 col-xs-12 text-middle">
                    
                        <div class="col-md-2 col-sm-12 col-xs-12 text-right">
                          Upload Certificate : </div><div class="col-md-4 col-sm-12 col-xs-12 text-middle">
                <asp:FileUpload ID="FlCertificate" runat="server"  Width="100%" Height="100%" /></div>
                       <div class="col-md-6 col-sm-12 col-xs-12 text-left">
                            <asp:Button ID="btncetf" runat="server" Text="Upload" Width="30%" Height="100%"  OnClick="btncetf_Click"/> 
                            <asp:Label ID="lbctf" runat="server" Text=""></asp:Label>
                            <asp:Label ID="lbctfname" runat="server" Visible="false" Text=""></asp:Label>
                               </div>
             
                    </div>
							
			</div>						
			<div class="col-md-12 col-sm-12 col-xs-12 text-middle">
						<div class="bd-dis">
                    <span style="color:red;" id="tc" ng-bind="tc" class="ng-binding"></span>
                            <p style="font-family:Arial; color:red;">Course Duration : 60 Days.
Course Content developed on flash and Supports only Firefox,Google Chrome up to version (78.0.3904), Opera, Internet Explorer browsers.
For Any support, have a look at Contact US page
                                <br />
                                Please verify PAN NO, E-mail ID and Aadhaar Number before submit your registration form.                                
	</p>
					<input type="checkbox" runat="server" id="CHKagree" value="Y" name="tandc" data-mandatory="1" 
                        ng-model="nia.selected" data-validatefor="alfanumeric" data-errtext="Please confirm to proceed" 
                        class="ng-pristine ng-untouched ng-valid"> &nbsp; I am aware of the Qualification and Eligibility Criteria for Brokers Online Training as prescribed by IRDAI and declare that I have fulfilled the same.  I further declare that the information given by me is true and I am aware that if any deviation from facts is noted or noticed, my application will be considered null and void
				</div>
							<%--<asp:Button ID="btnsubmit" CssClass="form-control btn btn-success .btn-next" runat="server" OnClientClick="return ValidateForm();" BackColor="#009688"   ForeColor="#ffffff"
    Font-Bold="true" ValidationGroup="vg" CausesValidation="true"  Text="PROCEED TO PAY" OnClick="btnsubmit_Click"  width="30%" Height="100%" />--%>
                        	<asp:Button ID="btnregister" CssClass="form-control btn btn-success .btn-next" runat="server" OnClientClick="return ValidateForm();" BackColor="#009688"   ForeColor="#ffffff"
    Font-Bold="true" ValidationGroup="vg" CausesValidation="true"  Text="Submit"   width="30%" Height="100%" OnClick="btnregister_Click" />					
					</div>
				
		</div>
	</div>
    </div>
          <br /><br />
<%--                <p> Copy of Training completion certificate in pdf format below 100 kb. File name should be given as your FullName_PAN Number (e.g. PriyankaDeshmukh_AJCPK1122R.pdf)</p>
                 <div class="col-md-12 col-sm-12 col-xs-12 text-middle">
                    
                       <div class="col-md-2 col-sm-12 col-xs-12 text-right">
                          Upload Certificate : </div><div class="col-md-4 col-sm-12 col-xs-12 text-middle">
                <asp:FileUpload ID="FlCertificate" runat="server"  Width="100%" Height="100%" /></div>
                       <div class="col-md-6 col-sm-12 col-xs-12 text-left">
                            <asp:Button ID="btncetf" runat="server" Text="Upload" Width="30%" Height="100%"  OnClick="btncetf_Click"/> 
                            <asp:Label ID="lbctf" runat="server" Text="" Font-Bold="true" ForeColor="#0fbb2c"></asp:Label>
                            <asp:Label ID="lbctfname" runat="server" Visible="false" Text="" ></asp:Label>
                       </div>
                      </div>
							
			</div>	--%>
<span class="col-xs-4 col-sm-12 text-right">Powered by</span>
				<div class="row">
					<div class="col-xs-4 col-sm-12 text-right"><img src="./nia_files/billdesk.png" alt="BillDesk" width="100px"></div>
				</div>
</div>
</div>
     


        <div hidden="hidden"><br /> <br /> <br /> <br />
           Check Sum Value :  <asp:Label runat="server" ID="checkSumValue" ></asp:Label>
         <br />
          <br /> <br />
         MSG : <asp:TextBox ID="msg"  runat="server" TextMode="MultiLine" Width="500px" Height="100px"></asp:TextBox>
         <br /> <br /> <br />
         <asp:Button ID="Button1"  runat="server" Text="submit"  OnClientClick="javascript: myfunc();"/>
      </div>
            </div>
   
         </div>
 
<script type="text/javascript" src="./nia_files/jquery-1.11.2.min.js"></script>
<script type="text/javascript" src="./nia_files/angular.min.js"></script>
<script type="text/javascript" src="./nia_files/bootstrap.min.js"></script>
<script type="text/javascript" src="./nia_files/bootstrap-datetimepicker.js" charset="UTF-8"></script>
<script type="text/javascript" src="./nia_files/validateform.js" charset="UTF-8"></script>
   
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
                var state = document.getElementById('ddlstate').value;
                if (state == "0") {
                    alert("Please Select State");
                    document.getElementById('<%=ddlstate.ClientID %>').focus();
                    return false;
                }
                else {
                    var statePin = document.getElementById('txtstatePin').value;
                    if (statePin == " ") {
                        alert("Please Enter Pin");
                        document.getElementById('<%=txtstatePin.ClientID %>').focus();
                        return false;
                    }
                    else {
                        var result2 = document.getElementById('ddlbrokingModule').value;
                        if (result2 == "0") {
                            alert("Please select Broking Module");
                            document.getElementById('<%=ddlbrokingModule.ClientID %>').focus();
                            return false;
                        }
                        else {

                            var result2 = document.getElementById('lbimage').textContent;
                            if (result2 == "") {
                                alert("Please Upload Your photograph");
                                document.getElementById('<%=FlPhoto.ClientID %>').focus();
                                return false;
                            }
                            else {
                                var company = document.getElementById('ddlcompanylist').value;
                                if (company == "0") {
                                    alert("Please Select Comapny");
                                    document.getElementById('<%=ddlcompanylist.ClientID %>').focus();
                                    return false;
                                }

                                else {
                                    var r = confirm(" Are you sure you want to pay for BROKERS’  RENEWAL  ONLINE TRAINING ?  Payment once made will not be refunded ");
                                    if (r == true) {

                                        return true;
                                    } else {

                                        return false;
                                    }
                                }

                            }

                        }

                    }
                    //});
                }

            }
        }

  </script>



<%--    <div class="modal fade" id="myModal" tabindex="-1" role="dialog">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                    <center>
                        <h4 class="modal-title">

                            Welcome to National Insurance Academy’s <br />
                            Brokers’ Online Learning Course

                        </h4>
                    </center>
                </div>
                <div class="modal-body">
                     <h5 style="color: #006fc9; font-family: helvetica neue, helvetica, arial, sans-serif; 
text-align:justify;">
                        Course Duration : 60 Days.<br /><br />

                        Course Content developed on flash and Supports only Firefox, Google Chrome up to version (78.0.3904), Opera, Internet Explorer browsers.<br /><br />
                        Course contents can be viewed only on Desktops and laptops. Course contents cannot be viewed on Android devices such as mobile phones , tablets etc.
                        <br /><br />
                        For Any support, have a look at Contact Us page.
                        <br />
                    </h5>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                </div>
            </div><!-- /.modal-content -->
        </div><!-- /.modal-dialog -->
    </div>--%>

<asp:HiddenField ID="hdnProcess" runat="server" />

    </form>
    <script src="NIA/js/jquery.js"></script>
    <script src="NIA/js/bootstrap.min.js"></script>
    <script>
        $(document).ready(function () {

            $('#myModal').modal('show');
            setTimeout(function () {
                $('#myModal').modal('hide');
            }, 15000);

        });
    </script>
    <script>
        // When the user scrolls down 20px from the top of the document, show the button
        window.onscroll = function () { scrollFunction() };

        function scrollFunction() {
            if (document.body.scrollTop > 20 || document.documentElement.scrollTop > 20) {
                document.getElementById("myBtn").style.display = "block";
            } else {
                document.getElementById("myBtn").style.display = "none";
            }
        }

        // When the user clicks on the button, scroll to the top of the document
        function topFunction() {
            document.body.scrollTop = 0;
            document.documentElement.scrollTop = 0;
        }
    </script>
</body>
</html>
