<%@ Page Language="C#" AutoEventWireup="true" CodeFile="BindGridview1.aspx.cs" Inherits="BindGridview1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="Scripts/jquery-1.4.1.min.js" type="text/javascript"></script>
    <style type="text/css">
        .Row1
        {
            background-color: #D2CDCD;
        }
        .Rows
        {
            background-color: #fff;
        }
        .Header
        {
            background-color: #fff;
            font-size: large;
            font-weight: bold;
        }
        table.gridtable
        {
            font-family: verdana,arial,sans-serif;
            font-size: 11px;
            color: #333333;
            border-width: 1px;
            border-color: #666666;
            border-collapse: collapse;
            text-align: center;
            margin: auto;
        }
        table.gridtable th
        {
            border-width: 1px;
            padding: 8px;
            border-style: solid;
            border-color: #666666;
            background-color: #dedede;
        }
        table.gridtable td
        {
            border-width: 1px;
            padding: 8px;
            border-style: solid;
            border-color: #666666;
            background-color: #ffffff;
        }
    </style>
    <script type="text/javascript">
        function BindGridView() {
            $.ajax({
                type: "Post",
                url: "BindGridview1.aspx/GetNames",
                data: "{}",
                contentType: "application/json",
                dataType: "json",
                success: OnSuccess,
                failure: OnFailure,
                error: OnError
                  
            })
        }

        function OnSuccess(data) {
            var headers = [];
            var rows = [];
            // header section
            headers.push("<tr class='Header'>");
            headers.push("<td><b>Name</b></td>");
            headers.push("<td><b>Age</b></td>");
            headers.push("</tr>");
            for (var i = 0; i < data.d.length; i++) {
                rows.push("<tr class='Row" + ((i % 2) + 1) + "'><td>" + data.d[i].FirstName +
                                            "</td><td>" + data.d[i].Age + "</td></tr>");
            }

            var top = "<table class='gridtable'>";
            var bottom = "</table>";
            var table = top + headers.join("") + rows.join("") + bottom;
            $("#dataGrid").empty();
            $("#dataGrid").html(table);
        }

        function OnFailure(response) {
            //debugger;
            alert('Failure!!!' + '<br/>' + response.reponseText);
        }

        function OnError(response) {
            //debugger;
            var errorText = response.responseText;
            alert('Error!!!' + '\n\n' + errorText);
        }
    </script>
</head>
<body onload="BindGridView();">
    <form id="form1" runat="server">
    <div id="dataGrid"  style="overflow:scroll;width:100%;">
        <%--  <table id="dataGrid" cellpadding="2" cellspacing="0" border="1">

        </table>--%>
    </div>
    </form>
</body>
</html>
