<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" ValidateRequest="false" 
    CodeFile="AddTask.aspx.cs" Inherits="AddTask" %>
<%@ Register TagPrefix="uc" TagName="TaskType" Src="UserControl/UserControlTaskType.ascx" %>
<%@ Register TagPrefix="ucProcess" TagName="ProcessType" Src="UserControl/UserControlProcessType.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
 <script src="kindeditor-4.1.10/kindeditor.js" type="text/javascript"></script>
    <script src="kindeditor-4.1.10/lang/en.js" type="text/javascript"></script>
    <link href="kindeditor-4.1.10/plugins/code/prettify.css" rel="stylesheet" type="text/css" />
    <script src="kindeditor-4.1.10/plugins/code/prettify.js" type="text/javascript"></script>
	<script src="kindeditor-4.1.10/plugins/code/code.js" type="text/javascript"></script>
    <script src="Scripts/jquery-1.4.1-vsdoc.js" type="text/javascript"></script>
    <script src="Scripts/CommonValidate.js" type="text/javascript"></script>
    <script type="text/javascript">
        KindEditor.ready(function (K) {

            editor = K.create('textarea', {
                allowImageUpload: true,
                uploadJson: 'kindeditor-4.1.10/asp.net/upload_json.ashx',
                fileManagerJson: 'kindeditor-4.1.10/asp.net/file_manager_json.ashx',

                //上传文件后执行的回调函数,获取上传图片的路径
                afterUpload: function (url) {

                },
                afterCreate: function () {
                  
                   // var html = editor.html();
                    this.sync();
//                    html = document.getElementsByName('ctl00$MainContent$txtDetails').value;
//                    editor.html(html);

                },
                langType: 'en',
				newlineTag: 'br',

                //编辑器宽度
                width: '700px',
                //编辑器高度
                height: '350px;'
            });

        });

        $(document).ready(function () {
            $('#<%=btnOK.ClientID%>').click(function () {

                var result = true;
                var titleid = $('#<%=txtTitle.ClientID%>');
                if (titleid.IsEmpty()) {
                    result = false;
                    alert('Title cannot be empty');
                }

                if (result) {
//                    var details = document.getElementsByName('ctl00$MainContent$txtDetails').value;
//                    alert('details' + details);
//                    if (details == '') {
//                        result = false;
//                        alert('Details cannot be empty');
//                    }
                }
                if (result) {
                    if (confirm('Are you sure to submit?'))
                        result = true;
                    else
                        result = false;
                }
                return result;

            });
        });
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
            <%--   <tr>
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
            </tr>--%>
            <tr>
                <td class="style1">
                    Type:
                </td>
                <td>
                      <uc:TaskType ID="ddlTaskType" runat="server" />
                </td>
            </tr>
             <tr>
                <td class="style1">
                    Status:
                </td>
                <td>
                        <ucProcess:ProcessType ID="ddlProcessType" runat="server" />
                </td>
            </tr>
            <tr>
                <td class="style1">
                    Task Details:
                </td>
                <td>
         <%--           <asp:TextBox ID="txtDetails" runat="server" TextMode="MultiLine" Style="width: 550px;
                        height: 150px;"></asp:TextBox>--%>
                        <asp:TextBox ID="txtDetails" TextMode="MultiLine" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
              <td class="style1">
              Attachment:
            </td>
            <td>
                <asp:FileUpload ID="FileUpload1" runat="server" />
            </td>
            </tr>
            <%-- <tr>
              <td class="style1">
              Assign To:
            </td>
                 <td>
                 <div style="border:1px">
                     <table width="200px" cellpadding="3" cellspacing="3">
                         <tr>
                             <td>
                                 <asp:ListBox ID="listAllUser" runat="server"></asp:ListBox>
                             </td>
                             <td>
                                 <asp:Button ID="btnAddTouser" runat="server" Text=">>" />
                                 <br />
                                 <br />
                                 <asp:Button ID="btnRemoveFromUser" runat="server" Text="<<" />
                             </td>
                             <td>
                                 <asp:ListBox ID="listAssignUser" runat="server"></asp:ListBox>
                             </td>
                         </tr>
                     </table>
                     </div>
                 </td>
            </tr>--%>
            <tr>
                <td class="style1">
                </td>
                <td>
                    <a href="Default.aspx">return to menu</a> &nbsp;&nbsp;
                    <asp:Button ID="btnOK" runat="server" Style="cursor: pointer" Text="Submit" 
                        OnClick="btnOK_Click" CssClass="btn-lit" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
