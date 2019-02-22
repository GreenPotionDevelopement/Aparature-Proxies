using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aparature_Proxies.Core.Stats
{
   public class StatsInfo
    {
        public static Stats TotalStats = new Stats();

        public class Stats
        {
            public int Success { get; set; } = 0;
            public int Failed { get; set; } = 0;
            public int Total { get; set; } = 0;
            public int CurrentTotal => Success + Failed;

            public List<Proxy> GoodProxies = new List<Proxy>();
        }

        public class Proxy
        {
            public string IP { get; set; }
            public int Port { get; set; }
            public long MS { get; set; }
        }
    }
}
