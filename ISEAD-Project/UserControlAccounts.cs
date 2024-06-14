using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Guna.UI2.WinForms.Helpers.GraphicsHelper;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ISEAD_Project
{
    public partial class UserControlAccounts : UserControl
    {
        DbConnection db = new DbConnection();
        public UserControlAccounts()
        {
            InitializeComponent();
            DbConnection db;
            LoadData();
            LoadDataAccount();
        }

        private void LoadData()
        {
            DataTable dt = new DataTable();
            try
            {
                db.OpenConnection();
                using (SqlCommand cmd = new SqlCommand("RStaffE6", db.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataReader reader = cmd.ExecuteReader();
                    dt.Load(reader);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                staffList.DataSource = dt;
                db.CloseConnection();
            }

        }

        private void LoadDataAccount()
        {
            DataTable dt = new DataTable();
            try
            {
                db.OpenConnection();
                using (SqlCommand cmd = new SqlCommand("ReadAllUserAccounts", db.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataReader reader = cmd.ExecuteReader();
                    dt.Load(reader);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                userAccountList.DataSource = dt;
                db.CloseConnection();
            }
        }

        private void btnSearchStaff_Click(object sender, EventArgs e)
        {
            string Name = staffName.Text;
            if (!int.TryParse(staffId.Text, out int id) && staffId.Text != String.Empty )
            {
                MessageBox.Show("Invalid id value.");
                return;
            }
            if (staffId.Text == String.Empty && staffName.Text == String.Empty)
            {
                LoadData();
                return; 
            }
            DataTable dt = new DataTable();
            try
            {
                db.OpenConnection();
                using (SqlCommand cmd = new SqlCommand("SearchStaff", db.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ID", id);
                    cmd.Parameters.AddWithValue("@Name", Name);
                    cmd.ExecuteNonQuery();
                    SqlDataReader reader = cmd.ExecuteReader();
                    dt.Load(reader);
                }
               
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                staffList.DataSource = dt;
                db.CloseConnection();
            }
        }
    }
}
