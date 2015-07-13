<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Chapter4_Selector.aspx.cs"
    Inherits="Jquery_Programming.Chapter4_Selector" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
<link rel="Stylesheet" href="http://ajax.aspnetcdn.com/ajax/jquery.ui/1.8.10/themes/redmond/jquery-ui.css" />
<script src="http://ajax.aspnetcdn.com/ajax/jquery/jquery-1.8.0.js"></script>
<script src="http://ajax.aspnetcdn.com/ajax/jquery.ui/1.8.22/jquery-ui.js"></script>

    <title></title>
    <script type="text/javascript">

        $(function () {

            var friends = {};
            friends.bill = {
                firstName: "Bill",
                lastName: "Gates",
                number: "(206) 555-5555",
                address: ['One Microsoft Way', 'Redmond', 'WA', '98052']
            };
            friends.steve = {
                firstName: "Steve",
                lastName: "Jobs",
                number: "(408) 555-5555",
                address: ['1 Infinite Loop', 'Cupertino', 'CA', '95014']
            };

            var list = function (obj) {
                for (var prop in obj) {
                    console.log(prop);
                }
            };

            var search = function (name) {
                for (var prop in friends) {
                    if (friends[prop].firstName === name) {
                        console.log(friends[prop]);
                        return friends[prop];
                    }
                }
            };
            search("Steve");
            $('a').click(function () {
                var urlLastName = window.location.href.substr(window.location.href.lastIndexOf("/") + 1);
                alert(urlLastName);
                if (urlLastName.indexOf('#') > 0) {
                    urlLastName = urlLastName.replace('#', 'section')
                }
                window.href = urlLastName;
            });

        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
       <div>    
		<asp:TextBox ID="txtStartDate" ClientIDMode="Static" runat="server" />
           <asp:Button ID="btnSearch" runat="server" Text="Search" 
               onclick="btnSearch_Click" />
           <asp:Label ID="lblMsg" runat="server" Text=""></asp:Label>
	</div>
    <a href="#one">test</a>
        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
    </div>
    </form>
</body>
</html>
