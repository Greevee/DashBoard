using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TS3Connection.objects
{

    public enum clientState
    {
        normal,
        mic_muted,
        speaker_muted,
        away
    }

    public class Client
    {
        public string id { get; set; }
        public string nickname { get; set; }
        public clientState state { get; set; }
        public bool isTalking { get; set; }

        public string client_input_muted { get; set; }
        public string client_output_muted { get; set; }
        public string client_away { get; set; }

        public string client_status { get; set; }


        public Client(string id)
        {
            this.id = id;
            this.isTalking = false;
            this.client_input_muted = "0";
            this.client_output_muted = "0";
            this.client_away = "0";
            this.client_status = clientState.normal.ToString();
            }

        public void CalcStatus()
        {
            if (this.client_away == "1")
            {
                this.state = clientState.away;
                client_status = clientState.away.ToString();
                return;
            }
            if (this.client_output_muted == "1")
            {
                this.state = clientState.speaker_muted;
                client_status = clientState.speaker_muted.ToString();
                return;
            }
            if (this.client_input_muted == "1")
            {
                this.state = clientState.mic_muted;
                client_status = clientState.mic_muted.ToString();
                return;
            }
            client_status = clientState.normal.ToString();
        }

    }


}
