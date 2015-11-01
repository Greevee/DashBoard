using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TS3Connection;

namespace GamerDashBoard.Models.TeamSpeak
{
    public class TeamSpeakInfoFactory
    {
        private Thread t;
        private TSConnection ts3;


        public TeamSpeakInfoFactory(TSConnection ts3)
        {
            this.ts3 = ts3;
        }

        public TeamSpeakInfo GetTeamSpeakInfo()
        {
            TeamSpeakInfo tsinfo = new TeamSpeakInfo();
            tsinfo.myClient = GetClientInfo(ts3.myClient);
            tsinfo.myChannel = GetChannelInfo(ts3.myChannel);

            return tsinfo;
        }

        private TeamSpeak.TeamSpeakChannelInfo GetChannelInfo(TS3Connection.objects.Channel ts3Chanel)
        {
            TeamSpeakChannelInfo channelInfo = new TeamSpeakChannelInfo();
            channelInfo.id = ts3Chanel.id;
            channelInfo.name = ts3Chanel.name;
            channelInfo.clients = new Dictionary<string, TeamSpeakClientInfo>();
            foreach(KeyValuePair < string,TS3Connection.objects.Client> entry in ts3Chanel.clients)
            {
                channelInfo.clients.Add(entry.Key, GetClientInfo(entry.Value));
            }

            return channelInfo;
        }

        private TeamSpeak.TeamSpeakClientInfo GetClientInfo(TS3Connection.objects.Client ts3Client)
        {
            TeamSpeakClientInfo clientInfo = new TeamSpeakClientInfo();
            clientInfo.nickname = ts3Client.nickname;
            clientInfo.id = ts3Client.id;
            clientInfo.client_status = ts3Client.client_status;
            clientInfo.isTalking = ts3Client.isTalking;

            return clientInfo;
        }
    }
}
