<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="Javascript权威指南.Index" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="js/common.js" type="text/javascript"></script>

</head>
<body>
    <form id="form1" runat="server">
    <div id="main">
    Accout Number:<input type="text" id="acct" value="641267927001" />
    <input type="button" id="btn" value="check" onclick="check();" />

    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label><br />
    
    <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
    </div>
    </form>
        <script type="text/javascript">
            function check() {
                // var acct = trimString(document.getElementById('acct').value);
                var acct = document.getElementById('acct').value.trim();

                if (isValidLen(acct,10,12)) {
                    alert('true');
                }
                else {
                    alert('false');
                }
            }
    </script>
</body>
</html>
