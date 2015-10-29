using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using TS3Connection.objects;
using TS3Connection.messages;

namespace TS3Connection.util
{
    public class Utils
    {
        public static string GetParamFromString(string response, string parameter)
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

        public static void updateClient(Client client, string updateMessage)
        {
            foreach(Notification.ClientUpdateType updateType in Enum.GetValues(typeof(Notification.ClientUpdateType)))
            if (updateMessage.Contains(updateType.ToString()))
            {
                client.client_input_muted= GetParamFromString(updateMessage, updateType.ToString());
                    client.CalcStatus();
                    break;
            }
        }
    }
}
