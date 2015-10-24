using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DashBoard.Models.Hardware.Network
{
    public class NetworkInfo : IHardwareInfo
    {
        public float kbitIn { get; set; }
        public float kbitOut { get; set; }

        public NetworkInfo()
        {

        }

        public NetworkInfo(float kbitIn,float kbitOut)
        {
            this.kbitIn = kbitIn;
            this.kbitOut = kbitOut;
        }

    }
}
