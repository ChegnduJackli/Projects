<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PopupWebPage.aspx.cs" Inherits="PopupWebPage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript">

        function PrintVendor() {
            popup_window = window.open("Default.aspx", "Information", "width=800,height=600,top=250,left=10,toolbars=no,scrollbars=no,status=no,resizable=no");
            popup_window.focus();
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <img src="../images/print.gif" style="cursor: pointer;" width="20" height="20" alt="Print"
            border="0" onclick="javascript:PrintVendor();" title="Click here for print text" />
        <a href="#">
            <img height="22" src="../Images/btn_close.gif" alt="Close" border="0" onclick="javascript:window.close();"
                width="105" title="Close" /></a> 
    </div>
    </form>
</body>
</html>
