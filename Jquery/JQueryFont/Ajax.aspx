<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="Ajax.aspx.cs" Inherits="Ajax" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
<asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true">
</asp:ScriptManager>
    <script src="Scripts/jquery-1.4.1.min.js" type="text/javascript"></script>
    <script language="javaScript" type="text/javascript" src="Scripts/common.js"></script>
    <style>
        #myBlockingDiv
        {
            color: #fff;
            background: #000;
            position: fixed;
            width: 100%;
            height: 100%;
            filter: alpha(opacity=85);
            opacity: .80;
            -ms-filter: "progid:DXImageTransform.Microsoft.Alpha(Opacity=85)"; /*--IE 8 Transparency--*/
            left: 0;
            top: 0;
            z-index: 10;
        }
        
        *html #myBlockingDiv
        {
            position: absolute;
            top: expression(eval(document.compatMode && document.compatMode==   'CSS1Compat' ) ? documentElement.scrollTop : document.body.scrollTop);
            height: expression(eval(document.compatMode && document.compatMode==   'CSS1Compat' ) ? documentElement.clientHeight : document.body.clientHeight);
        }
    </style>
    <script type='text/javascript' language='javascript'>
//        var req;
//        function SendRequest() {
//            if (navigator.appName == 'Microsoft Internet Explorer')
//                req = new ActiveXObject('Microsoft.XMLHTTP');
//            else req = new XMLHttpRequest();
//            var url = 'Handler.ashx';
//            req.onreadystatechange = function () {
//                if (req.readyState == 4 && req.status == 200) {
//                    if (req.responseText == 'Y') {
//                        stopTimer();
//                        window.location.href = 'Default.aspx';
//                    }
//                }
//            };
//            req.open('GET', url, true);
//            req.send(null);
//        }
//        var timer = '';
//        function startTimer() {
//            timer = window.setInterval('SendRequest()', 2500);
//            // window.setInterval('SendRequest()', 2000);
//        }
//        function stopTimer() {
//            window.clearInterval(timer);
//            timer = '';
//        }

//        function BlockPageEdit() {

//            var newdiv = document.createElement('div');
//            var divIdName = 'myBlockingDiv';
//            newdiv.setAttribute('id', divIdName);
//            newdiv.setAttribute('z-index', 2000);
//            newdiv.innerHTML = '<br/>&nbsp;&nbsp;&nbsp;&nbsp;Retrieve data... Please wait...&nbsp; <img src = "Images/loading.gif"/>';
//            document.body.appendChild(newdiv);
//        }

//        window.onload = function () {
//            BlockPageEdit();
//            startTimer();
//        };
        
    </script>
    <asp:Button ID="Button1" runat="server" Text="开始" OnClick="Button1_Click" />
    <asp:Label ID="lblBatchInvoiceScript" runat="server" Text=""></asp:Label>
</asp:Content>
