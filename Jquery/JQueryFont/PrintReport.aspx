<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="PrintReport.aspx.cs" Inherits="PrintReport" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <asp:ScriptManager ID="ScriptManager2" runat="server">
      </asp:ScriptManager>
    <rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" 
    Font-Size="8pt" InteractiveDeviceInfos="(Collection)" 
    WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt">
        <LocalReport ReportPath="Report.rdlc">
            <DataSources>
      <%--          <rsweb:ReportDataSource DataSourceId="ObjectDataSource1" Name="DataSet1" />
                <rsweb:ReportDataSource DataSourceId="ObjectDataSource2" Name="DataSet2" />--%>
            </DataSources>

        </LocalReport>
    </rsweb:ReportViewer>
<%--
    <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" 
    TypeName="DataSetLineTableAdapters."></asp:ObjectDataSource>
<asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
    TypeName="DataSet1TableAdapters."></asp:ObjectDataSource>--%>

    <asp:Button ID="btnPrintReport" runat="server" Text="Print report" 
        onclick="btnPrintReport_Click" />
          
</asp:Content>

