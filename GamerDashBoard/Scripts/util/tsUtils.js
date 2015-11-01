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

function renderClient(userContainer, number, client, isMe) {

    $("#d_teamspeak_user_entry_"+number).remove();
    var userEntry = $('<div id="d_teamspeak_user_entry_' + number + '" class="d_teamspeak_user_entry d_value">'+client.nickname+'</div>');


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
