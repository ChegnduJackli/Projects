<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Fileupload.aspx.cs" Inherits="Fileupload" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <script src="Scripts/jquery-1.4.1.min.js" type="text/javascript"></script>
<script type="text/javascript">
    function fireFileClick() {
        var objfile = $("#<%=FileUpload1.ClientID %>");
        objfile.click();

        var objTextBox = $("#<%=Text1.ClientID %>");
        alert(objfile.val);
        objTextBox.val = objfile.val;
    }


    function setHiddenValue() {
        document.getElementById("<%= Hidden1.ClientID %>").value = document.getElementById("<%=FileUpload1.ClientID %>").value;
    }
    </script>
     <input id="Hidden1" type="hidden" runat="server" />
  <input runat="server" onchange="setHiddenValue()" id="File1" type="file" style=" visibility:hidden;" />
  <br />
  <br />
  <asp:Button ID="Button1" OnClientClick="fireFileClick()" runat="server" Text="ASPNET Button" />
  <input id="Text1" type="text" runat="server" />
  <br />
  <br />
  <input id="Button2" type="button" onclick="fireFileClick()" value="HTML Button" />
  <br />
  <br />
    </div>
    <asp:FileUpload ID="FileUpload1" runat="server" Visible="true" />

</asp:Content>

