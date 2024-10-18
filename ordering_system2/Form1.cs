using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace ordering_system2
{
    public partial class Form1 : Form
    {
        functions Con;
        public Form1()
        {
            InitializeComponent();
            Con = new functions();

            ShowUser();
            invisible();
        }
        private void ShowUser()
        {
            try
            {
                string Query = "SELECT id AS ID, user AS User, gender AS Gender, pass AS Pass FROM user";
                UserData.DataSource = Con.GetData(Query);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }
        private void invisible()
        {
            button6.Visible = false;
            button7.Visible = false;
        }
        private void visible()
        {
            button6.Visible = true;
            button7.Visible = true;
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

        private void button1_Click(object sender, EventArgs e)
        {
            if (Username.Text == "" || gender.Text == "" || password.Text == "")
            {
                MessageBox.Show("Fill up all the data needed");
            }
            else
            {
                if (CheckIfUsernameExists(Username.Text))
                {
                    MessageBox.Show("Username already exists!!");
                }
                else
                {
                    try
                    {
                        string user = Username.Text;
                        string Gender = gender.Text;
                        string Pass = password.Text;






                        string Query = "INSERT INTO user (user, gender, pass) VALUES ('{0}','{1}','{2}')";
                        Query = string.Format(Query, user, Gender, Pass);

                        Con.SetData(Query);

                        ShowUser();

                        id.Text = "";
                        Username.Clear();
                        gender.SelectedIndex = -1;
                        password.Clear();

                        invisible();

                        MessageBox.Show("User Added!!");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
        }

        private Image ResizeImage(Image imgToResize, int width, int height)
        {
            return (Image)(new Bitmap(imgToResize, new Size(width, height)));
        }

        private bool CheckIfUsernameExists(string username)
        {
            return false;
        }

        private void UserList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

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

        private void gender_SelectedIndexChanged(object sender, EventArgs e)
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

        private void button4_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                string ID = id.Text;
                string user = Username.Text;
                string Gender = gender.Text;
                string pass = password.Text;

                string Query = "DELETE FROM user WHERE id = '{0}'";
                Query = string.Format(Query, ID);

                Con.SetData(Query);

                MessageBox.Show("User deleted!!");

                ShowUser();
                id.Text = "";
                Username.Clear();
                gender.SelectedIndex = -1;
                password.Clear();

                invisible();

            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            login stock = new login();
            stock.Show();
            this.Hide();
        }

        private void UserData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0) // Ensure that a valid row is clicked
                {
                    DialogResult r = MessageBox.Show("View?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                    if (r == DialogResult.Yes)
                    {
                        // Assign values from specific columns to respective controls
                        string usernameValue = UserData.Rows[e.RowIndex].Cells[2].Value.ToString();  // Column 2
                        string genderValue = UserData.Rows[e.RowIndex].Cells[3].Value.ToString();    // Column 3
                        string passwordValue = UserData.Rows[e.RowIndex].Cells[4].Value.ToString();  // Column 4

                        // Set the values to the corresponding controls
                        Username.Text = usernameValue;
                        gender.Text = genderValue;
                        password.Text = passwordValue;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }

        private void UserData_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0) // Ensure that a valid row is clicked
                {
                    DialogResult r = MessageBox.Show("Edit user??", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                    if (r == DialogResult.Yes)
                    {
                        // Assign values from specific columns to respective controls
                        string idValue = UserData.Rows[e.RowIndex].Cells[0].Value.ToString();  // Column 2
                        string usernameValue = UserData.Rows[e.RowIndex].Cells[1].Value.ToString();  // Column 2
                        string genderValue = UserData.Rows[e.RowIndex].Cells[2].Value.ToString();    // Column 3
                        string passwordValue = UserData.Rows[e.RowIndex].Cells[3].Value.ToString();  // Column 4

                        // Set the values to the corresponding controls
                        id.Text = idValue;
                        Username.Text = usernameValue;
                        gender.Text = genderValue;
                        password.Text = passwordValue;

                        visible();
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
            try
            {
                DialogResult r = MessageBox.Show("Cancel edit??", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                if (r == DialogResult.Yes)
                {
                    id.Text = "";
                    Username.Clear();
                    gender.SelectedIndex = -1;
                    password.Clear();
                    
                    invisible();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
            
        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                string userId = id.Text;
                string user = Username.Text;
                string Gender = gender.Text;
                string pass = password.Text;
                

                // Corrected SQL query for updating
                string Query = "UPDATE user SET user = '{1}', gender = '{2}', pass = '{3}' WHERE id = '{0}'";

                Query = string.Format(Query, userId, user, Gender, pass );

                id.Text = "";
                Username.Clear();
                gender.SelectedIndex = -1;
                password.Clear();

                Con.SetData(Query);

                ShowUser();
                invisible();

                MessageBox.Show("User Updated!!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
               
            }
        }
    }
}
