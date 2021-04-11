using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace container_sysinfo.Data
{
    public class SysInfo
    {
        public List<string> EnvVariables { get; set; }
        public string RuntimeIdentifier { get; set; }
        public string FrameworkDescription { get; set; }
        public int AvailableMBytesMemory { get; set; }
    }
}