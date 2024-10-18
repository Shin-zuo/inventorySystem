using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TreeView;

namespace ordering_system2
{
    public partial class items : Form
    {
        functions Con;
        public items()
        {
            InitializeComponent();
            Con = new functions();

            LoadComboBoxData();
            date();
        }

        private void items_Load(object sender, EventArgs e)
        {

        }
        private void date() 
        {
            string currentDate = DateTime.Now.ToString("dd/MM/yyyy");

            // Set the text of label12 to the current date
            date_label.Text = currentDate;
        }

        private void items_Load_1(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {
            // Hide the current form
            this.Hide();

            // Create and show the new form
            Form1 newForm = new Form1();
            newForm.Show();

            // Attach an event handler to handle closing the new form and re-showing the old form
            newForm.FormClosed += (s, args) => this.Show();
        }

        private void label8_Click(object sender, EventArgs e)
        {
            // Hide the current form
            this.Hide();

            // Create and show the new form
            category newForm = new category();
            newForm.Show();

            // Attach an event handler to handle closing the new form and re-showing the old form
            newForm.FormClosed += (s, args) => this.Show();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            // Hide the current form
            this.Hide();

            // Create and show the new form
            items newForm = new items();
            newForm.Show();

            // Attach an event handler to handle closing the new form and re-showing the old form
            newForm.FormClosed += (s, args) => this.Show();
        }

        private void guna2ComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void LoadComboBoxData()
        {
            string Query = "SELECT * FROM category";
            category.ValueMember = Con.GetData(Query).Columns["id"].ToString();
            category.DisplayMember = Con.GetData(Query).Columns["Category"].ToString();
            category.DataSource = Con.GetData(Query);
        }

        private void label9_Click(object sender, EventArgs e)
        {
            // Hide the current form
            this.Hide();

            // Create and show the new form
            stocks newForm = new stocks();
            newForm.Show();

            // Attach an event handler to handle closing the new form and re-showing the old form
            newForm.FormClosed += (s, args) => this.Show();
        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Dispose();

        }

        private void label13_Click(object sender, EventArgs e)
        {
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (num.Text == "" || brand.Text == "" || storageType.Text == "" || store.Text == "" || mother.Text == "" || video.Text == "" || psu.Text == "")
            {
                MessageBox.Show("No Data Inserted!!");
            }
            else
            {
                try
                {
                    string name = num.Text;
                    string bran = brand.Text;
                    string RAM = ram.Text;
                    string type = storageType.Text;
                    string storage = store.Text;
                    string motherBoard = mother.Text;
                    string vid = video.Text;
                    string PSU = psu.Text;
                    string date = date_label.Text;
                    string status = guna2ComboBox2.Text;

                    string Query = "INSERT INTO system_unit (pc_num, brand, ram, storage_type, storage, motherBoard, VIDEOcard, PSU, date, status  ) VALUES ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}')";
                    Query = string.Format(Query, name, bran, RAM, type, storage, motherBoard, vid, PSU, date, status);
                    Con.SetData(Query);

                    
                    MessageBox.Show("PC Added!!");

                    num.Clear();
                    brand.Clear();
                    ram.Clear();
                    store.Clear();
                    mother.Clear();
                    video.Clear();
                    psu.Clear();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2ComboBox2_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void description_TextChanged(object sender, EventArgs e)
        {

        }

        private void brand_TextChanged(object sender, EventArgs e)
        {

        }

        private void num_TextChanged(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (category.Text =="" || brand2.Text == "" || desc2.Text == "")
            {
                MessageBox.Show("Fill out all data!!");
            }
            else
            {
                try
                {
                    string cat = category.Text;
                    string brand = brand2.Text;
                    string desc = desc2.Text;
                    string date = date_label.Text;

                    string Query = "INSERT INTO equipment (category, brand, description, date) VALUES ('{0}','{1}','{2}','{3}')";
                    Query = string.Format(Query, cat, brand, desc, date);
                    Con.SetData(Query);

                    MessageBox.Show("Item Added!!!");

                    brand2.Clear();
                    desc2.Clear();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void guna2TextBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2TextBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel7_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            login stock = new login();
            stock.Show();
            this.Hide();
        }

        private void button5_Click_1(object sender, EventArgs e)
        {

            login stock = new login();
            stock.Show();
            this.Hide();
        }
    }
}
