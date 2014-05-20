<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CS.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript">
        function GetDynamicTextBox(value) {
            return '<input name = "DynamicTextBox" type="text" style="margin:3px;" value = "' + value + '" />' +
                    '&nbsp;&nbsp;<input type="button" value="Remove" onclick = "RemoveTextBox(this)" />'
        }
        function AddTextBox() {
            var div = document.createElement('DIV');
            div.innerHTML = GetDynamicTextBox("");
            document.getElementById("TextBoxContainer").appendChild(div);
        }

        function RemoveTextBox(div) {
            document.getElementById("TextBoxContainer").removeChild(div.parentNode);
        }

        function RecreateDynamicTextboxes() {
            var values = eval('<%=Values%>');
            alert(values);
            if (values != null) {
                var html = "";
                for (var i = 0; i < values.length; i++) {
                    html += "<div>" + GetDynamicTextBox(values[i]) + "</div>";
                }
                document.getElementById("TextBoxContainer").innerHTML = html;
            }
        }
        window.onload = RecreateDynamicTextboxes;


    </script>
</head>
<body>
    <form id="form1" runat="server">
    <input id="btnAdd" type="button" value="add" onclick="AddTextBox()" />
    <br />
    <br />
    <div id="TextBoxContainer">
        <!--Textboxes will be added here -->
    </div>
    <br />
    <asp:Button ID="btnPost" runat="server" Text="Post" OnClick="Post" />
    <hr />

    </form>
</body>
</html>
