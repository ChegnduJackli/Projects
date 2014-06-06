<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="Login1.aspx.cs" Inherits="Login_bak" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <link href="~/Styles/Site.css" rel="stylesheet" type="text/css" />
    <script src="Scripts/jquery-1.4.1.min.js" type="text/javascript"></script>
    <script src="Scripts/jquery-1.4.1-vsdoc.js" type="text/javascript"></script>
    <script type="text/javascript">

        function validateUserName() {
            var name = document.getElementById("txtUserName").value;
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
            var pass = document.getElementById("txtPassword").value;
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
            $("#txtUserName").bind("blur", function () {
                validateUserName();
            });
            $("#txtPassword").bind("blur", function () {
                validatePassword();
            });

            $("#btnSubmit").bind("click", function () {
                var name = document.getElementById("txtUserName").value;
                var pass = document.getElementById("txtPassword").value;

                var result = true;
                if (!validateUserName()) {
                    result = false;
                }
                if (!validatePassword()) {
                    result = false;
                }
                // return result;

                if (result) {
                    $.ajax({
                        type: "Get",
                        url: "Handler/GetUserHandler.ashx",
                        data: { "userName": name, "password": pass },
                        contentType: "application/json; charset=utf-8",
                        dataType: "json",
                        async: false,
                        beforeSend: function (XMLHttpRequest) {
                            document.getElementById("spanStatus").innerHTML = "Loading...";
                            //Pause(this,100000);
                        },
                        success: function (response) {
                            if (response) {
                                $("#btnSubmit").attr("disabled", "disabled");
                                document.getElementById("spanStatus").innerHTML = "Log In successfully."
                                window.location.href = "Default.aspx";
                            }
                            else {
                                $("#btnSubmit").removeAttr("disabled");
                                document.getElementById("spanStatus").innerHTML = "Log In failed."
                                window.location.href = "Login1.aspx";
                            }
                        }
                        ,
                        error: function (request, status, error) {
                            if (status == 403) {
                                $("#btnSubmit").removeAttr("disabled");
                                window.location.href = 'Login1.aspx';

                            }
                        },
                        failure: function (response) {
                            $("#btnSubmit").removeAttr("disabled");
                        }
                    });
                }
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
                    <input type="text" value="" class="textbox" id="txtUserName"  />
                </td>
            </tr>
            <tr>
                <td class="AlignRight">
                    Password:
                </td>
                <td>
                    <input type="password" value="" class="textbox" id="txtPassword" />
                </td>
            </tr>
            <tr>
                <td>
                </td>
                <td>
                    <input type="checkbox" value="Remember me next time" id="chkRem" />Remember me next
                    time
                </td>
            </tr>
            <tr>
                <td>
                </td>
                <td>
                    <input type="submit" value='Submit' class='btn-lit' id="btnSubmit"  />
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
        <div>
</asp:Content>
