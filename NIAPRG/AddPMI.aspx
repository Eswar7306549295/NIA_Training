<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddPMI.aspx.cs" Inherits="PMI.AddPMI" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml" ng-app="niaApp" ng-controller="niaCtrl" class="ng-scope">
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
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.9.1/jquery.min.js"></script>
   
     <link href="css/mxcdnboostrap.min.css" rel="stylesheet" />  
    <script lang="ja" type="text/javascript">

        //disable the start button until capture the photo
        $(function () {
           
           
            var isNotCaptured = true;
            // start video
            startCapture();
            if (isNotCaptured) {
                setInterval(takePhoto, 10 * 1000);
                isNotCaptured = false;
            }
        });


    </script>
    <script type = "text/javascript" >
        function preventBack() { window.history.forward(); }
        setTimeout("preventBack()", 5);
        window.onunload = function () { null };
    </script>

    <script type="text/javascript" src="http://jqueryjs.googlecode.com/files/jquery-1.3.1.min.js" > </script> 
<script type="text/javascript">

    function PrintElem(elem) {
        Popup($(elem).html());
    }
    function Popup(data) {
        var mywindow = window.open('', 'my div', 'height=400,width=600');
       
        mywindow.document.write(data);
       

        mywindow.print();
        mywindow.close();

        return true;
    }
 </script>
   <%-- <script language="javascript" type = "text/javascript" >
        function printDiv(divName) {
            var video = document.getElementById(video);
            video.hidden = true;
            var printContents = document.getElementById(divName).innerHTML;
           
            var originalContents = document.body.innerHTML;
            document.body.innerHTML = printContents;
            window.print();
            document.body.innerHTML = originalContents;
        }
</script>
    <script type = "text/javascript">
        function PrintPanel() {
            var panel = document.getElementById("<%=pnlContents.ClientID %>");
            var printWindow = window.open('', '', 'height=400,width=800');
           
            printWindow.document.write(panel.innerHTML);
          
            printWindow.document.close();
            setTimeout(function () {
                printWindow.print();
            }, 500);
            return false;
        }
    </script>--%>
</head>
<body>
    <form id="niaApp" runat="server">      
            <div class="container">
                <asp:ScriptManager ID="sm1" runat="server"  EnablePageMethods="true" />
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
         <asp:Panel id="pnlContents" runat = "server">
	  <div id="makepayment" >
	  <span style="color:red;" id="errorMsg" ng-bind="errMsg" class="ng-binding"></span>
		
		<!--Step 1: Identify Yourself-->
		<div class="row">
               <div class="col-md-6 col-sm-12 col-xs-12">
                  <div class="form-group" >
                     <label>Visitor Number <font>*</font></label>                     
                     <asp:TextBox ID="txtVisitorNo" runat="server" class="form-control ng-pristine ng-untouched ng-valid ng-valid-maxlength" ng-model="nia.nameOfCandidate" ReadOnly="true"
                          ></asp:TextBox>
                                </div>
                    <div class="form-group" >
                     <label>Name  <font>*</font></label>                      
                     <asp:TextBox ID="txtnameOfCandidate" runat="server"  class="form-control ng-pristine ng-untouched ng-valid ng-valid-maxlength" ng-model="nia.nameOfCandidate" data-mandatory="1" data-validatefor="name"
                          data-errtext="Invalid candidate name" placeholder="" maxlength="100"></asp:TextBox>
                                </div>
                  
               </div>
               <div class="col-md-3 col-sm-12 col-xs-12">
                  <div class="form-group">
                     <label>Photo<font>*</font></label>
                   <div class="bottom-video">
    <video id="video" autoplay height="140" width="180" ></video>
    <canvas id="canvas" width='100' height='130' style="border: 1px solid #d3d3d3; visibility:hidden; position:absolute; left:0px;" ></canvas>
   
    
</div>
 </div>
               </div>
                       <div class="col-md-3 col-sm-12 col-xs-12">
                  <div class="form-group"><br />
                      <img width="150px" id="imgPhoto" height="130"   />       
                            </div>
               </div>           
                 
            </div>

         
            <div class="row">
               <div class="col-md-6 col-sm-12 col-xs-12">
                    <div class="form-group">
                     <label>From/Organization <font>*</font></label>                   
                        <asp:TextBox ID="txtfrom" runat="server"  class="form-control ng-pristine ng-untouched ng-valid ng-valid-maxlength" 
                        ng-model="nia.nameOfCandidate" data-mandatory="1" data-validatefor="From"
                          data-errtext="Invalid candidate Organization" placeholder="" maxlength="100"   ></asp:TextBox>
                                      </div>
                
               </div>
               <div class="col-md-6 col-sm-12 col-xs-12">
                   
                  <div class="form-group">
                     <label>whom to meet <font>*</font></label>
                              <asp:TextBox ID="txtmeet" runat="server" class="form-control ng-pristine ng-untouched ng-valid ng-valid-maxlength" 
                                  ng-model="nia.meet" placeholder="" data-mandatory="1" data-validatefor="name" data-errtext="Invalid whom to meet" maxlength="6"></asp:TextBox>
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

                     <label>Mobile <font>*</font></label>
                     <asp:TextBox ID="txtmobile" runat="server" class="form-control ng-pristine ng-untouched ng-valid ng-valid-maxlength" type="text" ng-model="nia.txtmobile" placeholder=""  data-mandatory="1" data-validatefor="mobile" data-errtext="Invalid mobile number" maxlength="10"></asp:TextBox>
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
                     <label>Type of List </label>
                                   <asp:DropDownList ID="ddlTypeList" runat="server" style="width:50%;float:left" class="selectpicker form-control ng-pristine ng-untouched ng-valid" ng-init="nia.salutation = &#39;Mr.&#39;" >
                          <asp:ListItem Value="Office">Official</asp:ListItem>
                   <asp:ListItem Value="Personal">Personal</asp:ListItem>
                      </asp:DropDownList>   </div>
                  
               </div>
            </div>
            <div class="row">
               <div class="col-md-6 col-sm-12 col-xs-12">
                  <div class="form-group">
                     <label>In Time. </label>
                    <asp:TextBox ID="txtIntime" runat="server" ReadOnly="true" class="form-control ng-pristine ng-untouched ng-valid ng-valid-maxlength" type="text" 
                        ></asp:TextBox>
                                 </div>
               </div>
               <div class="col-md-6 col-sm-12 col-xs-12"><div class="form-group">
                     <label>Other Info </label>
                     <asp:TextBox ID="txtOtherInfo" runat="server" class="form-control ng-pristine ng-untouched ng-valid ng-valid-maxlength" 
                        ></asp:TextBox>
                              </div>
                   
               </div>
            </div>
           
           
          
</div>
     </asp:Panel>
        <div class="row">
               <div class="col-md-6 col-sm-12 col-xs-12">
                  
               </div>
               <div class="col-md-6 col-sm-12 col-xs-12">
                   <div class="form-group">
                   <asp:Button ID="btnsave" runat="server" Text="Save" OnClick="btnsave_Click"  CssClass="form-control btn btn-success .btn-next" OnClientClick="return ValidateForm();" Width="30%" Height="100%"/>
                   
                   <input type="button" onclick="PrintElem('#makepayment')" value="Print" style="width:30%; height:100%;"/>
               </div> </div>
            </div>

      
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

<script  lang="ja" type="text/javascript">
    //Camera Code   

    var localMediaStream = null;
    var video = document.getElementById('video');
    var canvas = document.getElementById('canvas');


    function upload() {
        var base64 = document.getElementById('imgPhoto').src;
        PageMethods.Upload(base64,
            function () { /* TODO: do something for success */ },
            function (e) { console.log(e); }
        );
        stopCapture();
      
     }

     function takePhoto() {
         if (localMediaStream) {
             var ctx = canvas.getContext('2d');

             // we double the source coordinates
             // ctx.drawImage(video, 140, 120, 640, 490, 0, 0, 140, 190);
             ctx.drawImage(video, 140, 120, 640, 490, 0, 0, 140, 190);
             document.getElementById('imgPhoto').src = canvas.toDataURL('image/jpeg');
             upload();
         }
     }

     navigator.getUserMedia = navigator.getUserMedia || navigator.webkitGetUserMedia || navigator.mozGetUserMedia || navigator.msGetUserMedia;
     window.URL = window.URL || window.webkitURL;

     function startCapture() {
         if (navigator.getUserMedia) {
             navigator.getUserMedia({ video: true }, function (stream) {
                 video.src = window.URL.createObjectURL(stream);
                 localMediaStream = stream;
             }, function (e) {
                 console.log(e);
                
                });
            }
            else {
                console.log('Native web camera streaming (getUserMedia) is not supported in this browser.');
               
                 return;
             }

         }

         function stopCapture() {
             video.pause();
             localMediaStream.stop();
         }
         //end script for camera  
    </script>

<script type="text/javascript" src="./css/jquery-1.11.2.min.js"></script>
<script type="text/javascript" src="./css/angular.min.js"></script>
<script type="text/javascript" src="./css/bootstrap.min.js"></script>
<script type="text/javascript" src="./css/bootstrap-datetimepicker.js" charset="UTF-8"></script>
<script type="text/javascript" src="./css/validateform.js" charset="UTF-8"></script>
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


           
        }



  </script>    </form>
</body>
</html>
