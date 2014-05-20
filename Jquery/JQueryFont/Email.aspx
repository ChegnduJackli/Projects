<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Email.aspx.cs" Inherits="Email" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
        <asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="Button" />
    </div>
    <div>
        <table width="100%" cellpadding="2" cellspacing="2" border="0" >
            <tr>
                <td>
                    Dear Sir / Mdm,
                </td>
            </tr>
            <tr>
                <td>
                    Your Vendors@gov account has been approved and is ready for use.
                </td>
            </tr>
            <tr>
                <td>
                    Below is a list of useful links to help get you started and maximize the potential
                    of the system.
                </td>
            </tr>
            <tr>
                <td>
                    Login Screen -<a href="http://www.vendors.gov.sg">http://www.vendors.gov.sg</a>
                </td>
            </tr>
            <tr>
                <td>
                    User Manual -<a href="https://app.vendors.gov.sg/Common/UserManual.aspx"></a>
                </td>
            </tr>
            <tr>
            </tr>
            <tr>
                <td>
                    If you have any other questions, you may use the following link to contact us.
                </td>
            </tr>
            <tr>
                <td>
                    <a href="http://app.helpdesk.agd.gov.sg/public_user/vendor/vendor/helpdesk.aspx">
                    </a>
                </td>
            </tr>
            <tr>
            </tr>
            <tr>
                <td>
                    This is an automated email and requires no signature.
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
