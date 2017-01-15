//;(function ($) {
//模块模式，一个名称空间，一个立即执行函数，一个返回函数
    var method = function ($) {



     function init() { alert('init'); };
     function flip() { alert('flip'); };

    // var init = function () { alert('init method') };
    // var flip = function () { alert('flip method')};

    return {
        //init: function () { alert('init method in return statement'); },
        //flip: function () { alert('flip method in return statement'); }
        init: init,
        flip: flip
    };

} (jQuery);