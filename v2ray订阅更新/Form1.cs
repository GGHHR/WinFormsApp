using System;
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
                // 在这里执行您的异步任务
                await new Sub_get().start("https://nodefree.org/", ".item-title a", ".section p","a1","1");
                await new Sub_get().start("https://clashnode.com/f/freenode", "[cp-post-title] a", ".post-content-content p:nth-child(20)","a2","2");
                await new Sub_get().start("https://v2cross.com/", ".entry-title a", ".entry-content h5","a3","3");
                await new Sub_get().start("https://clashgithub.com/", "[itemprop=\"name headline\"] a", ".article-content p:nth-child(11)","a4","4");
                await new Sub_get().start("https://www.yudou66.com/", ".entry-title a", ".post-body  p:nth-child(11)","a5","5");
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