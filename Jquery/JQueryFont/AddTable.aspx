<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AddTable.aspx.cs" Inherits="AddTable" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Add table</title>
    <script type="text/javascript">
        var strHtml = "";
        var totRecordsCount = 0;
        var tableHeaer = "<table align ='center' cellpadding='0' cellspacing='0' border='1'><tbody><tr ><td>UserName</td><td>Password</td><td>Sex</td><td>Number</td><td title=‘Delete’ align=‘center’  style=‘vertical-align:middle;text-align:center;width:5%;’ ><b>Delete</b></td></tr>";

        function addTable() {

            strHtml = tableHeaer;

            for (iCount = 1; iCount <= totRecordsCount; iCount++) {

                strHtml += "<tr><td align = 'left'><input type='text'  size='25' length='10' MAXLENGTH='254'  width='10' id='txtName" + iCount + "' name='txtName" + iCount + "' value='" + document.getElementById("txtName" + iCount).value + "' /></td>"
                strHtml += "<td align = 'left'><input type='text'  size='25' length='10' MAXLENGTH='254'  width='10' id='txtPassword" + iCount + "' name='txtPassword" + iCount + "' value='" + document.getElementById("txtPassword" + iCount).value + "' /></td>"
                strHtml += "<td align = 'left'><input type='text' size='25' length='10' MAXLENGTH='254'  width='10' id='txtSex" + iCount + "' name='txtSex" + iCount + "' value='" + document.getElementById("txtSex" + iCount).value + "'  /></td>"
                strHtml += "<td align = 'left'><input type='text'  size='25' length='10' MAXLENGTH='254'  width='10' id='txtNumber" + iCount + "' name='txtNumber" + iCount + "' value='" + document.getElementById("txtNumber" + iCount).value + "'  /></td>"
                strHtml += "<td align = 'left'><input type='button'  size='25' length='10' MAXLENGTH='254' value ='[Delete]'  width='10' onclick='deleteRowFromData(" + iCount + ");' /></td></tr>"

            }
            strHtml = strHtml + "</tbody></table>";
            return strHtml;

        }
        function AddRow() {

            if (totRecordsCount < 10) {

                strHtml = addTable();

                strHtml = strHtml.replace("</TBODY></TABLE>", "");
                strHtml = strHtml.replace("</tbody></table>", "");

                totRecordsCount += 1;

                strHtml += "<tr><td align = 'left'><input type='text'  size='25' length='10' MAXLENGTH='254'  width='10' id='txtName" + totRecordsCount + "' name='txtName" + totRecordsCount + "' value='' /></td>"
                strHtml += "<td align = 'left'><input type='text'  size='25' length='10' MAXLENGTH='254'  width='10' id='txtPassword" + totRecordsCount + "' name='txtPassword" + totRecordsCount + "' value='' /></td>"
                strHtml += "<td align = 'left'><input type='text' size='25' length='10' MAXLENGTH='254'  width='10' id='txtSex" + totRecordsCount + "' name='txtSex" + totRecordsCount + "' value=''  /></td>"
                strHtml += "<td align = 'left'><input type='text'  size='25' length='10' MAXLENGTH='254'  width='10' id='txtNumber" + totRecordsCount + "' name='txtNumber" + totRecordsCount + "' value=''  /></td>"
                strHtml += "<td align = 'left'><input type='button'  size='25' length='10' MAXLENGTH='254' value ='[Delete]'  width='10' onclick='deleteRowFromData(" + totRecordsCount + ");' /></td></tr>"
                strHtml = strHtml + "</tbody></table>";

                document.getElementById("idTable").innerHTML = strHtml;

            }
            else {
                document.getElementById("message").innerHTML = "max 10";
            }

        }

        function deleteRowFromData(instr) {

            document.getElementById("message").innerHTML = "";
            var iTempCount =0;
            if ((document.getElementById("txtName" + iCount) != null) && (document.getElementById("txtName" + iCount).value != "")) 
                resp = window.confirm("Are you sure you want to delete this Line Item?");
            else
                resp = true;
            for (iCount=1; iCount <=totRecordsCount; iCount++)
            {                        
                if(iCount == instr)
                  alert("equal");
             
           }
                
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div style="width: 700px">
        <div>
            <input type="button" value="Add table" onclick="AddRow()" />
        </div>
        <div id="idTable" style="width: 700px">
        </div>
        <div id="message" style=" color:Red">
        </div>
        <table align="center" cellpadding="0" cellspacing="0" border="1">
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
                    <td>
                        Delete
                    </td>
                </tr>
                <tr>
                    <td align='left'>
                        <input type='text' size='25px' length='10' maxlength='254' width='10' id='txtName1'
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
    </div>
    </form>
</body>
</html>
