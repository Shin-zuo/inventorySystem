using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ordering_system2
{
   
    public partial class view : Form
    {
        private DataGridViewRow selectedRow;
        functions Con;

        // Constructor that accepts the selected row from the DataGridView
        public view(DataGridViewRow selectedRow)
        {
            InitializeComponent();
            this.selectedRow = selectedRow;
            Con = new functions();

            // Ensure the load event handler is subscribed
            this.Load += view_load;
        }

        // Form load event handler
        private void view_load(object sender, EventArgs e)
        {
            try
            {
                // Set the TextBox values using the data from the selected row
                guna2TextBox1.Text = GetCellValue(0);
                guna2TextBox2.Text = GetCellValue(1);
                guna2TextBox3.Text = GetCellValue(2);
                guna2TextBox4.Text = GetCellValue(3);
                guna2ComboBox1.Text = GetCellValue(4);
                guna2TextBox6.Text = GetCellValue(5);
                guna2TextBox7.Text = GetCellValue(6);
                guna2TextBox8.Text = GetCellValue(7);
                guna2TextBox9.Text = GetCellValue(8);
                guna2TextBox10.Text = GetCellValue(9);
                statusbox.Text = GetCellValue(10);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while loading the data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Helper method to get the cell value safely
        private string GetCellValue(int cellIndex)
        {
            if (selectedRow.Cells.Count > cellIndex && selectedRow.Cells[cellIndex].Value != null)
            {
                return selectedRow.Cells[cellIndex].Value.ToString();
            }
            return string.Empty; // Return empty string if the value is null
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string id = guna2TextBox1.Text;
                string pc_num = guna2TextBox2.Text;
                string brand = guna2TextBox3.Text;
                string ram = guna2TextBox4.Text;
                string store_type = guna2ComboBox1.Text;
                string store_cap = guna2TextBox6.Text;
                string mother = guna2TextBox7.Text;
                string VCard = guna2TextBox8.Text;
                string PSU = guna2TextBox9.Text;
                string date = guna2TextBox10.Text;
                string status = statusbox.Text;

                // Corrected SQL query for updating
                string Query = "UPDATE system_unit SET pc_num = '{1}', brand = '{2}', ram = '{3}', storage_type = '{4}', storage = '{5}', motherBoard = '{6}', VIDEOcard = '{7}', PSU = '{8}', date = '{9}', status = '{10}' WHERE id = '{0}'";

                Query = string.Format(Query, id, pc_num, brand, ram, store_type, store_cap, mother, VCard, PSU, date, status);

                Con.SetData(Query);

                MessageBox.Show("Table Updated!!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void guna2ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void statusbox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void guna2TextBox10_TextChanged(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void guna2TextBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void guna2TextBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void guna2TextBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void guna2TextBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void guna2TextBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void guna2TextBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void guna2TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void view_Load_1(object sender, EventArgs e)
        {

        }
    }
}
