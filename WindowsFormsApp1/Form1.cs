﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PuppeteerSharp;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public static Boolean zhaodaole ;
        public Form1()
        {
            InitializeComponent();
            
            Start();
            //实例化Timer类，设置间隔时间为10000毫秒；
            // System.Timers.Timer t = new System.Timers.Timer(3000);
            // t.Elapsed += new System.Timers.ElapsedEventHandler(Start());
            // t.AutoReset = true;//设置是执行一次（false）还是一直执行(true)；
            // t.Enabled = true;//是否执行System.Timers.Timer.Elapsed事件；
        }
        public  static async  Task  Start()
        {
            var browser = await Puppeteer.LaunchAsync(new LaunchOptions
            {
                Headless = false,
                ExecutablePath = @"C:\Program Files (x86)\Microsoft\Edge\Application\msedge.exe",
            });
            var page =await   browser.NewPageAsync();
            await page.GoToAsync("https://www.ztzy.com/NewsList-28.html");
            await page.WaitForSelectorAsync(".list2");
            // 获取所有匹配的 .list2 li 元素
            var listItemElements = await page.QuerySelectorAllAsync(".list2 li a");
            List<string> hrefList = new List<string>(); // 创建一个列表来存放 href

            foreach (var listItem in listItemElements)
            {
                var hasHref = await listItem.EvaluateFunctionAsync<bool>("(element) => element.hasAttribute('href')");
                if (hasHref)
                {
                    var href = await listItem.EvaluateFunctionAsync<string>("(element) => element.getAttribute('href')");
                    Console.WriteLine(href);
                    hrefList.Add(href); // 将 href 添加到列表中
                }
            }
            
            foreach (var href in hrefList)
            {
                await page.GoToAsync("https://www.ztzy.com/"+href);
                await page.WaitForTimeoutAsync(1000);
                var content = await page.GetContentAsync();
                
                
                string[] ab = new string[]
                { 
                    "郑州天之同昌商贸有限公司",
                    "防雷检测",
                    "防雷装置",
                    "雷电检测"
                };
                foreach (var VARIABLE in ab)
                {
                    if (content.Contains(VARIABLE))
                    {
                        Console.WriteLine("找到了");
                        
                        // SendEmail("https://www.ztzy.com/"+href);
                        await browser.CloseAsync();
                    }
                }
            }
            await browser.CloseAsync();

        }
        static void SendEmail(string str)
        {
            //设置发送方邮件信息，例如：qq邮箱
            string stmpServer = @"smtp.qq.com";//smtp服务器地址
            string mailAccount = @"1241639333@qq.com";//邮箱账号
            string pwd = @"xuwhkreirlxbgjej";//邮箱密码（qq邮箱此处使用授权码，其他邮箱见邮箱规定使用的是邮箱密码还是授权码）
            
            // string mailTo = @"xcryxiqzzasaebbe";//邮箱密码（qq邮箱此处使用授权码，其他邮箱见邮箱规定使用的是邮箱密码还是授权码）

            //邮件服务设置
            SmtpClient smtpClient = new SmtpClient();
            smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;//指定电子邮件发送方式
            smtpClient.Host = stmpServer;//指定发送方SMTP服务器
            smtpClient.EnableSsl = true;//使用安全加密连接
            smtpClient.UseDefaultCredentials = true;//不和请求一起发送
            smtpClient.Credentials = new NetworkCredential(mailAccount, pwd);//设置发送账号密码

            MailMessage mailMessage = new MailMessage(mailAccount, "1241639333@qq.com");//实例化邮件信息实体并设置发送方和接收方
            mailMessage.Subject = "找到了";//设置发送邮件得标题
            mailMessage.Body =str;//设置发送邮件内容
            mailMessage.BodyEncoding = Encoding.UTF8;//设置发送邮件得编码
            mailMessage.IsBodyHtml = false;//设置标题是否为HTML格式
            mailMessage.Priority = MailPriority.Normal;//设置邮件发送优先级

            try
            {
                smtpClient.Send(mailMessage);//发送邮件
           
            }
            catch (SmtpException ex)
            {
                throw ex;
            }
 
        }
        
        
        
        private void label1_Click(object sender, EventArgs e)
        {
            throw new System.NotImplementedException();
        }

        private void label1_Click_1(object sender, EventArgs e)
        {
            throw new System.NotImplementedException();
        }

        private void label1_Click_2(object sender, EventArgs e)
        {
           
        }
    }
}