<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ReportPrint.aspx.cs" Inherits="ReportPrint" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

      <script language="javascript" type="text/javascript">

          function changeScreenSize() {
              window.resizeTo(screen.width, screen.height - 100);
              window.moveTo(0, 0);
              //document.getElementById("Pdf1").width = screen.width-35;
              //alert(screen.height);
              document.getElementById("Pdf1").height = screen.height;
          }
          function print() {
              var x = document.getElementById("Pdf1");
              x.click(); x.setActive(); x.focus(); x.print();
          }
      </script>
</head>
<body onload="changeScreenSize()">
    <div style="width: 100%;">
        <embed src="TempReport.pdf" id="Pdf1" name="Pdf1" width="100%" style="width: 100%;" />
    </div>
</body>
</html>
