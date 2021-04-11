using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace container_sysinfo.Data
{
    public class SysInfoService
    {
        public SysInfo GetSysInfo()
        {
            var sysInfo = new SysInfo();
            sysInfo.EnvVariables = new List<string>();
            foreach (DictionaryEntry de in Environment.GetEnvironmentVariables())
                sysInfo.EnvVariables.Add($"{de.Key} = {de.Value}");
            sysInfo.EnvVariables.Sort();

            sysInfo.FrameworkDescription = RuntimeInformation.FrameworkDescription;
            sysInfo.RuntimeIdentifier = RuntimeInformation.RuntimeIdentifier;

            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                var ramCounter = new PerformanceCounter("Memory", "Available MBytes");
                sysInfo.AvailableMBytesMemory = (int)ramCounter.NextValue();
            }

            return sysInfo;
        }
    }
}
