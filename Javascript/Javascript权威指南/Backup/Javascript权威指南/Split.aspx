<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Split.aspx.cs" Inherits="Javascript权威指南.Split" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="js/common.js" type="text/javascript"></script>

    
</head>
<body>
    <form id="form1" runat="server">
    <div id="main">
 </div>
 <div>
       <input type="button"  name="button" id="button1" value="button 1" /><br />
    <input type="button" name="button" id="button2" value="button 3" /><br />
    <input type="button"  name="button" id="button3" value="button 3" /><br />
    <input type="button"  name="button" id="button4" value="button 4" /><br />
    <input type="button"  name="button" id="button5" value="button 5" /><br />
    </div>
    </form>
        <script type="text/javascript">
            (function () {

                // var a = b = 5;
                String.prototype.repeatify = String.prototype.repeatify || function (times) {
                    var str = '';
                    for (var i = 0; i < times; i++) {
                        str += this;
                    }
                    return str;
                }

                

            })();
            WriteLine('hello'.repeatify(5));

            var fullname = 'John Doe';

            var obj = {

                fullname: 'Colin Ihrig',

                prop: {

                    fullname: 'Aurelio De Rosa',

                    getFullname: function () {

                        return this.fullname;

                    }
                }
            };

            WriteLine(obj.prop.getFullname());

            var test = obj.prop.getFullname;

            WriteLine(test());
            WriteLine(test.call(obj.prop));
            WriteLine(test.apply(obj.prop));

            var nodes = document.getElementsByName('button');
            for (var i = 0; i < nodes.length; i++) {
                nodes[i].addEventListener('click', function (i) {
                    return function () { WriteLine('You clicked element #' + i); }
                }(i));
            }

            WriteLine(typeof null); //object
            WriteLine(typeof {}); //object
            WriteLine(typeof []);//object
            WriteLine(typeof undefined); //undefined

            var myArray = [];
            if (myArray instanceof Array) {
                WriteLine("myArray is an instance of Array.");
            }
            else {
                WriteLine("myArray is not an instance of Array.");
            }
            function printing() {
                WriteLine(1);
                setTimeout(function () { WriteLine(2); }, 1000);
                setTimeout(function () { WriteLine(3); }, 0);
                WriteLine(4);
            }
            printing();


    </script>
</body>
</html>
