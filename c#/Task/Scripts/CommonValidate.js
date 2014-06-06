/// <reference path="jquery-1.4.1-vsdoc.js" />



$.fn.extend({
    IsEmpty: function () {
        if ($(this).val() === "" || $(this).val().trim().length == 0) {
            return true;
        }
        else {
            return false;
        }
    },
    IsEmail: function () { }

});