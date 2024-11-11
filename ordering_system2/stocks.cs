using Guna.UI2.WinForms;
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
using System.Data.SqlClient;
using static Guna.UI2.Native.WinApi;

namespace ordering_system2
{
    public partial class stocks : Form
    {
        functions Con;
        public stocks()
        {
            InitializeComponent();
            Con = new functions();

            ShowUnit();
            ShowEquipment();
        }
        private void ShowUnit()
        {
            try
            {
                string Query = "SELECT id AS ID, pc_num AS PC, brand AS Brand, ram AS RAM, storage_type AS Storage_Device, storage AS Capacity, motherBoard AS Mother_Board, VIDEOcard AS Video_Card, PSU AS PSU, date AS Date, status AS Status  FROM system_unit";
                SystemUnitData.DataSource = Con.GetData(Query);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }
        private void ShowEquipment()
        {
           
        }

        private void label1_Click(object sender, EventArgs e)
        {
            // Hide the current form
            this.Hide();

            // Create and show the new form
            Form1 newForm = new Form1();
            newForm.Show();

            // Attach an event handler to handle closing the new form and re-showing the old form
            newForm.FormClosed += (s, args) => this.Show();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            // Hide the current form
            this.Hide();

            // Create and show the new form
            equipments newForm = new equipments();
            newForm.Show();

            // Attach an event handler to handle closing the new form and re-showing the old form
            newForm.FormClosed += (s, args) => this.Show();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            // Hide the current form
            this.Hide();

            // Create and show the new form
            category newForm = new category();
            newForm.Show();

            // Attach an event handler to handle closing the new form and re-showing the old form
            newForm.FormClosed += (s, args) => this.Show();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            // Hide the current form
            this.Hide();

            // Create and show the new form
            stocks newForm = new stocks();
            newForm.Show();

            // Attach an event handler to handle closing the new form and re-showing the old form
            newForm.FormClosed += (s, args) => this.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    // Get the search input from the textbox
            //    string search = guna2TextBox1.Text.Trim(); // Trim whitespace

            //    // Ensure the search input is not empty
            //    if (string.IsNullOrWhiteSpace(search))
            //    {
            //        MessageBox.Show("Please enter a search term.");
            //        return;
            //    }
            //    else
            //    {
            //        // SQL query with parameters
            //        string query = "SELECT id AS ID, category AS Category, brand AS Brand, description AS Description "+
            //                       "FROM Equipment " +
            //                       "WHERE id LIKE @search OR category LIKE @search OR brand LIKE @search";

            //        // Create a command object and set parameters
            //        using (MySqlCommand cmd = new MySqlCommand(query, Con.GetConnection())) // Assuming Con.GetConnection() returns a valid MySqlConnection
            //        {
            //            // Use parameters to avoid SQL injection
            //            cmd.Parameters.AddWithValue("@search", "%" + search + "%"); // Adding wildcards for LIKE query

            //            // Execute the query and bind results to the DataGridView
            //            DataTable dt = new DataTable();
            //            using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
            //            {
            //                adapter.Fill(dt);
            //            }

            //            // Bind the DataTable to the DataGridView
            //            equipmentData.DataSource = dt;
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //    // Show error message if something goes wrong
            //    MessageBox.Show("An error occurred: " + ex.Message);
            //}
        }

        private void SystemUnitData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void SystemUnitData_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {

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
                        DataGridViewRow selectedRow = SystemUnitData.Rows[e.RowIndex];

                        // Pass the selected row to the view form and show it
                        view viewForm = new view(selectedRow);
                        viewForm.ShowDialog(); // Show it as a modal dialog
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    // Get the search input from the textbox
            //    string search = guna2TextBox2.Text.Trim(); // Trim whitespace

            //    // Ensure the search input is not empty
            //    if (string.IsNullOrWhiteSpace(search))
            //    {
            //        MessageBox.Show("Please enter a search term.");
            //        return;
            //    }
            //    else
            //    {
            //        // SQL query with parameters
            //        string query = "SELECT id AS ID, pc_num AS PC, brand AS Brand, ram AS RAM, " +
            //                       "storage_type AS Storage_Device, storage AS Capacity, " +
            //                       "motherBoard AS Mother_Board, VIDEOcard AS Video_Card, " +
            //                       "PSU AS PSU, date AS Date, status AS Status " +
            //                       "FROM system_unit " +
            //                       "WHERE id LIKE @search OR brand LIKE @search OR pc_num LIKE @search";

            //        // Create a command object and set parameters
            //        using (MySqlCommand cmd = new MySqlCommand(query, Con.GetConnection())) // Assuming Con.GetConnection() returns a valid MySqlConnection
            //        {
            //            // Use parameters to avoid SQL injection
            //            cmd.Parameters.AddWithValue("@search", "%" + search + "%"); // Adding wildcards for LIKE query

            //            // Execute the query and bind results to the DataGridView
            //            DataTable dt = new DataTable();
            //            using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
            //            {
            //                adapter.Fill(dt);
            //            }

            //            // Bind the DataTable to the DataGridView
            //            SystemUnitData.DataSource = dt;
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //    // Show error message if something goes wrong
            //    MessageBox.Show("An error occurred: " + ex.Message);
            //}
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                ShowUnit();
            }
            catch(Exception ex)
            {
                MessageBox.Show("An error occurred:" + ex.Message);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                ShowEquipment();
            }
            catch( Exception ex)
            {
                MessageBox.Show("An error occurred:" + ex.Message);
            }
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            login stock = new login();
            stock.Show();
            this.Hide();

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            add newForm = new add();
            newForm.Show();
        }

        private void search_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                string srch = search.Text.Trim(); // Trim whitespace


                // SQL query with parameters
                string totalQuery = $"SELECT COUNT(*) FROM system_unit  WHERE id LIKE '%{srch}%' OR pc_num LIKE '%{srch}%' OR brand LIKE '%{srch}%' OR ram LIKE '%{srch}%' OR storage_type LIKE '%{srch}%' OR storage LIKE '%{srch}%' OR motherBoard LIKE '%{srch}%' OR VIDEOcard LIKE '%{srch}%' OR PSU LIKE '%{srch}%' OR date LIKE '%{srch}%' OR status LIKE '%{srch}%' ";

                string query = $"SELECT id AS ID, pc_num AS PC, brand AS Brand, ram AS RAM, storage_type AS Storage_Device, storage AS Capacity, motherBoard AS Mother_Board, VIDEOcard AS Video_Card, PSU AS PSU, date AS Date, status AS Status FROM system_unit WHERE id LIKE '%{srch}%' OR pc_num LIKE '%{srch}%' OR brand LIKE '%{srch}%' OR ram LIKE '%{srch}%' OR storage_type LIKE '%{srch}%' OR storage LIKE '%{srch}%' OR motherBoard LIKE '%{srch}%' OR VIDEOcard LIKE '%{srch}%' OR PSU LIKE '%{srch}%' OR date LIKE '%{srch}%' OR status LIKE '%{srch}%' ";

                SystemUnitData.DataSource = Con.GetData(query);
                using (MySqlConnection con = Con.GetConnection())
                {

                    using (MySqlCommand countCmd = new MySqlCommand(totalQuery, con))
                    {
                        // Add the same parameter for the count query
                        countCmd.Parameters.AddWithValue("@search", "%" + srch + "%");

                        // Execute the count query
                        int totalCount = Convert.ToInt32(countCmd.ExecuteScalar());

                        // Display the count in label2
                        total.Text = totalCount.ToString();
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
