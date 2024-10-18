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


    public partial class view_user : Form
    {
        private DataGridViewRow selectedRow1;
        functions Con;

        public view_user(DataGridViewRow selectedRow1)
        {
            InitializeComponent();
            this.selectedRow1 = selectedRow1;
            Con = new functions();

            // Ensure the load event handler is subscribed
            this.Load += view_load;
        }
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
        private string GetCellValue(int cellIndex)
        {
            if (selectedRow1.Cells.Count > cellIndex && selectedRow1.Cells[cellIndex].Value != null)
            {
                return selectedRow1.Cells[cellIndex].Value.ToString();
            }
            return string.Empty; // Return empty string if the value is null
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
