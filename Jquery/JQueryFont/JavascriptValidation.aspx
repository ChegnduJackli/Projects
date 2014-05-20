<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="JavascriptValidation.aspx.cs" Inherits="HideOrShow" %>
   
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
 
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    

    <style type="text/css">
        .errMsg
        {
            color: Red;
            font-size: 12px;
        }
    </style>
    <div>
        <table>
            <tr>
                <td>
                    UserName:
                </td>
                <td>
                    <asp:TextBox ID="txtUserName" runat="server" onblur="validateUserName()" onclick="validateUserName()"></asp:TextBox>
                    <span id="spanNameMsg" class="errMsg"></span>
                </td>
            </tr>
            <tr>
                <td>
                    Password:
                </td>
                <td>
                    <asp:TextBox ID="txtPassword" runat="server" onblur="validatePassword()" onclick="validatePassword()"></asp:TextBox>
                    <span id="passMsg" class="errMsg"></span>
                </td>
            </tr>
            <tr>
                <td>
                </td>
                <td>
                    <asp:Button ID="btnLogin" runat="server" Text="Login" />
                </td>
            </tr>
        </table>
    </div>


    <script type="text/javascript">


  //      $(document).ready(function () {
            function validateUserName() {
                var name = document.getElementById('<%=txtUserName.ClientID %>').value;
                if (name === "") {
                    document.getElementById("spanNameMsg").innerHTML = "*Please input user name.";
                    return false;
                }
                else {
                    document.getElementById("spanNameMsg").innerHTML = "";
                    return true;
                }
            }
            function validatePassword() {
                var password = document.getElementById('<%=txtPassword.ClientID %>').value;
                if (password === "") {
                    document.getElementById("passMsg").innerHTML = "*Please input password.";
                    return false;
                }
                else if (!IsValidPassword(password)) {
                    return false;
                }
                else {
                    document.getElementById("passMsg").innerHTML = "";
                    return true;
                }
            }


            function validateForm() {
                var bReturn = true;
                if (!validateUserName()) {
                    bReturn = false;
                }

                if (!validatePassword()) {
                    bReturn = false;
                }
                if (!ValidateDatIsExist()) {
                    bReturn = false;
                }
                return bReturn;
            }

            var anUpperCase = /[A-Z]/;
            var aLowerCase = /[a-z]/;
            var aNumber = /[0-9]/;
            var aSpecial = /[!|@|#|$|%|^|&|*|(|)|-|_]/;

            function IsValidPassword(obj) {
                if (obj.length < 8) {
                    document.getElementById("passMsg").innerHTML = "password cannot less than 8 bits.";
                    return false;
                }
                if (!anUpperCase.test(obj) && !aLowerCase.test(obj)) {
                    document.getElementById("passMsg").innerHTML = "password must contain letter (a-z) or (A-Z).";
                    return false;
                }
                if (!aSpecial.test(obj)) {
                    document.getElementById("passMsg").innerHTML = "password must contain special characters.";
                    return false;
                }
                if (!aNumber.test(obj)) {
                    document.getElementById("passMsg").innerHTML = "password must contain number.";
                    return false;
                }
                return true;
            }
            function ValidateDatIsExist() {
                var myname = "lideng";
                $.ajax({
                    url: "HandlerTest1.ashx",
                    type: "Get",
                    data: { name: myname },
                    // dataType: "json",
                    success: function (result) {
                        alert(result);
                        if (result == "true") {
                            if (confirm("sure to commit?")) {
                                alert("commited");
                                return true;
                            }
                            else {
                                alert("not commited");
                                return false;
                            }
                        }

                    },
                    error: function () { alert("error"); return false; }
                });
            }
//        });

    </script>
    <script src="Scripts/ValidateLogin.js" type="text/javascript"></script>
</asp:Content>
