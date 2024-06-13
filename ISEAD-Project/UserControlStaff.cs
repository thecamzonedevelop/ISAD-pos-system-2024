using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ISEAD_Project
{
    public partial class UserControlStaff : UserControl
    {
        DbConnection db;
        public UserControlStaff()
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
                staffLiast.DataSource = dt;
                db.CloseConnection();
            }

        }
        private void ClearForm()
        {
            staffName.Text = string.Empty;
            staffPosition.Text = string.Empty;
            staffSalry.Text = string.Empty;
            staffContact.Text = string.Empty;
            staffDob.Text = string.Empty;
            Male.Checked = true;
            jobStatus.Checked = true;
        }
        private void saveStaff_Click(object sender, EventArgs e)
        {
            string Name = staffName.Text;
            string Position = staffPosition.Text;
            if (!int.TryParse(staffContact.Text, out int contact))
            {
                MessageBox.Show("Invalid contact value.");
                return;
            }
            if (!decimal.TryParse(staffSalry.Text, out decimal salaey))
            {
                MessageBox.Show("Invalid salary value.");
                return;
            }
            string dobs = staffDob.Text;
            string gender;
            bool isMale = Male.Checked;
            if (isMale)
            {
                gender = "M";
            }
            else
            {
                gender = "F";
            }
            int status;
            if (jobStatus.Checked)
            {
                status = 1;
            }
            else
            {
                status = 0;
            }

            try
            {
                db.OpenConnection();
                using (SqlCommand cmd = new SqlCommand("InsStaffE6", db.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@name", Name);
                    cmd.Parameters.AddWithValue("@gen", gender);
                    cmd.Parameters.AddWithValue("@dob", dobs);
                    cmd.Parameters.AddWithValue("@position", Position);
                    cmd.Parameters.AddWithValue("@salary", salaey);
                    cmd.Parameters.AddWithValue("@stopwork", status);
                    cmd.ExecuteNonQuery();
                }
                ClearForm();
                MessageBox.Show("Staff saved successfully.");
                LoadData(); // Reload data to reflect the new product
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

        private void Female_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void staffLiast_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (staffLiast.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = staffLiast.SelectedRows[0];
                staffName.Text = selectedRow.Cells["Name"].Value.ToString();
                staffPosition.Text = selectedRow.Cells["Position"].Value.ToString();


                staffSalry.Text = selectedRow.Cells["Salary"].Value.ToString();

                // Set jobStatus checkbox
                if (selectedRow.Cells["StopWork"].Value != DBNull.Value)
                {
                    jobStatus.Checked = Convert.ToBoolean(selectedRow.Cells["StopWork"].Value);
                }
                else
                {
                    jobStatus.Checked = false;
                }

                // Set gender radio buttons
                string gender = selectedRow.Cells["Gender"].Value.ToString();
                if (gender == "M")
                {
                    Male.Checked = true;
                    Female.Checked = false;
                }
                else if (gender == "F")
                {
                    Male.Checked = false;
                    Female.Checked = true;
                }
                else
                {
                    Male.Checked = false;
                    Female.Checked = false;
                }
            }
        }

        private void updateStaff_Click(object sender, EventArgs e)
        {
            // Check if a row is selected
            if (staffLiast.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a product to update.");
                return;
            }

            // Get the selected product ID from the DataGridView control (productLiast) and ensure it's a valid integer value before proceeding
            if (!int.TryParse(staffLiast.SelectedRows[0].Cells["ID"].Value.ToString(), out int id))
            {
                MessageBox.Show("Invalid product ID.");
                return;
            }

            string Name = staffName.Text;
            if (string.IsNullOrWhiteSpace(Name))
            {
                MessageBox.Show("Product name cannot be empty.");
                return;
            }
            string position = staffPosition.Text;

            if (!decimal.TryParse(staffSalry.Text, out decimal salary))
            {
                MessageBox.Show("Invalid salary value.");
                return;
            }
            string dobs = staffDob.Text;
            if (string.IsNullOrWhiteSpace(dobs))
            {
                MessageBox.Show("Date of birth cannot be empty.");
                return;
            }
            string gender;
            bool isMale = Male.Checked;
            if (isMale)
            {
                gender = "M";
            }
            else
            {
                gender = "F";
            }
            int status;
            if (jobStatus.Checked)
            {
                status = 1;
            }
            else
            {
                status = 0;
            }



            try
            {
                db.OpenConnection();
                using (SqlCommand cmd = new SqlCommand("UpStaffE6", db.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@name", Name);
                    cmd.Parameters.AddWithValue("@position", position);
                    cmd.Parameters.AddWithValue("@salary", salary);
                    cmd.Parameters.AddWithValue("@dob", dobs);
                    cmd.Parameters.AddWithValue("@gen", gender);
                    cmd.Parameters.AddWithValue("@stopwork", status);

                    cmd.ExecuteNonQuery();
                }
                ClearForm();
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

        private void deleteStaff_Click(object sender, EventArgs e)
        {
            // Check if a row is selected
            if (staffLiast.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a staff to delete.");
                return;
            }

            // Get the selected product ID from the DataGridView control (productLiast) and ensure it's a valid integer value before proceeding
            if (!int.TryParse(staffLiast.SelectedRows[0].Cells["ID"].Value.ToString(), out int id))
            {
                MessageBox.Show("Invalid staff ID.");
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
                using (SqlCommand cmd = new SqlCommand("DelStaffE6", db.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                }
                ClearForm();
                MessageBox.Show("staff deleted successfully.");
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
            ClearForm();
        }
    }
}
