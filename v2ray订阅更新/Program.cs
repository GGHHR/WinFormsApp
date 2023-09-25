using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace v2ray订阅更新
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            /*// 创建窗体实例并将其隐藏
            Form1 form = new Form1();
            form.WindowState = FormWindowState.Minimized;
            form.ShowInTaskbar = false;
            form.Visible = false;
            Application.Run();  */
            
            Application.Run(new Form1());
        }
    }
}