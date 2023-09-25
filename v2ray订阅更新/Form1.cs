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
            LoadDataAndExitAsync();
        }
        public string GetOutputTextBoxValue()
        {
            return textBox1.Text;
        }
        private async void LoadDataAndExitAsync()
        {
            await Task.Run(async () =>
            {
                // 在这里执行您的异步任务
                await new Sub_get().start("https://nodefree.org/", ".item-title a", ".section p","a1","1");
                await new Sub_get().start("https://clashnode.com/f/freenode", "[cp-post-title] a", ".post-content-content p:nth-child(18)","a2","2");
            });

            // 关闭应用程序
            Application.Exit();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            throw new System.NotImplementedException();
        }
    }
}