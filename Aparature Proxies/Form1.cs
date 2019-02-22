using Aparature_Proxies.Core.Checking;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Aparature_Proxies.Core.Stats;
using System.Diagnostics;

namespace Aparature_Proxies
{
    public partial class mainFrm : Form
    {
        public mainFrm()
        {
            InitializeComponent();
        }

        public class ACallbackResult
        {
            public Stopwatch watch { get; set; }
            public HttpWebRequest result { get; set; }
            public Tuple<string, int> proxy { get; set; }
        }

        public void RequestCallback(IAsyncResult result)
        {
            ACallbackResult res = (result.AsyncState as ACallbackResult);
            try
            {
                HttpWebResponse response = (res.result as HttpWebRequest).EndGetResponse(result) as HttpWebResponse;
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    res.watch.Stop();
                    StatsInfo.TotalStats.GoodProxies.Add(new StatsInfo.Proxy()
                    {
                        IP = res.proxy.Item1,
                        Port = res.proxy.Item2,
                        MS = res.watch.ElapsedMilliseconds,
                    });
                    StatsInfo.TotalStats.Success++;
                }
            }
            catch
            {
                StatsInfo.TotalStats.Failed++;
            }
            finally
            {
                try
                {
                    int progress = (int)((double)StatsInfo.TotalStats.CurrentTotal / (double)StatsInfo.TotalStats.Total * 100);
                    if (worker != null && worker.IsBusy)
                    {
                        worker.ReportProgress(percentProgress: progress);
                    }
                }
                catch
                {

                }
            }
        }

        public BackgroundWorker worker = new BackgroundWorker();

        private void Btn_StartChecking_Click(object sender, EventArgs e)
        {
            worker.DoWork += Worker_DoWork;
            worker.WorkerReportsProgress = true;
            worker.ProgressChanged += Worker_ProgressChanged;
            worker.RunWorkerCompleted += Worker_RunWorkerCompleted;
            worker.RunWorkerAsync();
        }

        private void Worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            StatsInfo.TotalStats.GoodProxies.ForEach((proxy) =>
            {
                ListViewItem itm = new ListViewItem($"{proxy.IP}:{proxy.Port}");
                itm.SubItems.Add(proxy.MS.ToString());

                LV_Proxies.Items.Add(itm);
            });
        }

        private void Worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            try
            {
                PB_Status.Value = e.ProgressPercentage;
                LB_Status.Text = $"Success: {StatsInfo.TotalStats.Success} - Failed {StatsInfo.TotalStats.Failed}";
            }
            catch
            {

            }
        }

        private void Worker_DoWork(object sender, DoWorkEventArgs e)
        {
            int x = 0;
            ProxyChecker.isWorking = true;
            while (ProxyChecker.isWorking)
            {
                if (x >= ProxyChecker.Proxies.Length) { ProxyChecker.isWorking = false; return; }
                for (int threads = 0; threads < 300; threads++)
                {
                    if (x >= ProxyChecker.Proxies.Length) { ProxyChecker.isWorking = false; return; }
                    Thread th = new Thread(() =>
                    {
                        try
                        {
                            if (x >= ProxyChecker.Proxies.Length) { ProxyChecker.isWorking = false; return; }
                            int index = ++x;
                            string ip = ProxyChecker.Proxies[index].Split(':')[0];
                            int port = int.Parse(ProxyChecker.Proxies[index].Split(':')[1]);
                            if (!string.IsNullOrEmpty(ip) || port != 0)
                            {
                                WebProxy proxy = new WebProxy(ip, port);
                                HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://example.com/");
                                request.Proxy = proxy;
                                request.Method = "GET";
                                ACallbackResult res = new ACallbackResult()
                                {
                                    proxy = new Tuple<string, int>(ip, port),
                                    result = request,
                                    watch = new Stopwatch(),
                                };
                                request.BeginGetResponse(RequestCallback, res);
                                {
                                    res.watch.Start();
                                }
                            }
                        }
                        catch
                        {
                            //StatsInfo.TotalStats.Failed++;
                        }
                    });
                    th.Start();
                }
            }
        }

        private void mainFrm_Load(object sender, EventArgs e)
        {
            string pth = $"{Environment.CurrentDirectory}/proxies.txt";
            if (!File.Exists(pth)) { return; }
            ProxyChecker.LoadProxies(pth);
        }

        private void mainFrm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (ProxyChecker.isWorking) { ProxyChecker.isWorking = false; }
        }
    }
}
