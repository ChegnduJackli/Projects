<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Reset.aspx.cs" Inherits="Reset" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <script src="Scripts/jquery-1.4.1.min.js" type="text/javascript"></script>
    <script type="text/javascript">

        $(document).ready(function () {
            function reset() {
                alert("cleare");
                $('#TextBox1').text('');
                $('#TextBox2').text('');
                $('#TextBox3').text('');
                $('#TextBox4').text('');
                return false;
            }
        });
    </script>
    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
    <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
    <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
    <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
    <asp:Button ID="Button1" runat="server" Text="Reset" OnClientClick="return reset();" />
    <script type="text/javascript">
        function People(name) {
            this.name = name;
            //对象方法  
            this.Introduce = function () {
                alert("My name is " + this.name);
            }
        }
        //类方法
        People.Run = function () {
            alert("I can run");
        }
        //原型方法
        People.prototype.IntroduceChinese = function () {
            alert("我的名字是" + this.name);
        }
  
        //测试  
        var p1=new People("Windking");  
        p1.Introduce();  
        People.Run();
        p1.IntroduceChinese();


//        var TransForm = function (obj, speed, moden, fn) {
//            this.obj = obj;
//            this.speed = speed;
//            this.mode = mode;   // 动画形式  
//            this.heightChange = 10;
//            this.fn = fn;
//            if (speed === 'fast')
//                this.speed = 10;
//            else if (speed === 'normal')
//                this.speed = 20;
//            else if (speed === 'slow')
//                this.speed = 30;
//        }

//        TransForm.prototype = {
        
        
       // }
    
    </script>
</asp:Content>


