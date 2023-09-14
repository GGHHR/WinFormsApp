using System.Runtime.InteropServices;
using System.Windows.Forms;
namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Screen screen = Screen.PrimaryScreen;
            
            // Calculate the center coordinates
            int center_x = screen.Bounds.Width / 2;
            int center_y = screen.Bounds.Height / 2;
            SetCursorPos(center_x, center_y);
        }
        
        [DllImport("user32.dll")]
        static extern bool SetCursorPos(int x, int y);
    }
}