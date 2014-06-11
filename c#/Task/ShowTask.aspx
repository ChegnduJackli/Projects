<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="ShowTask.aspx.cs" Inherits="ShowTask" %>

<%@ Register TagPrefix="ucProcess" TagName="ProcessType" Src="UserControl/UserControlProcessType.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <style type="text/css">
        hr
        {
            border-top: 1px solid #ddd;
        }
    </style>
    <script src="Scripts/jquery-1.4.1.min.js" type="text/javascript"></script>
    <script type="text/javascript">


        $(function () {
            //to submit commet

            LoadComment();



            // $('#btnSubmit').click(function () {
            $('#<%=btnSubmit.ClientID %>').click(function () {
                var taskID = $('#<%=hidID.ClientID %>').val();
                var content = $('#<%=txtComment.ClientID %>').val().replace(/\r|\n/g, '<br />');
                if (content.length == 0) {
                    //$('#cmtMsg').html("Comment connot be empty.");
                    $('#cmtMsg').css('color', 'red').html('Comment cannot be empty').show();
                    return false;
                }
                // var tab = '<table width="100%" cellpadding="1" cellspacing="0" border="0">';
                var tabHeader = '<tr style="background-color: #ddd; padding-top: 5px;">';
                var tabCont = '<tr style="height: 30px; overflow: auto;">';
                var trEnd = '</tr>';
                var tdEnd = '</td>';
                //   var tabEnd = '</table>'
                var tabHtml = '';
                $.ajax({
                    url: "Handler/CommentHandler.ashx",
                    type: "Get",
                    data: { "Type": "AddComment", "taskID": taskID, "Content": content },
                    dataType: "html", //server side return html 
                    async: true,
                    success: function (htmlData) {
                        if (htmlData =='false') {
                            $('#cmtMsg').css('color', 'red').html('Login in first').show();
                            return false;
                        }
                        $('#<%=txtComment.ClientID %>').val('').focus();
                        $('#cmtMsg').css("color", "blue").html("submit successfully").show().fadeOut(1800);

                        //                        $.each(data, function (i, d) {
                        //                            var datePar = new Date(parseInt(d.ReplyTime.replace(/\/+Date\(([\d+-]+)\)\/+/, '$1')));
                        //                            var header = tabHeader + '<td align="left">'+'#'+d.ID+' '+ d.userID + '</td><td align="right">' + datePar + '</td>' + trEnd;
                        //                            var cont = tabCont + '<td colspan="2">' + d.Content + '</td>' + trEnd;
                        //                            cont += tabCont + '<td colspan="2" align="right"><a href="#" onclick="return deleteRow(' + d.ID + ')">delete</a></td>' + trEnd;
                        //                            tabHtml += header + cont;
                        //                        });
                        //                        //tabHtml = tabHtml + tabEnd;
                        //                        $('#content').append(tabHtml);
                        $('#Maincontent').html(htmlData);
                    },
                    failure: function (data) {
                        $('#cmtMsg').html("Server is busy,hold on.");
                    }

                });
                return false; //no refresh

            });

        });
    </script>
    <script type="text/javascript">
        function deleteRow(ID) {
            if (parseInt(ID) <= 0) return false;

            $.ajax({
                url: "Handler/CommentHandler.ashx",
                type: "Get",
                async: true,
                dataType: "json", //server side return html 
                data: { "Type": "DeleteComment", "ID": ID },
                success: function (data) {
                    LoadComment();
                }
            });
            return false;
        }
      
        function NotRefresh() {
            var fileValue = document.getElementById("<%=linkAttachment.ClientID%>").innerHTML;
            if (fileValue.trim() === "No Attachment") {
                return false;
            }
            else {
                return true;
            }
            return false;
        }
        function LoadComment() {
            var taskID = $('#<%=hidID.ClientID %>').val();
            $('#loadComment').show();
            $.ajax({
                url: "Handler/CommentHandler.ashx",
                type: "Get",
                data: { "Type": "AllComment", "taskID": taskID },
                dataType: "html",//server side return html 
                async: true,
                success: function (htmlData) {
                    $('#Maincontent').html(htmlData);
                    $('#loadComment').hide();
                },
                failure: function (data) {
                    $('#cmtMsg').html("Server is busy,hold on.");
                }

            });
        }

    </script>
    <div style="height: auto;">
        <table width="100%" align="center">
            <tr align="center">
                <td>
                    <asp:Label ID="lblTitle" runat="server" Text="Label" Font-Bold="true" Font-Size="Medium"></asp:Label>
                </td>
            </tr>
        </table>
        <hr />
        <table style="width: auto; text-align: left; font-size: 12px;" align="center" cellpadding="1"
            cellspacing="4" border="0">
            <tr align="center" style="text-align: left;">
                <td>
                    Author:
                </td>
                <td>
                    <asp:Label ID="lblAuthor" runat="server" Text="Label"></asp:Label>
                </td>
                <td>
                    Create Time:
                </td>
                <td>
                    <asp:Label ID="lblCreateTime" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
            <tr align="center" style="text-align: left;">
                <td>
                    <asp:Label ID="lblStatusMessage" runat="server" Text="Status:"></asp:Label>
                </td>
                <td align="left">
                    <asp:Label ID="lblStatus" runat="server" Text="Label"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblCompleteTime" runat="server" Text=" Complete Time:"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblComTime" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
        </table>
        <div style="float: right; margin-right: 10px;">
            font size:<a href="#" id="fontSmall">
                <img src="Image/mg_minus.jpg" alt="Decrease font size" /></a> <a href="#" id="fontBig">
                    <img src="Image/mg_plus.jpg" alt="Increase font size" /></a>
        </div>
        <table width="100%" align="center" cellpadding="0" cellspacing="0">
            <tr>
                <td id='txtContent'>
                    <asp:Label ID="lblContent" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
        </table>
        <hr />
        <div style="float: left">
            Attachment: &nbsp; &nbsp;
            <asp:LinkButton ID="linkAttachment" OnClientClick="javascript:return NotRefresh();"
                Font-Underline="true" runat="server" OnClick="linkAttachment_Click">No Attachment</asp:LinkButton>
        </div>
        <div style="float: right">
            <asp:Panel ID="Panel1" runat="server">
                Mark to:&nbsp;
                <ucProcess:ProcessType ID="ddlProcessType" runat="server" />
                <asp:LinkButton runat="server" ID="linkConfirm" OnClientClick="javascript:return confirm('Are you sure to change status?');"
                    OnClick="linkConfirm_Click">Confirm</asp:LinkButton>
                &nbsp; &nbsp;
                <asp:LinkButton ID="linkEdit" runat="server" OnClick="linkEdit_Click">Edit</asp:LinkButton>
                &nbsp;&nbsp;
                <asp:LinkButton runat="server" ID="linkDel" OnClientClick="javascript:return confirm('Are you sure to delete this task?');"
                    OnClick="linkDel_Click">Delete</asp:LinkButton>
            </asp:Panel>
        </div>
        <asp:HiddenField ID="hidID" runat="server" />
        <asp:HiddenField ID="hidTaskUser" runat="server" />
        <asp:HiddenField ID="hidTypeID" runat="server" />
        <br />
        <br />
        <div style="float: left;">
            <b>Commet list:</b><br />
       
        </div>
           <br />
             <span id="loadComment" style="display:none">Load Comment,hold on...</span>
    
        <div id="Maincontent">
            <%--  <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Repeater1_ItemCommand"
                OnItemDataBound="Repeater1_ItemDataBound">
                <HeaderTemplate>
                    <table width="100%" cellpadding="1" cellspacing="0" border="0">
                </HeaderTemplate>
                <ItemTemplate>
                    <tr style="background-color: #ddd; padding-top: 5px;">
                        <td align="left">
                            #<%# Container.ItemIndex + 1 %><asp:Label runat="server" ID="lblUser" Text='<%# Eval("UserID") %>' />
                        </td>
                        <td align="right">
                            <asp:Label runat="server" ID="Label2" Text='<%# Eval("replyTime") %>' />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <%#Eval("Content")%>
                            </a>
                        </td>
                    </tr>
                    <tr style="height: 20px; overflow: auto;">
                        <asp:Panel ID="Panel1" runat="server" Visible="false">
                            <td colspan="2" align="right">
                                <asp:LinkButton runat="server" ID="linkDel" CommandName="Delete" CommandArgument='<%# Eval("ID") %>'
                                    OnClientClick="javascript:return confirm('Are you sure to Delete this?');">Delete</asp:LinkButton>
                            </td>
                        </asp:Panel>
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                    </table>
                </FooterTemplate>
            </asp:Repeater>--%>
        </div>
        <hr />
        <table width="100%" align="left" cellpadding="1" cellspacing="2">
            <tr>
                <td>
                    <b>Add comments: </b>
                </td>
            </tr>
            <tr>
                <td>
                    <%--      <asp:TextBox ID="txtComment" name="content" runat="server" TextMode="MultiLine"></asp:TextBox>--%>
                    <asp:TextBox ID="txtComment" runat="server" TextMode="MultiLine" Style="width: 400px;
                        height: 100px;"></asp:TextBox>
                    <span id="cmtMsg" style="color: Red;"></span>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="btnSubmit" CssClass="btn-lit" runat="server" Text="Submit" Style="cursor: pointer" />
                    <%--                   <input id='btnSubmit' type="button" class="btn-lit" value="Submit" style="cursor:pointer" />--%>
                </td>
            </tr>
        </table>
        <br />
        <br />
    </div>
</asp:Content>
