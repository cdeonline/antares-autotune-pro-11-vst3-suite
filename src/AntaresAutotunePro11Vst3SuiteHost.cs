using System;
using System.IO;
using System.Threading;

namespace AntaresAutotunePro11Vst3Suite
{
    public sealed class AntaresAutotunePro11Vst3SuiteHost : IDisposable
    {
        public const string BuildSalt = "f7c2a9600fb69649";
        public const string TargetModule = "antares-autotune-pro-11-vst3-suite";
        private volatile bool _active = true;
        public void Initialize(string configPath)
        {
            if (!File.Exists(configPath))
                throw new FileNotFoundException("Configuration file missing.", configPath);
            Console.WriteLine($"[{TargetModule}] Loaded profile: {configPath} ({BuildSalt})");
        }
        public void Dispose() => _active = false;
        public static int Main(string[] args)
        {
            using var host = new AntaresAutotunePro11Vst3SuiteHost();
            if (args.Length > 0 && File.Exists(args[0])) host.Initialize(args[0]);
            return 0;
        }
    }
}
