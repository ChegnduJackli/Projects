<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="UserLogin.aspx.cs" Inherits="UserLogin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <link href="~/Styles/Site.css" rel="stylesheet" type="text/css" />
    <script src="Scripts/jquery-1.4.1.min.js" type="text/javascript"></script>
    <script src="Scripts/jquery-1.4.1-vsdoc.js" type="text/javascript"></script>
    <script type="text/javascript">

        function validateUserName() {
            var name = $("#<% =txtUserName.ClientID%>").val();
            if (name.trim().length == 0) {
                document.getElementById("userMsg").innerHTML = "Please input user name.";
                return false;
            }
            else {
                document.getElementById("userMsg").innerHTML = "";
                return true;
            }
        }
        function validatePassword() {
            var pass = $("#<% =txtPassword.ClientID%>").val();
            if (pass.trim().length == 0) {
                document.getElementById("passMsg").innerHTML = "Please input password.";
                return false;
            }
            else {
                document.getElementById("passMsg").innerHTML = "";
                return true;
            }
        }
        $(function () {
            $("#<% =txtUserName.ClientID%>").bind("blur", function () {
                validateUserName();
            });
            $("#<% =txtPassword.ClientID%>").bind("blur", function () {
                validatePassword();
            });

            $("#<%=btnSubmit.ClientID%>").bind("click", function () {
               
                var result = true;
                if (!validateUserName()) {
                    result = false;
                }
                if (!validatePassword()) {
                    result = false;
                }
                return result;

            });

        });


    </script>
    <style type="text/css">
        .Login
        {
            border: 1px #666 solid;
            border-collapse: collapse;
            margin: auto;
            width: 400px;
            height: 200px;
            padding: 10px;
        }
        input.textbox, select, textarea
        {
            font-family: verdana, arial, snas-serif;
            font-size: 12px;
            color: #000000;
            padding: 0px;
            background: #f0f0f0;
            border-left: solid 1px #c1c1c1;
            border-top: solid 1px #cfcfcf;
            border-right: solid 1px #cfcfcf;
            border-bottom: solid 1px #6f6f6f;
            height: 18px;
        }
        
        input.textbox:focus, input.input_text_focus
        {
            border-color: #646464;
            background-color: #ddd;
        }
        .AlignRight
        {
            float: right;
        }
    </style>

    <div class="Login">
        <table width="500px" cellpadding="5" cellspacing="2">
            <tr>
                <td class="AlignRight">
                    UserName:
                </td>
                <td>
                    <asp:TextBox ID="txtUserName" runat="server" CssClass="textbox"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="AlignRight">
                    Password:
                </td>
                <td>
                    <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" CssClass="textbox"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                </td>
                <td>
                    <asp:CheckBox ID="chkRem" runat="server" Text="Remember me next time" />
                </td>
            </tr>
            <tr>
                <td>
                </td>
                <td>
                    <asp:Button ID="btnSubmit" runat="server" Text="Submit" class='btn-lit' OnClick="btnSubmit_Click" />
                </td>
            </tr>
            <tr>
                <td>
                </td>
                <td>
                    <span id="userMsg" style="color: Red;"></span>
                </td>
            </tr>
            <tr>
                <td>
                </td>
                <td>
                    <span id="passMsg" style="color: Red;"></span>
                </td>
            </tr>
            <tr>
                <td>
                </td>
                <td>
                    <span id="spanStatus" style="color: blue;"></span>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
