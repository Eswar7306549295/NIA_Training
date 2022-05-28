<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ExamBillDesk.aspx.cs" Inherits="NIAPRG.lib.ExamBillDesk" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
     <script type="text/javascript">
         function myfunc() {

             var frm = document.all("Exambilldesk");
             frm.submit();
         }
         window.onload = myfunc;
</script>
    <script type="text/javascript" src="http://code.jquery.com/jquery-1.8.2.js"></script>

<style type="text/css">
#pageloaddiv {
position: fixed;
left: 0px;
top: 0px;
width: 100%;
height: 100%;
z-index: 1000;
background: url('nia_files/pageloader.gif') no-repeat center center;
}

.container-full {
  margin: 0 auto;
  width: 100%;
  min-height:100%;
  background: url('http://www.desktopwallpaperhd.net/wallpapers/7/6/background-homepage-web-wood-opera-media-images-79414.jpg');
  color:#eee;
  overflow:hidden;
}
/* Preloader with Bootstrap Progress Bar
-----------------------------------------------*/
.loader {
	position: fixed;
	left: 0;
	top: 0;
	width: 100%;
	height: 100%;
	z-index: 99;
	background: url(https://6ed03b3e7ee716b29bc2dee79aafb8179ed53b19-www.googledrive.com/host/0B9VLbslO6g64UnFTUlQzWDVMdXM&#39;) 50% 50% no-repeat rgb(249,249,249);
}
.loader-container {
	width: 600px;
	height: 200px;
	position: absolute;
	top:0;
	bottom: 0;
	left: 0;
	right: 0;
	
	margin: auto;
	text-align: center;
}
</style>
</head>
<body>
     <form name='Exambilldesk' method='POST' action='https://pgi.billdesk.com/pgidsk/PGIMerchantPayment' >
  <div style="display:none;">
        <br /> <br /> <br /> <br />
           Check Sum Value :  <asp:Label runat="server" ID="checkSumValue" ></asp:Label>
         <br />
          <br /> <br />
         MSG : <%--<asp:TextBox ID="msg"  runat="server" TextMode="MultiLine" Width="500px" Height="100px"></asp:TextBox>--%>
         <br /> <br /> <br />
         <%--<asp:Button ID="btnsubmit"  runat="server" Text="submit"  OnClientClick="javascript: myfunc();"/>--%>
       <input  type='hidden'  name='msg' value="<% =ServerValue %>" />
<%--<input type='submit' name='PayNow' value='PayNow' class="btn-primary" />--%>
      </div>

         <div class='loader'>
  <div class='loader-container'>
    <h3><b>Please wait a moment while we are redirecting to payment gateway !</b></h3>
    <div class='progress progress-striped active'>
      <div class='progress-bar progress-bar-color' id='bar' role='progressbar' style='width: 0%;'></div>
    </div>
  </div>
</div>
     </form>
    <script>
        var progress = setInterval(function () {
            var $bar = $("#bar");

            if ($bar.width() >= 600) {
                clearInterval(progress);
            } else {
                $bar.width($bar.width() + 60);
            }
            $bar.text($bar.width() / 6 + "%");
            if ($bar.width() / 6 == 100) {
                $bar.text("Loading ... " + $bar.width() / 6 + "%");
            }
        }, 800);

        $(window).load(function () {
            $("#bar").width(600);
            $(".loader").fadeOut(3000);
        });
    </script>
</body>
</html>
