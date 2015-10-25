using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DashBoard.Models.Hardware.CPU
{
    class CPUInfoService
    {

        private PerformanceCounterCategory performanceCountercategory = new PerformanceCounterCategory("Processor Information");
        private PerformanceCounter performanceCounter = new PerformanceCounter("Processor Information", "% Processor Time");
        private string[] instances;
        Dictionary<string, CounterSample> counterSampleMap = new Dictionary<string, CounterSample>();

        public CPUInfoService()
        {
            instances = performanceCountercategory.GetInstanceNames();

            foreach (string instanceName in instances)
            {
                performanceCounter.InstanceName = instanceName;
                counterSampleMap.Add(instanceName, performanceCounter.NextSample());
            }
        }

        public static Double Calculate(CounterSample oldSample, CounterSample newSample)
        {
            double difference = newSample.RawValue - oldSample.RawValue;
            double timeInterval = newSample.TimeStamp100nSec - oldSample.TimeStamp100nSec;
            if (timeInterval != 0) return 100 * (1 - (difference / timeInterval));
            return 0;
        }


        public Dictionary<string, float> GetCPULoadMap()
        {
            Dictionary<string, float> cpuLoadMap = new Dictionary<string, float>();
            foreach (string instanceName in instances)
            {
                performanceCounter.InstanceName = instanceName;
                cpuLoadMap.Add(instanceName,  (float)Calculate(counterSampleMap[instanceName], performanceCounter.NextSample()));
                counterSampleMap[instanceName] = performanceCounter.NextSample();
            }
            return cpuLoadMap;
        }

    }     
}
