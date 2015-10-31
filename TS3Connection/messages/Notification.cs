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
            channeledited,
            unknown
        }

        public enum ClientUpdateType
        {
            client_input_muted,
            client_output_muted,
            client_away
        }

        public enum ChannelEdited
        {
            reasonid
        }

        public static NotificationType GetNotificationType(string response)
        {
            if (response.StartsWith("notifyclientupdated")){
                return NotificationType.clientupdated;
            }
            if (response.StartsWith("notifytalkstatuschange"))
            {
                return NotificationType.talkstatuschange;
            }
            if (response.StartsWith("notifyclientmoved"))
            {
                return NotificationType.clientmoved;
            }
            return NotificationType.talkstatuschange;
        }

        public enum TalkStatusChanceType
        {
            status
        }
    }
}
