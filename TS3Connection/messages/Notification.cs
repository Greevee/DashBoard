using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TS3Connection.messages
{
    public class Notification
    {
         public enum NotificationType
        {
            clientupdated,
            clientmoved,
            talkstatuschange,
            unknown
        }

        public enum ClientUpdateType
        {
            client_input_muted,
            client_output_muted,
            client_away
        }

        public static NotificationType GetNotificationType(string response)
        {
            if (response.StartsWith("notifyclientupdated")){
                return NotificationType.clientupdated;
            }
            return NotificationType.unknown;
        }
    }
}
