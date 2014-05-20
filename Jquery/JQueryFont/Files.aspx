<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Files.aspx.cs" Inherits="Files" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
<script type="text/javascript">
    $(document).ready(function () {
        $("#<%=FileUpload1.ClientID %>").blur(function () {
            var fileName = $('#<%=FileUpload1.ClientID%>').val()
            var file = document.getElementById("<%=FileUpload1.ClientID%>").value;

            alert(fileName);
            alert("file:" + file);
            console.log('there is some error');
        });

        function IsvalidateFileUpload() {
            console.log('there is some error');
        }

    });
</script>
    <asp:FileUpload ID="FileUpload1" runat="server" />
    <asp:Button ID="btnDownloadfile" runat="server" Text="Download the file" 
        onclick="btnDownloadfile_Click" />
</asp:Content>

