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
    }
}
