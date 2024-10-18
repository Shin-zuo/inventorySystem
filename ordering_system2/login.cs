using Org.BouncyCastle.Bcpg;
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


namespace ordering_system2
{
    public partial class login : Form
    {
        functions Con;
        public login()
        {
            InitializeComponent();
            Con = new functions();

        }

        private void login_Load(object sender, EventArgs e)
        {

        }



        private void button1_Click(object sender, EventArgs e)
        {
            
            if (username.Text == "" || password.Text == "")
            {
                MessageBox.Show("Missing Data!!");
                return;
            }

            string Query = "SELECT * FROM admin WHERE username = '{0}' AND pass = '{1}'";
            Query = string.Format(Query, username.Text, password.Text);
            DataTable dt = Con.GetData(Query);
            if (dt.Rows.Count > 0)
            {

                Form1 frm = new Form1();
                frm.Show();
                this.Hide();
            }
            else
            {
                string userQuery = "SELECT * FROM user WHERE user = '{0}' AND pass = '{1}'";
                userQuery = string.Format(userQuery, username.Text, password.Text);
                DataTable Dtable = Con.GetData(userQuery);
                if(Dtable.Rows.Count == 0)
                {
                    MessageBox.Show("Missing Data!!");
                }
                else
                {
                    stock_user stock = new stock_user();
                    stock.Show();
                    this.Hide();
                }
            }
        }
    


        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
