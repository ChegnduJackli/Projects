<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="PopMessage.aspx.cs" Inherits="PopMessage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <style>
        .fileupload
        {
            position: relative;
            overflow: hidden;
            cursor: pointer;
            background-color: #79bbff;
        }
        .left
        {
            float: left;
        }
        .both
        {
            clear: both;
        }
        .file-upload-container
        {
            width: 400px;
            border: 1px solid #efefef;
            padding: 10px;
            border-radius: 6px;
            -webkit-border-radius: 6px;
            -moz-border-radius: 6px;
            background: #fbfbfa;
        }
        .file-upload-override-button
        {
            position: relative;
            overflow: hidden;
            cursor: pointer;
            background-color: #79bbff;
        }
        .file-upload-override-button:hover
        {
            background-color: #378de5;
        }
        .file-upload-override-button:active
        {
            position: relative;
            top: 1px;
        }
        .file-upload-button
        {
            position: absolute;
            height: 50px;
            top: -10px;
            left: -10px;
            cursor: pointer;
            opacity: 0;
            filter: alpha(opacity=0);
        }
        .file-upload-filename
        {
            margin-left: 10px;
            height: auto;
            padding: 8px;
        }
        .file_input_button
{
	width: 100px; 
	position: absolute; 
	top: 0px;
	background-color: #33BB00;
	color: #FFFFFF;
	border-style: solid;
}
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <script src="Scripts/jquery-1.4.1.min.js" type="text/javascript"></script>
    <script src="Scripts/ValidateLogin.js" type="text/javascript"></script>
    <asp:Button ID="btnPopup" runat="server" Text="Pop up" OnClick="btnPopup_Click" />
    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
    <asp:Panel ID="Panel1" runat="server" Visible="false">
        <div>
            <asp:Button ID="Button1" runat="server" Text="OK"></asp:Button>
            <asp:Button ID="Button2" runat="server" Text="cancel"></asp:Button>
        </div>
    </asp:Panel>
    <asp:LinkButton ID="HyperLink1" runat="server" Text="asdfadfasf"></asp:LinkButton>
    <asp:LinkButton ID="LinkButton1" runat="server" OnClientClick="return deleteConfirm();">Delete</asp:LinkButton>
    <script type="text/javascript">
        function deleteConfirm() {
            // var value = $('#<%=HyperLink1.ClientID %>').val;
            var value = document.getElementById("<%=HyperLink1.ClientID%>").innerHTML;
            // var value = $("#<%=HyperLink1.ClientID%>").val;
            alert(value);
        }
 
    </script>
    <br />
    <br />
    <div>
        <asp:FileUpload ID="FileUpload1" runat="server" CssClass="file_input_button"     />
    </div>
  <div>

      <asp:TextBox ID="TextBox1" runat="server" style="width: 128px"></asp:TextBox>
      <asp:Button ID="Button3" runat="server" Text="Button" 
          onclick="Button3_Click" />
    </div>
</asp:Content>
