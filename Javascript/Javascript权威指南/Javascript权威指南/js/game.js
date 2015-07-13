var kPrizes = {
    BRONZE: { level: 1, name: 'Bronze', css_class: 's1' },
    SILVER: { level: 2, name: 'Silver', css_class: 's2' },
    GOLD: { level: 3, name: 'Gold', css_class: 's3' },
    PLATINUM: { level: 4, name: 'Platinum', css_class: 's4' }
};

//对象数组
var errormessages = {
    "0": ["Connection problem", "Unable to connect. Please check your Internet connection and try again."],
    "500": ["Server error", "Please try again in a few hours"],
    "400": ["Server error", "Please try again in a few hours"],
    "503": ["Server busy", "Please try again in a few minutes"],
    "move:/403": ["Bad move", "This move is not allowed"],
    "move:/403.9005": ["Insufficient points", "You have insufficient points for this move"],
    "403.10": ["Login problem", "Error logging in. Please quit your browser and restart."]
};

//普通数组
var kPrizeIndex = ['BRONZE', 'SILVER', 'GOLD', 'PLATINUM'];

var prizecolors = {
    'cash': {
        '1': '#00E61F',
        '2': '#E6DA00',
        '5': '#E6DA00',
        '10': '#E66700',
        '20': '#E66700',
        '50': '#ED1212',
        '200': '#FF0000'
    },

    'points': {
        '50': '#00AAFF',
        '100': '#00AAFF',
        '200': '#00AAFF',
        '500': '#00AAFF'
    }
};


var format_timestamp = function (d) {

    var date_string = d.toLocaleDateString();
    var s = date_string;
    s += " " + (d.getHours() % 12) + ":";
    var minutes = d.getMinutes() + ""; // convert to string, check length, add leading zero
    if (minutes.length == 1) { minutes = "0" + minutes; }
    s += minutes;
    s += (d.getHours() > 11) ? "pm" : "am";

    return s;

};

var update_timestamp = function (s) {
    var d = new Date();
    s += format_timestamp(d);
    return s;
}

//时间比较，用于时间差
var relative_timestamp = function (current, previous) {

    var msPerMinute = 60 * 1000;
    var msPerHour = msPerMinute * 60;
    var msPerDay = msPerHour * 24;
    var msPerMonth = msPerDay * 30;
    var msPerYear = msPerDay * 365;

    var elapsed = current - previous;

    if (elapsed < msPerMinute) {
        return Math.round(elapsed / 1000) + 's';
    }

    else if (elapsed < msPerHour) {
        return Math.round(elapsed / msPerMinute) + 'm';
    }

    else if (elapsed < msPerDay) {
        return Math.round(elapsed / msPerHour) + 'h';
    }
    else if (elapsed < msPerMonth) {
        return 'approximately ' + Math.round(elapsed / msPerDay) + 'd';
    }

    else if (elapsed < msPerYear) {
        return 'approximately ' + Math.round(elapsed / msPerMonth) + 'mon';
    }

    else {
        return 'approximately ' + Math.round(elapsed / msPerYear) + 'years ago';
    }

};

//getTime() Return the number of milliseconds since 1970/01/01:
Date.prototype.addHours = function (h) {
    this.setTime(this.getTime() + (h * 60 * 60 * 1000));
    return this;
}
Date.prototype.addMinutes = function (m) {
    this.setTime(this.getTime() + (m * 60* 1000));
    return this;
}
Date.prototype.addSeconds = function (s) {
    this.setTime(this.getTime() + (s * 1000));
    return this;
}




//        make_tile(boarddef, i, kPrizes.PLATINUM);
//   var prize_tile = make_prize_tile(prize[prize_status.level]);
 var make_prize_title=function(prizes)
 {
     var title={};
     var html='';

 }

 var log = function (s) {
     if (typeof console !== 'undefined') {
     //实际应用中，这里会移除。
          console.log(s);
     }
 };