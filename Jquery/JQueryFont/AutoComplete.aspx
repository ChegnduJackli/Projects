<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="AutoComplete.aspx.cs" Inherits="AutoComplete" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">


    <asp:TextBox ID="txtCity" runat="server"></asp:TextBox>
   <div id="ShowDataDiv" class="showDataDivStyle" title="txtCity">


</div>

<script type="text/javascript" language="javascript">
    //获取当前文档中Head标记
    var head = document.getElementsByTagName("head")[0];
    //创建一个script标记
    var script = document.createElement("script");
    //设置相关属性
    script.src = "Scripts/MacacoJSTools.js";
    script.type = "text/javascript";
    //追加到Head开始标记之后结束标记之前的位置
    head.appendChild(script);
    </script>


</asp:Content>

