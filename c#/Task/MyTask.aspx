<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="MyTask.aspx.cs" Inherits="MyTask" %>
<%@ Register TagPrefix="uc" TagName="TaskType" Src="UserControl/UserControlTaskType.ascx" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <style type="text/css">
        .content
        {
            width: 100%;
            margin: auto;
        }
        hr
        {
            border-top: 1px solid #ddd;
        }
        tr.border_bottom td
        {
            border-collapse: collapse;
            border-bottom: 1px dotted gray;
        }
        .rowClass tr:hover
        {
            background-color: #87CEEB;
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
    <div class="content">
        <p>
            <div style="text-align: right;">
                <uc:TaskType ID="ddlTaskType" runat="server" />
                &nbsp;&nbsp;
                <asp:Button ID="btnSearch" CssClass="btn-lit" runat="server" Text="Search" OnClick="btnSearch_Click" />
            </div>
        </p>
        <div style="float: left; margin-left: 5px; width: 559px;">
            <webdiyer:AspNetPager ID="AspNetPager1" runat="server" PageSize="30" AlwaysShow="false"
                OnPageChanged="AspNetPager1_PageChanged" ShowCustomInfoSection="Left" CustomInfoSectionWidth="40%"
                ShowPageIndexBox="always" PageIndexBoxType="DropDownList" CustomInfoHTML="Page %currentPageIndex% of<b> %PageCount% </b>; each page:%PageSize%">
            </webdiyer:AspNetPager>
        </div>
        <br />
        <br />
        <div>
            <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Repeater1_ItemCommand">
                <HeaderTemplate>
                    <table width="100%" cellpadding="1" cellspacing="0" border="0" class="rowClass">
                        <tr style="background-color: #EFEFDA; height: 25px; font-weight: bold;">
                            <td width="500px">
                                Title<asp:LinkButton ID="linkTitle" CommandName="Sort" CommandArgument="Title" runat="server"
                                    Font-Size="12px" ForeColor="blue">(Sort)</asp:LinkButton>
                            </td>
                            <td width="200px">
                                Time<asp:LinkButton ID="linkTime" CommandName="Sort" CommandArgument="CreateTime"
                                    runat="server" Font-Size="12px" ForeColor="blue">(Sort)</asp:LinkButton>
                            </td>
                            <td width="200px">
                                Type<asp:LinkButton ID="linkStatus" CommandName="Sort" CommandArgument="Status"
                                    runat="server" Font-Size="12px" ForeColor="blue">(Sort)</asp:LinkButton>
                            </td>
                        </tr>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr class="border_bottom" height="30px">
                        <td width="500px">
                            <a href='ShowTask.aspx?TaskID=<%#Eval("ID") %>'>
                                <%# Eval("Title").ToString().Length > 70 ? Eval("Title").ToString().Substring(0, 70) + "..." : Eval("Title").ToString()%></a>
                        </td>
                        <td width="200px">
                            <asp:Label runat="server" ID="Label2" Text='<%# Eval("CreateTime","{0:d}") %>' />
                        </td>
                        <td width="200px">
                            <asp:Label runat="server" ID="Label1" Text='<%# Eval("TypeName") %>' />
                        </td>
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                    </table>
                </FooterTemplate>
            </asp:Repeater>
        </div>
    </div>
</asp:Content>
