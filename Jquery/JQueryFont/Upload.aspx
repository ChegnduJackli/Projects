<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="Upload.aspx.cs" Inherits="Upload" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <input type="file" id="myFile" name="myFile" />
    <asp:Button runat="server" ID="btnUpload" OnClick="btnUploadClick" Text="Upload"
        OnClientClick="return ConfirmToDelete();" />
    <asp:HyperLink ID="HyperLink1" runat="server" Text="dfd"></asp:HyperLink>
    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
    <asp:TextBox ID="TextBox1" runat="server" Text="dfd" BorderStyle="None"></asp:TextBox>
    <script>
        function ConfirmToDelete() {
            var bReturn = true;
            var fileValue = document.getElementById("<%=TextBox1.ClientID%>").value;
            if (fileValue != null && fileValue.length > 0) {
                if (confirm("Are you sure to delete this?")) {
                    bReturn= true;
                }
                else {
                    bReturn= false;
                }
            }
            alert(bReturn);
            return bReturn;
        }

        var Person = function (name) {
            this.name = name;
        };

        //Add dynamically to the already defined object a new getter
        Person.prototype.getName = function () {
            return this.name;
        };

        //Create a new object of type Person
        var john = new Person("John");

        //Try the getter
        alert(john.getName());

        //If now I modify person, also John gets the updates
        Person.prototype.sayMyName = function () {
            alert('Hello, my name is ' + this.getName());
        };

        //Call the new method on john
        john.sayMyName();

        var obj = {};
        alert(obj.prototype);
        var MyClass = function () {
        }
        var myClass = new MyClass();
        alert(MyClass.prototype);
        alert(myClass.prototype);
    </script>
</asp:Content>
