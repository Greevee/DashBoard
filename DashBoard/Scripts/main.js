var sessionData = {};
var data;
var memoryBar = {};
var cpuBars = {};

var refresh_ms = 1000;



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
            sessionData.numerOfCores = incdata.cpuInfo.numberCores;
            setupMemory();
            setupCPU();
            window.setInterval(getHardwareInfo, refresh_ms);
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
            refreshCPU();
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

function setupCPU() {
    for (i = 0; i < sessionData.numerOfCores; i++) {
        
        var element = $('<div id="d_cpu_bar_' + i + '" class="d_cpu_bar"></div>');
        $("#d_cpu_bar_container").append(element)


        var options = {};
        options.max = "100";
        options.height = "100px";

        var cpuBar = new bar(options);
        cpuBar.appendToEle(element)

        cpuBars[i] = cpuBar

    }
}

function refreshCPU() {
    for (i = 0; i < sessionData.numerOfCores; i++) {
        cpuBars[i].updateValue(data.cpuInfo.cpuLoadMap["0,"+i]);
    }
    $("#d_cpu_total_value").text(data.cpuInfo.cpuLoadMap._Total.toFixed(0));
}


function setupMemory() {
    var options = {};
    options.max = sessionData.maxMemory;
    options.width = "140px";
    options.height = "410px";

    memoryBar = new bar(options);
    memoryBar.appendToEle($("#d_memory_bar_container"))

}

function refreshMemory() {
    var used = (sessionData.maxMemory - data.ramInfo.available).toFixed(0);
    var usedpercent = (Number(used)) / (Number(sessionData.maxMemory)) * 100
    memoryBar.updateValue(usedpercent);
    memoryBar.showValue(used);

}

function refreshNetwork() {
    $("#d_network_in_value").text(data.networkInfo.kbitIn.toFixed(0) + " kbyte/s")
    $("#d_network_out_value").text(data.networkInfo.kbitOut.toFixed(0) + " kbyte/s")
}



