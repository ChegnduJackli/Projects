<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="RequestQuerystring.WebForm1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript">
        function goto() {
            var id = '#004@$%^&?';
            var url = 'WebForm2.aspx?item=' + encodeURIComponent(id);
            //decodeURIComponent() to decode
            window.location.href = url;
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <p onclick="goto();">go to webForm2</p>
    <a href="javascript:void(0)" onclick="goto();">Run webForm2 Code</a>
    </div>
    </form>
</body>
</html>
