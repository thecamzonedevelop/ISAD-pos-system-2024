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
    public partial class LoadingForm : Form
    {
        private System.Windows.Forms.Timer timer;
        public LoadingForm()
        {
            InitializeComponent();
            InitializeTimer();
        }

        private void LoadingForm_Load(object sender, EventArgs e)
        {
            timer.Start();
        }
        private void InitializeTimer()
        {
            timer = new System.Windows.Forms.Timer();
            timer.Interval = 3000; // 3 seconds
            timer.Tick += Timer_Tick;
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            timer.Stop();
            this.Hide();
            Loginform loginForm = new Loginform();
            loginForm.Show();
        }
    }
}
