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

        private async void LoadDataAndExitAsync()
        {
            await Task.Run(async () =>
            {
                // 在这里执行您的异步任务
                await new Sub_get().start("https://nodefree.org/", ".item-title a", ".section p");
            });

            // 关闭应用程序
            Application.Exit();
        }
    }
}