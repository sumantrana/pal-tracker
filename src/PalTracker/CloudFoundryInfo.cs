

namespace PalTracker
{

    public class CloudFoundryInfo {

        public string Port { get; }
        public string MemoryLimit { get; }

        public string CfInstanceIndex { get; }

        public string CfInstanceAddr { get; }

        public CloudFoundryInfo ( string port, string memoryLimit, string instanceIndex, string instanceAddr ){
            Port = port;
            MemoryLimit = memoryLimit;
            CfInstanceIndex = instanceIndex;
            CfInstanceAddr = instanceAddr;
        }

    }
}