using System;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using PuppeteerSharp;

namespace v2ray订阅更新
{
    public class Sub_get1
    {
        public async Task  start(string url,string el,string remarks,string id)
        {
            var browser = await Puppeteer.LaunchAsync(new LaunchOptions
            {
                Headless = false,
                ExecutablePath = @"C:\Program Files (x86)\Microsoft\Edge\Application\msedge.exe",
            });
            var page = await browser.NewPageAsync(); 
            await page.GoToAsync(url,new NavigationOptions { Timeout = 99999 }); 
            
            await page.WaitForSelectorAsync(el, new WaitForSelectorOptions{Timeout = 99999});
            
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