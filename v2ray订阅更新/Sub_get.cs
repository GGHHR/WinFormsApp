using System;
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
            await page.GoToAsync(url);
            await page.WaitForSelectorAsync(list_el);
            string content = await page.EvaluateFunctionAsync<string>("(selector) => { return document.querySelector(selector).href; }", list_el);
            await page.GoToAsync(content);
            
            await page.WaitForSelectorAsync(el);
            string content1 = await page.EvaluateFunctionAsync<string>("(selector) => { return document.querySelector(selector).textContent; }", el);
            Console.WriteLine("标签中的内容：" + content1);
            browser.CloseAsync();
            
            new UpSubItem().Up(content1,remarks,id);
        }
    }
}