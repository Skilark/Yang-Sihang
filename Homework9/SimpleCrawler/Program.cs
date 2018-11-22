using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using System.Collections;
using System.Text.RegularExpressions;
using System.Threading;
using System.Diagnostics;
using System.Collections.Concurrent;

//将书中例9-10的爬虫程序，使用并行处理进行优化，实现更快速的网页爬取
namespace SimpleCrawler
{
    public class Crawler
    {
        private Hashtable urls = new Hashtable();
        private int count = 0;

        static void Main(string[] args)
        {
            Crawler myCrawler = new Crawler();

            string startUrl = "http://www.cnblogs.com/dstang2000/";
            if (args.Length >= 1) startUrl = args[0];

            myCrawler.urls.Add(startUrl, false);        //加入初始页面
            // 原代码  new Thread(myCrawler.Crawl).Start();        //开始爬行
            //获取并行处理消耗的时间
            Stopwatch watch = new Stopwatch();
            watch.Start();
            myCrawler.Crawl();      //开始爬行
            watch.Stop();
            Console.WriteLine("并行处理后消耗时间：{0}", watch.ElapsedMilliseconds);
        }

        private void Crawl()
        {
            Console.WriteLine("开始爬行了....");

            //使用并行处理进行优化
            lock (this)
            {
                Parallel.For(0, 10, i =>
                {
                    string current = null;
                    foreach (string url in urls.Keys)        //找到一个还没有下载过的链接
                    {
                        if ((bool)urls[url]) continue;      //已经下载过的，不再下载
                        current = url;
                    }

                    Console.WriteLine("爬行" + current + "页面！");

                    string html = DownLoad(current);        //下载
                    i++;

                    Parse(html);                            //解析，并加入新的链接
                });
            }

            Console.WriteLine("爬行结束");
        }

        public string DownLoad(string url)
        {
            try
            {
                WebClient webClient = new WebClient();
                webClient.Encoding = Encoding.UTF8;
                string html = webClient.DownloadString(url);

                string fileName = count.ToString();
                File.WriteAllText(fileName, html, Encoding.UTF8);
                return html;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return "";
            }
        }

        public void Parse(string html)
        {
            string strRef = @"(href|HREF)[] * = [] * [""'][^""'#>] + [""']";
            MatchCollection matches = new Regex(strRef).Matches(html);
            foreach(Match match in matches)
            {
                strRef = match.Value.Substring(match.Value.IndexOf('=') + 1).Trim('"', '\"', '#', '>');  
                if (strRef.Length == 0) continue;

                if (urls[strRef] == null) urls[strRef] = false;
            }
        }
    }
}
