function getClients(channel, speaking) {
    var clients = []
    for (var property in channel.clients) {
        if (channel.clients.hasOwnProperty(property)) {
            if (channel.clients[property].isTalking === speaking) {
                clients.push(channel.clients[property]);
            }
        }
    }
    return clients;
}

function getAllClients(channel) {
    var clients = []
    for (var property in channel.clients) {
        if (channel.clients.hasOwnProperty(property)) {
                clients.push(channel.clients[property]);
        }
    }
    return clients;
}

function renderClient(userContainer, number, client, isMe) {

    $("#d_teamspeak_user_entry_"+number).remove();
    var userEntry = $('<div id="d_teamspeak_user_entry_' + number + '" class="d_teamspeak_user_entry d_value"></div>');

    var icon_container = $('<span id="d_teamspeak_icon_container" class="d_teamspeak_icon_container"></span>')
    userEntry.append(icon_container);
    
    var user_name = $(' <span id="d_teamspeak_my_user_name" class="d_value d_teamspeak_username">' + client.nickname + '</span>')
    userEntry.append(user_name);
    
    switch (client.client_status) {
        case 'away':
            break;
        case 'speaker_muted':
            var icon = $('<svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 512 512" class="d_teamspeak_icon_speaker d_teamspeak_icon"><path class="path1" d="M480 704c88.366 0 160-71.634 160-160v-384c0-88.366-71.634-160-160-160s-160 71.634-160 160v384c0 88.366 71.636 160 160 160zM704 448v96c0 123.71-100.29 224-224 224-123.712 0-224-100.29-224-224v-96h-64v96c0 148.238 112.004 270.3 256 286.22v129.78h-128v64h320v-64h-128v-129.78c143.994-15.92 256-137.982 256-286.22v-96h-64z"></path></svg>');
            icon_container.append(icon);
            break;
        case 'mic_muted':
            var icon = $('<svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 1024 1024" class="d_teamspeak_icon_muted d_teamspeak_icon"><path class="path1" d="M480 704c88.366 0 160-71.634 160-160v-384c0-88.366-71.634-160-160-160s-160 71.634-160 160v384c0 88.366 71.636 160 160 160zM704 448v96c0 123.71-100.29 224-224 224-123.712 0-224-100.29-224-224v-96h-64v96c0 148.238 112.004 270.3 256 286.22v129.78h-128v64h320v-64h-128v-129.78c143.994-15.92 256-137.982 256-286.22v-96h-64z"></path></svg>');
            icon_container.append(icon);
            break;
        case 'normal':
            var icon = $('<svg xmlns="http://www.w3.org/2000/svg" viewBox="-10 -10 110 110" class="d_teamspeak_icon_normal d_teamspeak_icon"><circle cx="50" cy="50" r="38" /></svg>');
            icon_container.append(icon);
            if (client.isTalking === true) {
                icon.css("fill", "aqua");
            } else {
                icon.css("fill", "");
            }
            break;
    }
   

    if (isMe) {
        if (userContainer.find("#d_teamspeak_user_entry_1").size() == 0) {
            userContainer.append(userEntry);
        } else {
            userEntry.insertBefore(userContainer.find("#d_teamspeak_user_entry_1"));
        }
    } else {
        userContainer.append(userEntry);
    }
    /*
    if (teamspeak_data.myClient.client_status == "speaker_muted") {
        $("#d_teamspeak_user_icon_0 .d_teamspeak_icon_normal").hide();
        $("#d_teamspeak_user_icon_0 .d_teamspeak_icon_muted").hide();
        $("#d_teamspeak_user_icon_0 .d_teamspeak_icon_speaker").show();

    } else if (teamspeak_data.myClient.client_status == "mic_muted") {
        $("#d_teamspeak_user_icon_0 .d_teamspeak_icon_normal").hide();
        $("#d_teamspeak_user_icon_0 .d_teamspeak_icon_muted").show();
        $("#d_teamspeak_user_icon_0 .d_teamspeak_icon_speaker").hide();

    } else {
        $("#d_teamspeak_user_icon_0 .d_teamspeak_icon_muted").hide();
        $("#d_teamspeak_user_icon_0 .d_teamspeak_icon_normal").show();
        $("#d_teamspeak_user_icon_0 .d_teamspeak_icon_speaker").hide();
        //no status
        //show normal
        if (teamspeak_data.myClient.isTalking === true) {
            $("#d_teamspeak_user_entry_0 .d_teamspeak_icon_normal").css("fill", "aqua");
        } else {
            $("#d_teamspeak_user_entry_0 .d_teamspeak_icon_normal").css("fill", "");
        }
    }
    */

}
