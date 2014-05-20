<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Tablelign.aspx.cs" Inherits="Tablelign" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table width="900px" align="center" border="1" cellpadding="0" cellspacing="0">
               <tr style="background-color :gray;">
                <td>
                    Email:
                </td>
                <td>
                    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                    <asp:Button ID="Button1" runat="server" Text="Add" />
                </td>
            </tr>
            <tr style="background-color :Blue;">
            <td>
                 
            </td>
            <td>
                  <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
                     <asp:Button ID="Button2" runat="server" Text="[Delete]" />
            </td>
            </tr>
  <%--          <tr align="left">
                <td>
         
                </td>
                <td align="left">
                    <table align ="left" border ="1" cellpadding="0" cellspacing="0">
                        <tr>
                            <td>
                                <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                            </td>
                            <td>
                                validate like label show message.
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>--%>
        </table>
    </div>
    </form>
</body>
</html>
