<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Calender.aspx.cs" Inherits="Calender" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <script src="My97DatePicker/WdatePicker.js" type="text/javascript"></script>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <input type="text" id="d241" onfocus="WdatePicker({dateFmt:'dd/MM/yyyy HH:mm:ss'})"
        class="Wdate" style="width: 300px" />
    <a href="#" class="pp">click me</a>
    <div>
        <div>
        </div>
        <br />
        <table class="border" cellspacing="1" cellpadding="0">
            <tr>
                <td colspan="2" bgcolor="#e6e7e8">
                    abc
                </td>
            </tr>
            <tr>
                <td colspan="2" bgcolor="#e6e7e8">
                    def
                </td>
            </tr>
        </table>
    </div>
    <div>
        <input type="text" value="" id="input" size="1000" />
        <input type="text" value="" id="current" size="1000" />
        <script type="text/javascript">
            function counter() {
                var date = new Date();
                var year = date.getFullYear();
                var date2 = new Date(year, 12, 31, 23, 59, 59);

                var time = (date2 - date) / 1000;

                var day = Math.floor(time / (24 * 60 * 60))
                var hour = Math.floor(time % (24 * 60 * 60) / (60 * 60))
                var minute = Math.floor(time % (24 * 60 * 60) % (60 * 60) / 60);
                var second = Math.floor(time % (24 * 60 * 60) % (60 * 60) % 60);
                var str = year + "年还剩" + day + "天" + hour + "时" + minute + "分" + second + "秒";
                document.getElementById("input").value = str;
            }
            function getDateTime() {
                var now = new Date();
                var year = now.getFullYear();
                var month = now.getMonth() + 1;
                var day = now.getDate();
                var hour = now.getHours();
                var minute = now.getMinutes();
                var second = now.getSeconds();
                if (month.toString().length == 1) {
                    var month = '0' + month;
                }
                if (day.toString().length == 1) {
                    var day = '0' + day;
                }
                if (hour.toString().length == 1) {
                    var hour = '0' + hour;
                }
                if (minute.toString().length == 1) {
                    var minute = '0' + minute;
                }
                if (second.toString().length == 1) {
                    var second = '0' + second;
                }
                var dateTime = year + '/' + month + '/' + day + ' ' + hour + ':' + minute + ':' + second;
                document.getElementById("current").value = dateTime;

            }
            window.setInterval("counter()", 1000);
            window.setInterval("getDateTime()", 1000);
        </script>
    </div>
    </form>
</body>
</html>
