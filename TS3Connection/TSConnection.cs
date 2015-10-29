using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

using TS3QueryLib.Core;
using TS3QueryLib.Core.Client;
using TS3QueryLib.Core.Client.Entities;
using TS3QueryLib.Core.Client.Notification.EventArgs;
using TS3QueryLib.Core.Common;
using TS3QueryLib.Core.Common.Responses;
using TS3QueryLib.Core.Communication;
using TS3Connection.objects;
using TS3Connection.util;
using TS3Connection.messages;
using TS3QueryLib.Core.Client.Responses;
using TS3QueryLib.Core.CommandHandling;

namespace TS3Connection
{
    public class TSConnection
    {

        public State state { get; set; }
        public Client myClient { get; set; }
        public Channel myChannel { get; set; }

        public AsyncTcpDispatcher QueryDispatcher { get; set; }
        public QueryRunner QueryRunner { get; set; }

        public TSConnection()
        {
            state = State.Connecting;
        }
        public void Connect()
        {
            ConnectToClient();
        }

        public void Disconnect()
        {
            DisconnectFromClient();
        }

        public void ConnectToClient()
        {
            if (QueryDispatcher != null)
                return;
            QueryDispatcher = new AsyncTcpDispatcher("localhost", 25639);
            QueryDispatcher.BanDetected += QueryDispatcher_BanDetected;
            QueryDispatcher.ReadyForSendingCommands += QueryDispatcher_ReadyForSendingCommands;
            QueryDispatcher.ServerClosedConnection += QueryDispatcher_ServerClosedConnection;
            QueryDispatcher.SocketError += QueryDispatcher_SocketError;
            QueryDispatcher.NotificationReceived += QueryDispatcher_NotificationReceived;
            QueryDispatcher.Connect();
        }

        public void DisconnectFromClient()
        {
            if (QueryRunner != null)
                QueryRunner.Dispose();
            QueryDispatcher = null;
            QueryRunner = null;
        }


        private void QueryDispatcher_ReadyForSendingCommands(object sender, System.EventArgs e)
        {
            QueryRunner = new QueryRunner(QueryDispatcher);
            QueryRunner.Notifications.ChannelTalkStatusChanged += Notifications_ChannelTalkStatusChanged;
            QueryRunner.RegisterForNotifications(ClientNotifyRegisterEvent.Any);
            this.state = State.Connected;
            setupClientAndChannel();


        }

        private void setupClientAndChannel()
        {

            WhoAmIResponse whoAmIResponse = QueryRunner.SendWhoAmI();
            myClient = getClientInfo(whoAmIResponse.ClientId.ToString());

            myChannel = new Channel(whoAmIResponse.ChannelId.ToString());
        }

        private Client getClientInfo(string id)
        {
            Client client = new Client(id);
            Command cmd = new Command("clientvariable clid=" + id + " client_input_muted client_output_muted client_away client_nickname");
            string cmdResponse = QueryRunner.SendCommand(cmd);
            client.nickname = Utils.GetParamFromString(cmdResponse, "client_nickname");

            #region Statushandling
            string client_input_muted = Utils.GetParamFromString(cmdResponse, "client_input_muted");
            string client_output_muted = Utils.GetParamFromString(cmdResponse, "client_output_muted");
            string client_away = Utils.GetParamFromString(cmdResponse, "client_away");
            if (client_away == "1")
            {
                client.state = clientState.away;
            }
            else if (client_output_muted == "1")
            {
                client.state = clientState.speaker_muted;
            }
            else if (client_input_muted == "1")
            {
                client.state = clientState.mic_muted;
            }
            else
            {
                client.state = clientState.normal;
            }
            #endregion

            return client;

        }

        private void updateMyChannel()
        {
            WhoAmIResponse whoAmIResponse = QueryRunner.SendWhoAmI();

        }




        private void QueryDispatcher_ServerClosedConnection(object sender, System.EventArgs e)
        {
            Console.WriteLine("Connection to server closed/lost.");
            DisconnectFromClient();
        }

        private void QueryDispatcher_BanDetected(object sender, EventArgs<SimpleResponse> e)
        {
            Console.WriteLine(string.Format("You're account was banned!\nError-Message: {0}\nBan-Message:{1}", e.Value.ErrorMessage, e.Value.BanExtraMessage));
            DisconnectFromClient();
        }

        private void QueryDispatcher_SocketError(object sender, SocketErrorEventArgs e)
        {
            if (e.SocketError == SocketError.ConnectionReset)
                return;
            Console.WriteLine("Socket error!! Error Code: " + e.SocketError);
            DisconnectFromClient();
        }

        private void QueryDispatcher_NotificationReceived(object sender, EventArgs<string> e)
        {
            switch (Notification.GetNotificationType(e.Value))
            {
                case Notification.NotificationType.clientupdated:
                    Client client = getClient(Utils.GetParamFromString(e.Value, "clid"));
                    if (client != null)
                    {
                        Utils.updateClient(client, e.Value);
                    }
                    break;
            }

        }


        private Client getClient(string id)
        {
            if (myClient != null)
            {
                if (myClient.id == id)
                {
                    return myClient;
                }
            }
            if (myChannel != null)
            {
                if (myChannel.clients.ContainsKey(id))
                {
                    return myChannel.clients[id];
                }
            }
            return null;
        }


        private void Notifications_ChannelTalkStatusChanged(object sender, TalkStatusEventArgsBase e)
        {
            Console.WriteLine(e.GetDumpString());
        }

    }
}
