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

namespace TS3Connection
{
    public class TSConnection
    {

        public State state { get;}

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

            Console.WriteLine("Ready");
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
            Console.WriteLine(e.Value);
        }

        private void Notifications_ChannelTalkStatusChanged(object sender, TalkStatusEventArgsBase e)
        {
            Console.WriteLine(e.GetDumpString());
        }

    }
}
