using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TeamSpeakClientMonitor
{
    public class TeamSpeakClientMonitor
    {

        enum ClientState
        {
            normal,
            micmuted,
            soundmuted,
            away
        };

        private string host = "localhost";
        private int port = 25639;
        TelnetConnection tc;

        string channelD = "";
        string clientID = "";

        public TeamSpeakClientMonitor(string host, int port)
        {
            this.host = host;
            this.port = port;

        }

        public

        public TeamSpeakClientMonitor()
        {
        }

        public void connect()
        {
            tc = new TelnetConnection(host, port);
            string response = tc.Read();
            whoami();
        }


        private void whoami()
        {
            String cmd = "whoami";
            tc.WriteLine(cmd);
            string response = tc.Read();
            if (isError(response))
            {
                throw new TeamSpeakClientMonitorException("Connection failed");
            }
            else
            {
                clientID = getParamFromString(response, "clid");
                channelD = getParamFromString(response, "cid");
            }
        }

        public void refreshClient()
        {
            whoami();
        }



        private string getParamFromString(string response, string parameter)
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

        private bool isError(string response)
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
