using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using static System.ComponentModel.Design.ObjectSelectorEditor;

namespace ordering_system2
{
    public partial class stock_user : Form
    {
        functions Con;
        public stock_user()
        {
            InitializeComponent();
            Con = new functions();
            ShowEquipment();
            ShowUnit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                // Get the search input from the textbox
                string search = guna2TextBox1.Text.Trim(); // Trim whitespace

                // Ensure the search input is not empty
                if (string.IsNullOrWhiteSpace(search))
                {
                    MessageBox.Show("Please enter a search term."); 
                    return;
                }

                // SQL query to fetch the equipment data
                string query = "SELECT id AS ID, category AS Category, brand AS Brand, description AS Description " +
                               "FROM Equipment " +
                               "WHERE id LIKE @search OR category LIKE @search OR brand LIKE @search";

                // SQL query to get the total count
                string totalQuery = "SELECT COUNT(*) FROM Equipment WHERE id LIKE @search OR category LIKE @search OR brand LIKE @search OR description LIKE @search";

                // Create a connection object
                using (MySqlConnection con = Con.GetConnection()) // Assuming Con.GetConnection() returns a valid MySqlConnection
                {
                    // Create command for fetching equipment data
                    using (MySqlCommand cmd = new MySqlCommand(query, con))
                    {
                        // Use parameters to avoid SQL injection
                        cmd.Parameters.AddWithValue("@search", "%" + search + "%");

                        // Execute the query and bind results to the DataGridView
                        DataTable dt = new DataTable();
                        using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                        {
                            adapter.Fill(dt);
                        }

                        // Bind the DataTable to the DataGridView
                        equipmentData.DataSource = dt;
                    }

                    // Create command for getting the total count
                    using (MySqlCommand countCmd = new MySqlCommand(totalQuery, con))
                    {
                        // Add the same parameter for the count query
                        countCmd.Parameters.AddWithValue("@search", "%" + search + "%");

                        // Execute the count query
                        int totalCount = Convert.ToInt32(countCmd.ExecuteScalar());

                        // Display the count in label2
                        label2.Text = totalCount.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                // Show error message if something goes wrong
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }
        private void ShowUnit()
        {
            try
            {
                string Query = "SELECT id AS ID, pc_num AS PC, brand AS Brand, ram AS RAM, storage_type AS Storage_Device, storage AS Capacity, motherBoard AS Mother_Board, VIDEOcard AS Video_Card, PSU AS PSU, date AS Date, status AS Status  FROM system_unit";
                SystemUnitData2.DataSource = Con.GetData(Query);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }
        private void ShowEquipment()
        {
            try
            {
                string Query = "SELECT id, category, brand, description FROM equipment";
                equipmentData.DataSource = Con.GetData(Query);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void button3_Click(object sender, EventArgs e)
        {
            login frm = new login();
            frm.Show();
            this.Dispose();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                // Get the search input from the textbox
                string search = guna2TextBox2.Text.Trim(); // Trim whitespace

                // Ensure the search input is not empty
                if (string.IsNullOrWhiteSpace(search))
                {
                    MessageBox.Show("Please enter a search term.");
                    return;
                }
                else
                {
                    // SQL query with parameters
                    string query = "SELECT id AS ID, pc_num AS PC, brand AS Brand, ram AS RAM, " +
                                   "storage_type AS Storage_Device, storage AS Capacity, " +
                                   "motherBoard AS Mother_Board, VIDEOcard AS Video_Card, " +
                                   "PSU AS PSU, date AS Date, status AS Status " +
                                   "FROM system_unit " +
                                   "WHERE id LIKE @search OR brand LIKE @search OR pc_num LIKE @search"+
                                   "ram LIKE @search OR storage_type LIKE @search OR storage LIKE @search OR motherBoard LIKE @search OR VIDEOcard LIKE @search OR PSU LIKE @search OR date LIKE @search OR status LIKE @search";

                    // Create a command object and set parameters
                    using (MySqlCommand cmd = new MySqlCommand(query, Con.GetConnection())) // Assuming Con.GetConnection() returns a valid MySqlConnection
                    {
                        // Use parameters to avoid SQL injection
                        cmd.Parameters.AddWithValue("@search", "%" + search + "%"); // Adding wildcards for LIKE query

                        // Execute the query and bind results to the DataGridView
                        DataTable dt = new DataTable();
                        using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                        {
                            adapter.Fill(dt);
                        }

                        // Bind the DataTable to the DataGridView
                        SystemUnitData2.DataSource = dt;
                    }
                }
            }
            catch (Exception ex)
            {
                // Show error message if something goes wrong
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                ShowUnit();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred:" + ex.Message);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                ShowEquipment();
                label2.Text = "0";
            } 
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred:" + ex.Message);
            }
        }

        private void SystemUnitData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //try
            //{
            //    if (e.RowIndex >= 0) // Ensure that a valid row is clicked
            //    {
            //        DialogResult r = MessageBox.Show("View?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            //        if (r == DialogResult.Yes)
            //        {
            //            // Get the selected row
            //            DataGridViewRow selectedRow = SystemUnitData2.Rows[e.RowIndex];

            //            // Pass the selected row to the view form and show it
            //            view_user view_userForm = new view_user(selectedRow);
            //            view_userForm.ShowDialog(); // Show it as a modal dialog
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("An error occurred: " + ex.Message);
            //}
        }

        private void SystemUnitData_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0) // Ensure that a valid row is clicked
                {
                    DialogResult r = MessageBox.Show("View?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                    if (r == DialogResult.Yes)
                    {
                        // Get the selected row
                        DataGridViewRow selectedRow1 = SystemUnitData2.Rows[e.RowIndex];

                        // Pass the selected row to the view form and show it
                        view_user view_userForm = new view_user(selectedRow1);
                        view_userForm.ShowDialog(); // Show it as a modal dialog
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }
    }
}
