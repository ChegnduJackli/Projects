/// <reference path="jquery-ui-1.8.11.js" />
$(function () {
    $("img").mouseover(function () {
        $(this).animate({height:'+=25',width:+='25'})
        ,animate({height:'-=25',width:-='25'})  ;
    });

});
