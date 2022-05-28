<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ListofData.aspx.cs" Inherits="PMI.ListofData" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
   <meta name="viewport" content="width=device-width, initial-scale=1">
    <title></title>
    <link href="css/bootstrap.min.css" rel="stylesheet">
    <link href="css/font-awesome.min.css" rel="stylesheet">
     <link rel="stylesheet" href="css/style.css">
  <link rel="stylesheet" href="css/versatile.css">
  <link href="css/bootstrap-datetimepicker.min.css" rel="stylesheet" media="screen">
       
    <!-- Custom CSS -->
    <link href="css/style2.css" rel="stylesheet">
     <script language="javascript">
         function printDiv(divName) {
             var printContents = document.getElementById(divName).innerHTML;
             var originalContents = document.body.innerHTML;

             document.body.innerHTML = printContents;

             window.print();

             document.body.innerHTML = originalContents;
         }
</script>
</head>
<body>
    <form id="form1" runat="server">
    

         <div class="container">
  
                <div class="row" >
		<div class="col-xs-7 n-m-n-p"><img class="logo" src="./css/logo.png"></div>
		<div class="col-xs-5" >
			
			<div class="collapse navbar-collapse" id="navbar-collapse-1">
                                <ul class="nav navbar-nav   ">
                                   <li>
                                        <a href="AddPMI.aspx">Add PMI</a>
                                    </li>
                                     <li>
                                        <a href="ListofData.aspx">List</a>
                                    </li>
                                    <li>
                                        <a  href="#">Reports</a>
                                    </li>
                                   
                                </ul>

                            </div>
           
		</div>		
		
	</div>
                <div class="panel" style="display:block; padding: 18px;">
	<div class="tab-content" id="totalCont">
        <div id="griddiv" runat="server">
	  <div id="makepayment" >
	               <div class="row">
               <div class="col-md-12 col-sm-12 col-xs-12">
                  <div class="form-group" >
                     <center><h3>Visitors Data</h3></center>
                  
               </div>
               
            </div>    </div> 
           <div class="row">
                 <div class="col-md-3 col-sm-12 col-xs-12">
                           
                  <div class="form-group" style="float:left;">
                     <asp:TextBox ID="txtsearchname" runat="server" placeholder="Search by Name" class="form-control ng-pristine ng-untouched" 
                          ></asp:TextBox>   </div> 
          </div>   <div class="col-md-1 col-sm-12 col-xs-12"><div class="form-group" style="float:left;">
              <asp:Button ID="btnsearchName" runat="server" Text="Go " OnClick="btnsearchName_Click"  Width="100%" Height="100%"/>        
               </div>
            </div>   <div class="col-md-3 col-sm-12 col-xs-12">
                  <div class="form-group" >                    
                 <asp:TextBox ID="txtSearchDate" runat="server" placeholder="By Date(DD/MM/YYYY)" class="form-control ng-pristine ng-untouched" 
                          ></asp:TextBox>
               </div>
               
            </div>  <div class="col-md-1 col-sm-12 col-xs-12"><div class="form-group" style="float:left;">
              <asp:Button ID="btnsearchdate" runat="server" Text="Go " OnClick="btnsearchdate_Click"  Width="100%" Height="100%"/>        
               </div>
            </div>    <div class="col-md-4 col-sm-12 col-xs-12"><div class="form-group" style="float:right;">
              <asp:Button ID="btnFindAll" runat="server" Text="Find All " OnClick="btnFindAll_Click"  Width="100%" Height="100%"/>        
               </div>
            </div>    </div> 

    <asp:GridView ID="visitorsgrid" runat="server" AutoGenerateColumns="False" AutoGenerateEditButton="false" Width="100%" CellPadding="4" ForeColor="#333333"
         GridLines="Both" OnRowCommand="visitorsgrid_RowCommand" >  
     <AlternatingRowStyle BackColor="White" />  
     <columns>  
         <asp:TemplateField HeaderText="Visitor Id">  
             <ItemTemplate>  
                 <asp:Label ID="LbVisitorid" runat="server" Text='<%#Bind("Vid") %>'></asp:Label>  
             </ItemTemplate>  
         </asp:TemplateField>  
         <asp:TemplateField HeaderText="Name">  
             <ItemTemplate>  
                 <asp:Label ID="Lbname" runat="server" Text='<%#Bind("name") %>'></asp:Label>  
             </ItemTemplate>  
         </asp:TemplateField>  
         <asp:TemplateField HeaderText="From/Org">  
             <ItemTemplate>  
                 <asp:Label ID="Lbfromorg" runat="server" Text='<%#Bind("fromorg") %>'></asp:Label>  
             </ItemTemplate>  
         </asp:TemplateField>  
         <asp:TemplateField HeaderText="Whom to Meet">  
             <ItemTemplate>  
                 <asp:Label ID="lbwhomtomeet" runat="server" Text='<%#Bind("whomtomeet") %>'></asp:Label>  
             </ItemTemplate>
         </asp:TemplateField>  
         <asp:TemplateField HeaderText="Mobile">  
             <ItemTemplate>  
                 <asp:Label ID="Lbmobile" runat="server" Text='<%#Bind("mobile") %>'></asp:Label>  
             </ItemTemplate>  
         </asp:TemplateField> 
                  <asp:TemplateField HeaderText="IN Time">  
             <ItemTemplate>  
                 <asp:Label ID="LbINTIME" runat="server" Text='<%#Bind("INTIME") %>'></asp:Label>  
             </ItemTemplate>
                  </asp:TemplateField>  
                       <asp:TemplateField HeaderText="OUT Time">  
             <ItemTemplate>  
                 <asp:Label ID="lbOUTTIME" runat="server" Text='<%#Bind("OUTTIME") %>'></asp:Label>  
             </ItemTemplate>  
         </asp:TemplateField> 
         <asp:TemplateField HeaderText="Remarks">  
             <ItemTemplate>  
                 <asp:Label ID="lbremarks" runat="server" Text='<%#Bind("remarks") %>'></asp:Label>  
             </ItemTemplate>  
         </asp:TemplateField> 
          <asp:TemplateField HeaderText="Print">
        <ItemTemplate>
       <asp:LinkButton runat="server" ID="lnkprint" CommandArgument='<%#Eval("Vid") %>'
         CommandName="Printrow">Print</asp:LinkButton>
         </ItemTemplate>
       </asp:TemplateField>
           <asp:TemplateField HeaderText="Edit">
        <ItemTemplate>
       <asp:LinkButton runat="server" ID="lnkEdit" CommandArgument='<%#Eval("Vid") %>'
         CommandName="Editrow">Edit Data</asp:LinkButton>
         </ItemTemplate>
       </asp:TemplateField>
     </columns>  
     <EditRowStyle BackColor="#2461BF" />  
     <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />  
     <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />  
     <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />  
     <RowStyle BackColor="#EFF3FB" />  
     <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />  
     <SortedAscendingCellStyle BackColor="#F5F7FB" />  
     <SortedAscendingHeaderStyle BackColor="#6D95E1" />  
     <SortedDescendingCellStyle BackColor="#E9EBEF" />  
     <SortedDescendingHeaderStyle BackColor="#4870BE" />  
 </asp:GridView>  
          
  </div>
             <div class="row">
               <div class="col-md-7 col-sm-12 col-xs-12">
                  
               </div>
               <div class="col-md-5 col-sm-12 col-xs-12">
                   <div class="form-group" style="float:right;">
                  <input id="btnprint" type="button" onclick="printDiv('makepayment')" value="Print" style="width:100%; height:100%;"/>         
                  
               </div> </div>
            </div>  
        
        </div>
     <div id="divedit" runat="server" visible="false">
         <div class="row">
               <div class="col-md-6 col-sm-12 col-xs-12">
                  <div class="form-group" >
                     <label>Visitor Number <font>*</font></label>                     
                     <asp:TextBox ID="txtVisitorNo" runat="server" class="form-control ng-pristine ng-untouched ng-valid ng-valid-maxlength" ng-model="nia.nameOfCandidate" ReadOnly="true"
                          ></asp:TextBox>
                  </div>
               </div>
               <div class="col-md-6 col-sm-12 col-xs-12">
                  <div class="form-group" >
                     <label>Name  <font>*</font></label>
                     <asp:TextBox ID="txtnameOfCandidate" runat="server"  class="form-control ng-pristine ng-untouched ng-valid ng-valid-maxlength" ng-model="nia.nameOfCandidate" data-mandatory="1" data-validatefor="name"
                          ReadOnly="true"></asp:TextBox>
                                </div>               </div>
            </div>         
            <div class="row">
               <div class="col-md-6 col-sm-12 col-xs-12">
                    <div class="form-group">
                     <label>From/Org <font>*</font></label>
                   
                        <asp:TextBox ID="txtfrom" runat="server"  class="form-control ng-pristine ng-untouched ng-valid ng-valid-maxlength" 
                         ReadOnly="true"   ></asp:TextBox>
                                      </div>
                
               </div>
               <div class="col-md-6 col-sm-12 col-xs-12">
                   
                  <div class="form-group">
                     <label>whom to meet <font>*</font></label>
                              <asp:TextBox ID="txtmeet" runat="server" class="form-control ng-pristine ng-untouched ng-valid ng-valid-maxlength" 
                                 ReadOnly="true"></asp:TextBox>
                  </div>
               </div>
            </div>
            <div class="row">
               <div class="col-md-6 col-sm-12 col-xs-12">
                     <div class="form-group">
                     <label>Out time <font>*</font></label>
                         <asp:TextBox ID="txtOutTime" runat="server" class="form-control ng-pristine ng-untouched ng-valid ng-valid-maxlength" 
                           ></asp:TextBox>
                              </div>
                           </div>
                 
              
               <div class="col-md-6 col-sm-12 col-xs-12">
                    <div class="form-group">

                     <label>Remarks <font>*</font></label>
                        <asp:TextBox ID="txtRemarks" runat="server" TextMode="MultiLine" Rows="2" class="form-control ng-pristine ng-untouched ng-valid ng-valid-maxlength" ng-model="nia.txtAddress" 
                              data-mandatory="1" data-validatefor="string"  maxlength="210"></asp:TextBox>
                     
                
               </div>
            </div>
          </div>

 <div class="row">
               <div class="col-md-6 col-sm-12 col-xs-12">
                  
               </div>
               <div class="col-md-6 col-sm-12 col-xs-12">
                   <div class="form-group" style="float:right;">
                   <asp:Button ID="btnsave" runat="server" Text="Save" OnClick="btnsave_Click"  Width="100%" Height="100%"/>                   
                  
               </div> </div>
            </div>     </div>
        

      
            </div>
                        	
                       
                    </div>

        </div>

      
        <script src="js/jquery.js"></script>
        <script src="js/bootstrap.min.js"></script>
        <!-- Menu Toggle Script -->
        <script>
            $("#menu-toggle").click(function (e) {
                e.preventDefault();
                $("#wrapper").toggleClass("toggled");
            });
        </script>
        <script>
            $(selector).on('click', function () {
                $(selector).removeClass('active');
                $(this).addClass('active');
            });
        </script>
    </form>
</body>
</html>
