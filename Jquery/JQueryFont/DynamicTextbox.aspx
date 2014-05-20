<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DynamicTextbox.aspx.cs" Inherits="DynamicTextbox" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
     <script type="text/javascript">
         function addTextbox() {
             var hidden = document.getElementById("hf");
             var textboxToAdd = document.createElement("input");
             textboxToAdd.className = "selectorClass";
             textboxToAdd.id = "text" + hidden.value;
             hidden.value = parseInt(hidden.value) + 1;
             document.getElementById("pnl").appendChild(textboxToAdd);
         }
         function hideDynamicTextbox() {
             var alldynamic = document.getElementById("pnl").getElementsByTagName("input");
             for (var i = 0; i < alldynamic.length; i++) {
                 alldynamic[i].style.display = "none";
             }
         }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
       <input id="hf" type="hidden" value="1" />
    <div id="pnl" >
    </div>
    <input id="btn" value="Add textboxes" type="button" onclick="addTextbox()" />
    <input id="Button1" value="Hide dynamic textboxes" type="button" onclick="hideDynamicTextbox()" />
    </div>
    </form>
</body>
</html>
