var sessionData = {};
var hardware_data = [];
var teamspeak_data = {};
var memoryBar = {};
var cpuBars = {};

var refresh_ms_hardware = 2000;
var refresh_ms_date = 1000;
var refresh_ms_teamspeak = 100;



$(document).ready(function () {
    //site has been loaded, starting stuff!
    setup();
});

function setup() {

    window.setInterval(refreshDate, refresh_ms_date);

    //hardware
    jQuery.ajax({
        type: "GET",
        url: "http://" + window.location.host + "/api/hardwareinfo?cachebust=" + new Date().getTime(),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (incdata, status, jqXHR) {
            sessionData.maxMemory = incdata.ramInfo.max.toFixed(0);
            sessionData.numerOfCores = incdata.cpuInfo.numberCores;
            setupMemory();
            setupCPU();
            window.setInterval(getHardwareInfo, refresh_ms_hardware);
        },
        error: function (jqXHR, status) {
            //TODOErrorhandling!
        }
    });

    window.setInterval(getTeamSpeakInfo, refresh_ms_teamspeak);


}

function getTeamSpeakInfo() {
    jQuery.ajax({
        type: "GET",
        url: "http://" + window.location.host + "/api/teamspeakinfo?cachebust=" + new Date().getTime(),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (ts3data, status, jqXHR) {
            teamspeak_data = ts3data;
            refreshTeamSpeak();
        },
        error: function (jqXHR, status) {
            //TODOErrorhandling!
        }
    });
}

function getHardwareInfo() {
    jQuery.ajax({
        type: "GET",
        url: "http://" + window.location.host + "/api/hardwareinfo?cachebust=" + new Date().getTime(),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (incdata, status, jqXHR) {
            hardware_data = incdata;
            refreshNetwork();
            refreshMemory();
            refreshCPU();
        },
        error: function (jqXHR, status) {
            //TODOErrorhandling!
        }
    });
}


function refreshTeamSpeak() {
    $("#d_teamspeak_channel").text(teamspeak_data.myChannel.name);
    $("#d_teamspeak_my_user_name").text(teamspeak_data.myClient.nickname);

    if (teamspeak_data.myClient.client_output_muted == "1") {

    } else if (teamspeak_data.myClient.client_input_muted == "1") {
        $("#d_teamspeak_my_user_icon .d_teamspeak_icon_normal").hide();
        $("#d_teamspeak_my_user_icon .d_teamspeak_icon_muted").show();

    } else {
        $("#d_teamspeak_my_user_icon .d_teamspeak_icon_muted").hide();
        $("#d_teamspeak_my_user_icon .d_teamspeak_icon_normal").show();
        //no status
        //show normal
        if (teamspeak_data.myClient.isTalking === true) {
            $("#d_teamspeak_my_user_icon .d_teamspeak_icon_normal").css("fill", "aqua");
        } else {
            $("#d_teamspeak_my_user_icon .d_teamspeak_icon_normal").css("fill", "");
        }
    }


}

function refreshDate() {
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
    var barwidthPercent = 100 / (sessionData.numerOfCores);
    $('.d_cpu_bar').width(barwidthPercent + "%")


}

function refreshCPU() {
    for (i = 0; i < sessionData.numerOfCores; i++) {
        cpuBars[i].updateValue(hardware_data.cpuInfo.cpuLoadMap["0," + i]);
    }
    $("#d_cpu_total_value").text(hardware_data.cpuInfo.cpuLoadMap._Total.toFixed(0) + " %");
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
    var used = (sessionData.maxMemory - hardware_data.ramInfo.available).toFixed(0);
    var usedpercent = (Number(used)) / (Number(sessionData.maxMemory)) * 100
    memoryBar.updateValue(usedpercent);
    memoryBar.showValue(used);

}

function refreshNetwork() {
    $("#d_network_in_value").text(getNetworkValueFormatted(hardware_data.networkInfo.kbitIn));
    $("#d_network_out_value").text(getNetworkValueFormatted(hardware_data.networkInfo.kbitOut));
}



