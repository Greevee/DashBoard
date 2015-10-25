var data;

window.setInterval(getContacts, 1000);


function getContacts() {

    jQuery.ajax({
        type: "GET",
        url: "http://" + window.location.host + "/api/hardwareinfo",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (incdata, status, jqXHR) {
            console.log(data)
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
