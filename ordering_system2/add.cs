using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace ordering_system2
{
    public partial class add : Form
    {
        functions Con;
        public add()
        {
            InitializeComponent();
            Con = new functions();
            date();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (guna2TextBox1.Text == "" || guna2TextBox2.Text == "" || guna2TextBox3.Text == "" || guna2TextBox4.Text == "" || guna2ComboBox1.Text == "" || guna2TextBox6.Text == "" || guna2TextBox7.Text == "" || guna2TextBox8.Text == "" || guna2TextBox9.Text == ""  || statusbox.Text == "")
            {
                MessageBox.Show("Data Missing!!");
            }
            else
            {
                try
                {
                  
                    string pcNum = guna2TextBox2.Text;
                    string brand = guna2TextBox3.Text;
                    string ram = guna2TextBox4.Text;
                    string storage = guna2ComboBox1.Text;
                    string capacity = guna2TextBox6.Text;
                    string motherboard = guna2TextBox7.Text;
                    string videocard = guna2TextBox8.Text;
                    string psu = guna2TextBox9.Text;
                    string date = label12.Text;
                    string status = statusbox.Text;

                    string Query = "INSERT INTO system_unit ( pc_num, brand, ram, storage_type, storage, motherBoard, VIDEOcard, PSU, date, status) VALUES ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}')";

                    Query = string.Format(Query, pcNum, brand, ram, storage, capacity, motherboard, videocard, psu, date, status);
                    Con.SetData(Query);



                    MessageBox.Show("Unit Added!!");
                  
                    pcNum = "";
                    brand = "";
                    ram = "";
                    storage = "";
                    capacity = "";
                    motherboard = "";
                    videocard = "";
                    psu = "";
                    date = "";
                    status = "";
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        private void date()
        {
            string currentDate = DateTime.Now.ToString("dd/MM/yyyy");

            // Set the text of label12 to the current date
            label12.Text = currentDate;
        }
    }
}
