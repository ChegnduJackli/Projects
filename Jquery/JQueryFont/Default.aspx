<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">

    <script type="text/javascript">

Array.prototype.contains = function(k) {
    for(var p in this)
        if(this[p] === k)
            return true;
    return false;
}
    var emailArray = new Array("email1","email2","email3","email4");
    var ShowEmail =new Array();
    
    function addControl() {
        for (var i = 0; i < emailArray.length; i++) {
//            if (ShowEmail.length == 0) {
//                ShowEmail.push(emailArray[i]);
//                document.getElementById(emailArray[i]).style.display = "block";
//                   document.getElementById(arrayvalue).innerHTML = emailArray[i];
//                   document.all.div1.innerText = emailArray[i];
//                alert(ShowEmail.length);
//                break;
//        }
            if (!ShowEmail.contains(emailArray[i])) {
                ShowEmail.push(emailArray[i]);
                document.getElementById(emailArray[i]).style.display = "block";
                //  document.getElementById(arrayvalue).innerHTML = emailArray[i];
              //  alert(ShowEmail.length);
                break;
            }
        }
    }


    //    function HideEmailControl() {
    //        if (iCounter <= 4 && iCounter>0){
    //            document.getElementById("email" + iCounter).style.display = "none";
    //            iCounter--;
    //        }
    //    }
    //    function ShowEmailControl() {
    //        if (iCounter < 4 && iCounter >= 0) {
    //            iCounter++;
    //            document.getElementById("email" + iCounter).style.display = "block";
    //        }
    //    }


    Array.prototype.remove = function () {
        var what, a = arguments, L = a.length, ax;
        while (L && this.length) {
            what = a[--L];
            while ((ax = this.indexOf(what)) !== -1) {
                this.splice(ax, 1);
            }
        }
        return this;
    };

    if (!Array.prototype.indexOf) {
        Array.prototype.indexOf = function (what, i) {
            i = i || 0;
            var L = this.length;
            while (i < L) {
                if (this[i] === what) return i;
                ++i;
            }
            return -1;
        };
    }

    function removeControl(obj) {
        var emailID = "email" + obj;

        document.getElementById(emailID).style.display = "none";
        var index = ShowEmail.indexOf(emailID);
        if (index > -1)
            ShowEmail.remove(emailID);
//            ShowEmail.splice(emailID, 1);

      //  alert(ShowEmail.length);
//        if (ShowEmail.contains(emailID)) {
//            delete emailArray[obj - 1];

//        }
    }

    function test() {
        alert(123);
    }
    </script>
    <h2>
        Welcome to ASP.NET!
    </h2>
    <p>
        To learn more about ASP.NET visit <a href="http://www.asp.net" title="ASP.NET Website">
            www.asp.net</a>.
    </p>
    <p>
        You can also find <a href="http://go.microsoft.com/fwlink/?LinkID=152368&amp;clcid=0x409"
            title="MSDN ASP.NET Docs">documentation on ASP.NET at MSDN</a>.
    </p>
    <div>
        <asp:GridView ID="GridView1" runat="server">
        </asp:GridView>
    </div>
    <div>
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        <asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click" />
        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
    </div>
    <div>
           <input type="text" id="Button5" value="test" onkeyup ="test()" />
    </div>
    <div>
        <hr />
        <div id="arrayvalue">show array value</div>
        <div>
            <table>
                <tr>
                    <td>
                        <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <input type="button" id="btnAdd" value="Add" onclick="addControl()" />
                    </td>
                </tr>
                <tr id="email1" style ="display:none">
                    <td>
                        <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <input type="button" id="btnreduce" value="Reduce" onclick="removeControl(1)" />
                    </td>
                </tr>
                <tr id="email2"  style ="display:none">
                    <td>
                        <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <input type="button" id="Button2" value="Reduce" onclick="removeControl(2)" />
                    </td>
                </tr>
                <tr id="email3"  style ="display:none">
                    <td>
                        <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <input type="button" id="Button3" value="Reduce" onclick="removeControl(3)" />
                    </td>
                </tr>
                <tr id="email4"   style ="display:none">
                    <td>
                        <asp:TextBox ID="TextBox6" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <input type="button" id="Button4" value="Reduce" onclick="removeControl(4)" />
                    </td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>
