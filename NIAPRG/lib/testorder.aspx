<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="testorder.aspx.cs" Inherits="NIAPRG.lib.testorder" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript">
        function myfunc() {
            var frm = document.all("form2");
            frm.submit();
        }
       // window.onload = myfunc;
</script>
</head>
<body>
    <form id="form2" runat="server" action="courseordreturn.aspx">
     <div>
     msg 
         <asp:TextBox ID="msg"  runat="server" 
             
             Text="NIANEW|NIAREG000000000000015|JCIT5459612575|548481-458660|2.00|CIT|485446|03|INR|DIRECT|NA|NA|00000000.00|28-06-2017 12:10:24|0300|NA|9999555555|test@test.com|NA|NA|NA|NA|NA|NA|Success|EB551D6EC5A20B657505B121E4232DE49161A9354981DBC27693C2BA3FDF0525" TextMode="MultiLine" Width="500px" Height="100px"></asp:TextBox>
         
 <asp:Button ID="BTNSUBMIT"  runat="server" Text="submit" OnClientClick="myfunc" />
    </div>
    </form>
</body>
</html>
