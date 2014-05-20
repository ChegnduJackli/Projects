<%@ Page Language="C#" AutoEventWireup="true" CodeFile="trigger.aspx.cs" Inherits="trigger" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="Scripts/jquery-1.4.1.min.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            //查找所有 name 以 'letter' 结尾的 input 元素: 
           // $("input[name$='letter']")
            $('input[id$=_txtTest]').change( function () {
                alert($(this).val());
            });
            $('button').click( function () {
                $('#one_txtTest').val('hello').trigger('change');
            });
        });
    </script>
    <style type="text/css">
        #buttonTrigger
        {
            width: 78px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
   <input type='text' id='one_txtTest' value='' readonly='true' />
<button>hello</button>
    </div>
    </form>
</body>
</html>
