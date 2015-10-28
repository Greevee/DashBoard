using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using TeamSpeakClientMonitor.objects;

namespace TeamSpeakClientMonitor
{
    public class TeamSpeakClientMonitor
    {

        private string host = "localhost";
        private int port = 25639;
        TelnetConnection tc;

        private string channelD { set;  get; }
        private string clientID { set;  get; }

        public TSChannel myChannel { set; get; }
        public TSClient me { set;  get; }

        public TeamSpeakClientMonitor(string host, int port)
        {
            this.host = host;
            this.port = port;

        }

        public TeamSpeakClientMonitor()
        {
        }

        public void Connect()
        {
            tc = new TelnetConnection(host, port);
            string response = tc.Read();
            Whoami();
        }


        private void Whoami()
        {
            String cmd = "whoami";
            tc.WriteLine(cmd);
            string response = tc.Read();
            if (IsError(response))
            {
                throw new TeamSpeakClientMonitorException("Connection failed");
            }
            else
            {
                clientID = GetParamFromString(response, "clid");
                channelD = GetParamFromString(response, "cid");
            }
        }

        public void RefreshClient()
        {
            Whoami();
            //creaty me
            me = GetClientInfo(clientID);
            myChannel = GetChannelInfo(channelD);

        }

        private TSChannel GetChannelInfo(string channelID)
        {
            String cmd = "channelclientlist cid=" + channelID;
            tc.WriteLine(cmd);
            string response = tc.Read();
            if (IsError(response))
            {
                throw new TeamSpeakClientMonitorException("Command failed");
            }
            else
            {
                TSChannel channel = new TSChannel(channelID);
                channel.clients = new Dictionary<string, TSClient>();
                string[] users = response.Split('|');
                foreach(string user in users)
                {
                    string uId=GetParamFromString(user, "clid");
                    if(uId != me.id)
                    {
                        //if its not me
                        channel.clients.Add(uId, GetClientInfo(uId));
                    }
                   
                }
                return channel;

            }
        }

        private TSClient GetClientInfo(string clientID)
        {
            String cmd = "clientvariable clid="+clientID+" client_input_muted client_output_muted client_away client_nickname";
            tc.WriteLine(cmd);
            string response = tc.Read();
            if (IsError(response))
            {
                throw new TeamSpeakClientMonitorException("Command failed");
            }
            else
            {
                string nickname = GetParamFromString(response, "client_nickname");
                TSClient client = new TSClient(nickname);
                client.id = clientID;

                string client_input_muted = GetParamFromString(response, "client_input_muted");
                string client_output_muted = GetParamFromString(response, "client_output_muted");
                string client_away = GetParamFromString(response, "client_away");
                if (client_away == "1")
                {
                    client.state = TSClient.ClientState.away;
                }
                else if(client_output_muted=="1")
                {
                    client.state = TSClient.ClientState.soundmuted;
                }
                else if (client_input_muted == "1")
                {
                    client.state = TSClient.ClientState.micmuted;
                }
                else
                {
                    client.state = TSClient.ClientState.normal;
                }
                return client;

            }
        }


        private string GetParamFromString(string response, string parameter)
        {
            Regex regex = new Regex(parameter + @"=([^\s-]*)");
            Match match = regex.Match(response);
            if (match.Success)
            {
                return match.Groups[1].Value;

            }
            else
            {
                return "";
            }
        }

        private bool IsError(string response)
        {
            Regex regex = new Regex("msg=ok");
            Match match = regex.Match(response);
            if (match.Success)
            {
                return false;
            }
            else
            {
                return true;
            }
        }


    }
}
