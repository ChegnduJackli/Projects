<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="AddTable1.aspx.cs" Inherits="AddTable1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
<script type="text/javascript">
    var DudeNameSpace = {
        name: 'jeff',
        lastName: 'way',
        dosomething: function getname () { alert("do something"); }
    }

  
</script> 
<div>

</div>
   <table align="center" cellpadding="0" cellspacing="0" border="1" width="700px" >
    <tbody>
        <tr>
            <td>
                UserName
            </td>
            <td>
                Password
            </td>
            <td>
                Sex
            </td>
            <td>
                Number
            </td>
        </tr>
        <tr>
            <td align='left'>
                <input type='text' size='25' length='10' maxlength='254' width='10' id='txtName1'
                    name='txtName1' value='' />
            </td>
            <td align='left'>
                <input type='text' size='25' length='10' maxlength='254' width='10' id='txtPassword1'
                    name='txtPassword1' value='' />
            </td>
            <td align='left'>
                <input type='text' size='25' length='10' maxlength='254' width='10' id='txtSex1'
                    name='txtSex1' value='' />
            </td>
            <td align='left'>
                <input type='text' size='25' length='10' maxlength='254' width='10' id='txtNumber1'
                    name='txtNumber1' value='' />
            </td>
        </tr>
    </tbody>
</table>
</asp:Content>

