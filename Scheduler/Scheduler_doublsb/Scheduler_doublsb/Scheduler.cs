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
    public partial class Scheduler : MaterialSkin.Controls.MaterialForm
    {
        public Scheduler()
        {
            InitializeComponent();
        }

        private void Create_Tray_Icon()
        {
            WindowState = FormWindowState.Minimized;
            ShowInTaskbar = false;
            Visible = false;
            notifyIcon1.Visible = true;
            notifyIcon1.ContextMenuStrip = materialContextMenuStrip1;
        }

        private void 실행ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void SchedulerStart_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            Create_Tray_Icon();
        }
    }
}
