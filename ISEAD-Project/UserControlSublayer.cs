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
    public partial class UserControlSublayer : UserControl
    {
        DbConnection db;
        public UserControlSublayer()
        {
            InitializeComponent();
            db = new DbConnection();
            LoadData();
        }

        private void productLiast_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (subplayerLiast.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = subplayerLiast.SelectedRows[0];
                supName.Text = selectedRow.Cells["Supplier"].Value.ToString();
                supAddress.Text = selectedRow.Cells["Address"].Value.ToString();
                subContact.Text = selectedRow.Cells["Contact"].Value.ToString();
            }
        }

        private void UserControlSublayer_Load(object sender, EventArgs e)
        {

        }

        private void LoadData()
        {

            DataTable dt = new DataTable();
            try
            {
                db.OpenConnection();
                using (SqlCommand cmd = new SqlCommand("RSuppliersE6", db.Connection))
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
                subplayerLiast.DataSource = dt;
                db.CloseConnection();
            }
        }

        private void CLearForm()
        {
            supName.Text = String.Empty;
            supAddress.Text = String.Empty;
            subContact.Text = String.Empty;
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            string Name = supName.Text;
            string Address = supAddress.Text;
            if (!int.TryParse(subContact.Text, out int contact))
            {
                MessageBox.Show("Invalid contact value.");
                return;
            }
            if (Name == "" || Address == "")
            {
                MessageBox.Show("Please fill all fields.");
                return;
            }
            try
            {
                db.OpenConnection();
                using (SqlCommand cmd = new SqlCommand("InsSupplierE6", db.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@supplier", Name);
                    cmd.Parameters.AddWithValue("@address", Address);
                    cmd.Parameters.AddWithValue("@contact", contact);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Supplier added successfully.");
                    LoadData();
                    CLearForm();
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

        private void btnClear_Click(object sender, EventArgs e)
        {
            CLearForm();
        }

        private void deleteSuppliers_Click(object sender, EventArgs e)
        {
            // Check if a row is selected
            if (subplayerLiast.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a suppliers to delete.");
                return;
            }

            // Get the selected product ID from the DataGridView control (productLiast) and ensure it's a valid integer value before proceeding
            if (!int.TryParse(subplayerLiast.SelectedRows[0].Cells["ID"].Value.ToString(), out int id))
            {
                MessageBox.Show("Invalid Supplers ID.");
                return;
            }

            // Confirm deletion
            var confirmResult = MessageBox.Show("Are you sure to delete this suppliers?", "Confirm Delete", MessageBoxButtons.YesNo);
            if (confirmResult != DialogResult.Yes)
            {
                return;
            }

            try
            {
                db.OpenConnection();
                using (SqlCommand cmd = new SqlCommand("DelSupplierE6", db.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                }
                MessageBox.Show("Supplliers deleted successfully.");
                CLearForm();
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

        private void updateSuppliers_Click(object sender, EventArgs e)
        {
            // Check if a row is selected
            if (subplayerLiast.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a Suplliers to update.");
                return;
            }

            // Get the selected product ID from the DataGridView control (productLiast) and ensure it's a valid integer value before proceeding
            if (!int.TryParse(subplayerLiast.SelectedRows[0].Cells["ID"].Value.ToString(), out int id))
            {
                MessageBox.Show("Invalid Suplliers ID.");
                return;
            }

            string Name = supName.Text;
            string Address = supAddress.Text;
            if (!int.TryParse(subContact.Text, out int contact))
            {
                MessageBox.Show("Invalid contact value.");
                return;
            }
            if (Name == "" || Address == "")
            {
                MessageBox.Show("Please fill all fields.");
                return;
            }

            try
            {
                db.OpenConnection();
                using (SqlCommand cmd = new SqlCommand("UpSupplierE6", db.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@supplier", Name);
                    cmd.Parameters.AddWithValue("@address", Address);
                    cmd.Parameters.AddWithValue("@contact", contact);
                    cmd.ExecuteNonQuery();
                }
                CLearForm();
                MessageBox.Show("Suplliers updated successfully.");
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
    }
}
