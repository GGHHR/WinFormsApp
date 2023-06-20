using PuppeteerSharp;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace v2rayn
{
     class Page
    {
        public int pagenum;
        public Form1 Form1;
        public Page(Form1 FormForm)
        {
            this.Form1 = FormForm;
        }
        public async Task<List<string>> Start(int pageNum )
        { 
            var browser = await Puppeteer.LaunchAsync(new LaunchOptions
            {
                Headless = true,
                ExecutablePath = @"C:\Program Files (x86)\Microsoft\Edge\Application\msedge.exe",
            });

            var allMatches = new List<string>(); // List to store all the matches

            for (int currentPage = 1; currentPage <= pageNum; currentPage++)
            {
                var page = await browser.NewPageAsync();

                this.Form1.Label2Text =  "正在加载第"+ currentPage+"页";
               
                await page.GoToAsync($"https://github.com/search?q=节点&type=repositories&s=updated&o=desc&p={currentPage}");

                await page.WaitForSelectorAsync("a[class='v-align-middle']");

                var elements = await page.QuerySelectorAllAsync("span[class='search-match']");

                if (elements.Length == 0)
                {
                    elements = await page.QuerySelectorAllAsync("a[class='v-align-middle']");
                }

                var content = await Task.WhenAll(elements.Select(element => element.EvaluateFunctionAsync<string>("e => 'https://github.com/' + e.innerText")));

                
                // Write the content to a text file
                foreach (var element in content)
                {  
                    this.Form1.Label2Text = "正在加载 : " + element;

                    await page.GoToAsync(element);
                    var el = await page.QuerySelectorAllAsync("div[id='readme']");
                    foreach (var divElement in el)
                    {
                        var innerText = await divElement.EvaluateFunctionAsync<string>("e => e.innerText");
                        var regex = new Regex(@"\b(?:https?://|www\.)\S+\.yaml\b");
                        var matches = regex.Matches(innerText);

                        foreach (Match match in matches)
                        {
                            this.Form1.Addlist = match.Value; 
                            allMatches.Add(match.Value); // Store the match in the list
                        }
                    }
                }

                await page.CloseAsync();
            }

            await browser.CloseAsync();

            this.Form1.Label2Text = "加载完毕";
            File.AppendAllLines("I.txt", allMatches);
            return allMatches;
        }

    }
}
