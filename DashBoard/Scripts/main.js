var data;

$(document).ready(function () {
    //site has been loaded, starting stuff!
    window.setInterval(refreshTime, 1000);
    window.setInterval(getHardwareInfo, 250);

});

function getHardwareInfo() {
    jQuery.ajax({
        type: "GET",
        url: "http://" + window.location.host + "/api/hardwareinfo",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (incdata, status, jqXHR) {
            data = incdata;
            refreshNetwork();
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

function refreshMemory() {
    var bar_Memory = $("#d_memory_bar").barIndicator();
    bar_Memory.barIndicator('loadNewData', [newData]);
}

function refreshNetwork() {
    $("#d_network_in_value").text(data.networkInfo.kbitIn.toFixed(0) + " kbyte/s")
    $("#d_network_out_value").text(data.networkInfo.kbitOut.toFixed(0) + " kbyte/s")
}



