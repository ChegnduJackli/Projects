<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="CheckInvoice.aspx.cs" Inherits="CheckInvoice" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <asp:CheckBox ID="chkDirectInvoice" runat="server" />
    <asp:DropDownList ID="DropDownList1" runat="server">
    <asp:ListItem>1</asp:ListItem>
    <asp:ListItem>2</asp:ListItem>
    <asp:ListItem>3</asp:ListItem>
    </asp:DropDownList>

    <script type="text/javascript">
        var ctrlchkDirectInvoice = "<%=chkDirectInvoice.ClientID%>";
        var ctrlddllist = "<%=DropDownList1.ClientID%>";
    </script>

 <script type="text/javascript">
        function checkDirectInvoices() {
            var ctrlChkDirect = document.getElementById(ctrlchkDirectInvoice);
            if (ctrlChkDirect.checked) {
                document.getElementById(ctrlddllist).disabled = true;
                alert("Checked");
            }
            else {
                alert("not checked");
                document.getElementById(ctrlddllist).disabled = false;
            }
        }
    </script>
        
</asp:Content>

