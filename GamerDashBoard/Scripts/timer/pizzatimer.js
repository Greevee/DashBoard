function pizzatimer(alertTime) {

    var items = {};
    this.alertTime = alertTime;
    this.icon = $('<svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 100 100" class="d_timer_icon"><circle cx="50" cy="50" r="40" /><line x1="50" y1="50" x2="50" y2="15"/></svg>');
    this.icon.click(function () {
        if (sessionData.timerIsRunning === true) {
            $(this).css("animation", "");
            sessionData.timerIsRunning = false;
        } else {
            $(this).css("animation", "spin 10s linear infinite");
            sessionData.timerIsRunning = true;
            sessionData.timerstart = Date.now();
        }

    });

    //ewin bild, das sich dreht...

    this.appendToEle = function (elem) {
        elem.append(this.icon);
    }
}