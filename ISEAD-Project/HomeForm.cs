using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ISEAD_Project
{
    public partial class HomeForm : Form
    {
        public HomeForm()
        {
            InitializeComponent();
            UserControlHome uc = new UserControlHome();
            addUserControl(uc);
            timer1.Start();
            timeHeader.Text = DateTime.Now.ToLongTimeString();
            dateHeader.Text = DateTime.Now.ToShortDateString();
        }

        private void addUserControl(UserControl userControl)
        {
            userControl.Dock = DockStyle.Fill;
            PanelContener.Controls.Clear();
            PanelContener.Controls.Add(userControl);
            userControl.BringToFront();
        }
        private void guna2CircleButton1_Click(object sender, EventArgs e)
        {
            // Close window 
            if (Application.MessageLoop)
            {
                // WinForms app
                Application.Exit();
            }
            else
            {
                // Console app
                Environment.Exit(1);
            }
        }

        private void guna2CircleButton2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void dashbord_Click(object sender, EventArgs e)
        {
            UserControlHome uc = new UserControlHome();
            addUserControl(uc);

        }

        private void pos_Click(object sender, EventArgs e)
        {
            UserControlPOS uc = new UserControlPOS();
            addUserControl(uc);
        }

        private void product_Click(object sender, EventArgs e)
        {
            UserControlProduct uc = new UserControlProduct();
            addUserControl(uc);
        }

        private void customer_Click(object sender, EventArgs e)
        {
            UserControlCustomer uc = new UserControlCustomer();
            addUserControl(uc);
        }

        private void sublayer_Click(object sender, EventArgs e)
        {
            UserControlSublayer uc = new UserControlSublayer();
            addUserControl(uc);
        }

        private void staff_Click(object sender, EventArgs e)
        {
            UserControlStaff uc = new UserControlStaff();
            addUserControl(uc);
        }

        private void guna2Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timeHeader.Text = DateTime.Now.ToLongTimeString();
            timer1.Start();
        }
    }
}
