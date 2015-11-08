function getTimeString() {
    return new Date().toLocaleTimeString().replace("/.*(\d{2}:\d{2}:\d{2}).*/", "$1")
}

function getDateString() {
    var d = new Date();
    var day = d.getDate();
    var month = d.getMonth() + 1;

    if (day < 10) {
        day = "0" + d.getDate();
    }

    if (month < 10) {
        month = "0" + eval(d.getMonth() + 1);
    }
    return day + "." + month + "." + (d.getYear() - 100);
}


function getNetworkValueFormatted(kbyte_as_number) {
    if (kbyte_as_number > 1024) {
        return (kbyte_as_number/1024).toFixed(1)+" MByte/s"
    } else {
        return kbyte_as_number.toFixed(0) + " KByte/s"
    }
}

function getTimerString(s) {
    var ms = s % 1000;
    s = (s - ms) / 1000;
    var secs = s % 60;
    s = (s - secs) / 60;
    var mins = s % 60;
    var hrs = (s - mins) / 60;

    if (secs.toFixed(0).length == 1) {
        secs = "0" + secs.toFixed(0);
    }
    if (mins.toFixed(0).length == 1) {
        mins = "0" + mins.toFixed(0);
    }
    return hrs + ':' + mins + ':' + secs;
}