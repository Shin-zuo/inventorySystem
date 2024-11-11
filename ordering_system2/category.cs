using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using MySql.Data.MySqlClient;
using static System.ComponentModel.Design.ObjectSelectorEditor;

namespace ordering_system2
{
    public partial class category : Form
    {
        functions Con;

        public string Value { get; internal set; }

        public category()
        {
            InitializeComponent();
            Con = new functions();
            ShowCategories();
            loadCategory();
            date();
        }
        private void date()
        {
            string currentDate = DateTime.Now.ToString("dd/MM/yyyy");

            // Set the text of label12 to the current date
            label7.Text = currentDate;
        }
        private void ShowCategories()
        {
            {
                try
                {
                    string Query = "SELECT * FROM books";
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
            string Query = "SELECT * FROM bookcategory";
            guna2ComboBox1.ValueMember = Con.GetData(Query).Columns["id"].ToString();
            guna2ComboBox1.DisplayMember = Con.GetData(Query).Columns["Category"].ToString();
            guna2ComboBox1.DataSource = Con.GetData(Query);
        }

        private void button1_Click_1(object sender, EventArgs e)
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

                    string Query = "INSERT INTO bookcategory (category) VALUES ('{0}')";
                    Query = string.Format(Query, name);
                    Con.SetData(Query);

                    ShowCategories();
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

        private void category_Load_1(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
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

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

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

        private void CatName_TextChanged(object sender, EventArgs e)
        {

        }

        private void CategoryData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

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

        private void button2_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            login stock = new login();
            stock.Show();
            this.Hide();
        }

        private void guna2ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //try
            //{
            
            //        string srch = search.Text;
            //        string Query = "SELECT * FROM books WHERE id LIKE @srch OR title LIKE @srch OR category LIKE @srch";

            //        // Create a command object and set parameters
            //        using (MySqlCommand cmd = new MySqlCommand(Query, Con.GetConnection())) // Assuming Con.GetConnection() returns a valid MySqlConnection
            //        {
            //            // Use parameters to avoid SQL injection
            //            cmd.Parameters.AddWithValue("@srch", "%" + search + "%"); // Adding wildcards for LIKE query

            //            // Execute the query and bind results to the DataGridView
            //            DataTable dt = new DataTable();
            //            using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
            //            {
            //                adapter.Fill(dt);
            //            }

            //            // Bind the DataTable to the DataGridView
            //            books.DataSource = dt;
            //        }

            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (guna2TextBox1.Text == "")
            {
                MessageBox.Show("No Data Inserted!!");
            }
            else
            {
                try
                {
                    string title = guna2TextBox1.Text;
                    string category = guna2ComboBox1.Text;

                    string Query = "INSERT INTO books (title, category) VALUES ('{0}', '{1}')";
                    Query = string.Format(Query, title, category);
                    Con.SetData(Query);

                    ShowCategories();
                    MessageBox.Show("Category Added!!");
                    title = "";
                    category = "";
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void search_KeyPress(object sender, KeyPressEventArgs e)
        {
            //try
            //{
            //    // Get the search input from the textbox
            //    string srch = search.Text.Trim(); // Trim whitespace


            //    // SQL query with parameters
            //    string query = "SELECT id, title, category  FROM books WHERE id LIKE @srch OR title LIKE @srch OR category LIKE @srch";

            //    // Create a command object and set parameters
            //    using (MySqlCommand cmd = new MySqlCommand(query, Con.GetConnection())) // Assuming Con.GetConnection() returns a valid MySqlConnection
            //    {
            //        // Use parameters to avoid SQL injection
            //        cmd.Parameters.AddWithValue("@srch", "%" + srch + "%"); // Adding wildcards for LIKE query

            //        // Execute the query and bind results to the DataGridView
            //        DataTable dt = new DataTable();
            //        using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
            //        {
            //            adapter.Fill(dt);
            //        }

            //        // Bind the DataTable to the DataGridView
            //        books.DataSource = dt;
            //    }

            //}
            //catch (Exception ex)
            //{
            //    // Show error message if something goes wrong
            //    MessageBox.Show("An error occurred: " + ex.Message);
            //}
        }

        private void search_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                string srch = search.Text.Trim(); // Trim whitespace


                // SQL query with parameters
                string totalQuery = $"SELECT COUNT(*) FROM books WHERE id LIKE '%{srch}%' OR title LIKE '%{srch}%' OR category LIKE '%{srch}%'";
                string query = $"SELECT id, title, category  FROM books WHERE id LIKE '%{srch}%' OR title LIKE '%{srch}%'  OR category LIKE '%{srch}%' ";

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
            MessageBox.Show(ex.Message );
            }
        }
    }
}
