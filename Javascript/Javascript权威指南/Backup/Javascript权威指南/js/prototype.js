//IE 8 not support trim().
String.prototype.trim = String.prototype.trim || function () {
    if (!this) return this; //emptys string, no process.

    return this.replace(/^\s+|\s+$/g, '');
};




Array.prototype.indexOf = Array.prototype.indexOf || function (obj, start) {
    for (var i = (start || 0), j = this.length; i < j; i++) {
        if (this[i] === obj) {
            return i;
        }
    }
    return -1;
};
