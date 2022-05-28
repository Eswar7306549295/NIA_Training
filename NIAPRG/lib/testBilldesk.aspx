<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="testBilldesk.aspx.cs" Inherits="NIAPRG.lib.testBilldesk" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript">
        function myfunc() {
            var frm = document.all("form2");
            frm.submit();
        }
      //  window.onload = myfunc;
</script>
</head>
<body>
   <form id="form2"  runat="server">
    <br /> <br /> <br /> <br />
          
         <br />
          <br /> <br />
         MSG : <asp:TextBox ID="msg"  runat="server" TextMode="MultiLine" Width="500px" Height="100px"></asp:TextBox>
         <br /> <br /> <br />
       
        Check Sum Value :  <asp:Label runat="server" ID="checkSumValue" ></asp:Label>
       <asp:Button ID="btngenerate" runat="server" Text="Generate Check Sum Value" OnClick="btngenerate_Click" />
         
         <%--<asp:Button ID="btnsubmit"  runat="server" Text="submit"  OnClientClick="javascript: myfunc();"/>--%>
      
     </form>
</body>
</html>
