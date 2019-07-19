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
    public partial class Scheduler : Form
    {
        Main main;

        public Scheduler()
        {
            InitializeComponent();
            InitializeForm();

            main.Activate();
        }

        private void InitializeForm()
        {
            Setup_UI();
            Create_Tray_Icon();
        }

        private void Setup_UI()
        {
            main = new Main();
            main.Show();
        }

        private void Create_Tray_Icon()
        {
            WindowState = FormWindowState.Minimized;
            ShowInTaskbar = false;
            Visible = false;
            notifyIcon1.Visible = true;
            notifyIcon1.ContextMenuStrip = materialContextMenuStrip1;
        }

        private void Open(object sender, EventArgs e)
        {
            bool isOpen = false;
            FormCollection fc = Application.OpenForms;

            foreach (Form frm in fc)
            {
                if (frm.Name == "Main")
                {
                    isOpen = true;
                    break;
                }
            }

            if(!isOpen) main.Show();
        }

        private void Exit(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void SchedulerStart_FormClosing(object sender, FormClosingEventArgs e)
        {
            Create_Tray_Icon();
        }

        private void Scheduler_Load(object sender, EventArgs e)
        {

        }
    }
}
