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

        UserControlPerminstion ucp = new UserControlPerminstion();

        public HomeForm(string name)
        {
            InitializeComponent();
            if (Ulog.type == "admin")
            {
                UserControlHome uc = new UserControlHome();
                addUserControl(uc);
            }
            else
            {
                addUserControl(ucp);
            }
            timer1.Start();
            timeHeader.Text = DateTime.Now.ToLongTimeString();
            dateHeader.Text = DateTime.Now.ToShortDateString();
            useAccoun.Text = name;
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
            if (Ulog.type == "admin")
            {
                addUserControl(uc);
            }
            else
            {
                addUserControl(ucp);
            }

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
            if (Ulog.type == "admin")
            {
                addUserControl(uc);
            }
            else
            {
                addUserControl(ucp);
            }
        }

        private void sublayer_Click(object sender, EventArgs e)
        {
            UserControlSublayer uc = new UserControlSublayer();
            if (Ulog.type == "admin")
            {
                addUserControl(uc);
            }
            else
            {
                addUserControl(ucp);
            }
        }

        private void staff_Click(object sender, EventArgs e)
        {
            UserControlStaff uc = new UserControlStaff();
            if (Ulog.type == "admin")
            {
                addUserControl(uc);
            }
            else
            {
                addUserControl(ucp);
            }
        }

        private void guna2Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timeHeader.Text = DateTime.Now.ToLongTimeString();
            timer1.Start();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            Loginform loginform = new Loginform();
            // show MessageBox to confirm logout 
            var confirmResult = MessageBox.Show("Are you sure you want to logout?", "Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirmResult == DialogResult.Yes)
            {
                loginform.Show();
                this.Hide();
            }
            else
            {
                // do nothing
            }

        }

        private void useAccoun_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            UserControlAccounts uc = new UserControlAccounts();
            if (Ulog.type == "admin")
            {
                addUserControl(uc);
            }
            else
            {
                addUserControl(ucp);
            }
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            UserControlImport uc = new UserControlImport();
            addUserControl(uc);
        }
    }
}
