<%@ Page Language="C#" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="AdminCertificate.aspx.cs" Inherits="NIAPRG.lib.AdminCertificate" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <link rel="stylesheet" href="./nia_files/bootstrap.min.css" />
    <link rel="stylesheet" href="./nia_files/font-awesome.min.css">
    <link rel="stylesheet" href="./nia_files/style.css">
    <link rel="stylesheet" href="./nia_files/versatile.css">
    <link href="./nia_files/bootstrap-datetimepicker.min.css" rel="stylesheet" media="screen">
    <%--<style type="text/css">
        .auto-style1 {
            margin-left: 55px;
        }
    </style>--%>
</head>
<body>
    <form id="form1" runat="server">
        <br />
        <asp:Label runat="server" ID="lblmessage" Visible="false"></asp:Label>
<%--        <div class="row text-right">
            
        </div>--%>

        <div id="divdownload" runat="server" visible="false" >
          <h3 style=' text-align: left; color: #3f6cb1; font-weight:bold;'>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; You Certificate is generated as your PAN Number.PDF <asp:Button ID="btnexport" runat="server" Width="300px" Height="30px" Text=" Click here to Download" OnClick="btnexport_Click"  />
            </h3>
            
        </div>
        <div id="divnotgen" runat="server"  visible="false">

          <h3 style=' text-align: left; color: #3f6cb1; font-weight:bold;'>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Your Certificate not yet generated, We will update you soon...</h3>
        </div>
        <div id="ctf"   visible="false"   runat="server" style="background-repeat: no-repeat; background-position: center center; height: 900px; padding-top: 50px; background-image: url(../lib/nia_files/NIAFrame.jpg); padding-left: 10%; padding-right: 10%;">
            <div style="width: 90%; height: 90%; font-size: small;">


                <br />
                <br />
                <br />
                
                <div>
                    <table style="width: 100%; ">
                        <tr>
                             <td style="text-align: left; width:30%; ">&nbsp;</td><br /> <br /><br /><br />
                                <asp:Image ID="imglogo" runat="server" style="max-height:100px;max-width:100px;height:100px;width:100px;" Visible="false" /></td>
                            <td style="width:10%">&nbsp;</td>
                            <td style="text-align: left; width:50%; ">
                                <%--<div style="height: 250px">--%>
                                 
                                <asp:Image ID="userimg" runat="server"  style="max-height:100px;max-width:100px;height:100px;width:100px;" /></td>
                                <%--</div>--%>                        
                        </tr>
                    </table>
                </div>
                <div id="trainingfresh" style="margin-top:100px;">
                <div
                    style="text-align: center;"><br /><br />
                    <h2 style="color: red; font-weight: bold; font-size: large; /* padding: 59px; */">CERTIFICATION OF ONLINE BROKERS TRAINING
                    </h2>
                    <br />
                    <h3 style="font-size: 12px;" class="auto-style1">This is to certify that
                        <br /><b>
                        <asp:Label ID="lbname" runat="server"></asp:Label>
                        </b>
                        <br />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        has attended 
                        <asp:Label ID="lbCourseHrs" runat="server"></asp:Label>
                        Online Training Programme for the     
                        <br class="auto-style1" />&nbsp;
                        Insurance Brokers Examination as per Regulation 8(2)
                        <br class="auto-style1" />&nbsp;
                        Schedule I – Form E, Part I of Insurance Regulatory 
                        <br class="auto-style1" />&nbsp;
                        and Development Authority (Insurance Brokers) Regulations, 2018.
                        <br class="auto-style1" />
                        <br class="auto-style1" />&nbsp;
                        The said candidate had registered for the online training programme 
                        <br class="auto-style1" />&nbsp;
                        on
                        <asp:Label ID="lbstartdt" runat="server"></asp:Label>
                        and completed 
                        <asp:Label ID="lbCourseHrsCompleted" runat="server"></asp:Label>
                        on 
                        <asp:Label ID="lbcompleted" runat="server"></asp:Label>
                        <br class="auto-style1" />in&nbsp;<b>
                        <asp:Label ID="lbcourse" runat="server" style="color: red; font-weight: bold; font-size: large;" ></asp:Label>
                        </b>
                        <br class="auto-style1" />
                        <br class="auto-style1" />
                        <br class="auto-style1" />
                        <br class="auto-style1" />Completed on :
                        <asp:Label ID="lbdate" runat="server"></asp:Label>
                        <br class="auto-style1" />
                        <br class="auto-style1" />Training ID :
                        <asp:Label ID="lbtrgid" runat="server"></asp:Label>
                        <br class="auto-style1" />
                        <br class="auto-style1" />
                        <br class="auto-style1" />Course Co-ordinator
                        <br class="auto-style1" />National Insurance Academy
                    </h3>
                    <br class="auto-style1" />&nbsp;&nbsp; &nbsp; &nbsp; &nbsp;&nbsp;&nbsp; &nbsp; &nbsp; &nbsp;&nbsp;&nbsp; &nbsp; &nbsp; &nbsp;&nbsp;&nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp;
                    Training Valid till Date : <asp:Label ID="lbltrainingvaliddate" runat="server"></asp:Label>
                    <br class="auto-style1" />&nbsp;&nbsp; &nbsp; &nbsp; &nbsp;&nbsp;&nbsp; &nbsp; &nbsp; &nbsp;&nbsp;&nbsp; &nbsp; &nbsp; &nbsp;&nbsp;&nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp;
                    Note : The said candidate need to pass the examination on/before <asp:Label ID="lblnotedate" runat="server"></asp:Label>
                    <p class="auto-style1">
                        [This certificate is issued on 
                        <asp:Label ID="lbtodayDate" runat="server"></asp:Label>
                        ]<br class="auto-style1" />This is a computer generated document and NO signature is required.
           
                    </p>
                </div>
                </div>


</div>
            </div>

        <br />

          <div id="ctf2"   visible="false"   runat="server" style="background-repeat: no-repeat; background-position: center center; height: 900px; padding-top: 50px; background-image: url(../lib/nia_files/NIAFrame_02.jpg); padding-left: 10%; padding-right: 10%;">
            <div style="width: 90%; height: 90%; font-size: small;">


                <br />
                <br />
                <br />
                
                <div>
                    <table style="width: 100%; ">
                        <tr>
                             <td style="text-align: left; width:30%; ">&nbsp;</td>
                            <td style="text-align: left;width:50% "><br /><br /><br /><br />
                                <asp:Image ID="imglogo1" runat="server" style="max-height:100px;max-width:100px;height:100px;width:100px;" Visible="false" /></td>
                            <td style="width:10%">&nbsp;</td>
                            <td style="text-align: left; width:50%; ">
                                <%--<div style="height: 250px">--%>
                                 
                                <asp:Image ID="userimg1" runat="server"  style="max-height:100px;max-width:100px;height:100px;width:100px;" /></td>
                                <%--</div>--%>                        
                        </tr>
                    </table>
                </div>

                <div id="renewal" style="margin-top:100px;">
                <div
                    style="text-align: center;"><br /><br />
                    <h2 style="color: brown; font-weight: bold; font-size: large; /* padding: 59px; */">&nbsp;&nbsp; CERTIFICATION OF INSURANCE BROKERS ONLINE TRAINING FOR</h2>
                </div>
                    <div style="text-align: center; margin-left: 80px;">
                        <h2 style="color: brown; font-weight: bold; font-size: x-large ; /* padding: 59px; */">&nbsp;RENEWAL OF LICENCE
                    </h2>
                        <br />
                    <%--<asp:Label ID="Label1" runat="server" Text=""></asp:Label>
       <asp:Label ID="Label2" runat="server" Text=""></asp:Label>   --%>
                </div>
                <div style="margin-right: 15px; margin-left: 95px; text-align: center">
                    <h3 style="font-size: 12px;">This is to certify that
                <br/> 


                      <%--  This is to certify that
Mr./Ms./Dr.  ____________________  has undergone 25 hours Online Training and 
has completed the self-assessment test conducted by the National Insurance Academy for Renewal of License as per Regulation 18 of 
Insurance Regulatory and Development Authority (Insurance Brokers) Regulations, 2013 and 
Circular no. IRDAI/ BRK/ MISC/ CIR/ 260/ 11/ 2017 dated 29th November, 2017.--%>

                        <b>

                            <asp:Label ID="lbname1" runat="server"></asp:Label></b>
                        <br />
                        has undergone  <asp:Label ID="lbCourseHrs1" runat="server"></asp:Label> Online Training Programme and      
           <br />
                        has completed the self-assessment test conducted by the National Insurance Academy for
<%--           <br />--%>
                          
                        <br />Renewal of License as per 
                        <br />Regulations-Chapter –II ,Part B, 14(3) of the
           <br />
                        Insurance Regulatory and Development Authority of India (Insurance Brokers)
                        <br />Regulations, 2018 dated  January 19,2018 and 
           <br />
                         Circular no. IRDAI/ BRK/ MISC/ CIR/ 260/ 11/ 2017 dated 29th November, 2017.
                        <%--<br />
                        
           <br />--%>
                       
                    <asp:Label ID="lbstartdt1" Visible="false" runat="server"></asp:Label>
                        <asp:Label ID="lbCourseHrsCompleted1" Visible="false"  runat="server"></asp:Label>
           <asp:Label ID="Label5" Visible="false" runat="server"></asp:Label>
                        <br />
                         <b>
                            <asp:Label ID="lbcourse1" Visible="false"  runat="server" style="color: red; font-weight: bold; font-size: large;" ></asp:Label></b>
                        <br />
                       <%-- <br />
                        <br />--%>
                        Place : Pune, Maharashtra.
                        <br /><br />
                        Completed on :

                    <asp:Label ID="lbdate1" runat="server"></asp:Label>
                        <br /> <br />
                        Training ID :
                    <asp:Label ID="lbtrgid1" runat="server"></asp:Label>
                        <br />
                      <%--  <br />--%>
                        <br />
                        Course Co-ordinator
           <br />
                        National Insurance Academy
                    </h3><br />&nbsp;&nbsp; &nbsp; &nbsp; &nbsp;&nbsp;&nbsp; &nbsp; &nbsp; &nbsp;Training Valid till Date : <asp:Label ID="lblrenewaltrainingvaliddate" runat="server"></asp:Label>
                    <br />    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;&nbsp; &nbsp; &nbsp; &nbsp;Note : The said candidate can complete the next renewal training on/before six months from <asp:Label ID="lblrenewaltrainingvaliddate2" runat="server"></asp:Label> i.e. in the period of <asp:Label ID="lblrenewaltrainingvalidpriordate" runat="server"></asp:Label> and  
                    <br />      &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;&nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;&nbsp;&nbsp; &nbsp; &nbsp; &nbsp;<asp:Label ID="lblrenewaltrainingvaliddate3" runat="server"></asp:Label>.
                    <br />
                    <p> 
                        [This certificate is issued on <asp:Label ID="lbtodayDate1" runat="server"></asp:Label>
                        ]<br />
                        This is a computer generated document and NO signature is required.
           
                    </p>
                </div>
                </div>
            </div>
              

        </div>
        <br />

    </form>
</body>
<html>
    