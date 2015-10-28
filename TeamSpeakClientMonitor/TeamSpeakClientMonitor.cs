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

        private TSClient myClient;


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
        }

        private string getClientInfo()
        {

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
