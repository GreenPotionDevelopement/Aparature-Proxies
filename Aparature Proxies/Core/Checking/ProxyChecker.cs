using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aparature_Proxies.Core.Stats;

namespace Aparature_Proxies.Core.Checking
{
    class ProxyChecker
    {
        private static string[] _proxies = null;
        public static bool isWorking { get; set; } = false;

        public static string[] Proxies
        {
            get
            {
                return _proxies;
            }
            set
            {
                _proxies = value;
                if (_proxies.Length > 0)
                {
                    isProxyLoaded = true;
                    StatsInfo.TotalStats.Total = Proxies.Length;
                }
                else
                {
                    isProxyLoaded = false;
                }
            }
        }
        public static bool isProxyLoaded { get; set; } = false;
        public static void LoadProxies(string path) => Proxies = File.ReadAllLines(path);

       
    }
}
