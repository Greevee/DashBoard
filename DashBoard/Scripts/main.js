var sessionData = {};
var data;

var bar_Memory;

$(document).ready(function () {
    //site has been loaded, starting stuff!
    setup();
});

function setup() {

    window.setInterval(refreshTime, 1000);

    jQuery.ajax({
        type: "GET",
        url: "http://" + window.location.host + "/api/hardwareinfo",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (incdata, status, jqXHR) {
            sessionData.maxMemory = incdata.ramInfo.max.toFixed(0);
            setupMemory();

            window.setInterval(getHardwareInfo, 2000);
        },
        error: function (jqXHR, status) {
            //TODOErrorhandling!
        }
    });
}

function getHardwareInfo() {
    jQuery.ajax({
        type: "GET",
        url: "http://" + window.location.host + "/api/hardwareinfo",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (incdata, status, jqXHR) {
            data = incdata;
            refreshNetwork();
            refreshMemory();
        },
        error: function (jqXHR, status) {
            //TODOErrorhandling!
        }
    });
}

function refreshTime() {
    $("#d_date_time").text(getTimeString());
    $("#d_date_date").text(getDateString());
}

function setupMemory() {
    //ill need my own class later here, jquery will do for now...
}

function refreshMemory() {

    var available = (sessionData.maxMemory - data.ramInfo.available).toFixed(0)
    $('#d_memory_bar').jQMeter({
        goal: sessionData.maxMemory,
        raised: available,
        meterOrientation: 'vertical',
        width: '150px',
        height: '400px',
        animationSpeed: 0,
    });

}

function refreshNetwork() {
    $("#d_network_in_value").text(data.networkInfo.kbitIn.toFixed(0) + " kbyte/s")
    $("#d_network_out_value").text(data.networkInfo.kbitOut.toFixed(0) + " kbyte/s")
}



