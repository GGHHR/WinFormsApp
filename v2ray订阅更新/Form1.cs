﻿using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace v2ray订阅更新
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            
            InitializeComponent();
            
            string defaultValue = Properties.Settings.Default.DefaultValue;

            // 将默认值设置为输入框的值
            textBox1.Text = defaultValue; 
            this.Load += Form1_Load;
        } 
        public string GetOutputTextBoxValue()
        {
            return textBox1.Text;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            LoadDataAndExitAsync();
        }
        private async void LoadDataAndExitAsync()
        {
            await Task.Run(async () =>
            { 
                // 进来是列表的那种
                await new Sub_get().start("https://nodefree.org/", ".item-title a", ".section p","a1","1");
                await new Sub_get().start("https://clashnode.com/", "[cp-post-title] a", ".post-content-content h2+p+p+p","a2","2");
                await new Sub_get().start("https://v2cross.com/", ".entry-title a", ".entry-content h5","a3","3");
                await new Sub_get().start("https://clashgithub.com/", "[itemprop=\"name headline\"] a", ".article-content p:nth-child(11)","a4","4");
                await new Sub_get().start("https://www.iyio.net/", ".column article:nth-child(4) a", "pre","a5","5");
                await new Sub_get().start("https://kkzui.com/", ".row  .url-card:last-child a", ".panel-body p:nth-child(7)","a6","6");
            });
            
            
             await Task.Run(async () =>
            { 
                // 进来直接找链接
                await new Sub_get1().start("https://wanshanziwo.eu.org/", ".is-fullwidth tr:nth-child(3) td","b1","1000");
            });

            // 关闭应用程序
            Application.Exit();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            // 获取用户修改后的输入框值
            string modifiedValue = textBox1.Text;
            // 将值保存到配置文件
            Properties.Settings.Default.DefaultValue = modifiedValue;
            Properties.Settings.Default.Save();

        }
    }
}