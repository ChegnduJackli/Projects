<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Convert.aspx.cs" Inherits="Javascript权威指南.Convert" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript">
        var email = 'shawn.lee@monocoque.design';
     //   alert(IsValidEmail(email));
        function IsValidEmail(sValue) {

            var emailPat = /^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,6}|[0-9]{1,3})(\]?)$/;

            var matchArray = sValue.match(emailPat);
            if (matchArray == null) {
                return false;
            }

//            var emailPat = /^(\".*\"|[A-Za-z]\w*)@(\[\d{1,3}(\.\d{1,3}){3}]|[A-Za-z]\w*(\.[A-Za-z]\w*)+)$/;
//            var matchArray = sValue.match(emailPat);
//            if (matchArray == null) {
//                return false;
//            }
            return true;
        }
        isValidChar('test$&cd|[].pdf');
        function isValidChar(value) {
            var SpecialChar = ['[', ']', '{', '}', '$', '\\', ';', '\'', '|', '"', '/', '<', '>', '?', '`', '&', '*', '(', ')'];
            for (var i= 0 ;i<SpecialChar.length;i++) {
                if (value.indexOf(SpecialChar[i]) > -1) {
                    console.log('invalid char: ' + SpecialChar[i]);
                    break;
                }
            }
        }

       
        function isSplCharForAttentionTo(str) {
            var i;
            var s = str;



            if (str != "") {

                strNumExpression = /^[a-zA-Z0-9\&\'\t\~\`\!\@\$\^\*\(\)\-\_\=\{\}\:\;\<\>\,\.\/\|\[\]\<\>\s\\]+$/;


                for (i = 0; i < s.length; i++) {
                    var x = s.charAt(i);
                    if ((x).match(strNumExpression)) {
                        return false;
                    }
                    else {
                        return true;
                    }
                }
            }
            return false;
        }
        function validateInput() {
            var value = document.getElementById('inputID').value;
            alert(isSplCharForAttentionTo(value));
        }

    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Label ID="Label1" runat="server" Text=""></asp:Label><br />
        <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" 
            onselectedindexchanged="DropDownList1_SelectedIndexChanged">
        </asp:DropDownList><br />
                <asp:Label ID="Label2" runat="server" Text=""></asp:Label><br />
                          <asp:Label ID="Label3" runat="server" Text=""></asp:Label><br />
                          <input type="text" id="inputID" value="a#" onblur="validateInput();" />
        <asp:TextBox ID="TextBox1" runat="server" ></asp:TextBox>
        <asp:Button ID="Button1"
            runat="server" Text="Button" onclick="Button1_Click" />
                           <asp:Label ID="Label4" runat="server" Text=""></asp:Label><br />

    </div>
    </form>
</body>
</html>
