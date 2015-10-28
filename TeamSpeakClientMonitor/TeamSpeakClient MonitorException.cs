using System;

namespace TeamSpeakClientMonitor
{
    class TeamSpeakClientMonitorException:Exception
    {
        public TeamSpeakClientMonitorException()
        {

        }

        public TeamSpeakClientMonitorException(string message)
       : base(message)
        {
        }
           
    }
}
