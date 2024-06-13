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
    public partial class UserControlCustomer : UserControl
    {
        DbConnection db;
        public UserControlCustomer()
        {
            InitializeComponent();
            db = new DbConnection();
            LoadData();
        }

        private void UserControlCustomer_Load(object sender, EventArgs e)
        {

        }
        private void LoadData()
        {

            DataTable dt = new DataTable();
            try
            {
                db.OpenConnection();
                using (SqlCommand cmd = new SqlCommand("RCusE6", db.Connection))
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
                customerLiast.DataSource = dt;
                db.CloseConnection();
            }
        }
        private void CLearForm()
        {
            cusName.Text = String.Empty;
            cusContact.Text = String.Empty;
        }
        private void saveCustomer_Click(object sender, EventArgs e)
        {
            string customerName = cusName.Text;
            if (!int.TryParse(cusContact.Text, out int cusContacts))
            {
                MessageBox.Show("Invalid contact value.");
                return;
            }

            try
            {
                db.OpenConnection();
                using (SqlCommand cmd = new SqlCommand("InsCusE6", db.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@cn", customerName);
                    cmd.Parameters.AddWithValue("@co", cusContacts);
                    cmd.ExecuteNonQuery();
                }
                MessageBox.Show("Customrt saved successfully.");
                LoadData(); // Reload data to reflect the new product
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                CLearForm();
                db.CloseConnection();
            }
        }

        private void customerLiast_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (customerLiast.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = customerLiast.SelectedRows[0];
                cusName.Text = selectedRow.Cells["Name"].Value.ToString();
                cusContact.Text = selectedRow.Cells["Contact"].Value.ToString();

            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            CLearForm();
        }

        private void updateCustomer_Click(object sender, EventArgs e)
        {
            // Check if a row is selected
            if (customerLiast.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a customer to update.");
                return;
            }

            // Get the selected product ID from the DataGridView control (productLiast) and ensure it's a valid integer value before proceeding
            if (!int.TryParse(customerLiast.SelectedRows[0].Cells["ID"].Value.ToString(), out int id))
            {
                MessageBox.Show("Invalid customer ID.");
                return;
            }

            string Name = cusName.Text;
            if (string.IsNullOrWhiteSpace(Name))
            {
                MessageBox.Show("Customer name cannot be empty.");
                return;
            }
            if (!int.TryParse(cusContact.Text, out int contact))
            {
                MessageBox.Show("Invalid Contact.");
                return;
            }

            try
            {
                db.OpenConnection();
                using (SqlCommand cmd = new SqlCommand("UpCusE6", db.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@cn", Name);
                    cmd.Parameters.AddWithValue("@co", contact);
                    cmd.ExecuteNonQuery();
                }
                CLearForm();
                MessageBox.Show("Customer updated successfully.");
                LoadData(); // Reload data to reflect the updated product
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

        private void deleteCustomer_Click(object sender, EventArgs e)
        {
            // Check if a row is selected
            if (customerLiast.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a customrt to delete.");
                return;
            }

            // Get the selected product ID from the DataGridView control (productLiast) and ensure it's a valid integer value before proceeding
            if (!int.TryParse(customerLiast.SelectedRows[0].Cells["ID"].Value.ToString(), out int id))
            {
                MessageBox.Show("Invalid customrt ID.");
                return;
            }

            // Confirm deletion
            var confirmResult = MessageBox.Show("Are you sure to delete this customrt?", "Confirm Delete", MessageBoxButtons.YesNo);
            if (confirmResult != DialogResult.Yes)
            {
                return;
            }

            try
            {
                db.OpenConnection();
                using (SqlCommand cmd = new SqlCommand("DelCusE6", db.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                }
                CLearForm();
                MessageBox.Show("Customrt deleted successfully.");
                LoadData(); // Reload data to reflect the deleted product
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
