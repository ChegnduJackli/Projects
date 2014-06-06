<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="ShowTask_Bak.aspx.cs" Inherits="ShowTask_Bak" %>

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
    <script src="kindeditor-4.1.10/kindeditor-min.js" type="text/javascript"></script>
    <script src="Scripts/CommonValidate.js" type="text/javascript"></script>
    <script src="kindeditor-4.1.10/lang/zh_CN.js" type="text/javascript"></script>
<%--    <script type="text/javascript">

        $(document).ready(function () {


            var defaultSize = $('#txtContent').css('font-size');

            $('#fontReset').click(function () {
                $('#txtContent').css('font-size', defaultSize);
                return false;
            });

            $('#fontSmall').click(function () {
                var currentFontSize = $('#txtContent').css('font-size');
                var currentFontSizeNum = parseFloat(currentFontSize, 10);
                var newFontSize = currentFontSizeNum * 0.8;
                $('#txtContent').css('font-size', newFontSize);
                return false;
            });

            $('#fontBig').click(function () {

                var currentFontSize = $('#txtContent').css('font-size');
                var currentFontSizeNum = parseFloat(currentFontSize, 10);
                var newFontSize = currentFontSizeNum * 1.2;
                $('#txtContent').css('font-size', newFontSize);
                return false;
            });

        });
    </script>
    <script>
        KindEditor.ready(function (K) {
            K.each({
                'plug-align': {
                    name: '对齐方式',
                    method: {
                        'justifyleft': '左对齐',
                        'justifycenter': '居中对齐',
                        'justifyright': '右对齐'
                    }
                },
                'plug-order': {
                    name: '编号',
                    method: {
                        'insertorderedlist': '数字编号',
                        'insertunorderedlist': '项目编号'
                    }
                },
                'plug-indent': {
                    name: '缩进',
                    method: {
                        'indent': '向右缩进',
                        'outdent': '向左缩进'
                    }
                }
            }, function (pluginName, pluginData) {
                var lang = {};
                lang[pluginName] = pluginData.name;
                KindEditor.lang(lang);
                KindEditor.plugin(pluginName, function (K) {
                    var self = this;
                    self.clickToolbar(pluginName, function () {
                        var menu = self.createMenu({
                            name: pluginName,
                            width: pluginData.width || 100
                        });
                        K.each(pluginData.method, function (i, v) {
                            menu.addItem({
                                title: v,
                                checked: false,
                                iconClass: pluginName + '-' + i,
                                click: function () {
                                    self.exec(i).hideMenu();
                                }
                            });
                        })
                    });
                });
            });
            K.create('textarea', {
                themeType: 'qq',
                //编辑器宽度
                width: '600px',
                //编辑器高度
                height: '150px;',
                newlineTag: "br",
                langType: 'en',
                items: [
						'bold', 'italic', 'underline', 'fontname', 'fontsize', 'forecolor', 'hilitecolor', 'plug-align', 'plug-order', 'plug-indent', 'link'
					]
            });
        });
    </script>--%>
    <script type="text/javascript">

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
        function submit() {
            alert('df');
            var taskID = $('#<%=hidID.ClientID %>').val;
            var content = $('#<%=txtComment.ClientID %>').val;
            if (content.trim().length == 0) {
                $('#cmtMsg').html("Comment connot be empty.");
                return false;
            }
            return false;
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
            <b>Commet list:</b>
        </div>
        <br />
        <div class="content">
            <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Repeater1_ItemCommand"
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
            </asp:Repeater>
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
               <asp:TextBox ID="txtComment" runat="server" TextMode="MultiLine" style="width:400px; height:100px;"></asp:TextBox>
               <span id="cmtMsg" style="color:Red"></span>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="btnSubmit" CssClass="btn-lit" runat="server"  Text="Submit" Style="cursor: pointer"
                    />
                </td>
            </tr>
        </table>
        <br />
        <br />
    </div>
</asp:Content>
