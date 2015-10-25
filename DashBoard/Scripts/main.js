var data;



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
    var date = new Date();
    $("#d_date_time").text(new Date().toLocaleTimeString().replace("/.*(\d{2}:\d{2}:\d{2}).*/", "$1"));
    
    var d = new Date();
    var day = d.getDate();
    var month = d.getMonth() + 1;

    if (day < 10) {
        day = "0" + d.getDate();
    }

    if (month < 10) {
        month = "0" + eval(d.getMonth() + 1);
    }

    var date = day + "." + month + "." + (d.getYear()-100);

    $("#d_date_date").text(date);
}
