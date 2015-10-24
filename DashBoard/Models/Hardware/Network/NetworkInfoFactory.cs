using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DashBoard.Models.Hardware.Network
{
    public class NetworkInfoFactory
    {
        NetworkInfoService networkService = new NetworkInfoService();

        public NetworkInfo GetNetworkInfo()
        {
            NetworkInfo networkInfo = new NetworkInfo();
            networkInfo.kbitIn = networkService.GetKBitInPerSec();
            networkInfo.kbitOut = networkService.GetKBitOutPerSec();
            return networkInfo;
        }

        public void ChangeNetworkInterface(string InterfaceName)
        {
            networkService = new NetworkInfoService(InterfaceName);
        }
    }
}
