using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Scheduler_doublsb
{
    public partial class Main : Form
    {
        Graphics GFx;
        ColorPalette Palette;

        public Main()
        {
            InitializeComponent();
            Setup_UI();
        }

        private void Setup_UI()
        {
            Draw_Image();
        }

        private void Draw_Image()
        {
            Image ExitButtonImage = Properties.Resources.exit;
        }


        private void ExitButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Main_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            

            Rectangle rect1 = new Rectangle(0, 0, Size.Width + 20, 30);
            g.DrawImage(Properties.Resources.window, rect1);

            Rectangle rect2 = new Rectangle(Size.Width - 30, 0, 30, 30);
            g.DrawImage(Properties.Resources.exit, rect2);
        }
    }
}
