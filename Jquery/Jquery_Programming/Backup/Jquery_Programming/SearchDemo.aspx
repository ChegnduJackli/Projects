<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SearchDemo.aspx.cs" Inherits="Jquery_Programming.SearchDemo" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="Script/jquery-1.11.2.min.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(function () {
            // $("div:Contains('John')").css("text-decoration", "underline");
            //press enter key to trigger click button
            $('#txtSearch').keypress(function (event) {
                if (event.keyCode == 13) {
                    $('#btnSearch').trigger('click');
                    event.stopPropagation();
                    return false;
                }
            });


            $('#btnSearch').click(function () {
                var item = $('#txtSearch').val();
                if (item.length > 0) {
                 
                    //清空查询结果
                    $('#searchResult').html('');
                    var itemIndex = 0;
                    var newHtml = "";
                    //Use a regular expression (\s matches spaces, tabs, new lines, etc.)
                    var itemArr = item.split(/\s+/);
                    var newItemArr = [];
                    var maxCount = 0;
                    var fullMaxCount = 100;

                    $('.Faq > li').each(function (index) {

                        var $this = $(this).clone();
                        //first time the full text match
                        if ($this.is(":contains('" + item + "')")) {
                            $this.highlight(item);
                            var p = {};
                            p.index = index;
                            p.keyCount = fullMaxCount;
                            p.refThis = $this;
                            p.refText = $this.text();
                            newItemArr[index] = p;
                         
                            return; //jump the belowing code.
                        }
                        //then match word by word
                        for (var i = 0, len = itemArr.length; i < len; i++) {
                            // if ($this.text().toLowerCase().split(/\s+/).indexOf(itemArr[i].toLowerCase()) >= 0) {
                            if ($this.is(":contains('" + itemArr[i] + "')")) {
                                if (newItemArr[index] && newItemArr[index] != null) {
                                    newItemArr[index].keyCount++;
                                }
                                else {
                                    $this.highlight(itemArr[i]);
                                    var p = {};
                                    p.index = index;
                                    p.keyCount = 1;
                                    p.refThis = $this;
                                    p.refText = $this.text();
                                    newItemArr[index] = p;
                                   
                                }
                            }
                        }

                    });
                    if (newItemArr.length > 0) {
                        newItemArr.sort(function (a, b) {
                            return b.keyCount - a.keyCount;
                        });
                        var icount = Math.floor(maxCount / 2);
                        $.each(newItemArr, function (i, obj) {
                            if (obj != undefined) {
                                obj.refThis.find('i').text(itemIndex++);
                                newHtml += "<li> " + obj.refThis.html() + "</li>";
                            }
                        });
                    }
                    if (newHtml.length == 0) {
                        newHtml = "<h1>0 results </h1>";
                        newHtml += "<br />Your search returned no matches.";
                    }

                    $('#searchResult').append(newHtml);
                    $('.Faq').hide();
                }
            });


        });

        $.expr[":"].contains = $.expr.createPseudo(function (arg) {
            return function (elem) {
                return $(elem).text().toUpperCase().indexOf(arg.toUpperCase()) >= 0;
            };
        });

        jQuery.fn.highlight = function (pat) {
            function innerHighlight(node, pat) {
                var skip = 0;
                if (node.nodeType == 3) {
                    var pos = node.data.toUpperCase().indexOf(pat);
                    if (pos >= 0) {
                        var spannode = document.createElement('span');
                        spannode.className = 'highlight';
                        var middlebit = node.splitText(pos);
                        var endbit = middlebit.splitText(pat.length);
                        var middleclone = middlebit.cloneNode(true);
                        spannode.appendChild(middleclone);
                        middlebit.parentNode.replaceChild(spannode, middlebit);
                        skip = 1;
                    }
                }
                else if (node.nodeType == 1 && node.childNodes && !/(script|style)/i.test(node.tagName)) {
                    for (var i = 0; i < node.childNodes.length; ++i) {
                        i += innerHighlight(node.childNodes[i], pat);
                    }
                }
                return skip;
            }
            return this.each(function () {
                innerHighlight(this, pat.toUpperCase());
            });
        };

        jQuery.fn.removeHighlight = function () {
            function newNormalize(node) {
                for (var i = 0, children = node.childNodes, nodeCount = children.length; i < nodeCount; i++) {
                    var child = children[i];
                    if (child.nodeType == 1) {
                        newNormalize(child);
                        continue;
                    }
                    if (child.nodeType != 3) { continue; }
                    var next = child.nextSibling;
                    if (next == null || next.nodeType != 3) { continue; }
                    var combined_text = child.nodeValue + next.nodeValue;
                    new_node = node.ownerDocument.createTextNode(combined_text);
                    node.insertBefore(new_node, child);
                    node.removeChild(child);
                    node.removeChild(next);
                    i--;
                    nodeCount--;
                }
            }

            return this.find("span.highlight").each(function () {
                var thisParent = this.parentNode;
                thisParent.replaceChild(this.firstChild, this);
                newNormalize(thisParent);
            }).end();
        };

    </script>

    <style type="text/css">
        li
        {
            line-height: 30px;
            font-family: Arial;
        }
        #txtSearch
        {
            width: 200px;
        }
        i
        {
            font-size: 14px;
            font-weight: bold;
            margin: 10px;
        }
        ul
        {
            list-style-type: none;
        }
            .highlight {
    background-color: #fff34d;
    -moz-border-radius: 5px; /* FF1+ */
    -webkit-border-radius: 5px; /* Saf3-4 */
    border-radius: 5px; /* Opera 10.5, IE 9, Saf5, Chrome */
    -moz-box-shadow: 0 1px 4px rgba(0, 0, 0, 0.7); /* FF3.5+ */
    -webkit-box-shadow: 0 1px 4px rgba(0, 0, 0, 0.7); /* Saf3.0+, Chrome */
    box-shadow: 0 1px 4px rgba(0, 0, 0, 0.7); /* Opera 10.5+, IE 9.0 */
}

.highlight {
    padding:1px 4px;
    margin:0 -4px;
}
         
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        Search Here:<input id="txtSearch" placeholder="Please input key words to search" />
        <input type="button" id="btnSearch" value="Search" /></div>
    <ul id="searchResult">
    </ul>
    <ul class="Faq">
        <li><i>1</i>Question bans do not affect other privileges, such as commenting or voting,
            and there is no indication to the rest of the community that a particular user has
            been banned.</li>
        <li><i>2</i>The ban will be lifted automatically by the system when it determines that
            your positive contributions outweigh those questions which were poorly received.</li>
        <li><i>3</i>The only way to end a posting block is to positively contribute to the site;
            automatic bans never expire or "time out".</li>
        <li><i>4</i>If you see a similar message when trying to post an answer, please see our
            guidance on what to do about answer bans.</li>
        <li><i>5</i>Reading your question out loud to yourself can help you understand what
            it sounds like to others. Here are some additional tips for writing good, useful
            questions:</li>
    </ul>
    </form>
</body>
</html>
