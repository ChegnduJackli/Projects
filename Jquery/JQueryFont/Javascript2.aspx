<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="Javascript2.aspx.cs" Inherits="Javascript2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <script src="Scripts/jquery-1.4.1.min.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $('#btnregister').click(function () {
                alert("Click");
                var obj = { username: $("#txtuser").val(), name: $("#txtname").val() };
                $.ajax({
                    type: "POST",
                    contentType: "application/json",
                    url: "Javascript2.aspx/test",
                    //data: JSON.stringify(obj),
                  //  data: { "username": $("#txtuser").val(), "name": $("#txtname").val() },
                      dataType: "Text",
                    success: function (data) {
                        alert("Successfully register");
                        alert(data);
                    },
                    error: function (msg)
                    { alert("error"+msg); }
                });
            });
        });
    </script>
    <input type="text" id="txtuser" />
    <input type="text" id="txtname" />
    <input type="button" id="btnregister" value="caclute" />
</asp:Content>
