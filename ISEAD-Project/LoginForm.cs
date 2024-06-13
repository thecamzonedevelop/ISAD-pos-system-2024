using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ISEAD_Project
{
    public partial class Loginform : Form
    {
        private DbConnection db;

        public Loginform()
        {
            InitializeComponent();
            db = new DbConnection();
        }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {
            // Add any action for picture box click if needed
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

        private void btn_login_Click(object sender, EventArgs e)
        {
            string u_name = username.Text;
            string pwd = password.Text;

            if (string.IsNullOrEmpty(u_name) || string.IsNullOrEmpty(pwd))
            {
                MessageBox.Show("Please enter both username and password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                db.OpenConnection();
                string query = "SELECT roles FROM tbUsers WHERE u_name = @u_name AND pwd = @pwd";

                using (SqlCommand cmd = new SqlCommand(query, db.Connection))
                {
                    cmd.Parameters.AddWithValue("@u_name", u_name);
                    cmd.Parameters.AddWithValue("@pwd", pwd);

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            string role = dr["roles"].ToString();
                            MessageBox.Show($"Login successful! Role: {role}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            // Open the main form or perform other actions based on the user's role
                            this.Hide();
                            HomeForm homeForm = new HomeForm(); // Assuming HomeForm is the next form to be shown
                            homeForm.Show();
                        }
                        else
                        {
                            MessageBox.Show("Invalid username or password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                db.CloseConnection();
            }
        }

        private void loginform_Load(object sender, EventArgs e)
        {

        }
    }
}
