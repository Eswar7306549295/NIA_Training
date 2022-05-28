<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CourseAdminLogin.aspx.cs" Inherits="NIAPRG.lib.CourseAdminLogin" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">


    <script type="application/x-javascript"> addEventListener("load", function() { setTimeout(hideURLbar, 0); }, false); function hideURLbar(){ window.scrollTo(0,1); } </script>
    <!-- Bootstrap Core CSS -->
    <link href="css/bootstrap.min.css" rel='stylesheet' type='text/css' />
    <!-- Custom CSS -->
    <link href="css/style.css" rel='stylesheet' type='text/css' />
    <!-- Graph CSS -->
    <link href="css/font-awesome.css" rel="stylesheet">
    <!-- jQuery -->
    <!-- lined-icons -->
    <link rel="stylesheet" href="css/icon-font.min.css" type='text/css' />
    <!-- //lined-icons -->
    <!-- chart -->
    <script src="js/Chart.js"></script>
    <!-- //chart -->
    <!--animate-->
    <link href="css/animate.css" rel="stylesheet" type="text/css" media="all">
    <script src="js/wow.min.js"></script>
    <script>
        new WOW().init();
    </script>
    <!--//end-animate-->
    <!----webfonts--->
    <link href='//fonts.googleapis.com/css?family=Cabin:400,400italic,500,500italic,600,600italic,700,700italic' rel='stylesheet' type='text/css' />
    <!---//webfonts--->
    <!-- Meters graphs -->
    <script src="js/jquery-1.10.2.min.js"></script>
    <!-- Placed js at the end of the document so the pages load faster -->

    <%--Alert msg Styles start--%>
    <link rel="stylesheet" href="../alertmsg/alertify.core.css" />
    <link rel="stylesheet" href="../alertmsg/alertify.default.css" id="toggleCSS" />
    <script type="text/javascript" src="../alertmsg/jquery-1.9.1.js"></script>
    <script type="text/javascript" src="../alertmsg/alertify.min.js"></script>
    <%--Alert msg Styles End--%>
    <script src="../Scripts/jquery-1.10.2.js"></script>
    <script src="../Scripts/rollups/aes.js"></script>

</head>
<body class="sign-in-up">
    <form id="form1" runat="server" autocomplete="off">
        <div>
            <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server" CombineScripts="false">
                <Scripts>

                    <asp:ScriptReference Path="../js/webkit.js" />
                </Scripts>

            </asp:ToolkitScriptManager>
            <asp:HiddenField ID="hfUserid" runat="server" />
            <asp:Label ID="lblvalue" runat="server"></asp:Label>
            <section>
                <div id="page-wrapper" class="sign-in-wrapper">
                    <div class="graphs">
                        <div class="sign-in-form">
                            <div class="sign-in-form-top">
                                <p style="margin-top: 40px;"><span>Sign In</span> </p>
                            </div>
                            <div class="signin">

                                <div class="log-input">
                                    <div class="log-input-left">
                                        <asp:TextBox runat="server" ID="txtusername" class="user" autocomplete="off" onfocus="this.value = '';" required />
                                    </div>
                                    <div class="clearfix"></div>
                                </div>
                                <div class="log-input">
                                    <div class="log-input-left">
                                        <asp:TextBox runat="server" ID="txtloginpwd" type="password" autocomplete="off" class="lock" onfocus="this.value = '';" required />
                                    </div>
                                    <div class="clearfix"></div>
                                </div>
                                <asp:Button runat="server" ID="btnsubmit" type="submit" Text="Login to your account" OnClientClick=" return DummyPassword();" OnClick="btnsubmit_Click" />
                                <br />
                                <br />
                                <asp:Label ID="lblmsg" runat="server" Style="color: red;"></asp:Label>
                            </div>

                        </div>
                    </div>
                </div>
                <!--footer section start-->
                <footer>
                    <p>&copy 2017  All Rights Reserved  <a href="#"></a></p>
                </footer>
                <!--footer section end-->
            </section>
        </div>
        <%-- <div>
            <div>
      <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
      <input id="Button1" type="button" value="click" />
</div>
        </div>--%>
        <script type="text/javascript">


            function DummyPassword() {
                var value = document.getElementById("salt1").value;
                var pwdvalue = document.getElementById("txtloginpwd").value + value;
                //document.getElementById("txtloginpwd").value = pwdvalue;
                //return;
                var key = CryptoJS.enc.Utf8.parse('7061737323313233');

                var iv = CryptoJS.enc.Utf8.parse('7061737323313233');
                var txtloginpwd = pwdvalue;
                var encrypted = CryptoJS.AES.encrypt(CryptoJS.enc.Utf8.parse(txtloginpwd), key,

                    {

                        keySize: 128 / 8,

                        iv: iv,

                        mode: CryptoJS.mode.CBC,

                        padding: CryptoJS.pad.Pkcs7

                    });
                // alert(encrypted);
                var decrypted = CryptoJS.AES.decrypt(encrypted, key, {

                    keySize: 128 / 8,

                    iv: iv,

                    mode: CryptoJS.mode.CBC,

                    padding: CryptoJS.pad.Pkcs7

                });
                //  alert(encrypted+value);
                document.getElementById("txtloginpwd").value = encrypted;
                return;
            }

        </script>
        <asp:HiddenField ID="salt1" runat="server" />
    </form>
    <script src="js/jquery.nicescroll.js"></script>
    <script src="js/scripts.js"></script>
    <!-- Bootstrap Core JavaScript -->
    <script src="js/bootstrap.min.js"></script>
</body>
</html>

