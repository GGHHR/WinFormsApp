using System;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using PuppeteerSharp;

namespace v2ray订阅更新
{
    public class Sub_get
    {
        public async Task  start(string url,string list_el,string el,string remarks,string id)
        {

           
            var browser = await Puppeteer.LaunchAsync(new LaunchOptions
            {
                Headless = true,
                ExecutablePath = @"C:\Program Files (x86)\Microsoft\Edge\Application\msedge.exe",
            });
            
            var page = await browser.NewPageAsync();
            
            await page.GoToAsync(url, new NavigationOptions { Timeout = 50000 }); // 设置超时时间为5秒（5000毫秒）
            await page.WaitForSelectorAsync(list_el);
            string content = await page.EvaluateFunctionAsync<string>("(selector) => { return document.querySelector(selector).href; }", list_el);
            await page.GoToAsync(content, new NavigationOptions { Timeout = 50000 });
            
            await page.WaitForSelectorAsync(el);
            
            string content1 = await page.EvaluateFunctionAsync<string>("(selector) => { return document.querySelector(selector).textContent; }", el);
            
            
            // 定义匹配URL的正则表达式模式
            string urlPattern = @"https?://[^\s/$.?#].[^\s]*";
        
            // 创建正则表达式对象
            Regex regex = new Regex(urlPattern, RegexOptions.IgnoreCase);

            // 查找匹配的链接
            MatchCollection matches = regex.Matches(content1);

            // 输出匹配的链接
            foreach (Match match in matches)
            {
                
                string convertTarget = "";
                
                if(match.Value.EndsWith("yaml"))
                {
                    convertTarget = "mixed";
                }
                Console.WriteLine($@"链接{remarks}：{match.Value}");
                
                 new UpSubItem().Up(match.Value,remarks,id,convertTarget);
                 browser.CloseAsync();
            }
            
           
            
        }
    }
}