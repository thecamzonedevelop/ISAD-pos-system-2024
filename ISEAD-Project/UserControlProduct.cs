using System;
using System.Collections;
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
    public partial class UserControlProduct : UserControl
    {
        private DbConnection db;
        public UserControlProduct()
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
                using (SqlCommand cmd = new SqlCommand("RProductsE6", db.Connection))
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
                productLiast.DataSource = dt;
                db.CloseConnection();
            }
        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void productLiast_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (productLiast.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = productLiast.SelectedRows[0];
                proName.Text = selectedRow.Cells["Name"].Value.ToString();
                proPrice.Text = selectedRow.Cells["UnitPrice"].Value.ToString();
                proQty.Text = selectedRow.Cells["Quantity"].Value.ToString();
            }
        }

        private void CLearForm()
        {
            proName.Text = String.Empty;
            proPrice.Text = String.Empty;
            proQty.Text = String.Empty;
        }

        private void savePro_Click(object sender, EventArgs e)
        {
            string productName = proName.Text;
            if (!decimal.TryParse(proPrice.Text, out decimal price))
            {
                MessageBox.Show("Invalid price value.");
                return;
            }
            if (!int.TryParse(proQty.Text, out int quantity))
            {
                MessageBox.Show("Invalid quantity value.");
                return;
            }

            try
            {
                db.OpenConnection();
                using (SqlCommand cmd = new SqlCommand("InsProductE6", db.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@name", productName);
                    cmd.Parameters.AddWithValue("@unitPrice", price);
                    cmd.Parameters.AddWithValue("@quantity", quantity);
                    cmd.ExecuteNonQuery();
                }
                MessageBox.Show("Product saved successfully.");
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

        private void updatePro_Click(object sender, EventArgs e)
        {
            // Check if a row is selected
            if (productLiast.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a product to update.");
                return;
            }

            // Get the selected product ID from the DataGridView control (productLiast) and ensure it's a valid integer value before proceeding
            if (!int.TryParse(productLiast.SelectedRows[0].Cells["Code"].Value.ToString(), out int id))
            {
                MessageBox.Show("Invalid product ID.");
                return;
            }

            string productName = proName.Text;
            if (string.IsNullOrWhiteSpace(productName))
            {
                MessageBox.Show("Product name cannot be empty.");
                return;
            }

            if (!decimal.TryParse(proPrice.Text, out decimal price))
            {
                MessageBox.Show("Invalid price value.");
                return;
            }
            if (!int.TryParse(proQty.Text, out int quantity))
            {
                MessageBox.Show("Invalid quantity value.");
                return;
            }

            try
            {
                db.OpenConnection();
                using (SqlCommand cmd = new SqlCommand("UpProductE6", db.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@code", id);
                    cmd.Parameters.AddWithValue("@name", productName);
                    cmd.Parameters.AddWithValue("@unitPrice", price);
                    cmd.Parameters.AddWithValue("@quantity", quantity);
                    cmd.ExecuteNonQuery();
                }
                CLearForm();
                MessageBox.Show("Product updated successfully.");
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

        private void UserControlProduct_Load(object sender, EventArgs e)
        {

        }

        private void deletePro_Click(object sender, EventArgs e)
        {
            // Check if a row is selected
            if (productLiast.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a product to delete.");
                return;
            }

            // Get the selected product ID from the DataGridView control (productLiast) and ensure it's a valid integer value before proceeding
            if (!int.TryParse(productLiast.SelectedRows[0].Cells["Code"].Value.ToString(), out int id))
            {
                MessageBox.Show("Invalid product ID.");
                return;
            }

            // Confirm deletion
            var confirmResult = MessageBox.Show("Are you sure to delete this item?", "Confirm Delete", MessageBoxButtons.YesNo);
            if (confirmResult != DialogResult.Yes)
            {
                return;
            }

            try
            {
                db.OpenConnection();
                using (SqlCommand cmd = new SqlCommand("DelProductE6", db.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@code", id);
                    cmd.ExecuteNonQuery();
                }
                CLearForm();
                MessageBox.Show("Product deleted successfully.");
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

        private void btnClear_Click(object sender, EventArgs e)
        {
            CLearForm();
        }

        private void guna2CircleProgressBar1_ValueChanged(object sender, EventArgs e)
        {

        }
    }

}
