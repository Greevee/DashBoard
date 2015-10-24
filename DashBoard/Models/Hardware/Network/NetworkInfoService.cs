using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace DashBoard.Models.Hardware.Network
{
    public class NetworkInfoService
    {
        private string usedInterface = "Realtek PCIe GBE Family Controller";
        private PerformanceCounterCategory performanceCounterCategory = new PerformanceCounterCategory("Network Interface");
        private PerformanceCounter performanceCounterSent;
        private PerformanceCounter performanceCounterReceived;


        /// <summary>
        /// Creates a service that reads in and out of a specific network interface
        /// </summary>
        public NetworkInfoService()
        {
            Setup();

        }
        public NetworkInfoService(string networkInterface)
        {
            this.usedInterface = networkInterface;
            Setup();
        }

        private void Setup()
        {
            string[] instances = performanceCounterCategory.GetInstanceNames();
            foreach (string networkInterface in instances)
            {
                if (networkInterface == usedInterface)
                {
                    performanceCounterSent = new PerformanceCounter("Network Interface", "Bytes Sent/sec", networkInterface);
                    performanceCounterReceived = new PerformanceCounter("Network Interface", "Bytes Received/sec", networkInterface);
                }
            }
        }

        public float GetKBitInPerSec()
        {
            return performanceCounterReceived.NextValue() / 1000;
        }

        public float GetKBitOutPerSec()
        {
            return performanceCounterSent.NextValue() / 1000;
        }
    }
}
