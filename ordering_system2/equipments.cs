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

namespace ordering_system2
{
    public partial class equipments : Form
    {
        functions Con;
        public equipments()
        {
            InitializeComponent();
            Con = new functions();
            showData();
            loadCategory();
            date();
        }
      
        private void date()
        {
            string currentDate = DateTime.Now.ToString("dd/MM/yyyy");

            // Set the text of label12 to the current date
            label7.Text = currentDate;
        }
        private void showData()
        {
            {
                try
                {
                    string Query = "SELECT * FROM equipment";
                    books.DataSource = Con.GetData(Query);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }


        }

        private void loadCategory()
        {
            string Query = "SELECT * FROM equipmentcategory";
            guna2ComboBox1.ValueMember = Con.GetData(Query).Columns["id"].ToString();
            guna2ComboBox1.DisplayMember = Con.GetData(Query).Columns["type"].ToString();
            guna2ComboBox1.DataSource = Con.GetData(Query);
        }

       

        private void button1_Click(object sender, EventArgs e)
        {
            if (CatName.Text == "")
            {
                MessageBox.Show("No Data Inserted!!");
            }
            else
            {
                try
                {
                    string name = CatName.Text;

                    string Query = "INSERT INTO equipmentcategory (type) VALUES ('{0}')";
                    Query = string.Format(Query, name);
                    Con.SetData(Query);

                   
                    loadCategory();
                    MessageBox.Show("Category Added!!");
                    name = "";
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (guna2TextBox1.Text == ""|| guna2TextBox2.Text == "")
            {
                MessageBox.Show("No Data Inserted!!");
            }
            else
            {
                try
                {
                   
                    string category = guna2ComboBox1.Text;
                    string brand = guna2TextBox1.Text;
                    string desc = guna2TextBox2.Text;
                    string date = label7.Text;

                    string Query = "INSERT INTO equipment ( category, brand, description, date) VALUES ('{0}', '{1}', '{2}', '{3}')";
                    Query = string.Format(Query, category, brand, desc, date);
                    Con.SetData(Query);

                    showData();
                    MessageBox.Show("Item Added!!");
                    brand = "";
                    category = "";
                    desc = "";
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
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

        private void label4_Click_1(object sender, EventArgs e)
        {
            // Hide the current form
            this.Hide();

            // Create and show the new form
            category newForm = new category();
            newForm.Show();

            // Attach an event handler to handle closing the new form and re-showing the old form
            newForm.FormClosed += (s, args) => this.Show();
        }

        private void label2_Click_1(object sender, EventArgs e)
        {
            // Hide the current form
            this.Hide();

            // Create and show the new form
            equipments newForm = new equipments();
            newForm.Show();

            // Attach an event handler to handle closing the new form and re-showing the old form
            newForm.FormClosed += (s, args) => this.Show();
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

        private void button5_Click(object sender, EventArgs e)
        {
            login stock = new login();
            stock.Show();
            this.Hide();
        }

        private void search_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                string srch = search.Text.Trim(); // Trim whitespace


                // SQL query with parameters
                string totalQuery = $"SELECT COUNT(*) FROM equipment WHERE id LIKE '%{srch}%' OR category LIKE '%{srch}%' OR brand LIKE '%{srch}%'";
                string query = $"SELECT id, category, brand  FROM equipment WHERE id LIKE '%{srch}%' OR category LIKE '%{srch}%'  OR brand LIKE '%{srch}%' ";

                books.DataSource = Con.GetData(query);
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
