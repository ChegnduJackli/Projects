<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="Default.aspx.cs" Inherits="_Default" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<%@ Register TagPrefix="uc" TagName="TaskType" Src="UserControl/UserControlTaskType.ascx" %>
<%@ Register TagPrefix="ucProcess" TagName="ProcessType" Src="UserControl/UserControlProcessType.ascx" %>
<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <script src="Scripts/jquery-1.4.1.min.js" type="text/javascript"></script>
    <script type="text/javascript">
        function ChangeProcessType() {
            //MainContent_ddlTaskType_ddlStatus
            //MainContent_ddlProcessType_ddlStatus
            var typeStatus = document.getElementById('MainContent_ddlTaskType_ddlStatus');
            if (typeStatus.options[typeStatus.selectedIndex].value != "1") {
                var processStatus = document.getElementById('MainContent_ddlProcessType_ddlStatus');
                processStatus.disabled = true;
            }

        }
    </script>
    <style type="text/css">
        .content
        {
            width: 100%;
            margin: auto;
        }
        a:link
        {
            text-decoration: none;
            color: #000;
        }
        /* visited link */
        a:hover
        {
            color: #0000FF;
            text-decoration: underline;
        }
    </style>
    <h2>
    </h2>
    <p>
        <div style="text-align: right">
            <%--   <asp:DropDownList ID="ddlStatus" runat="server">
            </asp:DropDownList>--%>'
            <table align="right">
                <tr>
                    <td>
                        Type:
                    </td>
                    <td>
                        <uc:TaskType ID="ddlTaskType" runat="server" />
                    </td>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td>
                        Processing:
                    </td>
                    <td>
                        <ucProcess:ProcessType ID="ddlProcessType" runat="server" />
                    </td>
                    <td>
                        <asp:Button ID="btnSearch" CssClass="btn-lit" runat="server" Text="Search" OnClick="btnSearch_Click" />
                    </td>
                </tr>
            </table>
        </div>
    </p>
    <div style="float: left; margin-left: 5px; width: 559px;">
        <webdiyer:AspNetPager ID="AspNetPager1" runat="server" PageSize="12" AlwaysShow="false"
            OnPageChanged="AspNetPager1_PageChanged" ShowCustomInfoSection="Left" CustomInfoSectionWidth="40%"
            ShowPageIndexBox="always" PageIndexBoxType="DropDownList" CustomInfoHTML="Page %currentPageIndex% of<b> %PageCount% </b>; each page:%PageSize%">
        </webdiyer:AspNetPager>
    </div>
    <br />
    <br />
    <div class="content">
        <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Repeater1_ItemCommand"
            OnItemDataBound="Repeater1_ItemDataBound">
            <HeaderTemplate>
                <table width="100%" cellpadding="1" cellspacing="0" border="0">
            </HeaderTemplate>
            <ItemTemplate>
                <tr style="font-size: 16px; background-color: #EFEFDA">
                    <td align="left">
                        #<%# Container.ItemIndex + 1 %>&nbsp;<a href="#"><asp:Label runat="server" ID="lblUser"
                            Text='<%# Eval("userid") %>' /></a>
                    </td>
                    <td align="right">
                        <asp:Label runat="server" ID="Label2" Text='<%# Eval("CreateTime") %>' />
                    </td>
                </tr>
                <tr>
                    <td colspan="2" height="50px">
                        <a href='ShowTask.aspx?TaskID=<%#Eval("ID") %>'>
                            <%# Eval("Title").ToString().Length > 70 ? Eval("Title").ToString().Substring(0, 70) + "..." : Eval("Title").ToString()%></a>
                    </td>
                </tr>
                <tr>
                    <td align="left">
                        Type: &nbsp;
                        <asp:Label ID="lblType" runat="server" Font-Size="12px" Font-Bold="true" Text='<%# Eval("TypeName") %>'></asp:Label>
                     
                    </td>
                    <asp:Panel ID="Panel1" runat="server">
                        <td align="right">
                          &nbsp; &nbsp; 
                        <asp:Label ID="lblStatus" runat="server" Font-Size="12px" Font-Bold="true" Text='Status:'></asp:Label>
                        <asp:Label ID="lblProcessStatus" runat="server" Font-Size="12px" Font-Bold="true" Text='<%# Eval("ProcessTypeName") %>'></asp:Label>
                         <%--   Mark to:&nbsp;
                            <asp:DropDownList ID="ddlTaskStatus" runat="server">
                            </asp:DropDownList>
                            &nbsp;
                            <asp:LinkButton runat="server" ID="linkConfirm" CommandName="Confirm" CommandArgument='<%# Eval("ID") %>'
                                OnClientClick="javascript:return confirm('Are you sure to change status?');">Confirm</asp:LinkButton>
                            &nbsp; <a href='TaskDetails.aspx?TaskID=<%#Eval("ID") %>'>Edit</a> &nbsp;
                            <%--      <asp:HyperLink ID="HyperLink1" runat="server" Text="Edit" NavigateUrl='TaskDetails.aspx?TaskID=<%#Eval("ID") %>' />--%>
                          <%--  <asp:LinkButton runat="server" ID="linkDel" CommandName="Delete" CommandArgument='<%# Eval("ID") %>'
                                OnClientClick="javascript:return confirm('Are you sure to Delete this task?');">Delete</asp:LinkButton>--%>
                        </td>
                    </asp:Panel>
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                </table>
            </FooterTemplate>
        </asp:Repeater>
    </div>
    <br />
    <div style="float: left; margin-left: 5px; width: 559px;">
        <webdiyer:AspNetPager ID="AspNetPager2" runat="server" CloneFrom="AspNetPager1">
        </webdiyer:AspNetPager>
    </div>
</asp:Content>
