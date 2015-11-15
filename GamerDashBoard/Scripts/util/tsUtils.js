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

    $("#d_teamspeak_user_entry_" + number).remove();
    var userEntry = $('<div id="d_teamspeak_user_entry_' + number + '" class="d_teamspeak_user_entry d_value"></div>');

    var icon_container = $('<span id="d_teamspeak_icon_container" class="d_teamspeak_icon_container"></span>')
    userEntry.append(icon_container);

    var nickname = client.nickname.replace(/\\s/g, " ")

    var user_name = $(' <span id="d_teamspeak_my_user_name" class="d_value d_teamspeak_username">' + nickname + '</span>')
    user_name.css("color", "rgb(" + config.styleconig.color_r + "," + config.styleconig.color_g + "," + config.styleconig.color_b + ")");
    userEntry.append(user_name);

    switch (client.client_status) {
        case 'away':
            var icon = $('<svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 200 200" class="d_teamspeak_icon_speaker d_teamspeak_icon"><line x1="0" y1="0" x2="200" y2="200"/><line x1="0" y1="200" x2="200" y2="0"/><line x1="0" y1="100" x2="200" y2="100"/><line x1="0" y1="200" x2="200" y2="0"/></svg>');
            icon.css("stroke", "rgb(" + config.styleconig.color_r + "," + config.styleconig.color_g + "," + config.styleconig.color_b + ")");
            icon_container.append(icon);
            break;
        case 'speaker_muted':
            var icon = $('<svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 200 200" class="d_teamspeak_icon_speaker d_teamspeak_icon"><line x1="0" y1="0" x2="200" y2="200"/><line x1="0" y1="200" x2="200" y2="0"/></svg>');
            icon.css("stroke", "rgb(" + config.styleconig.color_r + "," + config.styleconig.color_g + "," + config.styleconig.color_b + ")");
            icon_container.append(icon);
            break;
        case 'mic_muted':
            var icon = $('<svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 200 200" class="d_teamspeak_icon_muted d_teamspeak_icon"><line x1="0" y1="100" x2="200" y2="100"/></svg>');
            icon.css("stroke", "rgb(" + config.styleconig.color_r + "," + config.styleconig.color_g + "," + config.styleconig.color_b + ")");
            icon_container.append(icon);
            break;
        case 'normal':
            var icon = $('<svg xmlns="http://www.w3.org/2000/svg" viewBox="-10 -10 110 110" class="d_teamspeak_icon_normal d_teamspeak_icon"><circle cx="50" cy="50" r="38" /></svg>');
            icon.css("stroke", "rgb(" + config.styleconig.color_r + "," + config.styleconig.color_g + "," + config.styleconig.color_b + ")");
            icon_container.append(icon);
            if (client.isTalking === true) {
                icon.css("fill", "rgb(" + config.styleconig.color_r + "," + config.styleconig.color_g + "," + config.styleconig.color_b + ")");
                icon.css("fill-opcapity","1")
            } else {
                icon.css("fill", "");
                icon.css("fill-opcapity", "0")
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
}
