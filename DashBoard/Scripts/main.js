var data;
var date = new Date();


window.setInterval(refreshDate, 1000);


function refreshDate() {

    jQuery.ajax({
        type: "GET",
        url: "http://" + window.location.host + "/api/hardwareinfo",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (incdata, status, jqXHR) {
            data = incdata;
            refresh();
        },

        error: function (jqXHR, status) {
            console.log(jqXHR)
        }
    });
}

function refresh() {
    $("#CPU").text(data.cpuInfo.cpuLoadMap["0,0"])
}
