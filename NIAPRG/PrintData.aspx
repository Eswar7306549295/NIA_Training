<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PrintData.aspx.cs" Inherits="PMI.PrintData" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type = "text/javascript">
        function PrintPanel() {
            var panel = document.getElementById("<%=form1.ClientID %>");
            var printWindow = window.open('', '', 'height=400,width=800');

            printWindow.document.write(panel.innerHTML);

            printWindow.document.close();
            setTimeout(function () {
                printWindow.print();
            }, 500);
            return false;

        }
        window.onload = PrintPanel;
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div id="divdata" runat="server">
   
    </div>
    </form>
</body>
</html>
