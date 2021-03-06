﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    ValidateRequest="false" CodeFile="TaskDetails.aspx.cs" Inherits="TaskDetails" %>
    <%@ Register TagPrefix="ucProcess" TagName="ProcessType" Src="UserControl/UserControlProcessType.ascx" %>
    <%@ Register TagPrefix="uc" TagName="TaskType" Src="UserControl/UserControlTaskType.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <script src="kindeditor-4.1.10/kindeditor.js" type="text/javascript"></script>
    <script src="kindeditor-4.1.10/lang/zh_CN.js" type="text/javascript"></script>
    <script src="kindeditor-4.1.10/lang/en.js" type="text/javascript"></script>
    <link href="kindeditor-4.1.10/plugins/code/prettify.css" rel="stylesheet" type="text/css" />
    <script src="kindeditor-4.1.10/plugins/code/prettify.js" type="text/javascript"></script>
    <script src="kindeditor-4.1.10/plugins/code/code.js" type="text/javascript"></script>
    <script type="text/javascript">
        KindEditor.ready(function (K) {

            editor = K.create('textarea', {
                allowImageUpload: true,
                uploadJson: 'kindeditor-4.1.10/asp.net/upload_json.ashx',
                fileManagerJson: 'kindeditor-4.1.10/asp.net/file_manager_json.ashx',

                //上传文件后执行的回调函数,获取上传图片的路径
                afterUpload: function (url) {

                },
                langType: 'en',
				 newlineTag: "br",
                //编辑器高度
                width: '700px',
                //编辑器宽度
                height: '350px;'
            });

        });

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
    </script>
    <style>
        .style1
        {
            width: 123px;
        }
        .tableborder
        {
            border: 0px;
            border-collapse: collapse;
            margin: auto;
            width: 800px;
        }
        .tableborder td
        {
            border-top: 1px #666 solid;
            border-right: 1px #666 solid;
        }
        .tableborder
        {
            border-bottom: 1px #666 solid;
            border-left: 1px #666 solid;
        }
    </style>
    <div>
        <asp:HiddenField ID="hidID" runat="server" />
        <table class="tableborder" cellpadding="5" cellspacing="10">
            <tr>
                <td class="style1">
                    Title:
                </td>
                <td>
                    <asp:TextBox ID="txtTitle" runat="server" Width="485px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style1">
                    Create time:
                </td>
                <td>
                    <asp:Label ID="lblCreateTime" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style1">
                    Complete Time:
                </td>
                <td>
                    <asp:Label ID="lblComTime" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
             <tr>
                <td class="style1">
                    Type:
                </td>
                <td>
                  <%--    <uc:TaskType ID="ddlTaskType" runat="server" />--%>
                  <asp:DropDownList ID="ddlTaskType"
                      runat="server">
                  </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="style1">
                    Process:
                </td>
                <td>
                   <%--   <ucProcess:ProcessType ID="ddlProcessType" runat="server" />--%>
                          <asp:DropDownList ID="ddlProcessType"
                      runat="server">
                  </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="style1">
                    Task Details:
                </td>
                <td>
                    <asp:TextBox ID="txtDetails" runat="server" TextMode="MultiLine"></asp:TextBox>
                </td>
            </tr>
            <tr>
              <td >
              Attachment:
            </td>
            <td>
                <asp:FileUpload ID="FileUpload1" runat="server" />
            </td>
            </tr>
            <tr>
                <td class="style1">
                    Attachment
                </td>
                <td>
                    <asp:LinkButton ID="linkAttachment" OnClientClick="javascript:return NotRefresh();"
                        runat="server" OnClick="linkAttachment_Click">No Attachment</asp:LinkButton>
                        &nbsp;&nbsp;&nbsp;&nbsp;<asp:LinkButton ID="linDelete" Visible="false" 
                        runat="server" onclick="linDelete_Click" OnClientClick="return confirm('Are you sure to delete this?')">Delete</asp:LinkButton>
                </td>
            </tr>
            <tr>
                <td class="style1">
                </td>
                <td>
                    <a href="Default.aspx">return to menu</a> &nbsp;&nbsp;
                    <asp:Button ID="btnOK" runat="server" Style="cursor: pointer" Text="Submit" OnClientClick="javascript:return confirm('Are you sure to submit ?')"
                        OnClick="btnOK_Click" />
                    &nbsp;&nbsp;
                    <asp:Button ID="btnDelete" runat="server" Style="cursor: pointer" Text="Delete Task"
                        OnClick="btnDelete_Click" OnClientClick="return confirm('Are you sure to delete this?')" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
