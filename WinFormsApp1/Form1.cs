using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace v2rayn
{
    public partial class Form1 : Form
    {
        public string currentPage = "";

        public string Label2Text
        {
            get { return label2.Text; }
            set { label2.Text = value; }
        }
        public string Addlist
        {
            set
            {
                if (!listView1.Items.ContainsKey(value))
                {
                    ListViewItem listViewItem = new ListViewItem(value);
                    listViewItem.Name = value;
                    listView1.Items.Add(listViewItem);
                }
            }
        }


        public Form1()
        {
            InitializeComponent();
            this.Resize += Form1_Resize;
            this.textBox1.Text = "3";
            // 创建 ListView 控件

            listView1.View = View.Details; // 使用详细信息视图模式

            // 添加列标题
            listView1.Columns.Add("链接", 300);



            listView1.DoubleClick += (sender, e) =>
            {
                ListView listView = (ListView)sender;
                if (listView.SelectedItems.Count > 0)
                {
                    ListViewItem selectedItem = listView.SelectedItems[0];
                    string content = selectedItem.Text;
                    Clipboard.SetText(content); // 将内容复制到剪贴板
                }
            };

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void Form1_Resize(object sender, EventArgs e)
        {

            int padding = 10;
            int width = this.Size.Width - 2 * padding - 20;
            int height = this.Size.Height - 2 * padding - 150;

            listView1.Location = new Point(10, 110);
            listView1.Size = new Size(width, height);
        }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private async void button1_Click(object sender, EventArgs e)
        {
            File.Delete("I.txt");
            listView1.Items.Clear();
            try
            {
                Page page = new Page(this);
                await page.Start(int.Parse(this.textBox1.Text));



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            /* this.textBox1.Text*/
        }


        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
