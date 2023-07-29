<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ExcelfileReportViewer.aspx.cs" Inherits="ExcelfileReportViewer" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
     <script type="text/javascript">

         function changeScreenSize() {
             window.resizeTo(screen.width, screen.height)
             document.getElementById("Pdf1").width = screen.width;
             document.getElementById("Pdf1").height = screen.height;
         }
     </script>
</head>
<body>
    <form id="form1" runat="server">
     <asp:Button ID="Button2" runat="server" style="float:right;" Text="Print" />  
    <div>
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
       
       <rsweb:ReportViewer ID="rptViewer" runat="server" Font-Names="Verdana" Font-Size="8pt"
            Height="95%" Width="100%" SizeToReportContent="True" OnDataBinding="rptViewer_DataBinding">
        </rsweb:ReportViewer>
        <asp:HiddenField ID="HidParam" runat="server"  Value="0"/>
    </div>
    </form>
</body>
</html>

