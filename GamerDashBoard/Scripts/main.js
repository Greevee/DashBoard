var config = {};
var sessionData = {};
var hardware_data = [];
var teamspeak_data = {};
var memoryBar = {};
var cpuBars = {};

var refresh_ms_hardware = 2000;
var refresh_ms_date = 1000;
var refresh_ms_teamspeak = 250;
var refresh_ms_config = 1000;

var max_ts_clients = 4;

var timer= {};

$(document).ready(function () {
    //site has been loaded, starting stuff!
    setup();
});

function setup() {

    //config
    jQuery.ajax({
        type: "GET",
        url: "http://" + window.location.host + "/api/configuration?cachebust=" + new Date().getTime(),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (incconfig, status, jqXHR) {
            config = incconfig;
            exeConfig();
            window.setInterval(getConfig, refresh_ms_config);
        },
        error: function (jqXHR, status) {
            //TODOErrorhandling!
        }
    });


    sessionData.prevTSData = {};
    //date

    window.setInterval(refreshDate, refresh_ms_date);
    timer = new pizzatimer(5000);
    timer.appendToEle($("#d_date_timer_icon"));

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

    //start TS3 service
    window.setInterval(getTeamSpeakInfo, refresh_ms_teamspeak);
}

function getConfig() {
    jQuery.ajax({
        type: "GET",
        url: "http://" + window.location.host + "/api/configuration?cachebust=" + new Date().getTime(),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (incconfig, status, jqXHR) {
            if (JSON.stringify(incconfig) == JSON.stringify(config)) {
                //do nmothing... or?
                refreshColors();
            } else {
                config = incconfig;
                exeConfig();
            }
        },
        error: function (jqXHR, status) {
            //TODOErrorhandling!
        }
    });
}

function refreshColors() {
    //TODO clean this mess up
    $(".d_colorable_border").css("border", "3px solid rgb(" + config.styleconig.color_r + "," + config.styleconig.color_g + "," + config.styleconig.color_b + ")")
    $(".d_colorable_color").css("color", "rgb(" + config.styleconig.color_r + "," + config.styleconig.color_g + "," + config.styleconig.color_b + ")")
    $(".d_value").css("color", "rgb(" + config.styleconig.color_r + "," + config.styleconig.color_g + "," + config.styleconig.color_b + ")")
    $(".d_timer_icon").css("stroke", "rgb(" + config.styleconig.color_r + "," + config.styleconig.color_g + "," + config.styleconig.color_b + ")")
    $(".d_inner_bar").css("background-color", "rgb(" + config.styleconig.color_r + "," + config.styleconig.color_g + "," + config.styleconig.color_b + ")")
    $(".d_teamspeak_icon").css("stroke", "rgb(" + config.styleconig.color_r + "," + config.styleconig.color_g + "," + config.styleconig.color_b + ")")
}

function exeConfig(){
    if (config.networkConfig.enabled===false) {
        $("#d_network_container").hide();
    } else {
        $("#d_network_container").show();
    }
    if (config.clockConfig.enabled === false) {
        $("#d_date_container").hide();
    } else {
        $("#d_date_container").show();
    }
    if (config.cpuConfig.enabled === false) {
        $("#d_cpu_container").hide();
    } else {
        $("#d_cpu_container").show();
    }
    if (config.memoryConfig.enabled === false) {
        $("#d_memory_container").hide();
    } else {
        $("#d_memory_container").show();
    }
    if (config.tsconfig.enabled === false) {
        $("#d_teamspeak_container").hide();
    } else {
        $("#d_teamspeak_container").show();
    }
  
    $('body').css("background-image", "url(../Style/Wallpapers/" + config.styleconig.wallpaper+")");


    refreshColors();
    
    
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
    //TODO more than x ppl, change logic to -> only speaker visible

    if (teamspeak_data.status == "Connecting") {
        sessionData.prevTSData = {};
        jQuery('#d_teamspeak_user_container').html('');
        //hide TS3
        $("#d_teamspeak_content").hide();
    } else if (teamspeak_data.status == "Disconnected") {

        sessionData.prevTSData = {};
        jQuery('#d_teamspeak_user_container').html('');
        //hide TS3
        $("#d_teamspeak_content").hide();
    } else if (teamspeak_data.status == "Connected") {
        $("#d_teamspeak_content").show();
        var i = 0;
        var userContainer = $("#d_teamspeak_user_container");

        if (JSON.stringify(sessionData.prevTSData.myClient) == JSON.stringify(teamspeak_data.myClient)) {
            //do nmothing... or?
            i++;
        } else {
            renderClient(userContainer, i, teamspeak_data.myClient, true);
            i++;
        }

        if (JSON.stringify(sessionData.prevTSData.myChannel) == JSON.stringify(teamspeak_data.myChannel)) {

        } else {
            $("#d_teamspeak_channel").text(teamspeak_data.myChannel.name);
            if (teamspeak_data.myChannel.numberOfClients > max_ts_clients) {

                var speakers = getClients(teamspeak_data.myChannel, true);
                for (var x in speakers) {
                    if (i - 1 < max_ts_clients) {
                        renderClient(userContainer, i, speakers[x], false);
                        i++;
                    }
                }

                if (i < max_ts_clients) {
                    for (j = i; j < max_ts_clients; j++) {
                        $("#d_teamspeak_user_entry_" + j).remove();
                    }
                }
                //printe x other persons in the channel
            } else {
                //everyone is displayed, no change of order
                var clients = getAllClients(teamspeak_data.myChannel);
                for (var x in clients) {
                    renderClient(userContainer, i, clients[x], false);
                    i++;
                }
                if (i < max_ts_clients) {
                    for (j = i; j < max_ts_clients; j++) {
                        $("#d_teamspeak_user_entry_" + j).remove();
                    }
                }
            }
        }
        //refresh info
        sessionData.prevTSData = teamspeak_data;
    }
}

function refreshDate() {
    $("#d_date_time").text(getTimeString());
    if (sessionData.timerIsRunning === true) {
        $("#d_date_date").text(getTimerString(Date.now() - sessionData.timerstart));
    } else {
        $("#d_date_date").text(getDateString());
    }

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



