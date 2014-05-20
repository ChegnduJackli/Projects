<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="KeepAlive.aspx.cs" Inherits="KeepAlive" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">

 <script  type="text/javascript">
     function ShowTimePassed() {
         var currentTime = new Date();
         answer = confirm("It is now " + currentTime.toLocaleTimeString() + " You have " + minutesBeforeLoggedOut + " minute left before getting logged out. Do you want to extend the session?");
         if (answer) {
             var img = new Image(1, 1);
             img.src = 'KeepAlive.aspx?date=' + escape(new Date());
         }
         else {
             document.location.href = "Index.aspx";
         }
     }
     window.setInterval('ShowTimePassed()', iTimeoutWarning);
</script>
</asp:Content>

