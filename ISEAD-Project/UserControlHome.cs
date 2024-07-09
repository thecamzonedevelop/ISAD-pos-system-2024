using Microsoft.VisualBasic.ApplicationServices;
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
    public partial class UserControlHome : UserControl
    {
        DbConnection db;

        public UserControlHome()
        {
            InitializeComponent();
            db = new DbConnection();
            LoadData();
        }

        private void LoadData()
        {
            DataTable dt = new DataTable();
            try
            {
                db.OpenConnection();
                using (SqlCommand cmd = new SqlCommand("DashboardStats", db.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataReader reader = cmd.ExecuteReader();
                    dt.Load(reader);
                }

                if (dt.Rows.Count > 0)
                {
                    DataRow row = dt.Rows[0];
                    dCustomer.Text = row["TotalCustomers"].ToString();
                    dProduct.Text = row["TotalProducts"].ToString();
                    dStaff.Text = row["TotalStaff"].ToString();
                    dPayments.Text = row["TotalPayments"].ToString();
                    dSuppliers.Text = row["TotalSuppliers"].ToString();
                    dUsers.Text = row["TotalUsers"].ToString();
                    dInvoices.Text = row["TotalInvoices"].ToString();
                    dImports.Text = row["TotalImports"].ToString();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {  
                db.CloseConnection();
            }
        }
    }
}
