<%@ Page Language="C#" AutoEventWireup="true" CodeFile="RunScript.aspx.cs" Inherits="RunScript"  %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Run Script page</title>
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
        body
        {
            /*background : #b6b7bc;*/
            font-size: .80em;
            font-family: "Helvetica Neue" , "Lucida Grande" , "Segoe UI" , Arial, Helvetica, Verdana, sans-serif;
            margin: 0px;
            padding: 0px;
            color: #696969;
            background-image: url("../Image/blue.png");
            background-repeat: repeat;
        }
        
        .btn-lit
        {
            /* background-image:url(../Image/sea.jpg) ;
    background-repeat:no-repeat;*/
            color: White;
            border: 0px;
            background: #4b6c9e;
            padding: 4px;
            cursor: pointer;
            font-weight: bold;
        }
        .btn-lit:hover
        {
            color: yellow;
        }
        #GridView1 tr:hover td
        {
            background: #F2CA6A;
        }
        #GridView1 tr:nth-child(even)
        {
            font-family: Arial, Helvetica, sans-serif;
            font-size: 11px;
            font-weight: normal;
            color: #000000;
            background-color: #E6E7E8;
            text-indent: 1px;
            height: 20px;
        }
        
        .GridRow1
        {
            font-family: Arial, Helvetica, sans-serif;
            font-size: 11px;
            font-weight: normal;
            color: #000000;
            background-color: #FFFFFF;
            text-indent: 1px;
            height: 20px;
        }
        .tableHeader
        {
            font-family: Arial, Helvetica, sans-serif;
            font-size: 11px;
            font-weight: bold;
            color: #000000;
            background-color: #F2CA6A;
            height: 25px;
            text-align: left;
            vertical-align: middle;
        }
        .txtbox
        {
            -webkit-border-radius: 5px;
            -moz-border-radius: 5px;
            border-radius: 5px;
            background-color: #D7EFFF;
            border: 1px solid #6297BC;
            outline: none;
            padding: 2px 2px;
            color: #333333;
            padding: 3px;
            margin-right: 4px;
            margin-bottom: 8px;
            font-family: tahoma, arial, sans-serif;
        }
        
    </style>
    <script type="text/javascript">
     
        function Submit() {
            var ddlReport = document.getElementById("<%=DropDownList1.ClientID%>");

            var Text = ddlReport.options[ddlReport.selectedIndex].text;
            if (Text != 'Batch') {
                var sql = document.getElementById("<%=txtContent.ClientID%>").value;
                if (sql.length == 0) {
                    return false;
                }
            }

            if (Text == 'Batch') {
                var fileupload = document.getElementById("<%=FileUpload1.ClientID%>").value;
                if (fileupload.length == 0) {
                    return false;
                }
            }
            if (Text != 'Query') {
                return confirm('Are you sure to submit?');
            }
            else {
                return true;
            }
        }
       

    </script>
</head>
<body>
    <form id="form1" runat="server">
      <input type="hidden" id="txtboxValue" />
    <div style="width: 800px; margin: auto; font-weight: bold; font-size: 16px;">
        Run Select ,Insert,Update,Delete, file(.sql) scripts
       
    </div>
    <table class="tableborder" cellpadding="5" cellspacing="10">
        <tr>
            <td class="style1">
                Type:
            </td>
            <td>
                <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="true" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
                </asp:DropDownList>
            </td>
        </tr>
        <asp:Panel ID="paneScripts" runat="server">
            <tr>
                <td class="style1">
                    Script:
                </td>
                <td>
                    <asp:TextBox ID="txtContent" runat="server" TextMode="MultiLine" CssClass="txtbox"
                       Style="width: 620px; height: 300px;"></asp:TextBox>
                </td>
            </tr>
        </asp:Panel>
        <asp:Panel ID="panelFile" runat="server">
            <tr>
                <td class="style">
                    file:
                </td>
                <td>
                    <asp:FileUpload ID="FileUpload1" runat="server" />
                </td>
            </tr>
        </asp:Panel>
        <tr>
            <td class="style1">
            </td>
            <td>
                <div style="display:table-cell">
                    <div style="display:inline-block">
                        <asp:Button ID="btnRun" CssClass="btn-lit" runat="server" OnClientClick='return Submit();'
                            Text="Run Script" OnClick="btnRun_Click" /></div>
                    <div style="display:inline-block; padding-left:500px">
                        <asp:Button ID="btnReset" CssClass="btn-lit" runat="server" Text="Clear" OnClick="btnReset_Click" /></div>
                </div>
            
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td>
                <asp:Label ID="lblMsg" runat="server" Text="" ForeColor="Blue"></asp:Label>
            </td>
        </tr>
    </table>
    <br />
    <asp:Panel ID="panelResults" runat="server">
        <div style="width: 800px; margin: auto; overflow: auto;">
            <h3>
                Query Results:</h3>
        </div>
        <table class="tableborder" cellpadding="5" cellspacing="10">
            <tr>
                <td>
                    Show Items:
                    <asp:DropDownList ID="ddlItems" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlItems_SelectedIndexChanged">
                    </asp:DropDownList>
                </td>
                <td>
                    Export to Excel:
                    <asp:ImageButton ID="imgExcel" runat="server" Height="19px" ImageUrl="~/Images/excel.gif"
                        OnClick="imgExcel_Click" ToolTip="Export to Excel" Width="19px" />&nbsp;
                </td>
            </tr>
        </table>
    </asp:Panel>
    <br />
    <div style="width: 80%; margin: auto; overflow: auto;">
        <asp:GridView ID="GridView1" runat="server" Width="100%" CssClass="GridRow1" HeaderStyle-CssClass="tableHeader"
            AllowPaging="true" PageSize="20" OnPageIndexChanging="GridView1_PageIndexChanging">
        </asp:GridView>
    </div>
    <br />
    <br />
    <br />
    </form>
</body>
</html>
