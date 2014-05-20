//function setWindowTimeout() {
//    window.setInterval(alert("test"), 3000);
//}


function ShowTimePassed() {
    var currentTime = new Date();
    answer = confirm("You session is about to expire. Do you want to extend ?");
    if (answer) {
        var img = new Image(1, 1);
        img.src = 'KeepAlive.aspx?date=' + escape(new Date());
    }
     else
       window.document.location.href="Default.aspx";				                     				    
}
function setWindowTimeout() {
    window.setInterval('ShowTimePassed()', 5000);
}