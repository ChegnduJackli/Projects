var iTimeoutWarning = 0.1 * 60 * 1000;

var iTimeoutWarningMin = iTimeoutWarning / (60 * 1000);


function ShowTimePassed() {
    var currentTime = new Date();
    answer = confirm("You session is about to expire. Do you want to extend ?");
    if (answer) {
        var img = new Image(1, 1);
        img.src = 'KeepAlive.aspx?date=' + escape(new Date());
    }
    else { 

    }
    // else
    //   window.document.location.href="../Vendor/Login.aspx";				                     				    
}
function setWindowTimeout() {
    window.setInterval('ShowTimePassed()', iTimeoutWarning);
}