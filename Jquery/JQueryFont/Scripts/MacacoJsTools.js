function $(tarGetID) { return document.getElementById(tarGetID); }

//获取操作区域
var showDataDiv = $("#ShowDataDiv");

//获取TextBox控件的引用（注：title是TextBox控件的ID）
var controlInpputID = $("<%=txtCity.ClientID%>");

//设置初始状态为不可见（隐藏）
showDataDiv.style.display = "none";

//为TextBox控件注册事件
controlInpputID.keyup = function () { SendRequest(this.value) };
controlInpputID.click = function () { SendRequest(this.value) };
controlInpputID.blur = function () {//注：此处注册的事件是当TextBox失去焦点时为在150毫秒调用一个匿名方法把显示数据的DIV隐藏
    setTimeout(function () {
        showDataDiv.style.display = "none";
    }, 150)
};

//创建XMLHttpRequest对象实例
function GetXMLHttpRequest() {
    //声明对象用于指XMLHttpRequest（创建成功指向XMLHttpRequest,失败指向一个bool类型值）
    var Http_Request = false;

    //根据浏览器创建不同的对象实例
    if (window.XMLHttpRequest) {

        //创建基于Mozilla浏览器的XMLHttpRequest对象实例
        Http_Request = new XMLHttpRequest();

        //判断请求类型是否有默认设置
        if (Http_Request.overrideMimeType) {

            //若无默认设置则设置为text/xml格式
            Http_Request.overrideMimeType = "text/xml";
        }
    } else if (window.ActiveXObject) {
        //创建基于IE浏览器XMLHttpRequest的对象实例
        try {

            //创建针对较新版本IE浏览器的XMLHttpRequest对象实例
            Http_Request = new ActiveXObject("Msxml2.XMLHTTP");

        } catch (e) {

            try {

                //创建针对较旧版本IE浏览器的XMLHttpRequest对象实例
                Http_Request = new ActiveXObject("Microsoft.XMLHTTP");

            }
            catch (e) {

                alert("您的浏览器不支持Ajax的处理操作，无法正常协助您完成查询操作！");

            }
        }
    }

    //返回导步请求处理对象
    return Http_Request;
}

//创建全局导步应用处理对象
var httpRequst;

function SendRequest(strPar) {
    if (strPar.length > 0) {

        //获取并赋值全局异步应用处理对象
        httpRequst = GetXMLHttpRequest();

        //判断是否创建成功
        if (httpRequst) {

            //指定状态更改后的操作
            httpRequst.onreadystatechange = ResponseHttpRequest;


            var url = "../GetCityData.ashx?" + encodeURI(strPar);


            //打开发送请求，指定方式及要请求的文件以及是否为异步调用
            httpRequst.open("GET", url, true);

            //发送请求
            httpRequst.send(null);
        }
    } else
        showDataDiv.style.display = 'none';
}


//创建用于响应请求结果的方法
function ResponseHttpRequest() {

    if (httpRequst.readyState == 4) {

        //判断是否正确响应
        if (httpRequst.status == 200) {

            //判断要操作的DIV是否获取到
            if (showDataDiv != null) {
                var reqText = httpRequst.responseText;
                //判断是否查询到数据如果查询到的数据较少则为不正常应将显示数据的DIV隐藏
                if (reqText.length > 10) {

                    /*将获取的文本添加到要显示数据的DIV中（注：此处不使用innerText是因为Firefox不完全支持该属性
                    （详细可以参考http://www.google.com.hk/）并且请求的数据中包括了HTML标记而我需要这些HTML标记
                    被浏览器解析并应用样式）*/
                    showDataDiv.innerHTML = reqText;

                    //获取DIV中所有的p村记即上面添加进去的HTML标记
                    var pCol = showDataDiv.getElementsByTagName("p");

                    //使用循环遍历所有P标记为其添加对应的事件与属性
                    for (i = 0; i < pCol.length; i++) {
                        //当用户点击某个P标记时则将该P标记内的内容放入TextBox控件中并将DIV隐藏
                        pCol[i].onclick = function () { controlInpputID.value = this.innerHTML; showDataDiv.style.display = "none"; }
                        //设置用户将鼠标悬停在当前P标记上时显示提示信息即P标记中的所有内容
                        pCol[i].title = pCol[i].innerHTML;
                    }
                    //显示从服务获取到的数据
                    showDataDiv.style.display = "block";
                } else {
                    //如果没有获取到数据隐藏DIV
                    showDataDiv.style.display = "none";
                }
            }
        }
    }
}
