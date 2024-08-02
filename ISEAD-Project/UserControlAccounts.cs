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
        int Id;
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
        private void ClearForm()
        {
            name.Text = String.Empty;
            username.Text = String.Empty;
            password.Text = String.Empty;
            confirmPassword.Text = String.Empty;

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
            if (!int.TryParse(staffId.Text, out int id) && staffId.Text != String.Empty)
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

        private void saveAccount_Click(object sender, EventArgs e)
        {
            string staffName = name.Text;
            string staffusername = username.Text;
            string staffpassword = password.Text;  // Fixed the typo here
            string staffConfirmPassword = confirmPassword.Text;
            string staffRole = roleAdmin.Checked ? "admin" : "staff";

            // Check if the username and password are not empty and password matches the confirm password field 
            if (staffusername.Length > 0 && staffpassword.Length > 0)
            {
                if (staffpassword == staffConfirmPassword)
                {
                    try
                    {
                        db.OpenConnection();
                        using (SqlCommand cmd = new SqlCommand("SaveUserAccount", db.Connection))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@staff_id", Id);  // Ensure Id is properly initialized
                            cmd.Parameters.AddWithValue("@u_name", staffusername);
                            cmd.Parameters.AddWithValue("@pwd", staffpassword);
                            cmd.Parameters.AddWithValue("@roles", staffRole);
                            cmd.ExecuteNonQuery();
                        }
                        MessageBox.Show("Account saved successfully.");
                        LoadDataAccount(); // Reload data to reflect the new account
                    }
                    catch (SqlException ex)
                    {
                        // Check if the error is due to a duplicate username
                        if (ex.Number == 50000)  // RAISERROR uses error number 50000 by default
                        {
                            MessageBox.Show("Error: Username already exists.");
                        }
                        else
                        {
                            MessageBox.Show("Error: " + ex.Message);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                    finally
                    {
                        ClearForm();
                        db.CloseConnection();
                    }
                }
                else
                {
                    MessageBox.Show("Password does not match.");
                }
            }
            else
            {
                MessageBox.Show("Username and password are required.");
            }
        }


        private void staffList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (staffList.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = staffList.SelectedRows[0];
                name.Text = selectedRow.Cells["Name"].Value.ToString();
                Id = Convert.ToInt32(selectedRow.Cells["ID"].Value);
                // username randomly generated name + id converted to lowercase and remove spaces
                username.Text = selectedRow.Cells["Name"].Value.ToString().ToLower().Replace(" ", "") + Id;

            }
        }

        private void userAccountList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (userAccountList.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = userAccountList.SelectedRows[0];
                name.Text = selectedRow.Cells["Staff Name"].Value.ToString();
                username.Text = selectedRow.Cells["Username"].Value.ToString();
                roleAdmin.Checked = selectedRow.Cells["Role"].Value.ToString() == "admin";
                roleStaff.Checked = selectedRow.Cells["Role"].Value.ToString() == "staff";
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void deleteAccount_Click(object sender, EventArgs e)
        {
            // Check if a row is selected
            if (userAccountList.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a staff account to delete.");
                return;
            }

            // Get the selected product ID from the DataGridView control (productLiast) and ensure it's a valid integer value before proceeding
            if (!int.TryParse(userAccountList.SelectedRows[0].Cells["ID"].Value.ToString(), out int id))
            {
                MessageBox.Show("Invalid Account ID.");
                return;
            }

            // Confirm deletion
            var confirmResult = MessageBox.Show("Are you sure to delete this Account?" + userAccountList.SelectedRows[0].Cells["Staff Name"].Value.ToString(), "Confirm Delete", MessageBoxButtons.YesNo);
            if (confirmResult != DialogResult.Yes)
            {
                return;
            }

            try
            {
                db.OpenConnection();
                using (SqlCommand cmd = new SqlCommand("DeleteUserAccount", db.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                }
                ClearForm();
                MessageBox.Show("Account deleted successfully.");
                LoadDataAccount();  // Reload data to reflect the deleted product
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

        private void updateAccount_Click(object sender, EventArgs e)
        {
            if (userAccountList.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a staff account to update.");
                return;
            }

            if (!int.TryParse(userAccountList.SelectedRows[0].Cells["ID"].Value.ToString(), out int id))
            {
                MessageBox.Show("Invalid Account ID.");
                return;
            }

            string staffName = name.Text;
            string staffusername = username.Text;
            string staffpassword = password.Text;
            string staffConfirmPassword = confirmPassword.Text;
            string staffRole = roleAdmin.Checked ? "admin" : "staff";

            if (staffusername.Length > 0 && staffpassword.Length > 0)
            {
                if (staffpassword == staffConfirmPassword)
                {
                    try
                    {
                        db.OpenConnection();
                        using (SqlCommand cmd = new SqlCommand("UpdateUserAccount", db.Connection))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@id", id);
                            cmd.Parameters.AddWithValue("@u_name", staffusername);
                            cmd.Parameters.AddWithValue("@pwd", staffpassword);
                            cmd.Parameters.AddWithValue("@roles", staffRole);
                            cmd.ExecuteNonQuery();
                        }
                        MessageBox.Show("Account updated successfully.");
                        LoadDataAccount(); // Reload data to reflect the updated account
                    }
                    catch (SqlException ex)
                    {
                        if (ex.Number == 50000)
                        {
                            MessageBox.Show("Error: Username already exists.");
                        }
                        else
                        {
                            MessageBox.Show("Error: " + ex.Message);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                    finally
                    {
                        ClearForm();
                        db.CloseConnection();
                    }
                }
                else
                {
                    MessageBox.Show("Password does not match.");
                }
            }
            else
            {
                MessageBox.Show("Username and password are required.");
            }

        }

        private void loadUserlist_Click(object sender, EventArgs e)
        {
            LoadDataAccount();
        }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}
