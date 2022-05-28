<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ExamReg.aspx.cs" Inherits="NIAPRG.lib.ExamReg" %>
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
    <link href="lib/css/style.css" rel="stylesheet">
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
			<p id="school-address">EXAMINATION REGISTRATION FORM </p>
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
                         OnTextChanged="txtpan_TextChanged" EnableViewState="true"
                         placeholder="" ng-model="nia.txtpan" data-mandatory="1" data-validatefor="PAN" data-errtext="Invalid PAN number" maxlength="10"></asp:TextBox>
                              </div>
               </div>
              <div class="col-md-6 col-sm-12 col-xs-12">
                  <div class="form-group" >
                     <label>Name of the candidate <font>*</font></label>
                      <asp:DropDownList ID="ddlsalutation" runat="server" style="width:16%;float:left; font-weight:bold;" class="selectpicker form-control ng-pristine ng-untouched ng-valid" ng-init="nia.salutation = &#39;Mr.&#39;" >
                          <asp:ListItem Value="Mr.">Mr.</asp:ListItem>                        
                   <asp:ListItem Value="Ms.">Ms.</asp:ListItem> <asp:ListItem Value="Dr.">Dr.</asp:ListItem>
                      </asp:DropDownList>
                     <asp:TextBox ID="txtnameOfCandidate" runat="server" style="float:right;width:83%;" class="form-control ng-pristine ng-untouched ng-valid ng-valid-maxlength" ng-model="nia.nameOfCandidate" data-mandatory="1" data-validatefor="name"
                          data-errtext="Invalid candidate name" placeholder="" maxlength="100"></asp:TextBox>
                                </div>
               </div>
               
            </div>
            <div class="row">
                 <div class="col-md-6 col-sm-12 col-xs-12">
                  <div class="form-group">
                     <label>Email ID <font>*</font></label>
                    <asp:TextBox ID="txtemail" runat="server" class="form-control ng-pristine ng-untouched ng-valid ng-valid-maxlength" placeholder="" ng-model="nia.txtemail"
                         data-mandatory="1" data-validatefor="email" data-errtext="Invalid email address" maxlength="60"></asp:TextBox>
                                     </div>
               </div>
               
               <div class="col-md-6 col-sm-12 col-xs-12">
                  <div class="form-group">
                     <label>Date of Birth <font>*</font></label>
                   
                        <asp:TextBox ID="txtDob" runat="server"  class="form-control ng-pristine ng-untouched ng-valid ng-valid-maxlength" 
                            placeholder="DD/MM/YYYY" value="" data-mandatory="1"  ng-model="nia.txtDob"  data-validatefor="date"
                            data-errtext="Invalid date of birth" maxlength="10" AutoPostBack="false" readonly="false"></asp:TextBox>
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
                     <label>State <font>*</font></label>
                      <asp:DropDownList  ID="ddlstate" runat="server" class="form-control">
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
                             <%-- <asp:TextBox ID="TxtState" runat="server" class="form-control ng-pristine ng-untouched ng-valid ng-valid-maxlength" 
                                   placeholder="" data-mandatory="1"  maxlength="100"></asp:TextBox>
                      <asp:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" TargetControlID="TxtState"
         MinimumPrefixLength="1" EnableCaching="true" CompletionSetCount="1" CompletionInterval="1000"
         ServiceMethod="GetState" >
    </asp:AutoCompleteExtender>--%>
                  </div>
               </div>


               
            </div>
            <div class="row">
                <div class="col-md-6 col-sm-12 col-xs-12">
                  <div class="form-group">
                     <label>PIN <font>*</font></label>
                              <asp:TextBox ID="txtpin" runat="server" class="form-control ng-pristine ng-untouched ng-valid ng-valid-maxlength" 
                                  ng-model="nia.txtpin" placeholder="" data-mandatory="1" data-validatefor="pincode" data-errtext="Invalid pin" maxlength="6"></asp:TextBox>
                  </div>
               </div>
               <div class="col-md-6 col-sm-12 col-xs-12">
                  <div class="form-group">
                     <label>Mobile <font>*</font></label>
                     <asp:TextBox ID="txtmobile" runat="server" class="form-control ng-pristine ng-untouched ng-valid ng-valid-maxlength" type="text" ng-model="nia.txtmobile" placeholder=""  data-mandatory="1" data-validatefor="mobile" data-errtext="Invalid mobile number" maxlength="10"></asp:TextBox>
                              </div>
               </div>
              
            </div>
           
            <div class="row">
                 <div class="col-md-6 col-sm-12 col-xs-12">
                  <div class="form-group">
                     <label>Telephone <font>*</font></label>
                                  <asp:TextBox ID="txttel" runat="server" class="form-control ng-pristine ng-untouched ng-valid ng-valid-maxlength" 
                                     ng-model="nia.txttel" placeholder=""  data-mandatory="1" data-validatefor="phone" data-errtext="Invalid telephone number" maxlength="13"></asp:TextBox>
                           </div>
               </div>
               <div class="col-md-6 col-sm-12 col-xs-12">
                  <div class="form-group">
                     <label>UID-Adhar Card No. <font></font></label>
                    <asp:TextBox ID="txtAdhar" runat="server" class="form-control ng-pristine ng-untouched ng-valid ng-valid-maxlength" type="text" 
                        placeholder="" ng-model="nia.txtAdhar" data-mandatory="0" data-validatefor="number" data-errtext="Invalid aadhar number" 
                        maxlength="12"></asp:TextBox>
                                 </div>
               </div>    
            </div>
            <div class="row">
               <div class="sponship-detail-title">Sponsorship Details, if applicable</div>
            </div>
            <div class="row">
               <div class="col-md-6 col-sm-12 col-xs-12">
                  <div class="form-group">
                     <label>Name of the Company </label>
                      <asp:DropDownList  ID="ddlcompanylist" runat="server" class="form-control">
                           <asp:ListItem  Value="1">Bajaj Capital Insurance Broking Limited </asp:ListItem>
                           <asp:ListItem Value="2">Bluechip Insurance Broking Private Limited </asp:ListItem>
                           <asp:ListItem Value="3">D2C Insurance Broking Private Limited </asp:ListItem>
                           <asp:ListItem Value="4">Coverfox Insurance Broking Pvt. Ltd </asp:ListItem>
                           <asp:ListItem Value="5">Rajkrishna Insurance Broker Pvt.Ltd </asp:ListItem>
                           <asp:ListItem Value="6">Edelweiss Insurance Brokers Limited </asp:ListItem>
                           <asp:ListItem Value="7">SMC Insurance Brokers Pvt. Ltd. </asp:ListItem>
                           <asp:ListItem Value="8">Integrated Insurance Broking Services Pvt Ltd </asp:ListItem>
                           <asp:ListItem Value="9">JLT Independent Insurance Brokers Pvt. Ltd. </asp:ListItem>
                           <asp:ListItem Value="10">Mahindra Insurance Brokers Ltd. </asp:ListItem>
                           <asp:ListItem Value="11">Marsh India Insurance Brokers Private Limited </asp:ListItem>
                           <asp:ListItem Value="12">Maruti Insurance Broking Pvt Ltd </asp:ListItem>
                           <asp:ListItem Value="13">NJ Insurance Brokers Pvt Ltd </asp:ListItem>
                           <asp:ListItem Value="14">Probus Insurance Broker Limited </asp:ListItem>
                           <asp:ListItem Value="15">Robinhood Insurance Broker Pvt Ltd </asp:ListItem>
                           <asp:ListItem Value="16">Singhma Insurance Broker Ltd</asp:ListItem>
                           <asp:ListItem Value="17">SMC Insurance Brokers Pvt. Ltd. </asp:ListItem>
                           <asp:ListItem Value="18">Not Applicable </asp:ListItem>
                      </asp:DropDownList>
                                     <%-- <asp:TextBox ID="txtNameCompany" runat="server" class="form-control ng-pristine ng-untouched ng-valid ng-valid-maxlength" 
                                          type="text" placeholder="" ng-model="nia.txtNameCompany" data-validatefor="nia_name_of_org" 
                                          data-errtext="Invalid company name" maxlength="100"></asp:TextBox>--%>
                  </div>
               </div>
               <div class="col-md-6 col-sm-12 col-xs-12">
                  <div class="form-group">
                     <label>Address </label>
                     <asp:TextBox ID="txtCmpAddress" runat="server" AutoCompleteType="Disabled" class="form-control ng-pristine ng-untouched ng-valid ng-valid-maxlength" rows="2" placeholder="" ng-model="nia.txtCmpAddress" data-validatefor="string" data-errtext="Invalid company address" maxlength="110"></asp:TextBox>
                            </div>
               </div>
                 
            </div>
           <div class="row">
               <div class="col-md-6 col-sm-12 col-xs-12">
                  <div class="form-group">
                     <label>State </label>
                      <asp:DropDownList  ID="ddlSponsorState" runat="server" class="form-control">
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
                                      <%--<asp:TextBox ID="TxtSponsorState" runat="server" class="form-control ng-pristine ng-untouched ng-valid ng-valid-maxlength" 
                                          type="text" placeholder=""  maxlength="100"></asp:TextBox>--%>
                  </div>
               </div>
               <div class="col-md-6 col-sm-12 col-xs-12">
                  <div class="form-group">
                     <label>Pin Code </label>
                     <asp:TextBox ID="TxtSponsorPin" runat="server" class="form-control ng-pristine ng-untouched ng-valid ng-valid-maxlength"  
                         data-validatefor="pincode" data-errtext="Invalid pin" placeholder="" maxlength="6"></asp:TextBox>
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
                        Educational Qualification : <font>( Select Highest Educational Qualification from the list provided below ) <font style="color:red">*</font></font>
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
									<label>Professional Qualification </label>
									<asp:TextBox ID="txtprofessionalQuali" runat="server" class="form-control ng-pristine ng-untouched ng-valid ng-valid-maxlength" 
                                        ng-model="nia.txtprofessionalQuali" placeholder="" data-validatefor="string" 
                                        data-errtext="Please enter your professional qualification" maxlength="100"></asp:TextBox>

							
						</div>
						</div>
                             			
							<div class="col-md-6 col-sm-12 col-xs-12">
								<div class="form-group">
									<label>Are you carrying any Reinsurance related activity ?   </label>
                      <asp:DropDownList ID="ddlreinsuranceReActi" runat="server"  class="selectpicker form-control ng-pristine ng-untouched ng-valid" >
                          <asp:ListItem Value="1" >No</asp:ListItem>
                           <asp:ListItem Value="2">Yes</asp:ListItem>
                          
                      </asp:DropDownList>
								 
								</div>
							</div>
							
						</div>
							
						<div class="row">					
							<div class="col-md-6 col-sm-12 col-xs-12">
								<div class="form-group">
									<label>Are you an Insurance Consultant for a continuous period of 7 years ?   </label>
									<asp:DropDownList ID="ddlinsuranceConsultant" runat="server" 
                                        class="selectpicker form-control ng-pristine ng-untouched ng-valid" ng-model="nia.ddlinsuranceConsultant" 
                                        data-errtext="Please select insurance consultant experience">
                        
                           <asp:ListItem Value="1">No</asp:ListItem>
                           <asp:ListItem Value="2">Yes</asp:ListItem>
                      </asp:DropDownList>
                                   
								</div>
							</div>	
                            <div class="col-md-6 col-sm-12 col-xs-12">
								<div class="form-group"><br />
									<label>Are you a principal underwriter for last 7 years ?   </label>
                                     <asp:DropDownList ID="ddlprincipleUnderwriter" runat="server" class="selectpicker form-control ng-pristine ng-untouched ng-valid" >
                         <asp:ListItem Value="1">No</asp:ListItem>
                           <asp:ListItem Value="2">Yes</asp:ListItem>
                           
                      </asp:DropDownList>
									
								</div>
							</div>					
							
						</div>

  <div class="row">	
      <div class="col-md-6 col-sm-12 col-xs-12">
								<div class="form-group">
									<label>Have you held the position of a Manager in any one of the nationalized insurance companies in India ?  </label>
									<asp:DropDownList ID="ddlpositionOfManager" runat="server" 
                                        class="selectpicker form-control ng-pristine ng-untouched ng-valid" ng-model="nia.ddlpositionOfManager" 
                                        data-validatefor="alfanumeric"  >
                         <asp:ListItem Value="1">No</asp:ListItem>
                           <asp:ListItem Value="2">Yes</asp:ListItem>
                      </asp:DropDownList>
                                   
								</div>
							</div>	
      <div class="col-md-6 col-sm-12 col-xs-12">
								<div class="form-group"><br />
									<label>No of Hours Training undergone :  </label>
									<asp:DropDownList ID="DdlReqHours" runat="server" 
                                        class="selectpicker form-control ng-pristine ng-untouched ng-valid" ng-model="nia.ddlpositionOfManager" 
                                        data-validatefor="alfanumeric"   >
                                        <asp:ListItem Value="0">Select</asp:ListItem>
                         <asp:ListItem Value="50" >50 Hours</asp:ListItem>
                           <asp:ListItem Value="25">25 Hours</asp:ListItem>
                      </asp:DropDownList>
                                   
								</div>
							</div>			
							
						</div>
						<div class="col-md-12 border_sp"></div>
						<div class="row">					
							<div class="col-md-6 col-sm-12 col-xs-12">
								<div class="form-group">
									<label>Training ID <font>*</font> </label>
									<asp:TextBox ID="txttrainingId"  runat="server"
                                        class="form-control ng-pristine ng-untouched"  maxlength="50" ></asp:TextBox>
								</div>
							</div>

                            <div class="col-md-6 col-sm-12 col-xs-12">
								<div class="form-group">
									<label>Training completion date <font>*</font></label>
									   <asp:TextBox runat="server" ID="completiondate" class="form-control ng-pristine ng-untouched ng-valid" 
                                            placeholder="DD/MM/YYYY" value="" ng-model="nia.trainingCompletedDate" data-validatefor="date" 
                                            data-errtext="Invalid training completion date"  ></asp:TextBox>
                                      
								</div> 
							</div>
                            
							

						</div>
						
          <div class="row">					
							<div class="col-md-6 col-sm-12 col-xs-12">
								<div class="form-group">
									<label>Have you appeared earlier for the exam <font>*</font> </label>
									<asp:DropDownList ID="ddlEarlierExam" runat="server" 
                                        class="selectpicker form-control ng-pristine ng-untouched ng-valid" OnSelectedIndexChanged="ddlEarlierExam_SelectedIndexChanged" AutoPostBack="true" ng-model="nia.ddlpositionOfManager" 
                                        data-validatefor="alfanumeric"  >
                         <asp:ListItem Value="1">No</asp:ListItem>
                           <asp:ListItem Value="2">Yes</asp:ListItem>
                      </asp:DropDownList>
                                   
							
						</div>
						</div>

                    
                            <div class="col-md-6 col-sm-12 col-xs-12">
								<div class="form-group">
									<label>No. of Attempts <font>*</font></label>
									   <asp:TextBox runat="server" ID="txtNoAttempts" class="form-control ng-pristine ng-untouched ng-valid" 
                                            Text="0" ReadOnly="true"
                                             ></asp:TextBox>
                                                                         
								</div> 
							</div>
                            
						</div>


          <div class="row">	
						<div class="col-md-6 col-sm-12 col-xs-12">
								<div class="form-group">
									<label>Details of Training Institute  </label>
									<asp:TextBox id="TxtDetailsTrInstitute"  runat="server"
                                        class="form-control ng-pristine ng-untouched ng-valid ng-valid-maxlength"  placeholder="" maxlength="50" ></asp:TextBox>
								</div>
							</div>	
					<div class="col-md-6 col-sm-12 col-xs-12">
						<div class="form-group">
							<label>Examination Centre <font>*</font></label>
                            <asp:DropDownList ID="ddlExamCentre" runat="server" class="selectpicker form-control ng-pristine ng-untouched ng-valid" 
                                ng-model="nia.examCentre" data-mandatory="1" data-validatefor="alfanumeric" data-errtext="Please select exam center">
                          <asp:ListItem Value="0" Text="Select">Select</asp:ListItem>
                           <asp:ListItem Value="1" Text="Pune"></asp:ListItem>
                           <asp:ListItem Value="2" Text="Chennai"></asp:ListItem>
                             <asp:ListItem Value="3" Text="Delhi"></asp:ListItem>
                                <asp:ListItem Value="4" Text="Kolkata"></asp:ListItem>
                                <asp:ListItem Value="5" Text="Mumbai"></asp:ListItem>
                                <asp:ListItem Value="6" Text="Ahmedabad"></asp:ListItem>
                                <asp:ListItem Value="7" Text="Hyderabad"></asp:ListItem>
                                <asp:ListItem Value="8" Text="Bangalore"></asp:ListItem>
                                 <asp:ListItem Value="9" Text="Vizag"></asp:ListItem>
                                 <asp:ListItem Value="10" Text="Lucknow"></asp:ListItem>
                                
                      </asp:DropDownList>
							
						</div>
					</div>
				</div>

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
                      </asp:DropDownList>
                            						</div>
					</div>
                    
                          <div class="col-md-6 col-sm-12 col-xs-12">
						<div class="form-group">
							<label>Applied for <font>*</font></label>
							 <asp:DropDownList ID="ddlappliedFor" runat="server" class="selectpicker form-control ng-pristine ng-untouched ng-valid" 
                                ng-model="nia.ddlappliedFor" data-mandatory="1" data-validatefor="alfanumeric" data-errtext="Please select Applied for">
                          <asp:ListItem Value="0" Text="Select">Select</asp:ListItem>
                           <%--<asp:ListItem Value="1" Text="Principal Officer"></asp:ListItem>
                           <asp:ListItem Value="2" Text="Broker Qualified Person"></asp:ListItem>
                                  <asp:ListItem Value="3" Text="Authorised Verifier"></asp:ListItem>--%>
                                 <asp:ListItem Value="1" Text=" Principal Officer / Broker Qualified Person"></asp:ListItem>
                                  <asp:ListItem Value="2" Text="Authorised Verifier"></asp:ListItem>
                      </asp:DropDownList>
						</div>
					</div>		  
                            
						</div>	
          
          
          <!--added new dropdown by somesh-->
              
              <div class="row">					
							
                            <div class="col-md-6 col-sm-12 col-xs-12">
						<div class="form-group">
							<label> Do you have insurance background <font>*</font></label>
							 <asp:DropDownList ID="ddlinsurance" runat="server" class="selectpicker form-control ng-pristine ng-untouched ng-valid" 
                                 ng-model="nia.ddlbrokingModule" data-mandatory="1" data-validatefor="alfanumeric" data-errtext="Please select Broking Module">
                           <asp:ListItem Value="1">No</asp:ListItem>
                           <asp:ListItem Value="2">Yes</asp:ListItem>
                      </asp:DropDownList>
                            						</div>
					</div>
                    
                          		  
                            
						</div>		
		<!--Step 3: Disclaimer-->
        
				<div class="row">
					<div class="col-md-12 col-sm-12 col-xs-12">
						<div class="bd-m-p">
                        <asp:Label ID="LBAMT" runat="server" Text="2950.00" Visible="false"></asp:Label>
							<input type="hidden" id="AMT" runat="server" ng-model="nia.txnAmt" value="2950.00"  class="ng-pristine ng-untouched ng-valid" >
                             <p>Examination Fess :           Rs. 2500/-    &   GST (18%)            :             Rs.   450/-<br />
Total Fees Charged :       Rs. 2950/-</p>
<%--                            <p>Test Fee : 2.00 /-</p>--%>
						</div>
					</div>
				</div>
			
		
		<!--Step 4: Payment-->
<div class="row">
	<div class="col-md-12 col-sm-12 col-xs-12"">
		<div style="padding:1% 0%; margin-left:auto; margin-right:auto;">
			<h5 class="title-pn">Please Upload Photo <font>*</font></h5>	
			<div class="please-none-dec">
				<p>Your photograph in jpeg format, file size below 30 kb. File name should be given as your FullName_PAN Number (e.g.PriyankaDeshmukh_AJCPK1122R.jpeg)</p>
				

               
                <div class="col-md-12 col-sm-12 col-xs-12 text-middle">
                    
                        <div class="col-md-2 col-sm-12 col-xs-12 text-right">
                          Upload Photo : </div><div class="col-md-4 col-sm-12 col-xs-12 text-middle">
                <asp:FileUpload ID="FlPhoto" runat="server"  Width="100%" Height="100%" /></div>
                       <div class="col-md-6 col-sm-12 col-xs-12 text-left">
                            <asp:Button ID="btnimage" runat="server" Text="Upload" Width="30%" Height="100%"  OnClick="btnimage_Click"/> 
                            <asp:Label ID="lbimage" runat="server" Text="" Font-Bold="true" ForeColor="#0fbb2c"></asp:Label>
                            <asp:Label ID="lbimagename" runat="server" Visible="false" Text="" ></asp:Label>
                               </div>
              
                    </div>
              <br /><br />
                <p> Copy of Training completion certificate in pdf format below 100 kb. File name should be given as your FullName_PAN Number (e.g. PriyankaDeshmukh_AJCPK1122R.pdf)</p>
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
							
			</div>						
			<div class="col-md-12 col-sm-12 col-xs-12 text-middle">
						<div class="bd-dis">
                    <span style="color:red;" id="tc" ng-bind="tc" class="ng-binding"></span>
                           
					<input type="checkbox" runat="server" id="CHKagree" value="Y" name="tandc" data-mandatory="1" 
                        ng-model="nia.selected" data-validatefor="alfanumeric" data-errtext="Please confirm to proceed" 
                        class="ng-pristine ng-untouched ng-valid"> &nbsp; I am aware of the Qualification and Eligibility Criteria for Brokers Online Examination as prescribed by IRDAI and declare that I have fulfilled the same.  I further declare that the information given by me is true and I am aware that if any deviation from facts is noted or noticed, my application will be considered null and void
				</div>
							<asp:Button ID="btnsubmit"  CssClass="form-control btn btn-success .btn-next" runat="server" OnClientClick="return ValidateForm();" BackColor="#009688"   ForeColor="#ffffff"
    Font-Bold="true" ValidationGroup="vg" CausesValidation="true"  Text="PROCEED TO PAY" OnClick="btnsubmit_Click"  width="30%" Height="100%" />
                        						<asp:Button ID="btnUpdate" CssClass="form-control btn btn-success .btn-next" runat="server" OnClientClick="return ValidateForm();" BackColor="#009688"   ForeColor="#ffffff"
    Font-Bold="true" ValidationGroup="vg" CausesValidation="true"  Text="UPDATE & PROCEED TO PAY" OnClick="btnUpdate_Click"  width="30%" Height="100%" />
					</div>
				
		</div>
	</div>
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
                var result2 = document.getElementById('txttrainingId').value;
                if (result2 == "") {
                    alert("Please Enter Training ID");
                    document.getElementById('<%=txttrainingId.ClientID %>').focus();
                    return false;
                }

                else {
                    var result3 = document.getElementById('completiondate').value;
                    if (result3 == "") {
                        alert("Please Enter Training Completion Date");
                        document.getElementById('<%=completiondate.ClientID %>').focus();
                        return false;
                    } else {
                        var result4 = document.getElementById('txtNoAttempts').textContent;
                        if (result4 == "0") {
                            alert("Please Enter No of Attempts");
                            document.getElementById('<%=txtNoAttempts.ClientID %>').focus();
                            return false;
                        }

                        else {

                            var result6 = document.getElementById('ddlExamCentre').value;
                            if (result6 == "0") {
                                alert("Please Select Examination Centre");
                                document.getElementById('<%=ddlExamCentre.ClientID %>').focus();
                                return false;
                            }
                            else {
                                var result1 = document.getElementById('ddlbrokingModule').value;
                                if (result1 == "0") {
                                    alert("Please select Broking Module");
                                    document.getElementById('<%=ddlbrokingModule.ClientID %>').focus();
                                    return false;
                                }
                                else {

                                    var result5 = document.getElementById('ddlappliedFor').value;
                                    if (result5 == "0") {
                                        alert("Please Select Applied For");
                                        document.getElementById('<%=ddlappliedFor.ClientID %>').focus();
                                        return false;
                                    }
                                    else {

                                        var result7 = document.getElementById('lbimage').textContent;
                                        if (result7 == "") {
                                            alert("Please Upload Your photograph");
                                            document.getElementById('<%=FlPhoto.ClientID %>').focus();
                                            return false;
                                        } else {

                                            var result8 = document.getElementById('lbctf').textContent;
                                            if (result8 == "") {
                                                alert("Please Upload Your Certificate");
                                                document.getElementById('<%=FlCertificate.ClientID %>').focus();
                                                return false;
                                            }
                                            else {
                                                return true;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }

            }
            //});
        }
        
        
       



  </script>
</body>
</html>
