//loop arrat
function loopArray(arr) {
    //for (var i = 0; i < arr.length; i++) {   //优化如下：数组的长度应该只查询一次而非每次循环都要查询
    for (var i = 0, len = arr.length; i < len; i++) {
        //如果想排除null,undefined和不存在的元素
        // if (!arr[i]) continue;

        //如果只想跳过不存在的元素仍然要处理存在的undefined元素
        // if (!(i in arr)) continue;

        //如果只想跳过undefined 和不存在的元素
        if (arr[i] == undefined) {
            WriteLine(i + " : " + " no data,undefined");
        }
        else {
            // WriteLine(i + " : " + arr[i]);
            WriteLine(arr[i]);
        }
    }
}

var strHtml = "";
function WriteLine(obj) {
    strHtml += "<p>" + obj + "</p>";
    document.getElementById("main").innerHTML = strHtml;
}

function isArrayLike(o) {

    if (o &&
typeof o == "object" &&
isFinite(o.length) &&
o.length > 0 &&
o.length === Math.floor(o.length) &&
o.lenth < 4294967296)
        return tre;
    else
        return false;
}


var operators = {
    add: function (x, y) {
        return x + y;
    },

    substract: function (x, y) {
        return x - y;
    },

    multiply: function (x, y) {
        return x * y;
    },

    divide: function (x, y) {
        return x / y;
    },
    pow: Math.pow //使用预定义函数
};
//将函数用做值
//这个函数接受一个名字作为运算符，在对象中查找这个运算符
//然后将它作用于所提供的操作数
function operate2(operation, oprand1, oprand2) {
    if (typeof operators[operation] === "function") {
        return operators[operation](oprand1, oprand2);
    }
    else throw "unkown operator";
}
factorial[1] = 1;
//计算阶乘，并将结果缓冲到函数的属性中
function factorial(n) {

    if (isFinite(n) && n > 0 && n == Math.round(n)) {  //有限的正整数
        if (!(n in factorial))
            factorial[n] = n * factorial(n - 1);  //计算结果并缓存

            return factorial(n);
        }
    
    else return NaN;
}

function inherit(p) {
    if (p == null) throw TypeError(); //p是一个对象，但不能是null

    if (Object.create) {
        return Object.create(p);
    }

    var t = typeof p;
    if (t != "object" && t != "function") throw TypeError();

    function f() { };   //定义一个空构造函数
    f.prototype = p;   //将其原型属性设置为p
    return new f();   //使用f()创建p的继承对象
}



function isValidLen(s, l, k) {
    var nums = "0123456789";
    var j = 0;
    var bReturn = true;
    for (var i = 0; i < s.length; i++) {
        // Check that current character is number.
        if (nums.indexOf(s.charAt(i)) >= 0) {
            j++;
        }
    }
    if ((j == l) || (j == k))
        bReturn = true;
    else
        bReturn = false;

    if (bReturn) {
        if (isValidChars(s, "[0-9$-]")) {
            bReturn = true; 
        }
        else {
            bReturn = false; 
        }
    }
    return bReturn;
}

//IE 8 not support trim().
String.prototype.trim = String.prototype.trim || function () {
    if (!this) return this; //空字符串不做处理

    return this.replace(/^\s+|\s+$/g, "");
}


function trimString(sInString) {
    if (sInString != null) {
        sInString = sInString.replace(/^\s+/g, ""); // strip leading
        return sInString.replace(/\s+$/g, ""); // strip trailing
    }
    else
        return "";
}


function isValidChars(sValue, sRule) {
    for (var i = 0; i < sValue.length; i++)
        if (!sValue.charAt(i).match(sRule)) {
            return false;
        }

    return true;
}
