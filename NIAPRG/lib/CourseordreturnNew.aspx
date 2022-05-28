<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="courseordreturnNew.aspx.cs" Inherits="NIAPRG.courseordreturnNew" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    
     <meta name="viewport" content="width=device-width, initial-scale=1" />
    <link rel="stylesheet" href="./nia_files/bootstrap.min.css" />
  <link rel="stylesheet" href="./nia_files/font-awesome.min.css" />
  <link rel="stylesheet" href="./nia_files/style.css" />
  <link rel="stylesheet" href="./nia_files/versatile.css" />
  <link href="./nia_files/bootstrap-datetimepicker.min.css" rel="stylesheet" media="screen" />
      <link rel="stylesheet" href="./nia_files/style2.css" />
    <link rel="stylesheet" href="./nia_files/bootstrap.css" />
    <link rel="stylesheet" href="./nia_files/main.css" />
   <script language="javascript">
       function foc() {
           if (window.document.forms["Form1"].TextBoxUserName.visible = true) {
               window.document.forms["Form1"].TextBoxUserName.focus();
           }
       }

    </script>   
</head>
<body>
    <form method="post" id="Form1">
       <%-- <nav class="navbar  ">
            <div class="container-fluid">
                <div class="col-md-2"></div><div class="col-md-8 ">
                    <center><img src="nia_files/1.jpg" class="imgclass" /></center>
                </div>
                <div class="col-md-2"></div>
                <!--/.nav-collapse -->
            </div>


            <!-- Fixed navbar -->
            <div class="container-fluid">
                <!-- Second navbar for categories -->
                <nav class="navbar navbar-default">

                    <div class="container">
                        <!-- Brand and toggle get grouped for better mobile display -->
                        <div class="navbar-header">
                            <button type="button" class="navbar-toggle collapsed" data-toggle="collapse" data-target="#navbar-collapse-1">
                                <span class="sr-only">Toggle navigation</span>
                                <span class="icon-bar"></span>
                                <span class="icon-bar"></span>
                                <span class="icon-bar"></span>
                            </button>
                            <a class="navbar-brand" href="#"></a>
                        </div>

                        <!-- Collect the nav links, forms, and other content for toggling -->
                        <div class="col-md-2"></div>
                        <div class="col-md-10">
                            <div class="collapse navbar-collapse" id="navbar-collapse-1">
                                <ul class="nav navbar-nav   ">
                                    <li>
                                        <a href="https://e-learning.niapune.org.in">Home</a>
                                    </li>
                                    <li>
                                        <a href="https://e-learning.niapune.org.in">Log On</a>
                                    </li>       
                                         <li>
                                        <a href="https://e-learning.niapune.org.in/ContactUs.html">Contact us</a>
                                    </li>
                                    <li>
                                        <a target="_blank" href="https://e-learning.niapune.org.in/help/FAQshomepage.pdf">Demo</a>
                                    </li>
                                    <li>
                                        <a href="#">FAQ/Help</a>
                                    </li>
                                </ul>

                            </div>
                        </div>


                        <!-- /.navbar-collapse -->
                    </div><!-- /.container -->
                </nav><!-- /.navbar -->



        </nav>--%>
        <div class="navbar navbar-static-top">
			<div class="container"> 
				<div class="navbar-header"> 
					<button class="collapsed navbar-toggle" aria-expanded="false" aria-controls="bs-navbar" type="button" data-target="#bs-navbar" data-toggle="collapse"> 
					<span class="sr-only">Toggle navigation</span> 
					<span class="icon-bar"></span> 
					<span class="icon-bar"></span> 
					<span class="icon-bar"></span> 
					</button> 
					<a class="navbar-brand" href="index.html"> <img src="nia_files/nia-logo.png" /></a> 
				</div> 
				<nav class="collapse navbar-collapse" id="bs-navbar"> 
					<ul class="nav navbar-nav navbar-right"> 
						<!--<li class="dropdown">
							<a class="dropdown-toggle" data-toggle="dropdown" href="#">instructions
							<span class="caret"></span></a>
							<ul class="dropdown-menu">
							  <li><a href="#">Page 1-1</a></li>
							  <li><a href="#">Page 1-2</a></li>
							  <li><a href="#">Page 1-3</a></li>
							</ul>
						</li>-->
                       
                        <li><a href="https://e-learning.niapune.org.in/">Home</a></li>
                        <li><a href="https://e-learning.niapune.org.in/Instructions.html">Instructions</a></li>
                        <li><a href="https://e-learning.niapune.org.in/democourse/nia/C1/demo/Unit_01/container.htm?sco=ITEM-B7C60880-9F8F-90B6-56A3-31A5E05C0CFD" target="_blank">Demo</a></li>
                        <!--<li><a href="#">FAQ’s</a></li>-->
                        <li><a href="https://e-learning.niapune.org.in/ContactUs.html">Contact us</a></li>
                        <li><a href="https://e-learning.niapune.org.in/Default.aspx">Login</a></li>
                        <li><a href="https://e-learning.niapune.org.in/lib/newReg.aspx" target="_blank">Registration</a></li>   
					</ul> 
				</nav> 
			</div>
		</div>
        <!-- Sidebar -->
        <!-- /#sidebar-wrapper -->
        <!-- Page Content -->

        <center>
            <div class="container-fluid">
                <div class="row">


                    <div class="col-md-3"></div>
                   
                    <div class="col-md-6">
                        <div class="login-page">
                            <br /><br />
                            <div class="form">
                                
        <div id="div1" runat="server">
              </div>
                                <asp:Label runat="server" ID="TESTLB" Visible="false" ></asp:Label>
                                <h4 style=" text-align: left; color: #3f6cb1; font-weight:bold;">For any support, Please refer Contact Us page</h4>



                                <p style=" text-align:left;">
                                    <span class="pagetext">
                                        National Insurance Academy<br />
                                        25,Balewadi, Baner Road,<br />
                                        NIA P.O., <br />
                                        Pune 411 045 India<br />
                                        Phone +91-20-27204000 / 27204444<br />
                                        Fax +91-20-27204555 / 27390396<br />
                                        E-mail: <a href="lms-support@niapune.org.in">lms-support@niapune.org.in</a> <br />
                                    </span>
                                </p>
                               
                              
                                
                              
                            </div>
                        </div>
                            </div>
                            <div class="col-md-3"></div>
                        </div>
                        	
                       
                    </div>

        </center>
        <!-- hostkkd cs kksd -->
        <!-- /#wrapper -->
        <!-- jQuery -->
        <script src="js/jquery.js"></script>

        <!-- Bootstrap Core JavaScript -->
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
