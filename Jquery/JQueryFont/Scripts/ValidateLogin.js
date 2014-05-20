/// <reference path="jquery-1.4.1.min.js" />

$(document).ready(function () {
    function validateForms() {
        var bReturn = true;
        if (!ValidateDatIsExist()) {
            bReturn = false;
        }
        return bReturn;

    
    }


//    function popup() {
//        alert("pop");
//        var value = document.getElementById("<%=TextBox1.ClientID%>").value;
//        alert(value);
//    }
    function ValidateDatIsExist() {
        var myname = "lideng";
        $.ajax({
            url: "HandlerTest1.ashx",
            type: "Get",
            data: { name: myname },
            dataType: "json",
            success: function (result) {
                if (result == "1") {
                    if (confirm("sure to commit?")) {
                        alert("commited");
                        return true;
                    }
                    else {
                        alert("not commited");
                        return false;
                    }
                }

            },
            error: function () { alert("error"); return false; }
        });
    }



});




