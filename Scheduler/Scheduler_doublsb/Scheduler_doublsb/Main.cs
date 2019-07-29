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
        //Controls
        Button[] TabControlButton = new Button[5];

        //Else
        ColorPalette Palette;
        bool isDragging;
        Point Lastpos;

        public Main()
        {
            isDragging = false;
            Palette = new ColorPalette();

            InitializeComponent();
            Setup_UI();
        }

        private void Setup_UI()
        {
            Assign_UI();
            Set_ControlSize();
            Set_ControlColor();
        }

        private void Assign_UI()
        {
            TabControlButton[0] = Tab_Month;
            TabControlButton[1] = Tab_Week;
            TabControlButton[2] = Tab_Day;
            TabControlButton[3] = Tab_Priority;
            TabControlButton[4] = Tab_Project;

            for (int i = 0; i < TabControlButton.Length; i++)
            {
                int j = i;
                TabControlButton[i].Click += delegate { Change_Tab(j); };
            }
        } 

        private void Set_ControlColor()
        {
            Tab_Month.BackColor = Palette.Get(ColorPalette.Color_.CheeryPink);
            Tab_Week.BackColor = Palette.Get(ColorPalette.Color_.Rhyme);
            Tab_Day.BackColor = Palette.Get(ColorPalette.Color_.Cyan);
            Tab_Priority.BackColor = Palette.Get(ColorPalette.Color_.Gray);
            Tab_Project.BackColor = Palette.Get(ColorPalette.Color_.Pink);

            Page_Month.BackgroundImage = Properties.Resources.ControlTab_01;
            Page_Month.BackgroundImageLayout = ImageLayout.Stretch;

            Page_Week.BackgroundImage = Properties.Resources.ControlTab_04;
            Page_Week.BackgroundImageLayout = ImageLayout.Stretch;

            Page_Day.BackgroundImage = Properties.Resources.ControlTab_03;
            Page_Day.BackgroundImageLayout = ImageLayout.Stretch;

            Page_Priority.BackgroundImage = Properties.Resources.ControlTab_02;
            Page_Priority.BackgroundImageLayout = ImageLayout.Stretch;

            Page_Project.BackgroundImage = Properties.Resources.ControlTab_05;
            Page_Project.BackgroundImageLayout = ImageLayout.Stretch;
        }

        private void Set_ControlSize()
        {
            for (int i = 0; i < TabControlButton.Length; i++)
            {
                TabControlButton[i].Size = new Size(80, 30);
                TabControlButton[i].Location = new Point(0 + 80 * i, 0);
            }

            CloseButton.Size = new Size(80, 30);
            CloseButton.Location = new Point(Size.Width - 80, 0);

            UpperPanel.Size = new Size(Size.Width, 30);
            UpperPanel.Location = new Point(0, 0);

            SchedulePage.Size = new Size(Size.Width, Size.Height - 30);
            SchedulePage.Location = new Point(0, 30);
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
            //Close();
        }

        private void Change_Tab(int PageIndex)
        {
            SchedulePage.SelectedIndex = PageIndex;
        }

        private void WindowPanel_MouseDown(object sender, MouseEventArgs e)
        {
            if (MouseButtons == MouseButtons.Left)
            {
                Lastpos = e.Location;
                isDragging = true;
            }
        }

        private void WindowPanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging)
            {
                Location = new Point(Location.X - Lastpos.X + e.X, Location.Y - Lastpos.Y + e.Y);
            }
        }

        private void WindowPanel_MouseUp(object sender, MouseEventArgs e)
        {
            isDragging = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
