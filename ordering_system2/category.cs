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
    public partial class category : Form
    {
        functions Con;

        public string Value { get; internal set; }

        public category()
        {
            InitializeComponent();
            Con = new functions();
            ShowCategories();
        }
        private void ShowCategories()
        {
            {
                try
                {
                    string Query = "SELECT * FROM category";
                    CategoryData.DataSource = Con.GetData(Query);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }


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

                    string Query = "INSERT INTO category (category) VALUES ('{0}')";
                    Query = string.Format(Query, name);
                    Con.SetData(Query);

                    ShowCategories();
                    MessageBox.Show("Category Added!!");
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
            items newForm = new items();
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
    }
}
