﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TestSpecialCharctor.aspx.cs" Inherits="Jquery_Programming.TestSpecialCharctor" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:TextBox ID="txtcont" runat="server"></asp:TextBox>
        <asp:Button ID="btnTest"
            runat="server" Text="test" onclick="btnTest_Click" /><br />
        Result:<asp:Label ID="lblResult" runat="server" Text=""></asp:Label><br />
        <asp:Label ID="lblcont" runat="server" Text=""></asp:Label>
    </div>
    <div>
    [ - NOT ALLOWED<br />
] - NOT ALLOWED<br />
{ - NOT ALLOWED<br />
} - NOT ALLOWED<br />
$ - NOT ALLOWED<br />
\ - NOT ALLOWED<br />
; - NOT ALLOWED<br />
' - NOT ALLOWED<br />
| - NOT ALLOWED<br />
" - NOT ALLOWED<br />
/ - NOT ALLOWED<br />
< - NOT ALLOWED<br />
> - NOT ALLOWED<br />
? - NOT ALLOWED<br />
` - NOT ALLOWED<br />
& - NOT ALLOWED<br />
* - NOT ALLOWED<br />
( - NOT ALLOWED<br />
) - NOT ALLOWED<br />

    </div>
    </form>
</body>
</html>
