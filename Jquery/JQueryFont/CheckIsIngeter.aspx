<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="CheckIsIngeter.aspx.cs" Inherits="CheckIsIngeter" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
<script>
//Function to allow only numeric values
    function CheckIntegers(obj) {
        // var strValue;
        if (obj != null) { strValue = obj.value; }
        var evt = e || event;
        var charCode = (evt.which) ? evt.which : evt.keyCode
        //currKey = e.keyCode || e.which || e.charCode;
        alert(charCode);
        if (charCode < 48 || charCode > 57) {charCode = null;}
//        if (charCode < 48 || charCode > 57) { return false; }
//        else
//        {return true;}
    }
function isNumberKey(evt) {
    var charCode = (evt.which) ? evt.which : event.keyCode
    return !(charCode > 31 && (charCode < 48 || charCode > 57));
}
function keyUsp(e) {
    var currKey = 0, e =e || event; 
    currKey = e.keyCode || e.which || e.charCode;

    if (currKey < 48 || currKey > 57) { return false; }
    else {
        return true;
    }
//    var keyName = String.fromCharCode(currKey);
    //    alert("按键码: " + currKey + " 字符: " + keyName);
    // onkeypress = "keyUp(this);"
    // onkeypress ="return keyUsp(event);" this is working 
}

</script>
    <asp:TextBox ID="TextBox1" runat="server" ></asp:TextBox>
</asp:Content>

